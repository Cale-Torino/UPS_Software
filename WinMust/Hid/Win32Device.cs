/*
 *  WinMust - Simple UPS status monitor
 *  Copyright (C) 2008  Thomas Kuhnke <thkuhnke@users.sourceforge.net>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 * ===================================================================
 *
 *  This file is based on libhidnet.
 *  Copyright (C) 2007-2008 George Helyar <ghelyar@gmail.com>.
 * 
 * ===================================================================
 * 
 *  Modification: I/O Exceptions catched
 *  
 *  Applys to: DataStream.Write(), DataStream.Read()
 *  
 *  Prevents unhandled exception error on unexpected loss of USB 
 *  connection (disconnected cable, system hibernate...).
 *  Hides write error, returns empty buffer on read error, and leaves
 *  it to the higher protocol to handle the connection problem.
 *  
 * ===================================================================
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

using System.Threading; //IOTimeout
using System.Runtime.Remoting.Messaging; //IOTimeout

namespace Hid.Win32
{
    public class Win32Device : IDisposable
    {
        protected IntPtr Handle;
        protected Win32Hid.HIDP_CAPS Capabilities;
        protected Win32Hid.HIDD_ATTRIBUTES Attributes;
        protected FileStream DataStream;

        //implement timeouts for Read/Write
        
        delegate object ReadDelegate(byte[] buffer);

        public object DoRead(byte[] buffer)
        {
            ReadDelegate d = new ReadDelegate(DoReadHandler);
            IAsyncResult res = d.BeginInvoke(buffer, null, null);
            if (res.IsCompleted == false)
            {
                res.AsyncWaitHandle.WaitOne(200, false);
                if (res.IsCompleted == false)
                    throw new ApplicationException("Timeout");
            }
            return d.EndInvoke((AsyncResult)res);
        }

        private object DoReadHandler(byte[] buffer)
        {
            try
            {
                return DataStream.Read(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {
                return buffer.Length;
            }
        }

        delegate object WriteDelegate(byte[] data);

        public object DoWrite(byte[] data)
        {
            WriteDelegate d = new WriteDelegate(DoWriteHandler);
            IAsyncResult res = d.BeginInvoke(data, null, null);
            if (res.IsCompleted == false)
            {
                res.AsyncWaitHandle.WaitOne(100, false);
                if (res.IsCompleted == false)
                    throw new ApplicationException("Timeout");
            }
            return d.EndInvoke((AsyncResult)res);
        }

        private object DoWriteHandler(byte[] data)
        {
            try
            {
                DataStream.Write(data, 0, data.Length);
            }
            catch (Exception) { }
            return null;
        }

        //end timeouts

        public Win32Device(string path)
        {
            this.Handle = GetDeviceHandle(path);

            // Get Attributes
            Attributes = new Win32Hid.HIDD_ATTRIBUTES();
            Win32Hid.HidD_GetAttributes(Handle, ref Attributes);

            if (Marshal.GetLastWin32Error() != 0)
                throw new Win32Exception("Cannot get device attributes.");

            // Get Capabilities
            Capabilities = new Win32Hid.HIDP_CAPS();
            IntPtr preparsedData;

            if (Win32Hid.HidD_GetPreparsedData(Handle, out preparsedData))
                try { Win32Hid.HidP_GetCaps(preparsedData, out Capabilities); }
                finally { Win32Hid.HidD_FreePreparsedData(ref preparsedData); }

            if (Marshal.GetLastWin32Error() != 0)
                throw new Win32Exception("Cannot get device capabilities.");

            // TODO look up report id, probably from usages.
            /*Console.WriteLine("Usage 0x{0:x4}, Usage Page 0x{1:x4}, I [{2}] ({3} {4} {5}), O [{6}] ({7} {8} {9}), F [{10}] ({11} {12} {13})",
                Capabilities.Usage, Capabilities.UsagePage,
                Capabilities.InputReportByteLength, Capabilities.NumberInputButtonCaps, Capabilities.NumberInputDataIndices, Capabilities.NumberInputValueCaps,
                Capabilities.OutputReportByteLength, Capabilities.NumberOutputButtonCaps, Capabilities.NumberOutputDataIndices, Capabilities.NumberOutputValueCaps,
                Capabilities.FeatureReportByteLength, Capabilities.NumberFeatureButtonCaps, Capabilities.NumberFeatureDataIndices, Capabilities.NumberFeatureValueCaps);*/

            // Get stream
            SafeFileHandle safeHandle = new SafeFileHandle(Handle, true);

            // TODO: separate input and output streams due to possibly different lengths
            DataStream = new FileStream(safeHandle, FileAccess.ReadWrite, Capabilities.InputReportByteLength, true);
        }

        public ushort VendorID { get { return Attributes.VendorID; } }
        public ushort ProductID { get { return Attributes.ProductID; } }
        public ushort Version { get { return Attributes.VersionNumber; } }
        public int InputLength { get { return Capabilities.InputReportByteLength; } }
        public int OutputLength { get { return Capabilities.OutputReportByteLength; } }

        public void Write(byte[] data)
        {
            if (data.Length != Capabilities.OutputReportByteLength)
                throw new Exception(String.Format(
                    "Data length must be {0} bytes.",
                    Capabilities.OutputReportByteLength));

            try
            {
                //DataStream.Write(data, 0, data.Length);
                DoWrite(data);
            }
            catch (Exception) // catch (IOException)
            { 
                //hide IOException
            }
        }

        public int Read(byte[] buffer)
        {
            if (buffer.Length != Capabilities.InputReportByteLength)
                throw new Exception(String.Format(
                    "Buffer length must be {0} bytes.",
                    Capabilities.InputReportByteLength));

            try
            {
                //return DataStream.Read(buffer, 0, buffer.Length);
                return (int)DoRead(buffer);
            }
            catch (Exception) // catch (IOException)
            {
                //on IOException return expected length of empty buffer: UPSInterfaceBase will handle this.
                return buffer.Length;
            }
        }

        public byte[] WriteRead(byte[] data)
        {
            Write(data);

            byte[] buffer = new byte[InputLength];
            Read(buffer);
            return buffer;
        }

        public string VendorName
        {
            get
            {
                byte[] buffer = new byte[256];
                if (!Win32Hid.HidD_GetManufacturerString(Handle, buffer, (ulong)buffer.LongLength))
                    throw new Win32Exception("Unable to get vendor name.");
                return TruncateZeroTerminatedString((new System.Text.UnicodeEncoding()).GetString(buffer));
            }
        }

        public string Name
        {
            get
            {
                byte[] buffer = new byte[256];
                if (!Win32Hid.HidD_GetProductString(Handle, buffer, (ulong)buffer.LongLength))
                    throw new Win32Exception("Unable to get device name.");
                return TruncateZeroTerminatedString((new System.Text.UnicodeEncoding()).GetString(buffer));
            }
        }

        public string SerialNumber
        {
            get
            {
                byte[] buffer = new byte[256];
                if (!Win32Hid.HidD_GetSerialNumberString(Handle, buffer, (ulong)buffer.LongLength))
                    throw new Win32Exception("Unable to get serial number.");
                return TruncateZeroTerminatedString((new System.Text.UnicodeEncoding()).GetString(buffer));
            }
        }

        protected static IntPtr GetDeviceHandle(string path)
        {
            IntPtr handle = Win32Hid.CreateFile(
                path,
                0x80000000 | 0x40000000, // GENERIC_READ | GENERIC_WRITE
                (uint)FileShare.ReadWrite, // Read | Write share.
                IntPtr.Zero,
                (uint)FileMode.Open,
                Win32Hid.FILE_FLAG_OVERLAPPED,
                IntPtr.Zero);

            if (Marshal.GetLastWin32Error() != 0 || handle == new IntPtr(-1))
                throw new Win32Exception(String.Format("Cannot create handle to device {0}", path));

            return handle;
        }

        private static string TruncateZeroTerminatedString(string input)
        {
            if (input == null)
                return null;

            return input.Substring(0, input.IndexOf('\0'));
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            // Close managed resources
            if (Disposing)
            {
                try { DataStream.Close(); }
                catch (Exception) { }
            }

            // Close unmanaged resources
            Win32Hid.CloseHandle(Handle);
        }
        #endregion
    }
}

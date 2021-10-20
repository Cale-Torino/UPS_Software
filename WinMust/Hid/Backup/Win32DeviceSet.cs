/*
 * Copyright (C) 2007-2008 George Helyar <ghelyar@gmail.com>.
 * 
 * This file is part of libhidnet.
 * 
 * libhidnet is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * libhidnet is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with libhidnet.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace Hid.Win32
{
	/// <summary>
	/// Set of Win32Devices that, when combined, conform to the IDevice interface. Usually
	/// one physical device will correspond to one Win32DeviceSet.
	/// </summary>
    public class Win32DeviceSet : IDevice
    {
        /// <summary>
        /// Collection of devices without associated Report IDs
        /// </summary>
        public readonly List<Win32Device> UnallocatedDevices;

        /// <summary>
        /// Collection of devices and their associated with Report IDs
        /// </summary>
        public readonly Dictionary<byte, Win32Device> Devices;

        private ushort _vendorID, _productID;

        /// <summary>
        /// Creates a Win32DeviceSet that may only contain devices with the
        /// specified vendor and product IDs.
        /// </summary>
        /// <param name="VendorID">Vendor ID for the devices</param>
        /// <param name="ProductID">Product ID for the devices</param>
        public Win32DeviceSet(ushort VendorID, ushort ProductID)
        {
            _vendorID = VendorID;
            _productID = ProductID;

            UnallocatedDevices = new List<Win32Device>();
            Devices = new Dictionary<byte, Win32Device>();
        }

        /// <summary>
        /// Adds the device to the UnallocatedDevices collection before a
        /// report ID is known.
        /// </summary>
        /// <param name="Device">Device to add</param>
        public void AddDevice(Win32Device Device)
        {
            if (Device.VendorID != _vendorID || Device.ProductID != _productID)
                throw new Exception("Device and/or Product IDs do not match this device set.");

            UnallocatedDevices.Add(Device);
        }

        /// <summary>
        /// Adds the device to the Devices collection. If the device already
        /// exists in the UnallocatedDevices collection, it is removed.
        /// </summary>
        /// <param name="ReportID">Report ID for device</param>
        /// <param name="Device">Device to add</param>
        public void AddDevice(byte ReportID, Win32Device Device)
        {
            if (Device.VendorID != _vendorID || Device.ProductID != _productID)
                throw new Exception("Device and/or Product IDs do not match this device set.");

            // Remove the device if it is already in the unallocated list.
            UnallocatedDevices.Remove(Device);

            // Add the device with it's report ID.
            Devices.Add(ReportID, Device);
        }

		/// <summary>
		/// Vendor ID of all the devices in the device set
		/// </summary>
        public ushort VendorID { get { return _vendorID; } }
		
		/// <summary>
		/// Product ID of all the devices in the device set
		/// </summary>
        public ushort ProductID { get { return _productID; } }

        /// <summary>
        /// Combines the report ID and data for use in native Windows HID
        /// calls.
        /// </summary>
        /// <param name="ReportID">Report ID of report</param>
        /// <param name="Data">Data of report</param>
        /// <returns>Combined report ID and data</returns>
        protected static byte[] AddIdToReport(byte ReportID, byte[] Data)
        {
            byte[] newData = new byte[Data.Length + 1]; //TEST
            newData[0] = ReportID;
            Array.Copy(Data, 0, newData, 1, Data.Length);

            return newData;
        }

        public void Write(byte ReportID, byte[] Data)
        {
            // If not specifically given, try to guess by output length
            if (!Devices.ContainsKey(ReportID))
                for (int i = 0; i < UnallocatedDevices.Count; i++)
                    if (UnallocatedDevices[i].OutputLength == Data.Length - 1)
                    {
                        Console.Error.WriteLine("Warning: Device with report ID"
                            + " 0x{0:x2} does not exist. A guess has been made "
                            + "based on the device's output length.", ReportID);
                        AddDevice(ReportID, UnallocatedDevices[i]);
                        break;
                    }

            // Write
            Devices[ReportID].Write(AddIdToReport(ReportID, Data));
        }

        public int Read(byte ReportID, byte[] Buffer)
        {
            // If not specifically given, try to guess by input length
            if (!Devices.ContainsKey(ReportID))
                for (int i = 0; i < UnallocatedDevices.Count; i++)
                    if (UnallocatedDevices[i].InputLength == Buffer.Length + 1)
                    {
                        Console.Error.WriteLine("Warning: Device with report ID"
                            + " 0x{0:x2} does not exist. A guess has been made "
                            + "based on the device's input length.", ReportID);
                        AddDevice(ReportID, UnallocatedDevices[i]);
                        break;
                    }

            // Read
            Win32Device device = Devices[ReportID];

            // Check buffer size
            if (Buffer.Length + 1 != device.InputLength)
                throw new Exception(String.Format(
                    "Buffer length must be {0} bytes.", device.InputLength - 1));

            // Create temporary buffer
            byte[] buffer = new byte[device.InputLength];

            // Read data
            int read = Devices[ReportID].Read(buffer);

            // Copy data into the return buffer
            Array.Copy(buffer, 1, Buffer, 0, read - 1);

            return read - 1;
        }

        public byte[] WriteRead(byte ReportID, byte[] Data)
        {
            Write(ReportID, Data);

            byte[] buffer = new byte[Devices[ReportID].InputLength - 1];
			Read(ReportID, buffer);
            
            return buffer;
        }

        public void Dispose()
        {
            foreach(Win32Device device in UnallocatedDevices)
                try { device.Dispose(); }
                catch (Exception) { /* Do Nothing */ }

            foreach (Win32Device device in Devices.Values)
                try { device.Dispose(); }
                catch (Exception) { /* Do Nothing */ }
        }
    }
}

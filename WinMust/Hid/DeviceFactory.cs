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
 *  Modification: All Linux related dependencies removed.
 *  
 * ===================================================================
 */

using System;
using System.Collections.Generic;
//using Hid.Linux;
using Hid.Win32;

namespace Hid
{
    /// <summary>
    /// Platform independant class that creates human interface devices.
    /// </summary>
    public static class DeviceFactory
    {
        /// <summary>
        /// Get the list of human interface device paths on the system.
        /// </summary>
        public static string[] DevicePaths
        {
            get
            {
                /*
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                    return LinuxHid.DevicePaths;
                else
                 */ 
                    return Win32Hid.DevicePaths;
            }
        }

        /// <summary>
        /// Creates a human interface device from it's path.
        /// </summary>
        /// <param name="Path">Path to the device</param>
        /// <returns>Human interface device</returns>
        public static IDevice CreateDevice(string Path)
        {
            /*if (Environment.OSVersion.Platform == PlatformID.Unix)
                return new LinuxDevice(Path);
             
            else
            {*/
                Win32Device device = new Win32Device(Path);
                Win32DeviceSet deviceSet = new Win32DeviceSet(device.VendorID, device.ProductID);
                
                deviceSet.AddDevice(device);
                return deviceSet;
            //}
        }

        /// <summary>
        /// Concatenates windows device sets with the same Vendor ID and Product ID
        /// into a single windows device set. Does nothing on Unix.
        /// </summary>
        private static IDevice[] ConcatenateDeviceSets(IDevice[] deviceSets)
        {   
            /*
            if (Environment.OSVersion.Platform == PlatformID.Unix)
                return deviceSets;
             */
            
            List<Win32DeviceSet> deviceSetList = new List<Win32DeviceSet>();

            foreach (IDevice deviceSetSource in deviceSets)
            {
                Win32DeviceSet deviceSet = (Win32DeviceSet)deviceSetSource;
                bool found = false;

                // Search for the vendor and product in the existing set list
                foreach (Win32DeviceSet deviceSetToCheck in deviceSetList)
                    if (deviceSetToCheck.VendorID == deviceSet.VendorID && deviceSetToCheck.ProductID == deviceSet.ProductID)
                    {
                        foreach (Win32Device device in deviceSet.UnallocatedDevices)
                            deviceSetToCheck.AddDevice(device);

                        foreach (KeyValuePair<byte, Win32Device> allocatedDevice in deviceSet.Devices)
                            deviceSetToCheck.AddDevice(allocatedDevice.Key, allocatedDevice.Value);

                        found = true;
                        break;
                    }

                // If it wasn't found, add a new entry to the list
                if (!found)
                    deviceSetList.Add(deviceSet);
            }

            return deviceSetList.ToArray();
        }

        /// <summary>
        /// Lists all of the human interface devices on the system.
        /// </summary>
        /// <returns>A list of human interface devices.</returns>
        public static IDevice[] Enumerate()
        {
            List<IDevice> devices = new List<IDevice>();

            foreach (string path in DevicePaths)
            {
                try { devices.Add(CreateDevice(path)); }
                catch (Win32Exception ex) { Console.Error.WriteLine("Warning: [{1}] {0}", ex.Message, ex.ErrorId); }
                catch (Exception ex) { Console.Error.WriteLine("Warning: {0}", ex.Message); }
            }

            return ConcatenateDeviceSets(devices.ToArray());
        }

        /// <summary>
        /// Lists all of the human interface devices on the system that match a specified Vendor ID.
        /// </summary>
        /// <returns>A list of human interface devices that match a specified Vendor ID.</returns>
        public static IDevice[] Enumerate(ushort VendorID)
        {
            List<IDevice> devices = new List<IDevice>();

            foreach (IDevice device in Enumerate())
                if (device.VendorID == VendorID)
                    devices.Add(device);

            return devices.ToArray();
        }

        /// <summary>
        /// Lists all of the human interface devices on the system that match specified Vendor ID
        /// and Product IDs.
        /// </summary>
        /// <returns>A list of human interface devices that match a specified Vendor ID and Product IDs.</returns>
        public static IDevice[] Enumerate(ushort VendorID, ushort ProductID)
        {
            List<IDevice> devices = new List<IDevice>();

            foreach (IDevice device in Enumerate())
                if (device.VendorID == VendorID && device.ProductID == ProductID)
                    devices.Add(device);

            return devices.ToArray();
        }
    }
}

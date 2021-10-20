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

namespace Hid
{
    /// <summary>
    /// Interface to represent Human Interface Devices
    /// </summary>
    public interface IDevice : IDisposable
    {
        /// <summary>
        /// 16 bit vendor identifier
        /// </summary>
        ushort VendorID { get; }

        /// <summary>
        /// 16 bit product identifier
        /// </summary>
        ushort ProductID { get; }
		
		// TODO add Version property - currently ambiguous on windows
		
		// TODO add Name property - currently ambiguous on windows

        /// <summary>
        /// Writes data with a specified report identifier to the device
        /// </summary>
        /// <param name="ReportID">Report identifier</param>
        /// <param name="Data">Data to write</param>
        void Write(byte ReportID, byte[] Data);

        /// <summary>
        /// Reads data with a specified report identifier from the device
        /// </summary>
        /// <param name="ReportID">Report identifier</param>
        /// <param name="Buffer">Buffer of adequate size to read data into</param>
        /// <returns>Number of bytes read</returns>
        int Read(byte ReportID, byte[] Buffer);

        /// <summary>
        /// Writes data to the device and then reads any response data.
        /// </summary>
        /// <param name="ReportID">Report identifier to read and write</param>
        /// <param name="Data">Data to write</param>
        /// <returns>Data read from the device</returns>
        byte[] WriteRead(byte ReportID, byte[] Data);
    }
}

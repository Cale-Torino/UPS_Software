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
 */

using System;
using System.Windows.Forms; //Needed for MessageBox
using Hid; //Needed for USB-HID access

namespace WinMust
{
    partial class UPSInterfaceBase
    {
        private class USBPortBase
        /// <summary>
        /// Packet-level USB communication with UPS
        /// </summary>
        {
            IDevice winmust;

            // === Public methods ===

            public bool Open()
            {
                // Find exactly one UPS
                IDevice[] device = DeviceFactory.Enumerate(0x665, 0x5161);

                if (device.Length < 1)
                {
                    //No Mustek PowerMust found!
                    return false;
                }

                if (device.Length > 1)
                    MessageBox.Show("Warning: " + device.Length.ToString() + " PowerMust found. Will only use first device.");

                winmust = device[0];

                if (winmust is Hid.Win32.Win32DeviceSet)
                {
                    Hid.Win32.Win32DeviceSet deviceSet = (Hid.Win32.Win32DeviceSet)winmust;

                    System.Collections.Generic.List<Hid.Win32.Win32Device> deviceList =
                        new System.Collections.Generic.List<Hid.Win32.Win32Device>(deviceSet.UnallocatedDevices);

                    foreach (Hid.Win32.Win32Device winDevice in deviceList)
                    {
                        switch (winDevice.OutputLength)
                        {
                            case 9:
                                deviceSet.AddDevice(0x00, winDevice);
                                break;

                            default:
                                winDevice.Dispose();
                                break;
                        }
                    }
                }

                return true;
            }

            public bool CallUPS()
            {
                //Try receiving an A and B style packet to test if everything is OK
                PacketStyleA PacketA = new PacketStyleA();
                PacketStyleB PacketB = new PacketStyleB();

                if (winmust != null)
                {
                    PacketA = RequestPacketStyleA();
                    PacketB = RequestPacketStyleB();
                }

                if (PacketA.RECEVEDCorrectly & PacketB.RECEVEDCorrectly)
                    return true;
                else
                    return false;
            }

            public void Close()
            {
                //dispose IDevice
                if (winmust != null)
                {
                    winmust = null;
                }
            }

            public PacketStyleA RequestPacketStyleA()
            {
                PacketStyleA NewPacket = new PacketStyleA();
                if (winmust != null)
                {
                    byte[] request = new byte[] { 0x51, 0x31, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    byte[] response;

                    //send 8-byte request and read first response
                    response = winmust.WriteRead(0x00, request);

                    if (response[0] == 0x28)
                    {
                        //expected response received!

                        string Input = "";

                        //parse all 6x8 = 48 bytes
                        for (int j = 1; j <= 6; j++)
                        {
                            for (int i = 0; i <= 7; i++)
                            {
                                Input = Input + Convert.ToChar(response[i]).ToString();
                            }
                            if (j != 6)
                                winmust.Read(0x00, response); //read next byte (except when last already received)
                        }

                        //let NewPacket parse input and update its values
                        NewPacket.ParseString(Input);
                    }
                }
                return NewPacket;
            }

            public PacketStyleB RequestPacketStyleB()
            {
                PacketStyleB NewPacket = new PacketStyleB();

                if (winmust != null)
                {
                    byte[] request = new byte[] { 0x46, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    byte[] response;

                    //send 8-byte request and read first response
                    response = winmust.WriteRead(0x00, request);

                    if (response[0] == 0x23)
                    {
                        //expected response received!

                        string Input = "";

                        //parse all 3x8 = 24 bytes
                        for (int j = 1; j <= 3; j++)
                        {
                            for (int i = 0; i <= 7; i++)
                            {
                                Input = Input + Convert.ToChar(response[i]).ToString();
                            }
                            if (j != 3)
                                winmust.Read(0x00, response); //read next byte (except when last already received)
                        }

                        //let NewPacket parse input and update its values
                        NewPacket.ParseString(Input);
                    }
                }
                return NewPacket;
            }

            public void ToggleAlarm()
            {
                if (winmust != null)
                {
                    byte[] request = new byte[] { 0x51, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    winmust.Write(0x00, request);
                }
            }

            public void StartTest()
            {
                if (winmust != null)
                {
                    byte[] request = new byte[] { 0x54, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    winmust.Write(0x00, request);
                }
            }
        }
    }
}
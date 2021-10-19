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
using System.IO.Ports; //Needed for Serial Port
using System.Windows.Forms; //Needed for MessageBox

namespace WinMust
{
    partial class UPSInterfaceBase
    {
        private class COMPortBase
        /// <summary>
        /// Low-level UPS COM-Port functionality
        /// </summary>
        {
            
            private SerialPort UPSSerialPort = new SerialPort();

            // === Public Methods ===
            
            public COMPortBase()
            {
                //set default values for SerialPort port
                UPSSerialPort.Parity = Parity.None;
                UPSSerialPort.StopBits = StopBits.One;
                UPSSerialPort.NewLine = "\r";
                UPSSerialPort.ReadTimeout = 500;
                UPSSerialPort.WriteTimeout = 250;
            }

            public bool OpenPort(string PortName, int BaudRate)
            {
                if (PortName != "" & BaudRate != 0)
                {
                    //tries opening serial port 'PortName' with selected baud rate
                    UPSSerialPort.BaudRate = BaudRate;
                    UPSSerialPort.PortName = PortName;

                    if (!UPSSerialPort.IsOpen)
                    {
                        try
                        {
                            UPSSerialPort.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                return UPSSerialPort.IsOpen;
            }

            public bool ClosePort()
            {
                //tries closing serial port
                if (UPSSerialPort.IsOpen)
                {
                    try
                    {
                        UPSSerialPort.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return !UPSSerialPort.IsOpen;
            }

            public bool CallUPS()
            {
                //sends call packet to UPS and reads back answer, if any
                //and reports result
                bool FoundAnswer = false;

                if (UPSSerialPort.IsOpen)
                {
                    string Input = "";
                    int loops = 0;

                    do
                    {
                        try
                        {
                            UPSSerialPort.DiscardInBuffer();
                            UPSSerialPort.WriteLine("M");
                        }
                        catch (System.Exception)
                        {
                            //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        try
                        {
                            Input = UPSSerialPort.ReadLine();
                        }
                        catch (TimeoutException)
                        {
                            //Catch timeout, when no UPS is there to answer
                        }
                        FoundAnswer = (Input.StartsWith("C")) & (Input.Length == 1);
                        //FoundAnswer = (Input.IndexOf("C") > -1) & (Input.Length == 1);
                        loops++;
                    }
                    while (!FoundAnswer & loops < 2);
                }
                return FoundAnswer;
            }

            public PacketStyleA RequestPacketStyleA()
            {
                //requests, reads and parses an A-Style packet

                PacketStyleA NewPacket = new PacketStyleA();

                if (UPSSerialPort.IsOpen == true)
                {
                    string Input = "";
                    try
                    {
                        UPSSerialPort.DiscardInBuffer();
                        UPSSerialPort.WriteLine("Q1");
                    }
                    catch (System.Exception)
                    {
                        //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        Input = UPSSerialPort.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        //Hide possible Timeout, because not critical
                    }

                    //Does the packet resemble what we are looking for?
                    if (Input.StartsWith("(") & Input.Length == 46)
                    {
                        //yes!
                        NewPacket.ParseString(Input);
                    }
                }
                return NewPacket;
            }

            public PacketStyleB RequestPacketStyleB()
            {
                //requests, reads and parses a B-Style packet
                //TEST: this method is not tested yet!
                PacketStyleB NewPacket = new PacketStyleB();


                if (UPSSerialPort.IsOpen == true)
                {
                    string Input = "";
                    try
                    {
                        UPSSerialPort.DiscardInBuffer();
                        UPSSerialPort.WriteLine("F");
                    }
                    catch (System.Exception)
                    {
                        //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        Input = UPSSerialPort.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        //Hide possible Timeout, because not critical
                    }

                    //Does the packet resemble what we are looking for?
                    if (Input.StartsWith("#") & Input.Length == 21)
                    {
                        //yes!
                        NewPacket.ParseString(Input);
                    }
                }

                return NewPacket;
            }

            public void ToggleAlarm()
            {
                if (UPSSerialPort.IsOpen == true)
                {
                    try
                    {
                        UPSSerialPort.WriteLine("Q");
                    }
                    catch (System.Exception)
                    {
                        //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            public void StartTest()
            {
                if (UPSSerialPort.IsOpen == true)
                {
                    try
                    {
                        UPSSerialPort.WriteLine("T");
                    }
                    catch (System.Exception)
                    {
                        //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

        }
    }
}

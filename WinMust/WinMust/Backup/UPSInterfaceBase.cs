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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.Threading; //TEST

namespace WinMust
{
    struct PacketStyleA
    /// <summary>
    /// Content of an A style packet
    /// </summary>
    {
        public float ACVoltage;
        public float LoadVoltage;
        public int Load;
        public float LoadFrequency;
        public float BatteryVoltage;
        public float Temperature;
        public bool BackupOperation;
        public bool BatteryCritical;
        public bool TestRunning;
        public bool AudibleAlarm;
        public bool RECEVEDCorrectly;

        public void ParseString(string Input)
        {
            try
            {
                ACVoltage = float.Parse(Input.Substring(1, 3)) + float.Parse(Input.Substring(5, 1)) / 10;
                LoadVoltage = float.Parse(Input.Substring(13, 3)) + float.Parse(Input.Substring(17, 1)) / 10;
                Load = System.Int32.Parse(Input.Substring(19, 3));
                LoadFrequency = float.Parse(Input.Substring(23, 2)) + float.Parse(Input.Substring(26, 1)) / 10;
                BatteryVoltage = float.Parse(Input.Substring(28, 2)) + float.Parse(Input.Substring(31, 1)) / 10;
                Temperature = float.Parse(Input.Substring(33, 2)) + float.Parse(Input.Substring(36, 1)) / 10; ;
                BackupOperation = Input.Substring(38, 1) == "1";
                BatteryCritical = Input.Substring(39, 1) == "1";
                TestRunning = Input.Substring(43, 1) == "1";
                AudibleAlarm = Input.Substring(45, 1) == "1";
                RECEVEDCorrectly = true;
            }
            catch (System.Exception)
            {
                RECEVEDCorrectly = false;
            }
        }
    }

    struct PacketStyleB
    /// <summary>
    /// Content of a B style packet
    /// </summary>
    {
        public float ACVoltage;
        public float LoadFrequency;
        public float DCVoltage;
        public bool RECEVEDCorrectly;

        public void ParseString(string Input)
        {
            try
            {
                ACVoltage = float.Parse(Input.Substring(1, 3)) + float.Parse(Input.Substring(5, 1)) / 10;
                DCVoltage = float.Parse(Input.Substring(11, 2)) + float.Parse(Input.Substring(14, 2)) / 100;
                LoadFrequency = float.Parse(Input.Substring(17, 2)) + float.Parse(Input.Substring(20, 1)) / 10;
                RECEVEDCorrectly = true;
            }
            catch (System.Exception)
            {
                RECEVEDCorrectly = false;
            }
        }
    }


    partial class UPSInterfaceBase
    /// <summary>
    /// Handles USB or RS232 interface to UPS
    /// </summary>
    {
        private UPSManagerBase ParentUPSManager; //reference to parent UPSManager
        private COMPortBase COMPort;
        private USBPortBase USBPort;
        private System.Windows.Forms.Timer timerPolling = new System.Windows.Forms.Timer();

        // === Public Methods ===

        public UPSInterfaceBase (UPSManagerBase UseThisUPSManager, string Interface)
        {
            ParentUPSManager = UseThisUPSManager; //set reference to parent UPSManager
            if (Interface == "RS232")
            {
                //RS232 was selected
                //create an instance of UPS COMPort
                COMPort = new COMPortBase();
            }
            else
            {
                //USB was selected
                //create an instance of UPS USBPort
                USBPort = new USBPortBase();
            }
            timerPolling.Enabled = false;
            timerPolling.Tick += new EventHandler(TimerEventProcessor); //add event handler to timer
        }

        public bool Connect() 
        {
            // overloaded method for USB connect
            if (USBPort != null)
            {
                if (USBPort.Open())
                {
                    if (USBPort.CallUPS())
                    {
                        return true;
                    }
                    else
                    {
                        USBPort.Close();
                        return false;
                    }
                }
            }
            return false;
        }

        public bool Connect(string COMPortName, int COMBaudRate) 
        {
            //overloaded method for COM connect
            if (COMPort != null)
            {
                //Open communication, call UPS and report success
                if (COMPort.OpenPort(COMPortName, COMBaudRate))
                {
                    if (COMPort.CallUPS())
                    {
                        return true;
                    }
                    else
                    {
                        COMPort.ClosePort();
                        return false;
                    }
                }
            }
            return false;
        }

        public void Disconnect() 
        {
            //Close communication
            if (COMPort != null)
            {
                StopPollingData();
                COMPort.ClosePort();
            }
            if (USBPort != null)
            {
                StopPollingData();
                USBPort.Close();
            }
        }

        public void StartPollingData(double COMPollingInterval)
        {
            //Start to collect data regularly, based on selected polling interval
            LoadData(); //...we want first set of data now!            
            timerPolling.Interval = (int)(COMPollingInterval*1000);
            timerPolling.Enabled = true; //... and the rest later
        }

        public void StopPollingData() 
        {
            //stop to collect data regularly
            timerPolling.Enabled = false;
            timerPolling.Stop();
        }

        public void ToggleAlarm() 
        {
            if (COMPort != null)
                COMPort.ToggleAlarm();
            if (USBPort != null)
                USBPort.ToggleAlarm();
        }

        public void StartTest() 
        {
            if (COMPort != null)
                COMPort.StartTest();
            if (USBPort != null)
                USBPort.StartTest();
        }

        // === Private Methods ===

        private void LoadData()
        {
            PacketStyleA NewPacket = new PacketStyleA();
            int loops = 1;
            do
                {
                if (COMPort != null)
                {
                    //request set of analog+status data
                    NewPacket = COMPort.RequestPacketStyleA();
                }
                else
                {
                    if (USBPort != null)
                    {
                        NewPacket = USBPort.RequestPacketStyleA();
                    }
                    //TEST begin ugly workaround for occasional "Connection to UPS lost" issue, when test is executed
                    //find better solution if possible!
                    if (!NewPacket.RECEVEDCorrectly)
                    {
                        USBPort.Close();
                        Thread.Sleep(1000);
                        if (!USBPort.Open()) { loops = 2; } // force exit!
                    }
                    //TEST end ugly workaround
                }
                loops++;
            } 
            while (loops <= 2 & !NewPacket.RECEVEDCorrectly);

            if (NewPacket.RECEVEDCorrectly)
            {
                ParentUPSManager.OnMessageFromUPS(NewPacket);
            }
            else
            {
                ParentUPSManager.OnMessageConnectionLost();
            }
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //Request another set of data
            LoadData();
        }
    }
}



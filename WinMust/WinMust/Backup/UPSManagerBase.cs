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
using System.Collections;               //required for "ArrayList"
using Microsoft.Win32;                  //required for windows registry access
using System.Runtime.InteropServices;   //required for "dllimport"
using System.Drawing;                   //required for "Point"
using System.Windows.Forms;             //required for "Application"
using System.IO.Ports;                  //required for Default Port Search

namespace WinMust
{
    public struct UIPrefsValues
    /// <summary>
    /// All Prefs Settings used in this Application
    /// </summary>
    {
        public int WindowLocationX;
        public int WindowLocationY;
        public string COMInterface;
        public string COMPortName;
        public int COMBaudRate;
        public int COMPollingInterval;
        public bool MinToTray;
        public bool RunOnStart;
        public bool ShutDownOnTime;
        public int ShutDownOnTimeTime;
        public bool ShutDownOnBatteryCritical;
        public bool ShutDownExecuteBatch;
        public int ShutDownBatchDuration;
        public string ShutDownBatchFileName;
    }

    public struct UIStatusValues
    /// <summary>
    /// UPS operating mode status flags
    /// </summary>
    {
        public bool BackupOperation;
        public bool BatteryLow;
        public bool BatteryCritical;
        public bool TestRunning;
        public bool AudibleAlarm;

        public void SetDefault()
        {
            BackupOperation = false;
            BatteryLow = false;
            BatteryCritical = false;
            TestRunning = false;
            AudibleAlarm = false;
        }

    }

    public struct UIValues
    /// <summary>
    /// Analog values measured by the UPS
    /// </summary>
    {
        public float ACVoltage;
        public float LoadVoltage;
        public int Load;
        public string LoadPower;
        public float LoadFrequency;
        public float BatteryVoltage;
        public float Temperature;

        public void SetZero()
        {
            ACVoltage = 0;
            LoadVoltage = 0;
            Load = 0;
            LoadPower = "0";
            LoadFrequency = 0;
            BatteryVoltage = 0;
            Temperature = 0;
        }

    }

    class UPSManagerBase
    /// <summary>
    /// Main Class for UPS Management
    /// </summary>
    {
        private bool UPSOpen = false;           //UPS was successfully contacted and is open now
        private bool BatchExecuted = false;     //Pre-Shutdown batch has been executed once
        private UIPrefsValues PrefsValues;      //Stores PrefsValues for current use
        private UIStatusValues UPSStatusValues; //Stores current (=most recent) UPS status flags
        private UIValues UPSValues;             //Stores current (=most recent) UPS analog values
        private DateTime OnBatteryStartTime;    //Timeflag marking start of "backup mode" (= battery operation)
        private MainForm ParentMainForm;        //Reference to parent form instance
        private UPSInterfaceBase UPS;           //General Interface to control UPS
        private System.Windows.Forms.Timer 
            timerShutdownChecker = new System.Windows.Forms.Timer(); //Check status of Shutdown/Batch timing
        private ArrayList AvailableCOMPorts = new ArrayList(); //List of currently installed Serial Ports
        private UPSTestHelperBase UPSTestHelper;

        // === Public Methods ===

        public UPSManagerBase(MainForm UseThisParentMainForm) 
        {
            //set reference to parent form instance
            ParentMainForm = UseThisParentMainForm;
            //set timer to default off and create event handler
            timerShutdownChecker.Enabled = false;
            timerShutdownChecker.Tick += new EventHandler(TimerShutdownCheckerEvent);
        }

        public void OpenUPS() 
        {
            //try to accquire a UPS with user-selected interface settings.
            //if successful, start polling.
            if (!UPSOpen)
            {
                if (PrefsValues.COMInterface == "RS232")
                {
                    if (PrefsValues.COMPortName != "" & PrefsValues.COMBaudRate != 0)
                    {
                        UPS = new UPSInterfaceBase(this, PrefsValues.COMInterface);
                        UPSOpen = UPS.Connect(PrefsValues.COMPortName, PrefsValues.COMBaudRate);
                    }
                }
                else
                {
                    UPS = new UPSInterfaceBase(this, PrefsValues.COMInterface);
                    UPSOpen = UPS.Connect();
                }

                ParentMainForm.RefreshUIStatus(UPSStatusValues);
                ParentMainForm.RefreshConnectionState(UPSOpen);
                
                if (UPSOpen)
                {
                    UPS.StartPollingData(PrefsValues.COMPollingInterval);
                }
                else
                {
                    MessageBox.Show("Port error or UPS not found!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UPS = null;
                }
            }
        }

        public void CloseUPS()
        {
            //stop all activity and close connection to UPS
            if (UPSOpen)
            {
                UPSOpen = false;
                UPS.StopPollingData();
                UPS.Disconnect();
                UPS = null;
                if (UPSStatusValues.BackupOperation)
                {
                    StopOnBattery();
                }
                UPSValues.SetZero(); //required to allow final "RefreshUIValues" to set zeros in GUI
                UPSStatusValues.SetDefault();
                ParentMainForm.RefreshUIValues(UPSValues);
                ParentMainForm.RefreshUIStatus(UPSStatusValues);
                ParentMainForm.RefreshConnectionState(UPSOpen);
            }
        }

        public void ToggleOpenCloseUPS()
        {
            //toggle "open" state of UPS OPEN
            //this is useful to make sure, MainForm does not have to know UPS state
            //(used by dual-function MainForm.buttonOpenCloseUPS)
            if (UPSOpen) { CloseUPS(); }
            else { OpenUPS(); }
        }
        
        public void ToggleAudibleAlarm() 
        {
            UPS.ToggleAlarm();
        }

        public void StartTest()
        {
            if (UPSOpen)
            {
                UPSTestHelper = new UPSTestHelperBase(ParentMainForm);
                UPS.StopPollingData();
                UPS.StartPollingData(PrefsValues.COMPollingInterval);
                UPS.StartTest();
            }
        }

        public void LoadPrefs()
        {
            // Read prefs-values from windows registry.
            // If no stored values are found, default values are used instead.

            // === Default Values ===

            PrefsValues.WindowLocationX = 500; //TEST Better middle of screen?
            PrefsValues.WindowLocationY = 500; //TEST Better middle of screen?
            PrefsValues.COMInterface = "USB";
            foreach (string s in SerialPort.GetPortNames())
            {
                AvailableCOMPorts.Add(s);
            }
            if (AvailableCOMPorts.Count > 0)
            {
                // default PortName = first port
                PrefsValues.COMPortName = AvailableCOMPorts[0].ToString();
            }
            else
            {
                PrefsValues.COMPortName = "";
            }
            PrefsValues.COMBaudRate = 2400;
            PrefsValues.COMPollingInterval = 2;
            PrefsValues.MinToTray = false;
            PrefsValues.RunOnStart = false;
            PrefsValues.ShutDownOnTime = false;
            PrefsValues.ShutDownOnTimeTime = 10;
            PrefsValues.ShutDownOnBatteryCritical = true;
            PrefsValues.ShutDownExecuteBatch = false;
            PrefsValues.ShutDownBatchDuration = 20;
            PrefsValues.ShutDownBatchFileName = "";

            // === Window Location ===

            // Attempt to open the key
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\WindowPos");

            // If the return value is null, the key doesn't exist
            if (key == null)
            {
                // The key doesn't exist; create it / open it
                key = Registry.CurrentUser.CreateSubKey("Software\\WinMust\\WindowPos");
            }

            //If the keys exist and are not empty, read their content!
            if ((key.GetValue("X") != null) & (key.GetValue("Y") != null))
            {
                PrefsValues.WindowLocationX = (int)key.GetValue("X");
                PrefsValues.WindowLocationY = (int)key.GetValue("Y");
            }

            // === Communication ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Communication");
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\WinMust\\Communication");
            }
            if (key.GetValue("Interface") != null)
            {
                PrefsValues.COMInterface = key.GetValue("Interface").ToString();
            }
            if (key.GetValue("Polling") != null)
            {
                PrefsValues.COMPollingInterval = (int)key.GetValue("Polling");
            }
            if (key.GetValue("BaudRate") != null)
            {
                PrefsValues.COMBaudRate = (int)key.GetValue("BaudRate");
            }
            if (key.GetValue("COMPort") != null)
            {
                if (AvailableCOMPorts.Contains(key.GetValue("COMPort").ToString()))
                {
                    // overwrite default with safed port name only, if it still exists
                    // on this computer (= is in list of available COMPorts)
                    // else, use default specified above
                    PrefsValues.COMPortName = key.GetValue("COMPort").ToString();
                }
            }

            // === Program ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Program");
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\WinMust\\Program");
            }
            if (key.GetValue("MinToTray") != null)
            {
                PrefsValues.MinToTray = System.Boolean.Parse(key.GetValue("MinToTray").ToString());
            }
            key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (key.GetValue("WinMust") != null)
            {
                PrefsValues.RunOnStart = (key.GetValue("WinMust").ToString() == Application.ExecutablePath.ToString() + " /autostart");
            }

            // === Shutdown ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Shutdown");
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\WinMust\\Shutdown");
            }
            if (key.GetValue("ShutDownOnBattery") != null)
            {
                PrefsValues.ShutDownOnBatteryCritical = System.Boolean.Parse(key.GetValue("ShutDownOnBattery").ToString());
            }
            if (key.GetValue("ShutDownOnTime") != null)
            {
                PrefsValues.ShutDownOnTime = System.Boolean.Parse(key.GetValue("ShutDownOnTime").ToString());
            }
            if (key.GetValue("ExecuteBatch") != null)
            {
                PrefsValues.ShutDownExecuteBatch = System.Boolean.Parse(key.GetValue("ExecuteBatch").ToString());
            }
            if (key.GetValue("BatchFile") != null)
            {
                PrefsValues.ShutDownBatchFileName = key.GetValue("BatchFile").ToString();
                if (!System.IO.File.Exists(PrefsValues.ShutDownBatchFileName) & PrefsValues.ShutDownBatchFileName != "")
                {
                    MessageBox.Show("Batch file does not exist: " + PrefsValues.ShutDownBatchFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PrefsValues.ShutDownBatchFileName = "";
                }
            }
            if (key.GetValue("ShutDownOnTimeTime") != null)
            {
                PrefsValues.ShutDownOnTimeTime = (int)key.GetValue("ShutDownOnTimeTime");
            }
            if (key.GetValue("BatchDuration") != null)
            {
                PrefsValues.ShutDownBatchDuration = (int)key.GetValue("BatchDuration");
            }

            // === Refresh GUI ===
            ParentMainForm.RefreshPrefs(PrefsValues, AvailableCOMPorts);
            ParentMainForm.RefreshWindowPosition(new Point(PrefsValues.WindowLocationX, PrefsValues.WindowLocationY));
            ParentMainForm.RefreshConnectionState(UPSOpen);
        }

        public void SavePrefs(UIPrefsValues NewPrefsValues)
        {
            //saves current prefs entered in GUI to registry
            //and updates running application with new prefs

            // === Update Current Application ===

            PrefsValues = NewPrefsValues;

            // === Window Location ===

            // Open the key
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\WindowPos", true);

            // Set the registry values
            key.SetValue("X", NewPrefsValues.WindowLocationX);
            key.SetValue("Y", NewPrefsValues.WindowLocationY);

            // === Communication ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Communication", true);
            key.SetValue("Interface", NewPrefsValues.COMInterface);
            key.SetValue("Polling", NewPrefsValues.COMPollingInterval);
            key.SetValue("BaudRate", NewPrefsValues.COMBaudRate);
            key.SetValue("COMPort", NewPrefsValues.COMPortName);

            // === Program ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Program", true);
            key.SetValue("MinToTray", NewPrefsValues.MinToTray);

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp != null)
            {
                if (NewPrefsValues.RunOnStart)
                {
                    rkApp.SetValue("WinMust", Application.ExecutablePath.ToString() + " /autostart");
                }
                else
                {
                    rkApp.DeleteValue("WinMust", false);
                }
            }

            // === ShutDown ===

            key = Registry.CurrentUser.OpenSubKey("Software\\WinMust\\Shutdown", true);
            key.SetValue("ShutDownOnBattery", PrefsValues.ShutDownOnBatteryCritical);
            key.SetValue("ShutDownOnTime", PrefsValues.ShutDownOnTime);
            key.SetValue("ShutDownOnTimeTime", PrefsValues.ShutDownOnTimeTime);
            key.SetValue("ExecuteBatch", PrefsValues.ShutDownExecuteBatch);
            key.SetValue("BatchFile", PrefsValues.ShutDownBatchFileName);
            key.SetValue("BatchDuration", PrefsValues.ShutDownBatchDuration);

            // === Refresh GUI ===

            ParentMainForm.RefreshPrefs(PrefsValues, AvailableCOMPorts);
        }

        public void OnMessageFromUPS(PacketStyleA PacketA)
        {
            //UPS reports new status + analog data
            //
            //this method is to be called by instance of 
            //UPSInterfaceBase when new data comes in

            // === Analog Values ===
            UPSValues.ACVoltage = PacketA.ACVoltage;
            UPSValues.LoadVoltage = PacketA.LoadVoltage;
            UPSValues.LoadFrequency = PacketA.LoadFrequency;
            UPSValues.Load = PacketA.Load;
            UPSValues.LoadPower = CalcPower(PacketA.Load, PacketA.BackupOperation);
            UPSValues.BatteryVoltage = PacketA.BatteryVoltage;
            UPSValues.Temperature = PacketA.Temperature;

            // referesh GUI analog values to show new data
            ParentMainForm.RefreshUIValues(UPSValues);

            // === Status Flags ===

            if (PacketA.TestRunning)
            {
                // a Test is running!
                UPSTestHelper.AddData(UPSValues.BatteryVoltage);
                // add voltage from old set of data! this makes sure, 
                // 1. the last value *before* test begin is registered by
                // the test helper, 2. all values during the test 
                // and 3. no useless value *after* the test.
            }

            //will be set to true, if any of the following flags change
            bool StatusChanged = false;

            if (UPSStatusValues.BatteryLow != DecideBatteryLow(UPSValues.BatteryVoltage))
            {
                //"battery low" condition has changed,
                //let DecideBatteryLow assign BatteryLow status flag
                UPSStatusValues.BatteryLow = DecideBatteryLow(UPSValues.BatteryVoltage);
                StatusChanged = true;
            }

            if (UPSStatusValues.BackupOperation != PacketA.BackupOperation)
            {
                //status of backup operation flag has changed
                //update stored value with new information
                UPSStatusValues.BackupOperation = PacketA.BackupOperation;
                if (PacketA.BackupOperation)
                {
                    //power lost, UPS now on battery
                    StartOnBattery();
                }
                else
                {
                    //power came back, UPS now on AC again
                    StopOnBattery();
                }
                StatusChanged = true;
            }
            if (UPSStatusValues.BatteryCritical != PacketA.BatteryCritical)
            {
                UPSStatusValues.BatteryCritical = PacketA.BatteryCritical;
                StatusChanged = true;
            }
            if (UPSStatusValues.TestRunning != PacketA.TestRunning)
            {
                if (!PacketA.TestRunning)
                {
                    // a Test has finished!
                    UPSStatusValues.TestRunning = PacketA.TestRunning;
                    StopTest();
                }

                UPSStatusValues.TestRunning = PacketA.TestRunning;
                StatusChanged = true;
            }
            if (UPSStatusValues.AudibleAlarm != PacketA.AudibleAlarm)
            {
                UPSStatusValues.AudibleAlarm = PacketA.AudibleAlarm;
                StatusChanged = true;
            }

            //update GUI status values only, if any values actually changed
            if (StatusChanged)
            {
                System.Media.SystemSounds.Exclamation.Play();
                ParentMainForm.RefreshUIStatus(UPSStatusValues);
            }

        }

        public void OnMessageFromUPS(PacketStyleB PacketB)
        {
            //TODO enter code here!
        }

        public void OnMessageConnectionLost()
        {
            CloseUPS();
            MessageBox.Show("Connection to UPS lost!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // === Private Methods ===

        private void StopTest()
        {
            //stop polling at higher rate and notify TestHelper
            if (UPSOpen)
            {
                UPS.StopPollingData();
                UPSTestHelper.TestFinished();
                UPS.StartPollingData(PrefsValues.COMPollingInterval);
                UPSTestHelper = null;
            }
        }
        
        private void ShutDownPC()
        {
            // initiate shutdown of this computer and close application
            // ShutdownBase.Lock();    //TEST for debugging purpose only
            ShutdownBase.Shutdown();   //real shutdown for non-testing version
            Application.Exit();
        }

        private void ExecuteBatch()
        {
            //executes the pre-shutdown batchfile
            if (!BatchExecuted)
            {
                try
                {
                    System.Diagnostics.Process.Start(PrefsValues.ShutDownBatchFileName);
                    BatchExecuted = true; //prevents multiple calls to this method
                }
                catch (SystemException)
                {
                    MessageBox.Show("Batch Execution failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
       
        private void StartOnBattery()
        {
            //called if UPS status changes to "backup operation"
            //starts regular timer-events to test, if further action neccessary
            OnBatteryStartTime = DateTime.Now;
            timerShutdownChecker.Interval = 10; // first raise of timer event should be very soon
            timerShutdownChecker.Enabled = true;
        }

        private void StopOnBattery()
        {
            //called if UPS status comes back from "backup operation" to normal operation
            //stops all timers and resets GUI
            timerShutdownChecker.Enabled = false;
            BatchExecuted = false; //reset to false required, if power comes back between batch execution and shutdown
            ParentMainForm.RefreshCounter(TimeSpan.Zero, TimeSpan.Zero); //reset timers in GUI
        }

        private void TimerShutdownCheckerEvent(Object myObject, EventArgs myEventArgs)
        {
            //checks, if action like shutdown or execute batch is required
            //updates GUI with current "On Battery since" / "Time to Battery" information
            //
            //event is raised immediately after status chages from normal to backup operation
            //during backup operation, event is raised every 1000ms

            if (UPSStatusValues.BackupOperation)
            {
                timerShutdownChecker.Interval = 1000; //... go Back to regular 1s after first execution

                TimeSpan TimeOnBattery = DateTime.Now - OnBatteryStartTime;
                TimeSpan ShutDownAfter = System.TimeSpan.FromMinutes(PrefsValues.ShutDownOnTimeTime);
                TimeSpan TimeToShutdown = ShutDownAfter - TimeOnBattery;
                TimeSpan BatchDuration = System.TimeSpan.FromSeconds(PrefsValues.ShutDownBatchDuration);

                if (PrefsValues.ShutDownOnTime)
                {
                    if (TimeSpan.Compare(ShutDownAfter, TimeOnBattery) <= 0)
                    {
                        ShutDownPC();
                    }

                    if (PrefsValues.ShutDownExecuteBatch & !BatchExecuted)
                    {
                        if (TimeSpan.Compare(TimeToShutdown, BatchDuration) <= 0)
                        {
                            BatchExecuted = true;
                            ExecuteBatch();
                        }
                    }
                    ParentMainForm.RefreshCounter(TimeOnBattery, TimeToShutdown);
                }
                else
                {
                    ParentMainForm.RefreshCounter(TimeSpan.Zero, TimeSpan.Zero);
                }

                if (UPSStatusValues.BatteryCritical & PrefsValues.ShutDownOnBatteryCritical)
                {
                    ShutDownPC();
                }
            }
        }

        private string CalcPower(int Load, bool BackupOperation)
        {
            //calculates approximate load (watts) from load (percents)

            //TEST old function, do not use
            // return Load * 480 / 100; 

            if (BackupOperation)
            {
                if (Load == 0) {return "0";}
                if (0 <= Load & Load <= 6) { return "≤ 50"; }
                if (7 <= Load & Load <= 12) { return "≤ 75"; }
                if (Load >= 13)
                {
                    return Math.Round(4.0597*Load + 23.628,0).ToString();
                }
            }
            else
            {
                if (Load == 0) { return "0"; }
                if (1 <= Load & Load <= 2) { return "≤ 50"; }
                if (3 <= Load & Load <= 7) { return "≤ 75"; }
                if (Load >= 8)
                {
                    return Math.Round(4.0460 * Load + 43.93,0).ToString();
                }
            }
            return "";
        }

        private bool DecideBatteryLow(float BatteryVoltage)
        { 
            return BatteryVoltage <= 10.5; 
        }

        // === Sub-Classes ===

        private class UPSTestHelperBase
        /// <summary>
        /// Does Test evauluation
        /// </summary>
        {
            private ArrayList TestVoltages = new ArrayList();
            private MainForm ParentMainForm;
            public UPSTestHelperBase(MainForm UseThisMainForm)
            {
                ParentMainForm = UseThisMainForm;
            }
            public void AddData(float BatteryVoltage)
            {
                TestVoltages.Add(BatteryVoltage);
            }
            public void TestFinished()
            {
                float InitialVoltage = 0;
                float FinalVoltage = 0;
                float FinalVoltageDrop = 0;

                if (TestVoltages.Count >= 2)
                {
                    InitialVoltage = (float)TestVoltages[0];
                    FinalVoltage = (float)TestVoltages[TestVoltages.Count - 1];
                    FinalVoltageDrop = InitialVoltage - FinalVoltage;
                }
                ParentMainForm.ReportTestResults(InitialVoltage, FinalVoltage, FinalVoltageDrop, TestVoltages);
            }
        }

        private static class ShutdownBase
        /// <summary>
        /// Performs PC Shutdown, Lock, Hibernate, ....
        /// </summary>
        {   // see URL for further information:
            // http://www.c-sharpcorner.com/UploadFile/thiagu304/desktopfunctions02112007140806PM/desktopfunctions.aspx

            [DllImport("user32.dll")]
            private static extern void LockWorkStation();
            [DllImport("user32.dll")]
            private static extern int ExitWindowsEx(int uFlags, int dwReason);

            public static void Lock() { LockWorkStation(); }
            public static void LogOff() { ExitWindowsEx(0, 0); }
            public static void ForceLogOff() { ExitWindowsEx(4, 0); }
            public static void Reboot() { ExitWindowsEx(2, 0); }
            public static void Shutdown() { ExitWindowsEx(1, 0); }
            public static void Hibernate() { Application.SetSuspendState(PowerState.Hibernate, true, true); }
            public static void StandBy() { Application.SetSuspendState(PowerState.Suspend, true, true); }
        }

    }
}

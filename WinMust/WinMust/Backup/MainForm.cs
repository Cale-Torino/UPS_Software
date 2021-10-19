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
using System.Windows.Forms;
using System.Collections;   //required for ArrayList
using System.Drawing;       //required for Antstreet
using System.Diagnostics;   //required to start standard web-browser by clicking link-label

namespace WinMust
{

    public partial class MainForm : Form
    {
        private AntStreet ACAnt;
        private AntStreet LoadAnt;
        private AntStreet BatteryAnt;
        private UPSManagerBase UPSManager;
        private bool AutoStart = false; //indicates, if application is started manually or auto-started on system startup

        // === Public Methods ===

        public MainForm(string[] args)
        {
            InitializeComponent();
            ACAnt = new AntStreet(pictureBoxACLine);
            LoadAnt = new AntStreet(pictureBoxLoadLine);
            BatteryAnt = new AntStreet(pictureBoxBatteryLine);
            UPSManager = new UPSManagerBase(this);
            labelVersion.Text = "Version: " + Application.ProductVersion.ToString();
            if (args.Length == 1 && (args[0] == "/autostart"))
            {
                AutoStart = true;
            }
        }

        public void RefreshWindowPosition(Point NewLocation)
        {
            this.Location = NewLocation;
        }

        public void RefreshUIValues(UIValues NewValues)
        {
            labelStatusACVoltage.Text = NewValues.ACVoltage.ToString("000.0") + " V";
            labelStatusLoadVoltage.Text = NewValues.LoadVoltage.ToString("000.0") + " V";
            labelStatusLoad.Text = NewValues.Load.ToString() + " %";
            labelStatusLoadPower.Text = NewValues.LoadPower + " W";
            labelStatusLoadFrequency.Text = NewValues.LoadFrequency.ToString("00.0") + " Hz";
            labelStatusBatteryVoltage.Text = NewValues.BatteryVoltage.ToString("00.0") + " V";
            if (notifyIcon1.Visible)
            {
                notifyIcon1.Text = "WinMust - On " + labelPowerSource.Text + " / AC: " + labelStatusACVoltage.Text + " / DC: " + labelStatusBatteryVoltage.Text;
            }
        }

        public void RefreshUIStatus(UIStatusValues StatusValues)
        {
            //Refresh Status-Dialog and Notify Icon according to Status Flags

            if (StatusValues.BackupOperation)
            {
                ACAnt.SetDirection(0);
                ACAnt.SetColor(Color.Gray, Color.LightGray);
                BatteryAnt.SetDirection(2);
                BatteryAnt.SetColor(Color.DarkRed, Color.Red);
                LoadAnt.SetDirection(1);
                LoadAnt.SetColor(Color.DarkRed, Color.Red);
                pictureBoxAC.Image = WinMust.Properties.Resources.AC_red_80;
                labelPowerSource.Text = "Battery";
                labelPowerSource.ForeColor = Color.DarkOrange;
            }
            else
            {
                if (!StatusValues.TestRunning)
                {
                    ACAnt.SetDirection(1);
                    ACAnt.SetColor(Color.DarkGreen, Color.LightGreen);
                    BatteryAnt.SetDirection(1);
                    BatteryAnt.SetColor(Color.DarkGreen, Color.LightGreen);
                    LoadAnt.SetDirection(1);
                    LoadAnt.SetColor(Color.DarkGreen, Color.LightGreen);
                }
                pictureBoxAC.Image = WinMust.Properties.Resources.AC_80;
                labelStatusACLine.ForeColor = Color.Black;
                labelPowerSource.Text = "AC Line";
                labelPowerSource.ForeColor = Color.Green;
            }

            if (StatusValues.BatteryCritical)
            {
                pictureBoxBattery.Image = WinMust.Properties.Resources.battery_red_80;
                labelStatusBatteryCondition.Text = "Battery CRITICAL";
                labelStatusBatteryCondition.ForeColor = Color.Red;
                labelStatusBatteryCondition.Visible = true;
            }
            if (StatusValues.BatteryLow)
            {
                pictureBoxBattery.Image = WinMust.Properties.Resources.battery_orange_80;
                labelStatusBatteryCondition.Text = "Battery Low";
                labelStatusBatteryCondition.ForeColor = Color.Orange;
                labelStatusBatteryCondition.Visible = true;
            }

            if (!StatusValues.BatteryCritical & !StatusValues.BatteryLow)
            {
                pictureBoxBattery.Image = WinMust.Properties.Resources.battery_80;
                labelStatusBatteryCondition.Visible = false;
            }

            if (StatusValues.TestRunning)
            {
                ACAnt.SetDirection(0);
                ACAnt.SetColor(Color.Gray, Color.LightGray);
                BatteryAnt.SetDirection(2);
                BatteryAnt.SetColor(Color.DarkRed, Color.Red);
                LoadAnt.SetDirection(1);
                LoadAnt.SetColor(Color.DarkRed, Color.Red);
                labelTestRunning.Visible = true;
                buttonTest.Enabled = false;
                buttonToggleAlarm.Enabled = false;
                buttonConnectDisconnect.Enabled = false;
            }
            else
            {
                labelTestRunning.Visible = false;
                buttonTest.Enabled = true;
                buttonToggleAlarm.Enabled = true;
                buttonConnectDisconnect.Enabled = true;
            }

            if (StatusValues.AudibleAlarm)
            {
                labelToggleAlarmState.Text = "Current State is: ON";
            }
            else
            {
                labelToggleAlarmState.Text = "Current State is: OFF";
            }

            if (notifyIcon1.Visible) 
            {
                notifyIcon1.Text = "WinMust - On " + labelPowerSource.Text + " / AC: " + labelStatusACVoltage.Text + " / B: " + labelStatusBatteryVoltage.Text;
            }
        }

        public void RefreshPrefs(UIPrefsValues NewPrefs, ArrayList AvailableCOMPortNames)
        {
            //refresh Prefs dialog with new NewPrefs

            // === Communication ===
            switch (NewPrefs.COMInterface)
            {
                case "RS232":
                    radioButtonRS232.Checked = true;
                    break;
                case "USB":
                    radioButtonUSB.Checked = true;
                    break;
            }
            comboBoxPort.Items.Clear();
            if (AvailableCOMPortNames.Count != 0)
            {
                foreach (string s in AvailableCOMPortNames)
                {
                    comboBoxPort.Items.Add(s);
                }
            }
            comboBoxPort.SelectedItem = NewPrefs.COMPortName;
            comboBoxBaud.SelectedItem = NewPrefs.COMBaudRate.ToString();
            maskedTextBoxPolling.Text = NewPrefs.COMPollingInterval.ToString();
            
            // === Program ===
            checkBoxMinToTray.Checked = NewPrefs.MinToTray;
            notifyIcon1.Visible = NewPrefs.MinToTray;
            checkBoxRunOnStart.Checked = NewPrefs.RunOnStart;

            // === Shutdown ===
            checkBoxShutDownOnTime.Checked = NewPrefs.ShutDownOnTime;
            maskedTextBoxShutDownOnTime.Text = NewPrefs.ShutDownOnTimeTime.ToString();
            checkBoxShutDownOnBattery.Checked = NewPrefs.ShutDownOnBatteryCritical;
            checkBoxBatch.Checked = NewPrefs.ShutDownExecuteBatch;
            textBoxBatchFileName.Text = NewPrefs.ShutDownBatchFileName;
            maskedTextBoxBatchDuration.Text = NewPrefs.ShutDownBatchDuration.ToString();
            
            buttonOK.Enabled = false;
        }

        public void RefreshConnectionState(bool Connected)
        {
            // refresh Status dialog, Prefs dialog and Notify Icon after change of Connection state

            radioButtonRS232.Enabled = !Connected;
            radioButtonUSB.Enabled = !Connected;
            labelPolling1.Enabled = !Connected;
            labelPolling2.Enabled = !Connected;
            maskedTextBoxPolling.Enabled = !Connected;
            buttonTest.Enabled = Connected;
            buttonToggleAlarm.Enabled = Connected;
            labelPowerSource.Visible = Connected;

            if (radioButtonRS232.Checked)
            {
                comboBoxBaud.Enabled = !Connected;
                comboBoxPort.Enabled = !Connected;
                labelPort1.Enabled = !Connected;
                labelBaud1.Enabled = !Connected;
            }

            if (Connected)
            {
                buttonConnectDisconnect.Text = "Disconnect";
                notifyIcon1.Text = "WinMust - UPS Connected";
                toolStripStatusLabelConnectionStatus.Text = "UPS Connected";
                if (radioButtonRS232.Checked)
                {
                    toolStripDropDownButtonRS232.Image = WinMust.Properties.Resources.RS232;
                    toolStripDropDownButtonUSB.Image = WinMust.Properties.Resources.USB_grey;
                    toolStripDropDownButtonRS232.Enabled = true;
                    toolStripDropDownButtonUSB.Enabled = false;
                }
                else
                {
                    toolStripDropDownButtonRS232.Image = WinMust.Properties.Resources.RS232_grey;
                    toolStripDropDownButtonUSB.Image = WinMust.Properties.Resources.USB;
                    toolStripDropDownButtonRS232.Enabled = false;
                    toolStripDropDownButtonUSB.Enabled = true;
                }
            }
            else
            {
                buttonConnectDisconnect.Text = "Connect";
                ACAnt.SetDirection(0);
                ACAnt.SetColor(Color.Gray, Color.LightGray);
                LoadAnt.SetDirection(0);
                LoadAnt.SetColor(Color.Gray, Color.LightGray);
                BatteryAnt.SetDirection(0);
                BatteryAnt.SetColor(Color.Gray, Color.LightGray);
                labelToggleAlarmState.Text = "Current State is: ?";
                notifyIcon1.Text = "WinMust - UPS Disconnected";
                toolStripStatusLabelConnectionStatus.Text = "UPS Disconnected";
                toolStripDropDownButtonRS232.Image = WinMust.Properties.Resources.RS232_grey;
                toolStripDropDownButtonUSB.Image = WinMust.Properties.Resources.USB_grey;
                toolStripDropDownButtonRS232.Enabled = false;
                toolStripDropDownButtonUSB.Enabled = false;
            }
           
            buttonConnectDisconnect.Enabled = true;
        }

        public void RefreshCounter(TimeSpan TimeOnBattery, TimeSpan TimeToShutDown)
        {
            // refresh stop-watch style labels

            if (TimeOnBattery == TimeSpan.Zero)
            {
                labelStatusTimeOnBattery.Enabled = false;
                labelStatusTimeOnBattery1.Enabled = false;
                labelStatusTimeToSD.Enabled = false;
                labelTimeToSD1.Enabled = false;
            }
            else
            {
                labelStatusTimeOnBattery.Enabled = true;
                labelStatusTimeOnBattery1.Enabled = true;
                labelStatusTimeToSD.Enabled = true;
                labelTimeToSD1.Enabled = true;
            }
            labelStatusTimeOnBattery.Text = TimeOnBattery.Minutes.ToString("00") + ":" + TimeOnBattery.Seconds.ToString("00");
            labelStatusTimeToSD.Text = TimeToShutDown.Minutes.ToString("00") + ":" + TimeToShutDown.Seconds.ToString("00");
        }

        public void ReportTestResults(float InitialVoltage, float FinalVoltage, float FinalVoltageDrop, ArrayList TestVoltages)
        {
            string Msg = "Test finished!\r\r" +
            "Voltage before Test: " + InitialVoltage.ToString("00.0") + " V\r" +
            "Final Voltage: " + FinalVoltage.ToString("00.0") + " V\r" +
            "Voltage Drop: " + FinalVoltageDrop.ToString("0.0") + " V\r";
            MessageBox.Show(Msg, "Battery Test Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === Private Methods ===

        private void SavePrefs()
        {
            //safe new preferences

            UIPrefsValues CurrentPrefs;

            // === Window Location ===
            CurrentPrefs.WindowLocationX = this.Location.X;
            CurrentPrefs.WindowLocationY = this.Location.Y;

            // === Communication ===
            if (radioButtonRS232.Checked)
            {
                CurrentPrefs.COMInterface = "RS232";
            }
            else
            {
                CurrentPrefs.COMInterface = "USB";
            }
            if (comboBoxBaud.SelectedItem != null)
            {
                CurrentPrefs.COMBaudRate = System.Int32.Parse(comboBoxBaud.SelectedItem.ToString());
            }
            else
            {
                CurrentPrefs.COMBaudRate = 2400;
            }

            if (comboBoxPort.SelectedItem != null)
            {
                CurrentPrefs.COMPortName = comboBoxPort.SelectedItem.ToString();
            }
            else
            {
                CurrentPrefs.COMPortName = "";
            }
            CurrentPrefs.COMPollingInterval = System.Int32.Parse(maskedTextBoxPolling.Text);

            // === Program ===
            CurrentPrefs.MinToTray = checkBoxMinToTray.Checked;
            CurrentPrefs.RunOnStart = checkBoxRunOnStart.Checked;

            // === Shutdown ===
            CurrentPrefs.ShutDownOnTime = checkBoxShutDownOnTime.Checked;
            CurrentPrefs.ShutDownOnTimeTime = System.Int32.Parse(maskedTextBoxShutDownOnTime.Text);
            CurrentPrefs.ShutDownOnBatteryCritical = checkBoxShutDownOnBattery.Checked;
            CurrentPrefs.ShutDownExecuteBatch = checkBoxBatch.Checked;
            CurrentPrefs.ShutDownBatchFileName = textBoxBatchFileName.Text;
            CurrentPrefs.ShutDownBatchDuration = System.Int32.Parse(maskedTextBoxBatchDuration.Text);

            UPSManager.SavePrefs(CurrentPrefs);
        }

        // === UI Events ===

        private void MainForm_Load(object sender, EventArgs e)
        {
            UPSManager.LoadPrefs();
            if (AutoStart & checkBoxMinToTray.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            UPSManager.OpenUPS();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Windows.Forms.DialogResult Result;
                Result = MessageBox.Show("Are you sure you want to exit WinMust?", "WinMust", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (Result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SavePrefs();
                    UPSManager.CloseUPS();    
                }
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (notifyIcon1.Visible & this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }

            if (this.WindowState == FormWindowState.Minimized)
            {
                //TODO Enter Code to stop all Ants here!
            }
            else
            {
                //TODO Enter Code to restart all Ants here!
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult DialogResult;
            DialogResult = MessageBox.Show("Are you sure you want to exit WinMust?", "WinMust", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (DialogResult != System.Windows.Forms.DialogResult.No)
            {
                UPSManager.CloseUPS();
                Application.Exit();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SavePrefs();
        }

        private void buttonToggleAlarm_Click(object sender, EventArgs e)
        {
            UPSManager.ToggleAudibleAlarm();
        }

        private void buttonConnectDisconnect_Click(object sender, EventArgs e)
        {
            buttonConnectDisconnect.Enabled = false;
            SavePrefs();
            UPSManager.ToggleOpenCloseUPS();
        }
        
        private void buttonTest_Click(object sender, EventArgs e)
        {
            string Msg =
            "The battery test is meant to be used with a fully charged battery. "
            + "(Note that completely recharging an empty battery may take up to 4 hours.)\r\r"
            + "Durig the test, the UPS will\r"
            + "- switch to backup operation,\r"
            + "- discharge the battery for about 5 seconds,\r"
            + "- switch back to normal operation.\r\r"
            + "After the test, WinMust will display the following test results:\r"
            + "- Battery voltage before test,\r"
            + "- Battery voltage after test,\r"
            + "- Battery voltage drop.\r\r"
            + "Perform test now?";
            System.Windows.Forms.DialogResult Result;
            Result = MessageBox.Show(Msg, "Battery Test", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                buttonTest.Enabled = false;
                UPSManager.StartTest();
            }
        }
        
        private void radioButtonRS232_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRS232.Checked == true)
            {
                labelPort1.Enabled = true;
                labelBaud1.Enabled = true;
                comboBoxBaud.Enabled = true;
                comboBoxPort.Enabled = true;
            }
            else
            {
                labelPort1.Enabled = false;
                labelBaud1.Enabled = false;
                comboBoxBaud.Enabled = false;
                comboBoxPort.Enabled = false;
            }
            buttonOK.Enabled = true;
        }

        private void checkBoxShutDownOnTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShutDownOnTime.Checked == true)
            {
                maskedTextBoxShutDownOnTime.Enabled = true;
                labelShutDownOnTime1.Enabled = true;
                checkBoxBatch.Enabled = true;
            }
            else
            {
                maskedTextBoxShutDownOnTime.Enabled = false;
                labelShutDownOnTime1.Enabled = false;
                checkBoxBatch.Enabled = false;
            }
            buttonOK.Enabled = true;
        }

        private void checkBoxBatch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBatch.Checked == true)
            {
                textBoxBatchFileName.Enabled = true;
                maskedTextBoxBatchDuration.Enabled = true;
                labelBatch1.Enabled = true;
                labelBatch2.Enabled = true;
                buttonBatchFileSelect.Enabled = true;
                if (textBoxBatchFileName.Text == "")
                {
                    buttonBatchFileSelect.PerformClick(); 
                }
                   
            }
            else 
            {
                textBoxBatchFileName.Enabled = false;
                maskedTextBoxBatchDuration.Enabled = false;
                labelBatch1.Enabled = false;
                labelBatch2.Enabled = false;
                buttonBatchFileSelect.Enabled = false;
            }
            buttonOK.Enabled = true;
        }

        private void checkBoxBatch_EnabledChanged(object sender, EventArgs e)
        {
            if (checkBoxBatch.Enabled)
            {
                textBoxBatchFileName.Enabled = checkBoxBatch.Checked;
                maskedTextBoxBatchDuration.Enabled = checkBoxBatch.Checked;
                labelBatch1.Enabled = checkBoxBatch.Checked;
                labelBatch2.Enabled = checkBoxBatch.Checked;
                buttonBatchFileSelect.Enabled = checkBoxBatch.Checked;
            }
            else
            {
                textBoxBatchFileName.Enabled = false;
                maskedTextBoxBatchDuration.Enabled = false;
                labelBatch1.Enabled = false;
                labelBatch2.Enabled = false;
                buttonBatchFileSelect.Enabled = false;
            }
        }
        
        private void buttonBatchFileSelect_Click(object sender, EventArgs e)
        {
            if (openBatchFileDialog.ShowDialog() != DialogResult.OK)
            {
                checkBoxBatch.Checked = false;
                openBatchFileDialog.FileName = "";
            }
            textBoxBatchFileName.Text = openBatchFileDialog.FileName;
            buttonOK.Enabled = true;
        }
       
        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://winmust.sourceforge.net");
            }
            catch { }
        }

        private void linkLabelLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.gnu.org/licenses/gpl.html");
            }
            catch { }
        }

        private void maskedTextBoxPolling_Validated(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void comboBoxPort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void comboBoxBaud_SelectionChangeCommitted(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void checkBoxShutDownOnBattery_CheckedChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void checkBoxMinToTray_CheckedChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void checkBoxRunOnStart_CheckedChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void maskedTextBoxShutDownOnTime_Validated(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void maskedTextBoxBatchDuration_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private class AntStreet
        /// <summary>
        /// Creates "Marching Ants" style animation
        /// </summary>
        /// 
        {
            private PictureBox MyPictureBox;     //Reference to picturebox, where ants should be placed
            private int AntStreetCounter = 0;    //Current animation step
            private int EllipseX = 5;            //X Coordinate for first ellipse
            private int AntStreetDirection = 0;     //Direction (right, left, stop)
            private const int EllipseSize = 7;      //Size of a single ellipse
            private const int EllipseStep = 15;     //X distance between two ellipses
            private Color EllipseFillColor = Color.Gray;
            private Color EllipseBorderColor = Color.DarkGray;
            private Graphics gr; //graphics object
            private System.Windows.Forms.Timer timerAntAnimation = new System.Windows.Forms.Timer(); //main animation timer

            //TODO:
            //-----
            //
            // 1. implement method to stop timer when application minimized

            public AntStreet(PictureBox UseThisBox)
            {
                MyPictureBox = UseThisBox; //set reference to target box
                timerAntAnimation.Tick += new EventHandler(TimerEventProcessor); //create new timer event handler
                timerAntAnimation.Interval = 1000; //main animation interval
                timerAntAnimation.Enabled = true;
                gr = Graphics.FromHwnd(MyPictureBox.Handle); //alternative: gr = MyPictureBox.CreateGraphics();
                DrawAntStreet(); //draw first ant immediately
            }

            public void SetDirection(int UseThisDirection)
            {
                //sets direction of animation
                //0 = stop
                //1 = normal (left to right)
                //2 = reverse (right to left)
                if (UseThisDirection <= 3 || UseThisDirection >= 0)
                    AntStreetDirection = UseThisDirection;
                else
                    throw new ArgumentException("The value must be between 0 or 3", "UseThisDirection");
            }

            public void SetColor(Color UseThisBorderColor, Color UseThisFillColor)
            {
                //set ellipse colors
                EllipseFillColor = UseThisFillColor;
                EllipseBorderColor = UseThisBorderColor;
            }

            private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
            {
                //on each timer event, draw next step
                DrawAntStreet();
            }

            private void DrawAntStreet()
            {
                //increase AntStreetCounter to next step in animation
                //clear picture box
                //draw new ants at next position

                MyPictureBox.Refresh(); //clear old antstreet

                switch (AntStreetDirection)
                {
                    //change AntStreetCounter based on direction
                    case 1:
                        if (AntStreetCounter <= 4)
                            AntStreetCounter++;
                        else
                            AntStreetCounter = 1;
                        break;

                    case 2:
                        if (AntStreetCounter >= 1)
                            AntStreetCounter--;
                        else
                            AntStreetCounter = 4;
                        break;
                    case 0:
                        AntStreetCounter = 0;
                        break;
                }

                EllipseX = AntStreetCounter * 3; //Calculate initial offset based on AntStreetCounter

                if (MyPictureBox.Width >= MyPictureBox.Height)
                {
                    //Horizontal picturebox needs horizontal antstreet...
                    for (int X = EllipseX; X <= MyPictureBox.Width; X = X + EllipseStep)
                    {
                        gr.FillEllipse(new SolidBrush(EllipseFillColor), X, 0, EllipseSize, EllipseSize);
                        gr.DrawEllipse(new Pen(EllipseBorderColor), X, 0, EllipseSize, EllipseSize);
                    }
                }
                else
                {
                    //Vertical picturebox needs vertical antstreet...
                    for (int X = EllipseX; X < MyPictureBox.Height; X = X + EllipseStep)
                    {
                        gr.FillEllipse(new SolidBrush(EllipseFillColor), 0, X, EllipseSize, EllipseSize);
                        gr.DrawEllipse(new Pen(EllipseBorderColor), 0, X, EllipseSize, EllipseSize);
                    }
                }
            }
        }

    }
}

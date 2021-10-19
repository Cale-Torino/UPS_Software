namespace WinMust
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.groupBoxPowerSource = new System.Windows.Forms.GroupBox();
            this.labelPowerSource = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.labelStatusBatteryCondition = new System.Windows.Forms.Label();
            this.labelTestRunning = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelStatusLoadPower = new System.Windows.Forms.Label();
            this.labelStatusLoadPower1 = new System.Windows.Forms.Label();
            this.pictureBoxUPS = new System.Windows.Forms.PictureBox();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.pictureBoxBattery = new System.Windows.Forms.PictureBox();
            this.pictureBoxAC = new System.Windows.Forms.PictureBox();
            this.labelStatusBatteryVoltage = new System.Windows.Forms.Label();
            this.labelStatusLoad = new System.Windows.Forms.Label();
            this.labelStatusLoadFrequency = new System.Windows.Forms.Label();
            this.labelStatusLoadVoltage = new System.Windows.Forms.Label();
            this.labelStatusACVoltage = new System.Windows.Forms.Label();
            this.labelStatusBatteryVoltage1 = new System.Windows.Forms.Label();
            this.labelStatusBattery = new System.Windows.Forms.Label();
            this.labelStatusLoad1 = new System.Windows.Forms.Label();
            this.labelStatusLoadFrequency1 = new System.Windows.Forms.Label();
            this.labelStatusLoadVoltage1 = new System.Windows.Forms.Label();
            this.labelStatusACVoltage1 = new System.Windows.Forms.Label();
            this.labelStatusPC = new System.Windows.Forms.Label();
            this.labelStatusACLine = new System.Windows.Forms.Label();
            this.pictureBoxACLine = new System.Windows.Forms.PictureBox();
            this.pictureBoxLoadLine = new System.Windows.Forms.PictureBox();
            this.pictureBoxBatteryLine = new System.Windows.Forms.PictureBox();
            this.groupBoxBackupOperation = new System.Windows.Forms.GroupBox();
            this.labelStatusTimeOnBattery1 = new System.Windows.Forms.Label();
            this.labelStatusTimeOnBattery = new System.Windows.Forms.Label();
            this.labelStatusTimeToSD = new System.Windows.Forms.Label();
            this.labelTimeToSD1 = new System.Windows.Forms.Label();
            this.tabPagePreferences = new System.Windows.Forms.TabPage();
            this.groupBoxProgram = new System.Windows.Forms.GroupBox();
            this.checkBoxRunOnStart = new System.Windows.Forms.CheckBox();
            this.checkBoxMinToTray = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxShutdown = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxBatchDuration = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxShutDownOnTime = new System.Windows.Forms.MaskedTextBox();
            this.labelShutDownOnTime1 = new System.Windows.Forms.Label();
            this.checkBoxShutDownOnTime = new System.Windows.Forms.CheckBox();
            this.labelBatch1 = new System.Windows.Forms.Label();
            this.checkBoxShutDownOnBattery = new System.Windows.Forms.CheckBox();
            this.labelBatch2 = new System.Windows.Forms.Label();
            this.checkBoxBatch = new System.Windows.Forms.CheckBox();
            this.buttonBatchFileSelect = new System.Windows.Forms.Button();
            this.textBoxBatchFileName = new System.Windows.Forms.TextBox();
            this.groupBoxAudible = new System.Windows.Forms.GroupBox();
            this.labelToggleAlarmState = new System.Windows.Forms.Label();
            this.labelToggleAlarm1 = new System.Windows.Forms.Label();
            this.buttonToggleAlarm = new System.Windows.Forms.Button();
            this.groupBoxCommunication = new System.Windows.Forms.GroupBox();
            this.buttonConnectDisconnect = new System.Windows.Forms.Button();
            this.maskedTextBoxPolling = new System.Windows.Forms.MaskedTextBox();
            this.labelPolling2 = new System.Windows.Forms.Label();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.labelPolling1 = new System.Windows.Forms.Label();
            this.labelBaud1 = new System.Windows.Forms.Label();
            this.labelPort1 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.radioButtonRS232 = new System.Windows.Forms.RadioButton();
            this.radioButtonUSB = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxCredits = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelProgramDescription = new System.Windows.Forms.Label();
            this.labelProgramName = new System.Windows.Forms.Label();
            this.labelLicense1 = new System.Windows.Forms.Label();
            this.labelHome1 = new System.Windows.Forms.Label();
            this.textBoxGNUDisclaimer = new System.Windows.Forms.TextBox();
            this.linkLabelLicense = new System.Windows.Forms.LinkLabel();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.textBoxGNULicense = new System.Windows.Forms.TextBox();
            this.pictureBoxGPL = new System.Windows.Forms.PictureBox();
            this.pictureBoxWinMust = new System.Windows.Forms.PictureBox();
            this.openBatchFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonUSB = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonRS232 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.groupBoxPowerSource.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxACLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBatteryLine)).BeginInit();
            this.groupBoxBackupOperation.SuspendLayout();
            this.tabPagePreferences.SuspendLayout();
            this.groupBoxProgram.SuspendLayout();
            this.groupBoxShutdown.SuspendLayout();
            this.groupBoxAudible.SuspendLayout();
            this.groupBoxCommunication.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinMust)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageStatus);
            this.tabControl.Controls.Add(this.tabPagePreferences);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(-1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(549, 416);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.groupBoxPowerSource);
            this.tabPageStatus.Controls.Add(this.groupBox9);
            this.tabPageStatus.Controls.Add(this.groupBoxBackupOperation);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(541, 390);
            this.tabPageStatus.TabIndex = 0;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // groupBoxPowerSource
            // 
            this.groupBoxPowerSource.Controls.Add(this.labelPowerSource);
            this.groupBoxPowerSource.Location = new System.Drawing.Point(9, 317);
            this.groupBoxPowerSource.Name = "groupBoxPowerSource";
            this.groupBoxPowerSource.Size = new System.Drawing.Size(252, 67);
            this.groupBoxPowerSource.TabIndex = 29;
            this.groupBoxPowerSource.TabStop = false;
            this.groupBoxPowerSource.Text = "Power Source";
            // 
            // labelPowerSource
            // 
            this.labelPowerSource.AutoSize = true;
            this.labelPowerSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPowerSource.Location = new System.Drawing.Point(89, 29);
            this.labelPowerSource.Name = "labelPowerSource";
            this.labelPowerSource.Size = new System.Drawing.Size(0, 18);
            this.labelPowerSource.TabIndex = 0;
            this.labelPowerSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.labelStatusBatteryCondition);
            this.groupBox9.Controls.Add(this.labelTestRunning);
            this.groupBox9.Controls.Add(this.buttonTest);
            this.groupBox9.Controls.Add(this.labelStatusLoadPower);
            this.groupBox9.Controls.Add(this.labelStatusLoadPower1);
            this.groupBox9.Controls.Add(this.pictureBoxUPS);
            this.groupBox9.Controls.Add(this.pictureBoxLoad);
            this.groupBox9.Controls.Add(this.pictureBoxBattery);
            this.groupBox9.Controls.Add(this.pictureBoxAC);
            this.groupBox9.Controls.Add(this.labelStatusBatteryVoltage);
            this.groupBox9.Controls.Add(this.labelStatusLoad);
            this.groupBox9.Controls.Add(this.labelStatusLoadFrequency);
            this.groupBox9.Controls.Add(this.labelStatusLoadVoltage);
            this.groupBox9.Controls.Add(this.labelStatusACVoltage);
            this.groupBox9.Controls.Add(this.labelStatusBatteryVoltage1);
            this.groupBox9.Controls.Add(this.labelStatusBattery);
            this.groupBox9.Controls.Add(this.labelStatusLoad1);
            this.groupBox9.Controls.Add(this.labelStatusLoadFrequency1);
            this.groupBox9.Controls.Add(this.labelStatusLoadVoltage1);
            this.groupBox9.Controls.Add(this.labelStatusACVoltage1);
            this.groupBox9.Controls.Add(this.labelStatusPC);
            this.groupBox9.Controls.Add(this.labelStatusACLine);
            this.groupBox9.Controls.Add(this.pictureBoxACLine);
            this.groupBox9.Controls.Add(this.pictureBoxLoadLine);
            this.groupBox9.Controls.Add(this.pictureBoxBatteryLine);
            this.groupBox9.Location = new System.Drawing.Point(9, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(511, 305);
            this.groupBox9.TabIndex = 28;
            this.groupBox9.TabStop = false;
            // 
            // labelStatusBatteryCondition
            // 
            this.labelStatusBatteryCondition.AutoSize = true;
            this.labelStatusBatteryCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusBatteryCondition.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelStatusBatteryCondition.Location = new System.Drawing.Point(280, 235);
            this.labelStatusBatteryCondition.Name = "labelStatusBatteryCondition";
            this.labelStatusBatteryCondition.Size = new System.Drawing.Size(74, 13);
            this.labelStatusBatteryCondition.TabIndex = 40;
            this.labelStatusBatteryCondition.Text = "Battery Low";
            this.labelStatusBatteryCondition.Visible = false;
            // 
            // labelTestRunning
            // 
            this.labelTestRunning.AutoSize = true;
            this.labelTestRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestRunning.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelTestRunning.Location = new System.Drawing.Point(309, 266);
            this.labelTestRunning.Name = "labelTestRunning";
            this.labelTestRunning.Size = new System.Drawing.Size(82, 13);
            this.labelTestRunning.TabIndex = 39;
            this.labelTestRunning.Text = "Test running!";
            this.labelTestRunning.Visible = false;
            // 
            // buttonTest
            // 
            this.buttonTest.Enabled = false;
            this.buttonTest.Location = new System.Drawing.Point(406, 260);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(79, 24);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "Battery Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelStatusLoadPower
            // 
            this.labelStatusLoadPower.AutoSize = true;
            this.labelStatusLoadPower.Location = new System.Drawing.Point(456, 171);
            this.labelStatusLoadPower.Name = "labelStatusLoadPower";
            this.labelStatusLoadPower.Size = new System.Drawing.Size(27, 13);
            this.labelStatusLoadPower.TabIndex = 34;
            this.labelStatusLoadPower.Text = "0 W";
            // 
            // labelStatusLoadPower1
            // 
            this.labelStatusLoadPower1.AutoSize = true;
            this.labelStatusLoadPower1.Location = new System.Drawing.Point(396, 171);
            this.labelStatusLoadPower1.Name = "labelStatusLoadPower1";
            this.labelStatusLoadPower1.Size = new System.Drawing.Size(40, 13);
            this.labelStatusLoadPower1.TabIndex = 33;
            this.labelStatusLoadPower1.Text = "Power:";
            // 
            // pictureBoxUPS
            // 
            this.pictureBoxUPS.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUPS.Image")));
            this.pictureBoxUPS.Location = new System.Drawing.Point(193, 33);
            this.pictureBoxUPS.Name = "pictureBoxUPS";
            this.pictureBoxUPS.Size = new System.Drawing.Size(90, 90);
            this.pictureBoxUPS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUPS.TabIndex = 32;
            this.pictureBoxUPS.TabStop = false;
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoad.Image")));
            this.pictureBoxLoad.Location = new System.Drawing.Point(398, 36);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLoad.TabIndex = 31;
            this.pictureBoxLoad.TabStop = false;
            // 
            // pictureBoxBattery
            // 
            this.pictureBoxBattery.Image = global::WinMust.Properties.Resources.battery_80;
            this.pictureBoxBattery.Location = new System.Drawing.Point(205, 207);
            this.pictureBoxBattery.Name = "pictureBoxBattery";
            this.pictureBoxBattery.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxBattery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBattery.TabIndex = 30;
            this.pictureBoxBattery.TabStop = false;
            // 
            // pictureBoxAC
            // 
            this.pictureBoxAC.Image = global::WinMust.Properties.Resources.AC_80;
            this.pictureBoxAC.Location = new System.Drawing.Point(23, 36);
            this.pictureBoxAC.Name = "pictureBoxAC";
            this.pictureBoxAC.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAC.TabIndex = 29;
            this.pictureBoxAC.TabStop = false;
            // 
            // labelStatusBatteryVoltage
            // 
            this.labelStatusBatteryVoltage.AutoSize = true;
            this.labelStatusBatteryVoltage.Location = new System.Drawing.Point(160, 247);
            this.labelStatusBatteryVoltage.Name = "labelStatusBatteryVoltage";
            this.labelStatusBatteryVoltage.Size = new System.Drawing.Size(23, 13);
            this.labelStatusBatteryVoltage.TabIndex = 16;
            this.labelStatusBatteryVoltage.Text = "0 V";
            // 
            // labelStatusLoad
            // 
            this.labelStatusLoad.AutoSize = true;
            this.labelStatusLoad.Location = new System.Drawing.Point(456, 158);
            this.labelStatusLoad.Name = "labelStatusLoad";
            this.labelStatusLoad.Size = new System.Drawing.Size(24, 13);
            this.labelStatusLoad.TabIndex = 15;
            this.labelStatusLoad.Text = "0 %";
            // 
            // labelStatusLoadFrequency
            // 
            this.labelStatusLoadFrequency.AutoSize = true;
            this.labelStatusLoadFrequency.Location = new System.Drawing.Point(456, 145);
            this.labelStatusLoadFrequency.Name = "labelStatusLoadFrequency";
            this.labelStatusLoadFrequency.Size = new System.Drawing.Size(29, 13);
            this.labelStatusLoadFrequency.TabIndex = 14;
            this.labelStatusLoadFrequency.Text = "0 Hz";
            // 
            // labelStatusLoadVoltage
            // 
            this.labelStatusLoadVoltage.AutoSize = true;
            this.labelStatusLoadVoltage.Location = new System.Drawing.Point(456, 132);
            this.labelStatusLoadVoltage.Name = "labelStatusLoadVoltage";
            this.labelStatusLoadVoltage.Size = new System.Drawing.Size(23, 13);
            this.labelStatusLoadVoltage.TabIndex = 13;
            this.labelStatusLoadVoltage.Text = "0 V";
            // 
            // labelStatusACVoltage
            // 
            this.labelStatusACVoltage.AutoSize = true;
            this.labelStatusACVoltage.Location = new System.Drawing.Point(72, 132);
            this.labelStatusACVoltage.Name = "labelStatusACVoltage";
            this.labelStatusACVoltage.Size = new System.Drawing.Size(23, 13);
            this.labelStatusACVoltage.TabIndex = 12;
            this.labelStatusACVoltage.Text = "0 V";
            // 
            // labelStatusBatteryVoltage1
            // 
            this.labelStatusBatteryVoltage1.AutoSize = true;
            this.labelStatusBatteryVoltage1.Location = new System.Drawing.Point(90, 247);
            this.labelStatusBatteryVoltage1.Name = "labelStatusBatteryVoltage1";
            this.labelStatusBatteryVoltage1.Size = new System.Drawing.Size(46, 13);
            this.labelStatusBatteryVoltage1.TabIndex = 8;
            this.labelStatusBatteryVoltage1.Text = "Voltage:";
            // 
            // labelStatusBattery
            // 
            this.labelStatusBattery.AutoSize = true;
            this.labelStatusBattery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusBattery.Location = new System.Drawing.Point(90, 231);
            this.labelStatusBattery.Name = "labelStatusBattery";
            this.labelStatusBattery.Size = new System.Drawing.Size(47, 13);
            this.labelStatusBattery.TabIndex = 7;
            this.labelStatusBattery.Text = "Battery";
            this.labelStatusBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatusLoad1
            // 
            this.labelStatusLoad1.AutoSize = true;
            this.labelStatusLoad1.Location = new System.Drawing.Point(396, 158);
            this.labelStatusLoad1.Name = "labelStatusLoad1";
            this.labelStatusLoad1.Size = new System.Drawing.Size(34, 13);
            this.labelStatusLoad1.TabIndex = 6;
            this.labelStatusLoad1.Text = "Load:";
            // 
            // labelStatusLoadFrequency1
            // 
            this.labelStatusLoadFrequency1.AutoSize = true;
            this.labelStatusLoadFrequency1.Location = new System.Drawing.Point(396, 145);
            this.labelStatusLoadFrequency1.Name = "labelStatusLoadFrequency1";
            this.labelStatusLoadFrequency1.Size = new System.Drawing.Size(60, 13);
            this.labelStatusLoadFrequency1.TabIndex = 5;
            this.labelStatusLoadFrequency1.Text = "Frequency:";
            // 
            // labelStatusLoadVoltage1
            // 
            this.labelStatusLoadVoltage1.AutoSize = true;
            this.labelStatusLoadVoltage1.Location = new System.Drawing.Point(396, 132);
            this.labelStatusLoadVoltage1.Name = "labelStatusLoadVoltage1";
            this.labelStatusLoadVoltage1.Size = new System.Drawing.Size(46, 13);
            this.labelStatusLoadVoltage1.TabIndex = 4;
            this.labelStatusLoadVoltage1.Text = "Voltage:";
            // 
            // labelStatusACVoltage1
            // 
            this.labelStatusACVoltage1.AutoSize = true;
            this.labelStatusACVoltage1.Location = new System.Drawing.Point(20, 132);
            this.labelStatusACVoltage1.Name = "labelStatusACVoltage1";
            this.labelStatusACVoltage1.Size = new System.Drawing.Size(46, 13);
            this.labelStatusACVoltage1.TabIndex = 3;
            this.labelStatusACVoltage1.Text = "Voltage:";
            // 
            // labelStatusPC
            // 
            this.labelStatusPC.AutoSize = true;
            this.labelStatusPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusPC.Location = new System.Drawing.Point(396, 116);
            this.labelStatusPC.Name = "labelStatusPC";
            this.labelStatusPC.Size = new System.Drawing.Size(35, 13);
            this.labelStatusPC.TabIndex = 2;
            this.labelStatusPC.Text = "Load";
            this.labelStatusPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatusACLine
            // 
            this.labelStatusACLine.AutoSize = true;
            this.labelStatusACLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusACLine.Location = new System.Drawing.Point(20, 116);
            this.labelStatusACLine.Name = "labelStatusACLine";
            this.labelStatusACLine.Size = new System.Drawing.Size(51, 13);
            this.labelStatusACLine.TabIndex = 0;
            this.labelStatusACLine.Text = "AC Line";
            this.labelStatusACLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxACLine
            // 
            this.pictureBoxACLine.Location = new System.Drawing.Point(75, 65);
            this.pictureBoxACLine.Name = "pictureBoxACLine";
            this.pictureBoxACLine.Size = new System.Drawing.Size(148, 11);
            this.pictureBoxACLine.TabIndex = 35;
            this.pictureBoxACLine.TabStop = false;
            // 
            // pictureBoxLoadLine
            // 
            this.pictureBoxLoadLine.Location = new System.Drawing.Point(268, 65);
            this.pictureBoxLoadLine.Name = "pictureBoxLoadLine";
            this.pictureBoxLoadLine.Size = new System.Drawing.Size(145, 11);
            this.pictureBoxLoadLine.TabIndex = 36;
            this.pictureBoxLoadLine.TabStop = false;
            // 
            // pictureBoxBatteryLine
            // 
            this.pictureBoxBatteryLine.Location = new System.Drawing.Point(234, 103);
            this.pictureBoxBatteryLine.Name = "pictureBoxBatteryLine";
            this.pictureBoxBatteryLine.Size = new System.Drawing.Size(11, 108);
            this.pictureBoxBatteryLine.TabIndex = 37;
            this.pictureBoxBatteryLine.TabStop = false;
            // 
            // groupBoxBackupOperation
            // 
            this.groupBoxBackupOperation.Controls.Add(this.labelStatusTimeOnBattery1);
            this.groupBoxBackupOperation.Controls.Add(this.labelStatusTimeOnBattery);
            this.groupBoxBackupOperation.Controls.Add(this.labelStatusTimeToSD);
            this.groupBoxBackupOperation.Controls.Add(this.labelTimeToSD1);
            this.groupBoxBackupOperation.Location = new System.Drawing.Point(267, 317);
            this.groupBoxBackupOperation.Name = "groupBoxBackupOperation";
            this.groupBoxBackupOperation.Size = new System.Drawing.Size(253, 67);
            this.groupBoxBackupOperation.TabIndex = 22;
            this.groupBoxBackupOperation.TabStop = false;
            this.groupBoxBackupOperation.Text = "Backup Operation";
            // 
            // labelStatusTimeOnBattery1
            // 
            this.labelStatusTimeOnBattery1.AutoSize = true;
            this.labelStatusTimeOnBattery1.Enabled = false;
            this.labelStatusTimeOnBattery1.Location = new System.Drawing.Point(16, 25);
            this.labelStatusTimeOnBattery1.Name = "labelStatusTimeOnBattery1";
            this.labelStatusTimeOnBattery1.Size = new System.Drawing.Size(84, 13);
            this.labelStatusTimeOnBattery1.TabIndex = 12;
            this.labelStatusTimeOnBattery1.Text = "Time on Battery:";
            // 
            // labelStatusTimeOnBattery
            // 
            this.labelStatusTimeOnBattery.AutoSize = true;
            this.labelStatusTimeOnBattery.Enabled = false;
            this.labelStatusTimeOnBattery.Location = new System.Drawing.Point(121, 25);
            this.labelStatusTimeOnBattery.Name = "labelStatusTimeOnBattery";
            this.labelStatusTimeOnBattery.Size = new System.Drawing.Size(34, 13);
            this.labelStatusTimeOnBattery.TabIndex = 19;
            this.labelStatusTimeOnBattery.Text = "00:00";
            // 
            // labelStatusTimeToSD
            // 
            this.labelStatusTimeToSD.AutoSize = true;
            this.labelStatusTimeToSD.Enabled = false;
            this.labelStatusTimeToSD.Location = new System.Drawing.Point(121, 38);
            this.labelStatusTimeToSD.Name = "labelStatusTimeToSD";
            this.labelStatusTimeToSD.Size = new System.Drawing.Size(34, 13);
            this.labelStatusTimeToSD.TabIndex = 21;
            this.labelStatusTimeToSD.Text = "00:00";
            // 
            // labelTimeToSD1
            // 
            this.labelTimeToSD1.AutoSize = true;
            this.labelTimeToSD1.Enabled = false;
            this.labelTimeToSD1.Location = new System.Drawing.Point(16, 38);
            this.labelTimeToSD1.Name = "labelTimeToSD1";
            this.labelTimeToSD1.Size = new System.Drawing.Size(96, 13);
            this.labelTimeToSD1.TabIndex = 14;
            this.labelTimeToSD1.Text = "Time to Shutdown:";
            // 
            // tabPagePreferences
            // 
            this.tabPagePreferences.Controls.Add(this.groupBoxProgram);
            this.tabPagePreferences.Controls.Add(this.buttonOK);
            this.tabPagePreferences.Controls.Add(this.groupBoxShutdown);
            this.tabPagePreferences.Controls.Add(this.groupBoxAudible);
            this.tabPagePreferences.Controls.Add(this.groupBoxCommunication);
            this.tabPagePreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreferences.Name = "tabPagePreferences";
            this.tabPagePreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreferences.Size = new System.Drawing.Size(541, 390);
            this.tabPagePreferences.TabIndex = 1;
            this.tabPagePreferences.Text = "Preferences";
            this.tabPagePreferences.UseVisualStyleBackColor = true;
            // 
            // groupBoxProgram
            // 
            this.groupBoxProgram.Controls.Add(this.checkBoxRunOnStart);
            this.groupBoxProgram.Controls.Add(this.checkBoxMinToTray);
            this.groupBoxProgram.Location = new System.Drawing.Point(9, 276);
            this.groupBoxProgram.Name = "groupBoxProgram";
            this.groupBoxProgram.Size = new System.Drawing.Size(175, 75);
            this.groupBoxProgram.TabIndex = 2;
            this.groupBoxProgram.TabStop = false;
            this.groupBoxProgram.Text = "Program Options";
            // 
            // checkBoxRunOnStart
            // 
            this.checkBoxRunOnStart.AutoSize = true;
            this.checkBoxRunOnStart.Location = new System.Drawing.Point(16, 46);
            this.checkBoxRunOnStart.Name = "checkBoxRunOnStart";
            this.checkBoxRunOnStart.Size = new System.Drawing.Size(145, 17);
            this.checkBoxRunOnStart.TabIndex = 7;
            this.checkBoxRunOnStart.Text = "Run on Windows Startup";
            this.checkBoxRunOnStart.UseVisualStyleBackColor = true;
            this.checkBoxRunOnStart.CheckedChanged += new System.EventHandler(this.checkBoxRunOnStart_CheckedChanged);
            // 
            // checkBoxMinToTray
            // 
            this.checkBoxMinToTray.AutoSize = true;
            this.checkBoxMinToTray.Location = new System.Drawing.Point(16, 23);
            this.checkBoxMinToTray.Name = "checkBoxMinToTray";
            this.checkBoxMinToTray.Size = new System.Drawing.Size(102, 17);
            this.checkBoxMinToTray.TabIndex = 6;
            this.checkBoxMinToTray.Text = "Minimize to Tray";
            this.checkBoxMinToTray.UseVisualStyleBackColor = true;
            this.checkBoxMinToTray.CheckedChanged += new System.EventHandler(this.checkBoxMinToTray_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(445, 356);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 24);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Text = "Apply";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxShutdown
            // 
            this.groupBoxShutdown.Controls.Add(this.maskedTextBoxBatchDuration);
            this.groupBoxShutdown.Controls.Add(this.maskedTextBoxShutDownOnTime);
            this.groupBoxShutdown.Controls.Add(this.labelShutDownOnTime1);
            this.groupBoxShutdown.Controls.Add(this.checkBoxShutDownOnTime);
            this.groupBoxShutdown.Controls.Add(this.labelBatch1);
            this.groupBoxShutdown.Controls.Add(this.checkBoxShutDownOnBattery);
            this.groupBoxShutdown.Controls.Add(this.labelBatch2);
            this.groupBoxShutdown.Controls.Add(this.checkBoxBatch);
            this.groupBoxShutdown.Controls.Add(this.buttonBatchFileSelect);
            this.groupBoxShutdown.Controls.Add(this.textBoxBatchFileName);
            this.groupBoxShutdown.Location = new System.Drawing.Point(190, 17);
            this.groupBoxShutdown.Name = "groupBoxShutdown";
            this.groupBoxShutdown.Size = new System.Drawing.Size(330, 253);
            this.groupBoxShutdown.TabIndex = 3;
            this.groupBoxShutdown.TabStop = false;
            this.groupBoxShutdown.Text = "Shutdown Options";
            // 
            // maskedTextBoxBatchDuration
            // 
            this.maskedTextBoxBatchDuration.Enabled = false;
            this.maskedTextBoxBatchDuration.HidePromptOnLeave = true;
            this.maskedTextBoxBatchDuration.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxBatchDuration.Location = new System.Drawing.Point(251, 117);
            this.maskedTextBoxBatchDuration.Mask = "00";
            this.maskedTextBoxBatchDuration.Name = "maskedTextBoxBatchDuration";
            this.maskedTextBoxBatchDuration.RejectInputOnFirstFailure = true;
            this.maskedTextBoxBatchDuration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBoxBatchDuration.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxBatchDuration.TabIndex = 13;
            this.maskedTextBoxBatchDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxBatchDuration.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxBatchDuration.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxBatchDuration_MaskInputRejected);
            // 
            // maskedTextBoxShutDownOnTime
            // 
            this.maskedTextBoxShutDownOnTime.HidePromptOnLeave = true;
            this.maskedTextBoxShutDownOnTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxShutDownOnTime.Location = new System.Drawing.Point(251, 27);
            this.maskedTextBoxShutDownOnTime.Mask = "00";
            this.maskedTextBoxShutDownOnTime.Name = "maskedTextBoxShutDownOnTime";
            this.maskedTextBoxShutDownOnTime.RejectInputOnFirstFailure = true;
            this.maskedTextBoxShutDownOnTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBoxShutDownOnTime.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxShutDownOnTime.TabIndex = 9;
            this.maskedTextBoxShutDownOnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxShutDownOnTime.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxShutDownOnTime.Validated += new System.EventHandler(this.maskedTextBoxShutDownOnTime_Validated);
            // 
            // labelShutDownOnTime1
            // 
            this.labelShutDownOnTime1.AutoSize = true;
            this.labelShutDownOnTime1.Location = new System.Drawing.Point(277, 30);
            this.labelShutDownOnTime1.Name = "labelShutDownOnTime1";
            this.labelShutDownOnTime1.Size = new System.Drawing.Size(23, 13);
            this.labelShutDownOnTime1.TabIndex = 17;
            this.labelShutDownOnTime1.Text = "min";
            // 
            // checkBoxShutDownOnTime
            // 
            this.checkBoxShutDownOnTime.AutoSize = true;
            this.checkBoxShutDownOnTime.Location = new System.Drawing.Point(20, 28);
            this.checkBoxShutDownOnTime.Name = "checkBoxShutDownOnTime";
            this.checkBoxShutDownOnTime.Size = new System.Drawing.Size(218, 17);
            this.checkBoxShutDownOnTime.TabIndex = 8;
            this.checkBoxShutDownOnTime.Text = "Shutdown after Time on Battery elapsed:";
            this.checkBoxShutDownOnTime.UseVisualStyleBackColor = true;
            this.checkBoxShutDownOnTime.CheckedChanged += new System.EventHandler(this.checkBoxShutDownOnTime_CheckedChanged);
            // 
            // labelBatch1
            // 
            this.labelBatch1.AutoSize = true;
            this.labelBatch1.Enabled = false;
            this.labelBatch1.Location = new System.Drawing.Point(35, 120);
            this.labelBatch1.Name = "labelBatch1";
            this.labelBatch1.Size = new System.Drawing.Size(133, 13);
            this.labelBatch1.TabIndex = 14;
            this.labelBatch1.Text = "Execute before Shutdown:";
            // 
            // checkBoxShutDownOnBattery
            // 
            this.checkBoxShutDownOnBattery.AutoSize = true;
            this.checkBoxShutDownOnBattery.Checked = true;
            this.checkBoxShutDownOnBattery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShutDownOnBattery.Location = new System.Drawing.Point(20, 206);
            this.checkBoxShutDownOnBattery.Name = "checkBoxShutDownOnBattery";
            this.checkBoxShutDownOnBattery.Size = new System.Drawing.Size(294, 17);
            this.checkBoxShutDownOnBattery.TabIndex = 14;
            this.checkBoxShutDownOnBattery.Text = "Shutdown immediately when UPS reports \'Battery Critical\'";
            this.checkBoxShutDownOnBattery.UseVisualStyleBackColor = true;
            this.checkBoxShutDownOnBattery.CheckedChanged += new System.EventHandler(this.checkBoxShutDownOnBattery_CheckedChanged);
            // 
            // labelBatch2
            // 
            this.labelBatch2.AutoSize = true;
            this.labelBatch2.Enabled = false;
            this.labelBatch2.Location = new System.Drawing.Point(277, 120);
            this.labelBatch2.Name = "labelBatch2";
            this.labelBatch2.Size = new System.Drawing.Size(24, 13);
            this.labelBatch2.TabIndex = 13;
            this.labelBatch2.Text = "sec";
            // 
            // checkBoxBatch
            // 
            this.checkBoxBatch.AutoSize = true;
            this.checkBoxBatch.Enabled = false;
            this.checkBoxBatch.Location = new System.Drawing.Point(20, 62);
            this.checkBoxBatch.Name = "checkBoxBatch";
            this.checkBoxBatch.Size = new System.Drawing.Size(180, 17);
            this.checkBoxBatch.TabIndex = 10;
            this.checkBoxBatch.Text = "Run Batch-File before Shutdown";
            this.checkBoxBatch.UseVisualStyleBackColor = true;
            this.checkBoxBatch.CheckedChanged += new System.EventHandler(this.checkBoxBatch_CheckedChanged);
            this.checkBoxBatch.EnabledChanged += new System.EventHandler(this.checkBoxBatch_EnabledChanged);
            // 
            // buttonBatchFileSelect
            // 
            this.buttonBatchFileSelect.Enabled = false;
            this.buttonBatchFileSelect.Location = new System.Drawing.Point(245, 83);
            this.buttonBatchFileSelect.Name = "buttonBatchFileSelect";
            this.buttonBatchFileSelect.Size = new System.Drawing.Size(55, 24);
            this.buttonBatchFileSelect.TabIndex = 12;
            this.buttonBatchFileSelect.Text = "Select...";
            this.buttonBatchFileSelect.UseVisualStyleBackColor = true;
            this.buttonBatchFileSelect.Click += new System.EventHandler(this.buttonBatchFileSelect_Click);
            // 
            // textBoxBatchFileName
            // 
            this.textBoxBatchFileName.Enabled = false;
            this.textBoxBatchFileName.Location = new System.Drawing.Point(38, 85);
            this.textBoxBatchFileName.Name = "textBoxBatchFileName";
            this.textBoxBatchFileName.ReadOnly = true;
            this.textBoxBatchFileName.Size = new System.Drawing.Size(196, 20);
            this.textBoxBatchFileName.TabIndex = 11;
            // 
            // groupBoxAudible
            // 
            this.groupBoxAudible.Controls.Add(this.labelToggleAlarmState);
            this.groupBoxAudible.Controls.Add(this.labelToggleAlarm1);
            this.groupBoxAudible.Controls.Add(this.buttonToggleAlarm);
            this.groupBoxAudible.Location = new System.Drawing.Point(190, 276);
            this.groupBoxAudible.Name = "groupBoxAudible";
            this.groupBoxAudible.Size = new System.Drawing.Size(330, 75);
            this.groupBoxAudible.TabIndex = 4;
            this.groupBoxAudible.TabStop = false;
            this.groupBoxAudible.Text = "UPS audible Alarm";
            // 
            // labelToggleAlarmState
            // 
            this.labelToggleAlarmState.AutoSize = true;
            this.labelToggleAlarmState.Location = new System.Drawing.Point(17, 41);
            this.labelToggleAlarmState.Name = "labelToggleAlarmState";
            this.labelToggleAlarmState.Size = new System.Drawing.Size(91, 13);
            this.labelToggleAlarmState.TabIndex = 16;
            this.labelToggleAlarmState.Text = "Current State is: ?";
            // 
            // labelToggleAlarm1
            // 
            this.labelToggleAlarm1.AutoSize = true;
            this.labelToggleAlarm1.Location = new System.Drawing.Point(17, 27);
            this.labelToggleAlarm1.Name = "labelToggleAlarm1";
            this.labelToggleAlarm1.Size = new System.Drawing.Size(155, 13);
            this.labelToggleAlarm1.TabIndex = 15;
            this.labelToggleAlarm1.Text = "Press \'Toggle\' to change State.";
            // 
            // buttonToggleAlarm
            // 
            this.buttonToggleAlarm.Enabled = false;
            this.buttonToggleAlarm.Location = new System.Drawing.Point(246, 30);
            this.buttonToggleAlarm.Name = "buttonToggleAlarm";
            this.buttonToggleAlarm.Size = new System.Drawing.Size(55, 24);
            this.buttonToggleAlarm.TabIndex = 15;
            this.buttonToggleAlarm.Text = "Toggle";
            this.buttonToggleAlarm.UseVisualStyleBackColor = true;
            this.buttonToggleAlarm.Click += new System.EventHandler(this.buttonToggleAlarm_Click);
            // 
            // groupBoxCommunication
            // 
            this.groupBoxCommunication.Controls.Add(this.buttonConnectDisconnect);
            this.groupBoxCommunication.Controls.Add(this.maskedTextBoxPolling);
            this.groupBoxCommunication.Controls.Add(this.labelPolling2);
            this.groupBoxCommunication.Controls.Add(this.comboBoxBaud);
            this.groupBoxCommunication.Controls.Add(this.labelPolling1);
            this.groupBoxCommunication.Controls.Add(this.labelBaud1);
            this.groupBoxCommunication.Controls.Add(this.labelPort1);
            this.groupBoxCommunication.Controls.Add(this.comboBoxPort);
            this.groupBoxCommunication.Controls.Add(this.radioButtonRS232);
            this.groupBoxCommunication.Controls.Add(this.radioButtonUSB);
            this.groupBoxCommunication.Location = new System.Drawing.Point(9, 17);
            this.groupBoxCommunication.Name = "groupBoxCommunication";
            this.groupBoxCommunication.Size = new System.Drawing.Size(175, 254);
            this.groupBoxCommunication.TabIndex = 1;
            this.groupBoxCommunication.TabStop = false;
            this.groupBoxCommunication.Text = "Communication";
            // 
            // buttonConnectDisconnect
            // 
            this.buttonConnectDisconnect.Location = new System.Drawing.Point(50, 201);
            this.buttonConnectDisconnect.Name = "buttonConnectDisconnect";
            this.buttonConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectDisconnect.TabIndex = 5;
            this.buttonConnectDisconnect.Text = "Connect";
            this.buttonConnectDisconnect.UseVisualStyleBackColor = true;
            this.buttonConnectDisconnect.Click += new System.EventHandler(this.buttonConnectDisconnect_Click);
            // 
            // maskedTextBoxPolling
            // 
            this.maskedTextBoxPolling.HidePromptOnLeave = true;
            this.maskedTextBoxPolling.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxPolling.Location = new System.Drawing.Point(112, 152);
            this.maskedTextBoxPolling.Mask = "00";
            this.maskedTextBoxPolling.Name = "maskedTextBoxPolling";
            this.maskedTextBoxPolling.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxPolling.TabIndex = 4;
            this.maskedTextBoxPolling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxPolling.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxPolling.Validated += new System.EventHandler(this.maskedTextBoxPolling_Validated);
            // 
            // labelPolling2
            // 
            this.labelPolling2.AutoSize = true;
            this.labelPolling2.Location = new System.Drawing.Point(137, 155);
            this.labelPolling2.Name = "labelPolling2";
            this.labelPolling2.Size = new System.Drawing.Size(24, 13);
            this.labelPolling2.TabIndex = 15;
            this.labelPolling2.Text = "sec";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400"});
            this.comboBoxBaud.Location = new System.Drawing.Point(90, 110);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(71, 21);
            this.comboBoxBaud.TabIndex = 3;
            this.comboBoxBaud.SelectionChangeCommitted += new System.EventHandler(this.comboBoxBaud_SelectionChangeCommitted);
            // 
            // labelPolling1
            // 
            this.labelPolling1.AutoSize = true;
            this.labelPolling1.Location = new System.Drawing.Point(13, 155);
            this.labelPolling1.Name = "labelPolling1";
            this.labelPolling1.Size = new System.Drawing.Size(79, 13);
            this.labelPolling1.TabIndex = 5;
            this.labelPolling1.Text = "Polling Interval:";
            // 
            // labelBaud1
            // 
            this.labelBaud1.AutoSize = true;
            this.labelBaud1.Location = new System.Drawing.Point(25, 113);
            this.labelBaud1.Name = "labelBaud1";
            this.labelBaud1.Size = new System.Drawing.Size(61, 13);
            this.labelBaud1.TabIndex = 4;
            this.labelBaud1.Text = "Baud Rate:";
            // 
            // labelPort1
            // 
            this.labelPort1.AutoSize = true;
            this.labelPort1.Location = new System.Drawing.Point(25, 88);
            this.labelPort1.Name = "labelPort1";
            this.labelPort1.Size = new System.Drawing.Size(29, 13);
            this.labelPort1.TabIndex = 3;
            this.labelPort1.Text = "Port:";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(90, 83);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(71, 21);
            this.comboBoxPort.TabIndex = 2;
            this.comboBoxPort.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPort_SelectionChangeCommitted);
            // 
            // radioButtonRS232
            // 
            this.radioButtonRS232.AutoSize = true;
            this.radioButtonRS232.Checked = true;
            this.radioButtonRS232.Location = new System.Drawing.Point(16, 61);
            this.radioButtonRS232.Name = "radioButtonRS232";
            this.radioButtonRS232.Size = new System.Drawing.Size(61, 17);
            this.radioButtonRS232.TabIndex = 1;
            this.radioButtonRS232.TabStop = true;
            this.radioButtonRS232.Text = "RS-232";
            this.radioButtonRS232.UseVisualStyleBackColor = true;
            this.radioButtonRS232.CheckedChanged += new System.EventHandler(this.radioButtonRS232_CheckedChanged);
            // 
            // radioButtonUSB
            // 
            this.radioButtonUSB.AutoSize = true;
            this.radioButtonUSB.Location = new System.Drawing.Point(16, 28);
            this.radioButtonUSB.Name = "radioButtonUSB";
            this.radioButtonUSB.Size = new System.Drawing.Size(47, 17);
            this.radioButtonUSB.TabIndex = 0;
            this.radioButtonUSB.Text = "USB";
            this.radioButtonUSB.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxCredits);
            this.tabPage3.Controls.Add(this.labelVersion);
            this.tabPage3.Controls.Add(this.labelCopyright);
            this.tabPage3.Controls.Add(this.labelProgramDescription);
            this.tabPage3.Controls.Add(this.labelProgramName);
            this.tabPage3.Controls.Add(this.labelLicense1);
            this.tabPage3.Controls.Add(this.labelHome1);
            this.tabPage3.Controls.Add(this.textBoxGNUDisclaimer);
            this.tabPage3.Controls.Add(this.linkLabelLicense);
            this.tabPage3.Controls.Add(this.linkLabelHome);
            this.tabPage3.Controls.Add(this.textBoxGNULicense);
            this.tabPage3.Controls.Add(this.pictureBoxGPL);
            this.tabPage3.Controls.Add(this.pictureBoxWinMust);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(541, 390);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxCredits
            // 
            this.textBoxCredits.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCredits.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCredits.Location = new System.Drawing.Point(14, 75);
            this.textBoxCredits.Multiline = true;
            this.textBoxCredits.Name = "textBoxCredits";
            this.textBoxCredits.ReadOnly = true;
            this.textBoxCredits.Size = new System.Drawing.Size(474, 32);
            this.textBoxCredits.TabIndex = 14;
            this.textBoxCredits.Text = "USB interface features of this software incorporate the open-source project HID.N" +
                "et (libhidnet) Copyright (C) 2007-2008 George Helyar";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(82, 29);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 13);
            this.labelVersion.TabIndex = 13;
            this.labelVersion.Text = "labelVersion";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(82, 42);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(175, 13);
            this.labelCopyright.TabIndex = 12;
            this.labelCopyright.Text = "Copyright (C) 2008 Thomas Kuhnke";
            // 
            // labelProgramDescription
            // 
            this.labelProgramDescription.AutoSize = true;
            this.labelProgramDescription.Location = new System.Drawing.Point(134, 12);
            this.labelProgramDescription.Name = "labelProgramDescription";
            this.labelProgramDescription.Size = new System.Drawing.Size(140, 13);
            this.labelProgramDescription.TabIndex = 11;
            this.labelProgramDescription.Text = "- Simple UPS Status Monitor";
            // 
            // labelProgramName
            // 
            this.labelProgramName.AutoSize = true;
            this.labelProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramName.Location = new System.Drawing.Point(82, 12);
            this.labelProgramName.Name = "labelProgramName";
            this.labelProgramName.Size = new System.Drawing.Size(56, 13);
            this.labelProgramName.TabIndex = 10;
            this.labelProgramName.Text = "WinMust";
            // 
            // labelLicense1
            // 
            this.labelLicense1.AutoSize = true;
            this.labelLicense1.Location = new System.Drawing.Point(10, 357);
            this.labelLicense1.Name = "labelLicense1";
            this.labelLicense1.Size = new System.Drawing.Size(102, 13);
            this.labelLicense1.TabIndex = 8;
            this.labelLicense1.Text = "License Information:";
            // 
            // labelHome1
            // 
            this.labelHome1.AutoSize = true;
            this.labelHome1.Location = new System.Drawing.Point(10, 344);
            this.labelHome1.Name = "labelHome1";
            this.labelHome1.Size = new System.Drawing.Size(80, 13);
            this.labelHome1.TabIndex = 7;
            this.labelHome1.Text = "Program Home:";
            // 
            // textBoxGNUDisclaimer
            // 
            this.textBoxGNUDisclaimer.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGNUDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGNUDisclaimer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxGNUDisclaimer.Location = new System.Drawing.Point(14, 113);
            this.textBoxGNUDisclaimer.Multiline = true;
            this.textBoxGNUDisclaimer.Name = "textBoxGNUDisclaimer";
            this.textBoxGNUDisclaimer.ReadOnly = true;
            this.textBoxGNUDisclaimer.Size = new System.Drawing.Size(505, 81);
            this.textBoxGNUDisclaimer.TabIndex = 5;
            this.textBoxGNUDisclaimer.Text = resources.GetString("textBoxGNUDisclaimer.Text");
            // 
            // linkLabelLicense
            // 
            this.linkLabelLicense.AutoSize = true;
            this.linkLabelLicense.Location = new System.Drawing.Point(118, 357);
            this.linkLabelLicense.Name = "linkLabelLicense";
            this.linkLabelLicense.Size = new System.Drawing.Size(185, 13);
            this.linkLabelLicense.TabIndex = 4;
            this.linkLabelLicense.TabStop = true;
            this.linkLabelLicense.Text = "http://www.gnu.org/licenses/gpl.html";
            this.linkLabelLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicense_LinkClicked);
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.AutoSize = true;
            this.linkLabelHome.Location = new System.Drawing.Point(96, 344);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(153, 13);
            this.linkLabelHome.TabIndex = 3;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "http://winmust.sourceforge.net";
            this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
            // 
            // textBoxGNULicense
            // 
            this.textBoxGNULicense.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGNULicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGNULicense.Location = new System.Drawing.Point(13, 208);
            this.textBoxGNULicense.Multiline = true;
            this.textBoxGNULicense.Name = "textBoxGNULicense";
            this.textBoxGNULicense.ReadOnly = true;
            this.textBoxGNULicense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGNULicense.Size = new System.Drawing.Size(507, 125);
            this.textBoxGNULicense.TabIndex = 0;
            this.textBoxGNULicense.Text = resources.GetString("textBoxGNULicense.Text");
            // 
            // pictureBoxGPL
            // 
            this.pictureBoxGPL.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGPL.Image")));
            this.pictureBoxGPL.Location = new System.Drawing.Point(431, 344);
            this.pictureBoxGPL.Name = "pictureBoxGPL";
            this.pictureBoxGPL.Size = new System.Drawing.Size(88, 31);
            this.pictureBoxGPL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxGPL.TabIndex = 6;
            this.pictureBoxGPL.TabStop = false;
            // 
            // pictureBoxWinMust
            // 
            this.pictureBoxWinMust.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWinMust.Image")));
            this.pictureBoxWinMust.Location = new System.Drawing.Point(13, 7);
            this.pictureBoxWinMust.Name = "pictureBoxWinMust";
            this.pictureBoxWinMust.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxWinMust.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWinMust.TabIndex = 1;
            this.pictureBoxWinMust.TabStop = false;
            // 
            // openBatchFileDialog
            // 
            this.openBatchFileDialog.Filter = "Batch File|*.bat|All files|*.*";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WinMust";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openToolStripMenuItem.Text = "Open WinMust";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 16);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonUSB,
            this.toolStripDropDownButtonRS232,
            this.toolStripStatusLabelConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButtonUSB
            // 
            this.toolStripDropDownButtonUSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonUSB.Enabled = false;
            this.toolStripDropDownButtonUSB.Image = global::WinMust.Properties.Resources.USB_grey;
            this.toolStripDropDownButtonUSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonUSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonUSB.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.toolStripDropDownButtonUSB.Name = "toolStripDropDownButtonUSB";
            this.toolStripDropDownButtonUSB.Padding = new System.Windows.Forms.Padding(10, 2, 0, 1);
            this.toolStripDropDownButtonUSB.ShowDropDownArrow = false;
            this.toolStripDropDownButtonUSB.Size = new System.Drawing.Size(47, 23);
            this.toolStripDropDownButtonUSB.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButtonUSB.ToolTipText = "USB Connected";
            // 
            // toolStripDropDownButtonRS232
            // 
            this.toolStripDropDownButtonRS232.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonRS232.Enabled = false;
            this.toolStripDropDownButtonRS232.Image = global::WinMust.Properties.Resources.RS232_grey;
            this.toolStripDropDownButtonRS232.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonRS232.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonRS232.Name = "toolStripDropDownButtonRS232";
            this.toolStripDropDownButtonRS232.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripDropDownButtonRS232.ShowDropDownArrow = false;
            this.toolStripDropDownButtonRS232.Size = new System.Drawing.Size(37, 23);
            this.toolStripDropDownButtonRS232.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButtonRS232.ToolTipText = "RS232 Disconnected";
            // 
            // toolStripStatusLabelConnectionStatus
            // 
            this.toolStripStatusLabelConnectionStatus.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.toolStripStatusLabelConnectionStatus.Name = "toolStripStatusLabelConnectionStatus";
            this.toolStripStatusLabelConnectionStatus.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripStatusLabelConnectionStatus.Size = new System.Drawing.Size(113, 20);
            this.toolStripStatusLabelConnectionStatus.Text = "UPS Disconnected";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(534, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "WinMust";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageStatus.ResumeLayout(false);
            this.groupBoxPowerSource.ResumeLayout(false);
            this.groupBoxPowerSource.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxACLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBatteryLine)).EndInit();
            this.groupBoxBackupOperation.ResumeLayout(false);
            this.groupBoxBackupOperation.PerformLayout();
            this.tabPagePreferences.ResumeLayout(false);
            this.groupBoxProgram.ResumeLayout(false);
            this.groupBoxProgram.PerformLayout();
            this.groupBoxShutdown.ResumeLayout(false);
            this.groupBoxShutdown.PerformLayout();
            this.groupBoxAudible.ResumeLayout(false);
            this.groupBoxAudible.PerformLayout();
            this.groupBoxCommunication.ResumeLayout(false);
            this.groupBoxCommunication.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinMust)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.TabPage tabPagePreferences;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelStatusACLine;
        private System.Windows.Forms.Label labelStatusPC;
        private System.Windows.Forms.Label labelStatusBattery;
        private System.Windows.Forms.Label labelStatusLoad1;
        private System.Windows.Forms.Label labelStatusLoadFrequency1;
        private System.Windows.Forms.Label labelStatusLoadVoltage1;
        private System.Windows.Forms.Label labelStatusACVoltage1;
        private System.Windows.Forms.Label labelStatusBatteryVoltage1;
        private System.Windows.Forms.Label labelStatusTimeOnBattery1;
        private System.Windows.Forms.Label labelTimeToSD1;
        private System.Windows.Forms.Label labelStatusBatteryVoltage;
        private System.Windows.Forms.Label labelStatusLoad;
        private System.Windows.Forms.Label labelStatusLoadFrequency;
        private System.Windows.Forms.Label labelStatusLoadVoltage;
        private System.Windows.Forms.Label labelStatusACVoltage;
        private System.Windows.Forms.Label labelStatusTimeToSD;
        private System.Windows.Forms.Label labelStatusTimeOnBattery;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.PictureBox pictureBoxWinMust;
        private System.Windows.Forms.TextBox textBoxGNUDisclaimer;
        private System.Windows.Forms.LinkLabel linkLabelLicense;
        private System.Windows.Forms.PictureBox pictureBoxGPL;
        private System.Windows.Forms.Label labelLicense1;
        private System.Windows.Forms.Label labelHome1;
        private System.Windows.Forms.GroupBox groupBoxCommunication;
        private System.Windows.Forms.RadioButton radioButtonRS232;
        private System.Windows.Forms.RadioButton radioButtonUSB;
        private System.Windows.Forms.Label labelPort1;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.GroupBox groupBoxShutdown;
        private System.Windows.Forms.GroupBox groupBoxAudible;
        private System.Windows.Forms.Button buttonToggleAlarm;
        private System.Windows.Forms.CheckBox checkBoxShutDownOnBattery;
        private System.Windows.Forms.Label labelBatch1;
        private System.Windows.Forms.Label labelBatch2;
        private System.Windows.Forms.CheckBox checkBoxBatch;
        private System.Windows.Forms.Button buttonBatchFileSelect;
        private System.Windows.Forms.TextBox textBoxBatchFileName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBoxBackupOperation;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelProgramDescription;
        private System.Windows.Forms.Label labelProgramName;
        private System.Windows.Forms.GroupBox groupBoxProgram;
        private System.Windows.Forms.CheckBox checkBoxMinToTray;
        private System.Windows.Forms.CheckBox checkBoxRunOnStart;
        private System.Windows.Forms.Label labelPolling1;
        private System.Windows.Forms.Label labelBaud1;
        private System.Windows.Forms.Label labelShutDownOnTime1;
        private System.Windows.Forms.CheckBox checkBoxShutDownOnTime;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Label labelPolling2;
        private System.Windows.Forms.Label labelToggleAlarmState;
        private System.Windows.Forms.Label labelToggleAlarm1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.PictureBox pictureBoxAC;
        private System.Windows.Forms.PictureBox pictureBoxUPS;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.PictureBox pictureBoxBattery;
        private System.Windows.Forms.Label labelStatusLoadPower;
        private System.Windows.Forms.Label labelStatusLoadPower1;
        private System.Windows.Forms.PictureBox pictureBoxACLine;
        private System.Windows.Forms.PictureBox pictureBoxLoadLine;
        private System.Windows.Forms.PictureBox pictureBoxBatteryLine;
        private System.Windows.Forms.OpenFileDialog openBatchFileDialog;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPolling;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxShutDownOnTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBatchDuration;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBoxPowerSource;
        private System.Windows.Forms.Label labelPowerSource;
        private System.Windows.Forms.Button buttonConnectDisconnect;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelTestRunning;
        private System.Windows.Forms.Label labelStatusBatteryCondition;
        private System.Windows.Forms.TextBox textBoxCredits;
        private System.Windows.Forms.TextBox textBoxGNULicense;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonUSB;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonRS232;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnectionStatus;
    }
}


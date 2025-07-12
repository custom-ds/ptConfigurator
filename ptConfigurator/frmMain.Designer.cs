namespace ptConfigurator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.commTracker = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDisablePathAboveAltitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cmboSymbol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmboPath2SSID = new System.Windows.Forms.ComboBox();
            this.cmboPath1SSID = new System.Windows.Forms.ComboBox();
            this.cmboDestinationSSID = new System.Windows.Forms.ComboBox();
            this.cmboCallsignSSID = new System.Windows.Forms.ComboBox();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblBeacon4E = new System.Windows.Forms.Label();
            this.txtBeacon4VoltThreshXmit = new System.Windows.Forms.TextBox();
            this.lblBeacon4D = new System.Windows.Forms.Label();
            this.lblBeacon4C = new System.Windows.Forms.Label();
            this.txtBeacon4VoltThreshGPS = new System.Windows.Forms.TextBox();
            this.lblBeacon4B = new System.Windows.Forms.Label();
            this.lblBeacon4A = new System.Windows.Forms.Label();
            this.txtBeacon4MinDelay = new System.Windows.Forms.TextBox();
            this.radBeacon4 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBeacon3Slot2 = new System.Windows.Forms.TextBox();
            this.txtBeacon3Slot1 = new System.Windows.Forms.TextBox();
            this.lblBeacon3C = new System.Windows.Forms.Label();
            this.lblBeacon3B = new System.Windows.Forms.Label();
            this.lblBeacon3A = new System.Windows.Forms.Label();
            this.txtBeacon2DelayMid = new System.Windows.Forms.TextBox();
            this.txtBeacon2DelayLow = new System.Windows.Forms.TextBox();
            this.txtBeacon2DelayHigh = new System.Windows.Forms.TextBox();
            this.txtBeacon2AltitudeLow = new System.Windows.Forms.TextBox();
            this.txtBeacon2AltitudeHigh = new System.Windows.Forms.TextBox();
            this.lblBeacon2H = new System.Windows.Forms.Label();
            this.lblBeacon2G = new System.Windows.Forms.Label();
            this.lblBeacon2F = new System.Windows.Forms.Label();
            this.lblBeacon2E = new System.Windows.Forms.Label();
            this.lblBeacon2D = new System.Windows.Forms.Label();
            this.lblBeacon2C = new System.Windows.Forms.Label();
            this.lblBeacon2B = new System.Windows.Forms.Label();
            this.lblBeacon2A = new System.Windows.Forms.Label();
            this.lblBeacon1H = new System.Windows.Forms.Label();
            this.lblBeacon1G = new System.Windows.Forms.Label();
            this.lblBeacon1F = new System.Windows.Forms.Label();
            this.txtBeacon1DelayHigh = new System.Windows.Forms.TextBox();
            this.txtBeacon1SpeedHigh = new System.Windows.Forms.TextBox();
            this.lblBeacon1D = new System.Windows.Forms.Label();
            this.lblBeacon1E = new System.Windows.Forms.Label();
            this.txtBeacon1DelayMid = new System.Windows.Forms.TextBox();
            this.lblBeacon1C = new System.Windows.Forms.Label();
            this.txtBeacon1DelayLow = new System.Windows.Forms.TextBox();
            this.lblBeacon1B = new System.Windows.Forms.Label();
            this.txtBeacon1SpeedLow = new System.Windows.Forms.TextBox();
            this.lblBeacon1A = new System.Windows.Forms.Label();
            this.lblBeacon0A = new System.Windows.Forms.Label();
            this.txtBeacon0Delay = new System.Windows.Forms.TextBox();
            this.radBeacon3 = new System.Windows.Forms.RadioButton();
            this.radBeacon2 = new System.Windows.Forms.RadioButton();
            this.radBeacon1 = new System.Windows.Forms.RadioButton();
            this.radBeacon0 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.chkXmitSeconds = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.chkEnableBME280 = new System.Windows.Forms.CheckBox();
            this.chkXmitCustom = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkXmitAirPressure = new System.Windows.Forms.CheckBox();
            this.cmboAnnouceMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkXmitAirTemp = new System.Windows.Forms.CheckBox();
            this.chkXmitBatteryVoltage = new System.Windows.Forms.CheckBox();
            this.chkXmitGPSQuality = new System.Windows.Forms.CheckBox();
            this.chkXmitBurstAltitude = new System.Windows.Forms.CheckBox();
            this.txtStatusMessage = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.chkTrackerRebootHourly = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.chkGPSDisableDuringXmit = new System.Windows.Forms.CheckBox();
            this.chkRadioGlobalFreq = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.lblRadioFreqRxB = new System.Windows.Forms.Label();
            this.lblRadioFreqTxB = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblRadioFreqRx = new System.Windows.Forms.Label();
            this.lblRadioFreqTx = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRadioTxDelay = new System.Windows.Forms.TextBox();
            this.cmboRadioType = new System.Windows.Forms.ComboBox();
            this.txtRadioFreqTx = new System.Windows.Forms.TextBox();
            this.txtRadioFreqRx = new System.Windows.Forms.TextBox();
            this.chkRadioCourtesyTone = new System.Windows.Forms.CheckBox();
            this.cmboGPSType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmboGPSSerialBaud = new System.Windows.Forms.ComboBox();
            this.chkGPSSerialInvert = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolReadConfig = new System.Windows.Forms.ToolStripButton();
            this.toolWriteConfig = new System.Windows.Forms.ToolStripButton();
            this.toolCommPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolRefreshCommPorts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExercise = new System.Windows.Forms.ToolStripButton();
            this.toolTestTransmitter = new System.Windows.Forms.ToolStripButton();
            this.toolConsole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAboutConfigurator = new System.Windows.Forms.ToolStripButton();
            this.timerAttn = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusConfigVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkDelayXmitWithoutGPS = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commTracker
            // 
            this.commTracker.BaudRate = 19200;
            this.commTracker.PortName = "COM13";
            this.commTracker.WriteTimeout = 250;
            this.commTracker.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.commTracker_DataReceived);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 568);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtDisablePathAboveAltitude);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.cmboSymbol);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmboPath2SSID);
            this.tabPage1.Controls.Add(this.cmboPath1SSID);
            this.tabPage1.Controls.Add(this.cmboDestinationSSID);
            this.tabPage1.Controls.Add(this.cmboCallsignSSID);
            this.tabPage1.Controls.Add(this.txtPath2);
            this.tabPage1.Controls.Add(this.txtPath1);
            this.tabPage1.Controls.Add(this.txtDestination);
            this.tabPage1.Controls.Add(this.txtCallsign);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calls/Paths";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SkyBlue;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(311, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(241, 47);
            this.label13.TabIndex = 33;
            this.label13.Text = "Enter your amateur radio callsign.  Balloons traditionally use SSID of \'11\', but " +
    "not required.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SkyBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(311, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "Normally left blank.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SkyBlue;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(311, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(241, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "If used, recommend  \'WIDE2\' and \'1\'";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "meters above Sea Level";
            // 
            // txtDisablePathAboveAltitude
            // 
            this.txtDisablePathAboveAltitude.Location = new System.Drawing.Point(178, 213);
            this.txtDisablePathAboveAltitude.Name = "txtDisablePathAboveAltitude";
            this.txtDisablePathAboveAltitude.Size = new System.Drawing.Size(100, 20);
            this.txtDisablePathAboveAltitude.TabIndex = 9;
            this.txtDisablePathAboveAltitude.TextChanged += new System.EventHandler(this.txtDisablePathAboveAltitude_TextChanged);
            this.txtDisablePathAboveAltitude.Leave += new System.EventHandler(this.txtDisablePathAboveAltitude_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Disable Path Above:";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.SkyBlue;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(311, 128);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(241, 17);
            this.label28.TabIndex = 27;
            this.label28.Text = "Normally left as \"APRS\" and SSID \"0\"";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmboSymbol
            // 
            this.cmboSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSymbol.FormattingEnabled = true;
            this.cmboSymbol.Items.AddRange(new object[] {
            "Jeep",
            "Balloon",
            "House"});
            this.cmboSymbol.Location = new System.Drawing.Point(120, 82);
            this.cmboSymbol.Name = "cmboSymbol";
            this.cmboSymbol.Size = new System.Drawing.Size(158, 21);
            this.cmboSymbol.TabIndex = 2;
            this.cmboSymbol.SelectedIndexChanged += new System.EventHandler(this.cmboSymbol_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Symbol:";
            // 
            // cmboPath2SSID
            // 
            this.cmboPath2SSID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPath2SSID.FormattingEnabled = true;
            this.cmboPath2SSID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmboPath2SSID.Location = new System.Drawing.Point(226, 177);
            this.cmboPath2SSID.Name = "cmboPath2SSID";
            this.cmboPath2SSID.Size = new System.Drawing.Size(52, 21);
            this.cmboPath2SSID.TabIndex = 8;
            this.cmboPath2SSID.SelectedIndexChanged += new System.EventHandler(this.cmboPath2SSID_SelectedIndexChanged);
            // 
            // cmboPath1SSID
            // 
            this.cmboPath1SSID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPath1SSID.FormattingEnabled = true;
            this.cmboPath1SSID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmboPath1SSID.Location = new System.Drawing.Point(226, 152);
            this.cmboPath1SSID.Name = "cmboPath1SSID";
            this.cmboPath1SSID.Size = new System.Drawing.Size(52, 21);
            this.cmboPath1SSID.TabIndex = 6;
            this.cmboPath1SSID.SelectedIndexChanged += new System.EventHandler(this.cmboPath1SSID_SelectedIndexChanged);
            // 
            // cmboDestinationSSID
            // 
            this.cmboDestinationSSID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDestinationSSID.FormattingEnabled = true;
            this.cmboDestinationSSID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmboDestinationSSID.Location = new System.Drawing.Point(226, 125);
            this.cmboDestinationSSID.Name = "cmboDestinationSSID";
            this.cmboDestinationSSID.Size = new System.Drawing.Size(52, 21);
            this.cmboDestinationSSID.TabIndex = 4;
            this.cmboDestinationSSID.SelectedIndexChanged += new System.EventHandler(this.cmboDestinationSSID_SelectedIndexChanged);
            // 
            // cmboCallsignSSID
            // 
            this.cmboCallsignSSID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCallsignSSID.FormattingEnabled = true;
            this.cmboCallsignSSID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmboCallsignSSID.Location = new System.Drawing.Point(226, 55);
            this.cmboCallsignSSID.Name = "cmboCallsignSSID";
            this.cmboCallsignSSID.Size = new System.Drawing.Size(52, 21);
            this.cmboCallsignSSID.TabIndex = 1;
            this.cmboCallsignSSID.SelectedIndexChanged += new System.EventHandler(this.cmboCallsignSSID_SelectedIndexChanged);
            // 
            // txtPath2
            // 
            this.txtPath2.Location = new System.Drawing.Point(120, 178);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(100, 20);
            this.txtPath2.TabIndex = 7;
            this.txtPath2.TextChanged += new System.EventHandler(this.txtPath2_TextChanged);
            this.txtPath2.Leave += new System.EventHandler(this.txtPath2_Leave);
            // 
            // txtPath1
            // 
            this.txtPath1.Location = new System.Drawing.Point(120, 152);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.Size = new System.Drawing.Size(100, 20);
            this.txtPath1.TabIndex = 5;
            this.txtPath1.TextChanged += new System.EventHandler(this.txtPath1_TextChanged);
            this.txtPath1.Leave += new System.EventHandler(this.txtPath1_Leave);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(120, 126);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(100, 20);
            this.txtDestination.TabIndex = 3;
            this.txtDestination.TextChanged += new System.EventHandler(this.txtDestination_TextChanged);
            this.txtDestination.Leave += new System.EventHandler(this.txtDestination_Leave);
            // 
            // txtCallsign
            // 
            this.txtCallsign.Location = new System.Drawing.Point(120, 56);
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(100, 20);
            this.txtCallsign.TabIndex = 0;
            this.txtCallsign.TextChanged += new System.EventHandler(this.txtCallsign_TextChanged);
            this.txtCallsign.Leave += new System.EventHandler(this.txtCallsign_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Path 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Path 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Destination:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Callsign:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.lblBeacon4E);
            this.tabPage2.Controls.Add(this.txtBeacon4VoltThreshXmit);
            this.tabPage2.Controls.Add(this.lblBeacon4D);
            this.tabPage2.Controls.Add(this.lblBeacon4C);
            this.tabPage2.Controls.Add(this.txtBeacon4VoltThreshGPS);
            this.tabPage2.Controls.Add(this.lblBeacon4B);
            this.tabPage2.Controls.Add(this.lblBeacon4A);
            this.tabPage2.Controls.Add(this.txtBeacon4MinDelay);
            this.tabPage2.Controls.Add(this.radBeacon4);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtBeacon3Slot2);
            this.tabPage2.Controls.Add(this.txtBeacon3Slot1);
            this.tabPage2.Controls.Add(this.lblBeacon3C);
            this.tabPage2.Controls.Add(this.lblBeacon3B);
            this.tabPage2.Controls.Add(this.lblBeacon3A);
            this.tabPage2.Controls.Add(this.txtBeacon2DelayMid);
            this.tabPage2.Controls.Add(this.txtBeacon2DelayLow);
            this.tabPage2.Controls.Add(this.txtBeacon2DelayHigh);
            this.tabPage2.Controls.Add(this.txtBeacon2AltitudeLow);
            this.tabPage2.Controls.Add(this.txtBeacon2AltitudeHigh);
            this.tabPage2.Controls.Add(this.lblBeacon2H);
            this.tabPage2.Controls.Add(this.lblBeacon2G);
            this.tabPage2.Controls.Add(this.lblBeacon2F);
            this.tabPage2.Controls.Add(this.lblBeacon2E);
            this.tabPage2.Controls.Add(this.lblBeacon2D);
            this.tabPage2.Controls.Add(this.lblBeacon2C);
            this.tabPage2.Controls.Add(this.lblBeacon2B);
            this.tabPage2.Controls.Add(this.lblBeacon2A);
            this.tabPage2.Controls.Add(this.lblBeacon1H);
            this.tabPage2.Controls.Add(this.lblBeacon1G);
            this.tabPage2.Controls.Add(this.lblBeacon1F);
            this.tabPage2.Controls.Add(this.txtBeacon1DelayHigh);
            this.tabPage2.Controls.Add(this.txtBeacon1SpeedHigh);
            this.tabPage2.Controls.Add(this.lblBeacon1D);
            this.tabPage2.Controls.Add(this.lblBeacon1E);
            this.tabPage2.Controls.Add(this.txtBeacon1DelayMid);
            this.tabPage2.Controls.Add(this.lblBeacon1C);
            this.tabPage2.Controls.Add(this.txtBeacon1DelayLow);
            this.tabPage2.Controls.Add(this.lblBeacon1B);
            this.tabPage2.Controls.Add(this.txtBeacon1SpeedLow);
            this.tabPage2.Controls.Add(this.lblBeacon1A);
            this.tabPage2.Controls.Add(this.lblBeacon0A);
            this.tabPage2.Controls.Add(this.txtBeacon0Delay);
            this.tabPage2.Controls.Add(this.radBeacon3);
            this.tabPage2.Controls.Add(this.radBeacon2);
            this.tabPage2.Controls.Add(this.radBeacon1);
            this.tabPage2.Controls.Add(this.radBeacon0);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Beaconing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblBeacon4E
            // 
            this.lblBeacon4E.AutoSize = true;
            this.lblBeacon4E.Location = new System.Drawing.Point(322, 442);
            this.lblBeacon4E.Name = "lblBeacon4E";
            this.lblBeacon4E.Size = new System.Drawing.Size(48, 13);
            this.lblBeacon4E.TabIndex = 44;
            this.lblBeacon4E.Text = "millivolts.";
            // 
            // txtBeacon4VoltThreshXmit
            // 
            this.txtBeacon4VoltThreshXmit.Location = new System.Drawing.Point(234, 440);
            this.txtBeacon4VoltThreshXmit.Name = "txtBeacon4VoltThreshXmit";
            this.txtBeacon4VoltThreshXmit.Size = new System.Drawing.Size(77, 20);
            this.txtBeacon4VoltThreshXmit.TabIndex = 42;
            this.txtBeacon4VoltThreshXmit.Leave += new System.EventHandler(this.txtBeacon4VoltThreshXmit_Leave);
            // 
            // lblBeacon4D
            // 
            this.lblBeacon4D.AutoSize = true;
            this.lblBeacon4D.Location = new System.Drawing.Point(52, 442);
            this.lblBeacon4D.Name = "lblBeacon4D";
            this.lblBeacon4D.Size = new System.Drawing.Size(172, 13);
            this.lblBeacon4D.TabIndex = 43;
            this.lblBeacon4D.Text = "Transmit Voltage Enable Threshold";
            // 
            // lblBeacon4C
            // 
            this.lblBeacon4C.AutoSize = true;
            this.lblBeacon4C.Location = new System.Drawing.Point(322, 414);
            this.lblBeacon4C.Name = "lblBeacon4C";
            this.lblBeacon4C.Size = new System.Drawing.Size(48, 13);
            this.lblBeacon4C.TabIndex = 41;
            this.lblBeacon4C.Text = "millivolts.";
            // 
            // txtBeacon4VoltThreshGPS
            // 
            this.txtBeacon4VoltThreshGPS.Location = new System.Drawing.Point(234, 411);
            this.txtBeacon4VoltThreshGPS.Name = "txtBeacon4VoltThreshGPS";
            this.txtBeacon4VoltThreshGPS.Size = new System.Drawing.Size(77, 20);
            this.txtBeacon4VoltThreshGPS.TabIndex = 39;
            this.txtBeacon4VoltThreshGPS.Leave += new System.EventHandler(this.txtBeacon4VoltThreshGPS_Leave);
            // 
            // lblBeacon4B
            // 
            this.lblBeacon4B.AutoSize = true;
            this.lblBeacon4B.Location = new System.Drawing.Point(52, 414);
            this.lblBeacon4B.Name = "lblBeacon4B";
            this.lblBeacon4B.Size = new System.Drawing.Size(154, 13);
            this.lblBeacon4B.TabIndex = 40;
            this.lblBeacon4B.Text = "GPS Voltage Enable Threshold";
            this.lblBeacon4B.Click += new System.EventHandler(this.label29_Click);
            // 
            // lblBeacon4A
            // 
            this.lblBeacon4A.AutoSize = true;
            this.lblBeacon4A.Location = new System.Drawing.Point(52, 385);
            this.lblBeacon4A.Name = "lblBeacon4A";
            this.lblBeacon4A.Size = new System.Drawing.Size(185, 13);
            this.lblBeacon4A.TabIndex = 38;
            this.lblBeacon4A.Text = "Minimum delay between transmissions";
            // 
            // txtBeacon4MinDelay
            // 
            this.txtBeacon4MinDelay.Location = new System.Drawing.Point(247, 383);
            this.txtBeacon4MinDelay.Name = "txtBeacon4MinDelay";
            this.txtBeacon4MinDelay.Size = new System.Drawing.Size(38, 20);
            this.txtBeacon4MinDelay.TabIndex = 37;
            this.txtBeacon4MinDelay.Leave += new System.EventHandler(this.txtBeacon4MinDelay_Leave);
            // 
            // radBeacon4
            // 
            this.radBeacon4.AutoSize = true;
            this.radBeacon4.Location = new System.Drawing.Point(20, 358);
            this.radBeacon4.Name = "radBeacon4";
            this.radBeacon4.Size = new System.Drawing.Size(132, 17);
            this.radBeacon4.TabIndex = 36;
            this.radBeacon4.Text = "Low Power Beaconing";
            this.radBeacon4.UseVisualStyleBackColor = true;
            this.radBeacon4.CheckedChanged += new System.EventHandler(this.radBeacon4_CheckedChanged);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SkyBlue;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(328, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(241, 44);
            this.label14.TabIndex = 35;
            this.label14.Text = "Set both to same value for single transmission per minute.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBeacon3Slot2
            // 
            this.txtBeacon3Slot2.Location = new System.Drawing.Point(244, 322);
            this.txtBeacon3Slot2.Name = "txtBeacon3Slot2";
            this.txtBeacon3Slot2.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon3Slot2.TabIndex = 16;
            this.txtBeacon3Slot2.TextChanged += new System.EventHandler(this.txtBeacon3Slot2_TextChanged);
            this.txtBeacon3Slot2.Leave += new System.EventHandler(this.txtBeacon3Slot2_Leave);
            // 
            // txtBeacon3Slot1
            // 
            this.txtBeacon3Slot1.Location = new System.Drawing.Point(107, 322);
            this.txtBeacon3Slot1.Name = "txtBeacon3Slot1";
            this.txtBeacon3Slot1.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon3Slot1.TabIndex = 15;
            this.txtBeacon3Slot1.TextChanged += new System.EventHandler(this.txtBeacon3Slot1_TextChanged);
            this.txtBeacon3Slot1.Leave += new System.EventHandler(this.txtBeacon3Slot1_Leave);
            // 
            // lblBeacon3C
            // 
            this.lblBeacon3C.AutoSize = true;
            this.lblBeacon3C.Location = new System.Drawing.Point(204, 325);
            this.lblBeacon3C.Name = "lblBeacon3C";
            this.lblBeacon3C.Size = new System.Drawing.Size(34, 13);
            this.lblBeacon3C.TabIndex = 34;
            this.lblBeacon3C.Text = "Slot 2";
            // 
            // lblBeacon3B
            // 
            this.lblBeacon3B.AutoSize = true;
            this.lblBeacon3B.Location = new System.Drawing.Point(67, 325);
            this.lblBeacon3B.Name = "lblBeacon3B";
            this.lblBeacon3B.Size = new System.Drawing.Size(34, 13);
            this.lblBeacon3B.TabIndex = 33;
            this.lblBeacon3B.Text = "Slot 1";
            // 
            // lblBeacon3A
            // 
            this.lblBeacon3A.AutoSize = true;
            this.lblBeacon3A.Location = new System.Drawing.Point(52, 298);
            this.lblBeacon3A.Name = "lblBeacon3A";
            this.lblBeacon3A.Size = new System.Drawing.Size(195, 13);
            this.lblBeacon3A.TabIndex = 32;
            this.lblBeacon3A.Text = "Set seconds past the minute to transmit.";
            // 
            // txtBeacon2DelayMid
            // 
            this.txtBeacon2DelayMid.Location = new System.Drawing.Point(353, 212);
            this.txtBeacon2DelayMid.Name = "txtBeacon2DelayMid";
            this.txtBeacon2DelayMid.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon2DelayMid.TabIndex = 12;
            this.txtBeacon2DelayMid.TextChanged += new System.EventHandler(this.txtBeacon2DelayMid_TextChanged);
            this.txtBeacon2DelayMid.Leave += new System.EventHandler(this.txtBeacon2DelayMid_Leave);
            // 
            // txtBeacon2DelayLow
            // 
            this.txtBeacon2DelayLow.Location = new System.Drawing.Point(317, 186);
            this.txtBeacon2DelayLow.Name = "txtBeacon2DelayLow";
            this.txtBeacon2DelayLow.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon2DelayLow.TabIndex = 11;
            this.txtBeacon2DelayLow.TextChanged += new System.EventHandler(this.txtBeacon2DelayLow_TextChanged);
            this.txtBeacon2DelayLow.Leave += new System.EventHandler(this.txtBeacon2DelayLow_Leave);
            // 
            // txtBeacon2DelayHigh
            // 
            this.txtBeacon2DelayHigh.Location = new System.Drawing.Point(317, 241);
            this.txtBeacon2DelayHigh.Name = "txtBeacon2DelayHigh";
            this.txtBeacon2DelayHigh.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon2DelayHigh.TabIndex = 14;
            this.txtBeacon2DelayHigh.TextChanged += new System.EventHandler(this.txtBeacon2DelayHigh_TextChanged);
            this.txtBeacon2DelayHigh.Leave += new System.EventHandler(this.txtBeacon2DelayHigh_Leave);
            // 
            // txtBeacon2AltitudeLow
            // 
            this.txtBeacon2AltitudeLow.Location = new System.Drawing.Point(94, 186);
            this.txtBeacon2AltitudeLow.Name = "txtBeacon2AltitudeLow";
            this.txtBeacon2AltitudeLow.Size = new System.Drawing.Size(77, 20);
            this.txtBeacon2AltitudeLow.TabIndex = 10;
            this.txtBeacon2AltitudeLow.TextChanged += new System.EventHandler(this.txtBeacon2AltitudeLow_TextChanged);
            this.txtBeacon2AltitudeLow.Leave += new System.EventHandler(this.txtBeacon2AltitudeLow_Leave);
            // 
            // txtBeacon2AltitudeHigh
            // 
            this.txtBeacon2AltitudeHigh.Location = new System.Drawing.Point(94, 238);
            this.txtBeacon2AltitudeHigh.Name = "txtBeacon2AltitudeHigh";
            this.txtBeacon2AltitudeHigh.Size = new System.Drawing.Size(77, 20);
            this.txtBeacon2AltitudeHigh.TabIndex = 13;
            this.txtBeacon2AltitudeHigh.TextChanged += new System.EventHandler(this.txtBeacon2AltitudeHigh_TextChanged);
            this.txtBeacon2AltitudeHigh.Leave += new System.EventHandler(this.txtBeacon2AltitudeHigh_Leave);
            // 
            // lblBeacon2H
            // 
            this.lblBeacon2H.AutoSize = true;
            this.lblBeacon2H.Location = new System.Drawing.Point(360, 244);
            this.lblBeacon2H.Name = "lblBeacon2H";
            this.lblBeacon2H.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon2H.TabIndex = 26;
            this.lblBeacon2H.Text = "seconds.";
            // 
            // lblBeacon2G
            // 
            this.lblBeacon2G.AutoSize = true;
            this.lblBeacon2G.Location = new System.Drawing.Point(177, 244);
            this.lblBeacon2G.Name = "lblBeacon2G";
            this.lblBeacon2G.Size = new System.Drawing.Size(134, 13);
            this.lblBeacon2G.TabIndex = 25;
            this.lblBeacon2G.Text = "meters MSL, transmit every";
            // 
            // lblBeacon2F
            // 
            this.lblBeacon2F.AutoSize = true;
            this.lblBeacon2F.Location = new System.Drawing.Point(52, 241);
            this.lblBeacon2F.Name = "lblBeacon2F";
            this.lblBeacon2F.Size = new System.Drawing.Size(38, 13);
            this.lblBeacon2F.TabIndex = 24;
            this.lblBeacon2F.Text = "Above";
            // 
            // lblBeacon2E
            // 
            this.lblBeacon2E.AutoSize = true;
            this.lblBeacon2E.Location = new System.Drawing.Point(396, 215);
            this.lblBeacon2E.Name = "lblBeacon2E";
            this.lblBeacon2E.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon2E.TabIndex = 23;
            this.lblBeacon2E.Text = "seconds.";
            // 
            // lblBeacon2D
            // 
            this.lblBeacon2D.AutoSize = true;
            this.lblBeacon2D.Location = new System.Drawing.Point(52, 215);
            this.lblBeacon2D.Name = "lblBeacon2D";
            this.lblBeacon2D.Size = new System.Drawing.Size(285, 13);
            this.lblBeacon2D.TabIndex = 22;
            this.lblBeacon2D.Text = "Between XXXXX meters and YYYYY meters, transmit every";
            // 
            // lblBeacon2C
            // 
            this.lblBeacon2C.AutoSize = true;
            this.lblBeacon2C.Location = new System.Drawing.Point(360, 189);
            this.lblBeacon2C.Name = "lblBeacon2C";
            this.lblBeacon2C.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon2C.TabIndex = 21;
            this.lblBeacon2C.Text = "seconds.";
            // 
            // lblBeacon2B
            // 
            this.lblBeacon2B.AutoSize = true;
            this.lblBeacon2B.Location = new System.Drawing.Point(177, 189);
            this.lblBeacon2B.Name = "lblBeacon2B";
            this.lblBeacon2B.Size = new System.Drawing.Size(134, 13);
            this.lblBeacon2B.TabIndex = 20;
            this.lblBeacon2B.Text = "meters MSL, transmit every";
            // 
            // lblBeacon2A
            // 
            this.lblBeacon2A.AutoSize = true;
            this.lblBeacon2A.Location = new System.Drawing.Point(52, 189);
            this.lblBeacon2A.Name = "lblBeacon2A";
            this.lblBeacon2A.Size = new System.Drawing.Size(36, 13);
            this.lblBeacon2A.TabIndex = 19;
            this.lblBeacon2A.Text = "Below";
            // 
            // lblBeacon1H
            // 
            this.lblBeacon1H.AutoSize = true;
            this.lblBeacon1H.Location = new System.Drawing.Point(290, 137);
            this.lblBeacon1H.Name = "lblBeacon1H";
            this.lblBeacon1H.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon1H.TabIndex = 18;
            this.lblBeacon1H.Text = "seconds.";
            // 
            // lblBeacon1G
            // 
            this.lblBeacon1G.AutoSize = true;
            this.lblBeacon1G.Location = new System.Drawing.Point(137, 137);
            this.lblBeacon1G.Name = "lblBeacon1G";
            this.lblBeacon1G.Size = new System.Drawing.Size(104, 13);
            this.lblBeacon1G.TabIndex = 17;
            this.lblBeacon1G.Text = "knots, transmit every";
            // 
            // lblBeacon1F
            // 
            this.lblBeacon1F.AutoSize = true;
            this.lblBeacon1F.Location = new System.Drawing.Point(52, 137);
            this.lblBeacon1F.Name = "lblBeacon1F";
            this.lblBeacon1F.Size = new System.Drawing.Size(38, 13);
            this.lblBeacon1F.TabIndex = 16;
            this.lblBeacon1F.Text = "Above";
            // 
            // txtBeacon1DelayHigh
            // 
            this.txtBeacon1DelayHigh.Location = new System.Drawing.Point(247, 134);
            this.txtBeacon1DelayHigh.Name = "txtBeacon1DelayHigh";
            this.txtBeacon1DelayHigh.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon1DelayHigh.TabIndex = 9;
            this.txtBeacon1DelayHigh.TextChanged += new System.EventHandler(this.txtBeacon1DelayHigh_TextChanged);
            this.txtBeacon1DelayHigh.Leave += new System.EventHandler(this.txtBeacon1DelayHigh_Leave);
            // 
            // txtBeacon1SpeedHigh
            // 
            this.txtBeacon1SpeedHigh.Location = new System.Drawing.Point(96, 134);
            this.txtBeacon1SpeedHigh.Name = "txtBeacon1SpeedHigh";
            this.txtBeacon1SpeedHigh.Size = new System.Drawing.Size(35, 20);
            this.txtBeacon1SpeedHigh.TabIndex = 8;
            this.txtBeacon1SpeedHigh.TextChanged += new System.EventHandler(this.txtBeacon1SpeedHigh_TextChanged);
            this.txtBeacon1SpeedHigh.Leave += new System.EventHandler(this.txtBeacon1SpeedHigh_Leave);
            // 
            // lblBeacon1D
            // 
            this.lblBeacon1D.AutoSize = true;
            this.lblBeacon1D.Location = new System.Drawing.Point(52, 111);
            this.lblBeacon1D.Name = "lblBeacon1D";
            this.lblBeacon1D.Size = new System.Drawing.Size(233, 13);
            this.lblBeacon1D.TabIndex = 13;
            this.lblBeacon1D.Text = "Between XX knots and YY knots, transmit every";
            // 
            // lblBeacon1E
            // 
            this.lblBeacon1E.AutoSize = true;
            this.lblBeacon1E.Location = new System.Drawing.Point(350, 111);
            this.lblBeacon1E.Name = "lblBeacon1E";
            this.lblBeacon1E.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon1E.TabIndex = 12;
            this.lblBeacon1E.Text = "seconds.";
            // 
            // txtBeacon1DelayMid
            // 
            this.txtBeacon1DelayMid.Location = new System.Drawing.Point(307, 108);
            this.txtBeacon1DelayMid.Name = "txtBeacon1DelayMid";
            this.txtBeacon1DelayMid.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon1DelayMid.TabIndex = 7;
            this.txtBeacon1DelayMid.TextChanged += new System.EventHandler(this.txtBeacon1DelayMid_TextChanged);
            this.txtBeacon1DelayMid.Leave += new System.EventHandler(this.txtBeacon1DelayMid_Leave);
            // 
            // lblBeacon1C
            // 
            this.lblBeacon1C.AutoSize = true;
            this.lblBeacon1C.Location = new System.Drawing.Point(290, 85);
            this.lblBeacon1C.Name = "lblBeacon1C";
            this.lblBeacon1C.Size = new System.Drawing.Size(50, 13);
            this.lblBeacon1C.TabIndex = 10;
            this.lblBeacon1C.Text = "seconds.";
            // 
            // txtBeacon1DelayLow
            // 
            this.txtBeacon1DelayLow.Location = new System.Drawing.Point(247, 82);
            this.txtBeacon1DelayLow.Name = "txtBeacon1DelayLow";
            this.txtBeacon1DelayLow.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon1DelayLow.TabIndex = 6;
            this.txtBeacon1DelayLow.TextChanged += new System.EventHandler(this.txtBeacon1DelayLow_TextChanged);
            this.txtBeacon1DelayLow.Leave += new System.EventHandler(this.txtBeacon1DelayLow_Leave);
            // 
            // lblBeacon1B
            // 
            this.lblBeacon1B.AutoSize = true;
            this.lblBeacon1B.Location = new System.Drawing.Point(137, 85);
            this.lblBeacon1B.Name = "lblBeacon1B";
            this.lblBeacon1B.Size = new System.Drawing.Size(104, 13);
            this.lblBeacon1B.TabIndex = 8;
            this.lblBeacon1B.Text = "knots, transmit every";
            // 
            // txtBeacon1SpeedLow
            // 
            this.txtBeacon1SpeedLow.Location = new System.Drawing.Point(94, 82);
            this.txtBeacon1SpeedLow.Name = "txtBeacon1SpeedLow";
            this.txtBeacon1SpeedLow.Size = new System.Drawing.Size(37, 20);
            this.txtBeacon1SpeedLow.TabIndex = 5;
            this.txtBeacon1SpeedLow.TextChanged += new System.EventHandler(this.txtBeacon1SpeedLow_TextChanged);
            this.txtBeacon1SpeedLow.Leave += new System.EventHandler(this.txtBeacon1SpeedLow_Leave);
            // 
            // lblBeacon1A
            // 
            this.lblBeacon1A.AutoSize = true;
            this.lblBeacon1A.Location = new System.Drawing.Point(52, 85);
            this.lblBeacon1A.Name = "lblBeacon1A";
            this.lblBeacon1A.Size = new System.Drawing.Size(36, 13);
            this.lblBeacon1A.TabIndex = 6;
            this.lblBeacon1A.Text = "Below";
            // 
            // lblBeacon0A
            // 
            this.lblBeacon0A.AutoSize = true;
            this.lblBeacon0A.Location = new System.Drawing.Point(52, 40);
            this.lblBeacon0A.Name = "lblBeacon0A";
            this.lblBeacon0A.Size = new System.Drawing.Size(186, 13);
            this.lblBeacon0A.TabIndex = 5;
            this.lblBeacon0A.Text = "Seconds delay between transmissions";
            // 
            // txtBeacon0Delay
            // 
            this.txtBeacon0Delay.Location = new System.Drawing.Point(247, 37);
            this.txtBeacon0Delay.Name = "txtBeacon0Delay";
            this.txtBeacon0Delay.Size = new System.Drawing.Size(38, 20);
            this.txtBeacon0Delay.TabIndex = 4;
            this.txtBeacon0Delay.TextChanged += new System.EventHandler(this.txtBeacon0Delay_TextChanged);
            this.txtBeacon0Delay.Leave += new System.EventHandler(this.txtBeacon0Delay_Leave);
            // 
            // radBeacon3
            // 
            this.radBeacon3.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.radBeacon3.AutoSize = true;
            this.radBeacon3.Location = new System.Drawing.Point(22, 278);
            this.radBeacon3.Name = "radBeacon3";
            this.radBeacon3.Size = new System.Drawing.Size(74, 17);
            this.radBeacon3.TabIndex = 3;
            this.radBeacon3.Text = "Time Slots";
            this.radBeacon3.UseVisualStyleBackColor = true;
            this.radBeacon3.CheckedChanged += new System.EventHandler(this.radBeacon3_CheckedChanged);
            // 
            // radBeacon2
            // 
            this.radBeacon2.AutoSize = true;
            this.radBeacon2.Location = new System.Drawing.Point(22, 163);
            this.radBeacon2.Name = "radBeacon2";
            this.radBeacon2.Size = new System.Drawing.Size(146, 17);
            this.radBeacon2.TabIndex = 2;
            this.radBeacon2.Text = "Altitude-based Beaconing";
            this.radBeacon2.UseVisualStyleBackColor = true;
            this.radBeacon2.CheckedChanged += new System.EventHandler(this.radBeacon2_CheckedChanged);
            // 
            // radBeacon1
            // 
            this.radBeacon1.AutoSize = true;
            this.radBeacon1.Location = new System.Drawing.Point(22, 65);
            this.radBeacon1.Name = "radBeacon1";
            this.radBeacon1.Size = new System.Drawing.Size(142, 17);
            this.radBeacon1.TabIndex = 1;
            this.radBeacon1.Text = "Speed-based Beaconing";
            this.radBeacon1.UseVisualStyleBackColor = true;
            this.radBeacon1.CheckedChanged += new System.EventHandler(this.radBeacon1_CheckedChanged);
            // 
            // radBeacon0
            // 
            this.radBeacon0.AutoSize = true;
            this.radBeacon0.Checked = true;
            this.radBeacon0.Location = new System.Drawing.Point(22, 20);
            this.radBeacon0.Name = "radBeacon0";
            this.radBeacon0.Size = new System.Drawing.Size(86, 17);
            this.radBeacon0.TabIndex = 0;
            this.radBeacon0.TabStop = true;
            this.radBeacon0.Text = "Simple Delay";
            this.radBeacon0.UseVisualStyleBackColor = true;
            this.radBeacon0.CheckedChanged += new System.EventHandler(this.radBeacon0_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.chkXmitSeconds);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.chkEnableBME280);
            this.tabPage3.Controls.Add(this.chkXmitCustom);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.chkXmitAirPressure);
            this.tabPage3.Controls.Add(this.cmboAnnouceMode);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.chkXmitAirTemp);
            this.tabPage3.Controls.Add(this.chkXmitBatteryVoltage);
            this.tabPage3.Controls.Add(this.chkXmitGPSQuality);
            this.tabPage3.Controls.Add(this.chkXmitBurstAltitude);
            this.tabPage3.Controls.Add(this.txtStatusMessage);
            this.tabPage3.Controls.Add(this.label27);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 542);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Telemetry";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.SkyBlue;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Location = new System.Drawing.Point(222, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(320, 17);
            this.label26.TabIndex = 32;
            this.label26.Text = "Seconds since tracker boot. Useful for tracking firmware issues.";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkXmitSeconds
            // 
            this.chkXmitSeconds.AutoSize = true;
            this.chkXmitSeconds.Location = new System.Drawing.Point(40, 161);
            this.chkXmitSeconds.Margin = new System.Windows.Forms.Padding(2);
            this.chkXmitSeconds.Name = "chkXmitSeconds";
            this.chkXmitSeconds.Size = new System.Drawing.Size(111, 17);
            this.chkXmitSeconds.TabIndex = 31;
            this.chkXmitSeconds.Text = "Transmit Seconds";
            this.chkXmitSeconds.UseVisualStyleBackColor = true;
            this.chkXmitSeconds.CheckedChanged += new System.EventHandler(this.chkXmitSeconds_CheckedChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(39, 270);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 30;
            this.label33.Text = "i2c Devices";
            // 
            // chkEnableBME280
            // 
            this.chkEnableBME280.AutoSize = true;
            this.chkEnableBME280.Location = new System.Drawing.Point(40, 285);
            this.chkEnableBME280.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableBME280.Name = "chkEnableBME280";
            this.chkEnableBME280.Size = new System.Drawing.Size(139, 17);
            this.chkEnableBME280.TabIndex = 29;
            this.chkEnableBME280.Text = "Enable BME280 Sensor";
            this.chkEnableBME280.UseVisualStyleBackColor = true;
            this.chkEnableBME280.CheckedChanged += new System.EventHandler(this.chkEnableBME280_CheckedChanged);
            // 
            // chkXmitCustom
            // 
            this.chkXmitCustom.AutoSize = true;
            this.chkXmitCustom.Location = new System.Drawing.Point(40, 182);
            this.chkXmitCustom.Margin = new System.Windows.Forms.Padding(2);
            this.chkXmitCustom.Name = "chkXmitCustom";
            this.chkXmitCustom.Size = new System.Drawing.Size(153, 17);
            this.chkXmitCustom.TabIndex = 6;
            this.chkXmitCustom.Text = "Transmit Custom Telemetry";
            this.chkXmitCustom.UseVisualStyleBackColor = true;
            this.chkXmitCustom.CheckedChanged += new System.EventHandler(this.chkXmitCustom_CheckedChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SkyBlue;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(392, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Max 40 chars.";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkXmitAirPressure
            // 
            this.chkXmitAirPressure.AutoSize = true;
            this.chkXmitAirPressure.Location = new System.Drawing.Point(41, 139);
            this.chkXmitAirPressure.Name = "chkXmitAirPressure";
            this.chkXmitAirPressure.Size = new System.Drawing.Size(125, 17);
            this.chkXmitAirPressure.TabIndex = 5;
            this.chkXmitAirPressure.Text = "Transmit Air Pressure";
            this.chkXmitAirPressure.UseVisualStyleBackColor = true;
            this.chkXmitAirPressure.CheckedChanged += new System.EventHandler(this.chkXmitAirPressure_CheckedChanged);
            // 
            // cmboAnnouceMode
            // 
            this.cmboAnnouceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboAnnouceMode.FormattingEnabled = true;
            this.cmboAnnouceMode.Items.AddRange(new object[] {
            "None (Power Savings)",
            "LED Only",
            "Buzzer Only",
            "LED and Buzzer"});
            this.cmboAnnouceMode.Location = new System.Drawing.Point(212, 222);
            this.cmboAnnouceMode.Name = "cmboAnnouceMode";
            this.cmboAnnouceMode.Size = new System.Drawing.Size(160, 21);
            this.cmboAnnouceMode.TabIndex = 7;
            this.cmboAnnouceMode.SelectedIndexChanged += new System.EventHandler(this.cmboAnnouceMode_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Controller Announce Mode";
            // 
            // chkXmitAirTemp
            // 
            this.chkXmitAirTemp.AutoSize = true;
            this.chkXmitAirTemp.Location = new System.Drawing.Point(41, 116);
            this.chkXmitAirTemp.Name = "chkXmitAirTemp";
            this.chkXmitAirTemp.Size = new System.Drawing.Size(144, 17);
            this.chkXmitAirTemp.TabIndex = 4;
            this.chkXmitAirTemp.Text = "Transmit Air Temperature";
            this.chkXmitAirTemp.UseVisualStyleBackColor = true;
            this.chkXmitAirTemp.CheckedChanged += new System.EventHandler(this.chkXmitAirTemp_CheckedChanged);
            // 
            // chkXmitBatteryVoltage
            // 
            this.chkXmitBatteryVoltage.AutoSize = true;
            this.chkXmitBatteryVoltage.Location = new System.Drawing.Point(41, 93);
            this.chkXmitBatteryVoltage.Name = "chkXmitBatteryVoltage";
            this.chkXmitBatteryVoltage.Size = new System.Drawing.Size(178, 17);
            this.chkXmitBatteryVoltage.TabIndex = 3;
            this.chkXmitBatteryVoltage.Text = "Transmit System Battery Voltage";
            this.chkXmitBatteryVoltage.UseVisualStyleBackColor = true;
            this.chkXmitBatteryVoltage.CheckedChanged += new System.EventHandler(this.chkXmitBatteryVoltage_CheckedChanged);
            // 
            // chkXmitGPSQuality
            // 
            this.chkXmitGPSQuality.AutoSize = true;
            this.chkXmitGPSQuality.Location = new System.Drawing.Point(41, 70);
            this.chkXmitGPSQuality.Name = "chkXmitGPSQuality";
            this.chkXmitGPSQuality.Size = new System.Drawing.Size(142, 17);
            this.chkXmitGPSQuality.TabIndex = 2;
            this.chkXmitGPSQuality.Text = "Transmit GPS Fix Quality";
            this.chkXmitGPSQuality.UseVisualStyleBackColor = true;
            this.chkXmitGPSQuality.CheckedChanged += new System.EventHandler(this.chkXmitGPSQuality_CheckedChanged);
            // 
            // chkXmitBurstAltitude
            // 
            this.chkXmitBurstAltitude.AutoSize = true;
            this.chkXmitBurstAltitude.Location = new System.Drawing.Point(41, 47);
            this.chkXmitBurstAltitude.Name = "chkXmitBurstAltitude";
            this.chkXmitBurstAltitude.Size = new System.Drawing.Size(131, 17);
            this.chkXmitBurstAltitude.TabIndex = 1;
            this.chkXmitBurstAltitude.Text = "Transmit Burst Altitude";
            this.chkXmitBurstAltitude.UseVisualStyleBackColor = true;
            this.chkXmitBurstAltitude.CheckedChanged += new System.EventHandler(this.chkXmitBurstAltitude_CheckedChanged);
            // 
            // txtStatusMessage
            // 
            this.txtStatusMessage.Location = new System.Drawing.Point(130, 21);
            this.txtStatusMessage.Name = "txtStatusMessage";
            this.txtStatusMessage.Size = new System.Drawing.Size(241, 20);
            this.txtStatusMessage.TabIndex = 0;
            this.txtStatusMessage.Leave += new System.EventHandler(this.txtStatusMessage_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(38, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 13);
            this.label27.TabIndex = 3;
            this.label27.Text = "Status Message:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkDelayXmitWithoutGPS);
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.label31);
            this.tabPage4.Controls.Add(this.chkTrackerRebootHourly);
            this.tabPage4.Controls.Add(this.label30);
            this.tabPage4.Controls.Add(this.label29);
            this.tabPage4.Controls.Add(this.chkGPSDisableDuringXmit);
            this.tabPage4.Controls.Add(this.chkRadioGlobalFreq);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.lblRadioFreqRxB);
            this.tabPage4.Controls.Add(this.lblRadioFreqTxB);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.lblRadioFreqRx);
            this.tabPage4.Controls.Add(this.lblRadioFreqTx);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.txtRadioTxDelay);
            this.tabPage4.Controls.Add(this.cmboRadioType);
            this.tabPage4.Controls.Add(this.txtRadioFreqTx);
            this.tabPage4.Controls.Add(this.txtRadioFreqRx);
            this.tabPage4.Controls.Add(this.chkRadioCourtesyTone);
            this.tabPage4.Controls.Add(this.cmboGPSType);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.cmboGPSSerialBaud);
            this.tabPage4.Controls.Add(this.chkGPSSerialInvert);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(597, 542);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tracker";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.SkyBlue;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Location = new System.Drawing.Point(334, 170);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(231, 18);
            this.label32.TabIndex = 41;
            this.label32.Text = "Avoid use for long-duration flights.";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label32.Click += new System.EventHandler(this.label32_Click);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.SkyBlue;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Location = new System.Drawing.Point(334, 431);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(231, 34);
            this.label31.TabIndex = 40;
            this.label31.Text = "Good for long-duration flights. Will affect Burst altitude on latex balloons.";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkTrackerRebootHourly
            // 
            this.chkTrackerRebootHourly.AutoSize = true;
            this.chkTrackerRebootHourly.Location = new System.Drawing.Point(51, 433);
            this.chkTrackerRebootHourly.Name = "chkTrackerRebootHourly";
            this.chkTrackerRebootHourly.Size = new System.Drawing.Size(94, 17);
            this.chkTrackerRebootHourly.TabIndex = 39;
            this.chkTrackerRebootHourly.Text = "Reboot Hourly";
            this.chkTrackerRebootHourly.UseVisualStyleBackColor = true;
            this.chkTrackerRebootHourly.CheckedChanged += new System.EventHandler(this.chkTrackerRebootHourly_CheckedChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(24, 405);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(125, 13);
            this.label30.TabIndex = 38;
            this.label30.Text = "General Tracker Settings";
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.SkyBlue;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Location = new System.Drawing.Point(334, 353);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(231, 18);
            this.label29.TabIndex = 37;
            this.label29.Text = "Useful for power-sensitive environments.";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkGPSDisableDuringXmit
            // 
            this.chkGPSDisableDuringXmit.AutoSize = true;
            this.chkGPSDisableDuringXmit.Location = new System.Drawing.Point(51, 354);
            this.chkGPSDisableDuringXmit.Name = "chkGPSDisableDuringXmit";
            this.chkGPSDisableDuringXmit.Size = new System.Drawing.Size(165, 17);
            this.chkGPSDisableDuringXmit.TabIndex = 36;
            this.chkGPSDisableDuringXmit.Text = "Power down GPS during Xmit";
            this.chkGPSDisableDuringXmit.UseVisualStyleBackColor = true;
            this.chkGPSDisableDuringXmit.CheckedChanged += new System.EventHandler(this.chkGPSDisableDuringXmit_CheckedChanged);
            // 
            // chkRadioGlobalFreq
            // 
            this.chkRadioGlobalFreq.AutoSize = true;
            this.chkRadioGlobalFreq.Location = new System.Drawing.Point(51, 99);
            this.chkRadioGlobalFreq.Margin = new System.Windows.Forms.Padding(2);
            this.chkRadioGlobalFreq.Name = "chkRadioGlobalFreq";
            this.chkRadioGlobalFreq.Size = new System.Drawing.Size(180, 17);
            this.chkRadioGlobalFreq.TabIndex = 35;
            this.chkRadioGlobalFreq.Text = "Use Global Frequency Database";
            this.chkRadioGlobalFreq.UseVisualStyleBackColor = true;
            this.chkRadioGlobalFreq.CheckedChanged += new System.EventHandler(this.chkRadioGlobalFreq_CheckedChanged);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.SkyBlue;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Location = new System.Drawing.Point(384, 72);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(181, 18);
            this.label25.TabIndex = 34;
            this.label25.Text = "Default 25.";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRadioFreqRxB
            // 
            this.lblRadioFreqRxB.AutoSize = true;
            this.lblRadioFreqRxB.Location = new System.Drawing.Point(261, 146);
            this.lblRadioFreqRxB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadioFreqRxB.Name = "lblRadioFreqRxB";
            this.lblRadioFreqRxB.Size = new System.Drawing.Size(29, 13);
            this.lblRadioFreqRxB.TabIndex = 33;
            this.lblRadioFreqRxB.Text = "MHz";
            // 
            // lblRadioFreqTxB
            // 
            this.lblRadioFreqTxB.AutoSize = true;
            this.lblRadioFreqTxB.Location = new System.Drawing.Point(261, 122);
            this.lblRadioFreqTxB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadioFreqTxB.Name = "lblRadioFreqTxB";
            this.lblRadioFreqTxB.Size = new System.Drawing.Size(29, 13);
            this.lblRadioFreqTxB.TabIndex = 32;
            this.lblRadioFreqTxB.Text = "MHz";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Enabled = false;
            this.label22.Location = new System.Drawing.Point(48, 296);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 13);
            this.label22.TabIndex = 31;
            this.label22.Text = "GPS Baud Rate:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Location = new System.Drawing.Point(48, 270);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "GPS Type:";
            // 
            // lblRadioFreqRx
            // 
            this.lblRadioFreqRx.AutoSize = true;
            this.lblRadioFreqRx.Location = new System.Drawing.Point(67, 145);
            this.lblRadioFreqRx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadioFreqRx.Name = "lblRadioFreqRx";
            this.lblRadioFreqRx.Size = new System.Drawing.Size(103, 13);
            this.lblRadioFreqRx.TabIndex = 29;
            this.lblRadioFreqRx.Text = "Receive Frequency:";
            // 
            // lblRadioFreqTx
            // 
            this.lblRadioFreqTx.AutoSize = true;
            this.lblRadioFreqTx.Location = new System.Drawing.Point(67, 122);
            this.lblRadioFreqTx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadioFreqTx.Name = "lblRadioFreqTx";
            this.lblRadioFreqTx.Size = new System.Drawing.Size(103, 13);
            this.lblRadioFreqTx.TabIndex = 28;
            this.lblRadioFreqTx.Text = "Transmit Frequency:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 77);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "TNC Tx Delay:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Location = new System.Drawing.Point(48, 53);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Transmitter Type:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "VHF Transceiver Settings";
            // 
            // txtRadioTxDelay
            // 
            this.txtRadioTxDelay.Location = new System.Drawing.Point(161, 75);
            this.txtRadioTxDelay.Margin = new System.Windows.Forms.Padding(2);
            this.txtRadioTxDelay.Name = "txtRadioTxDelay";
            this.txtRadioTxDelay.Size = new System.Drawing.Size(76, 20);
            this.txtRadioTxDelay.TabIndex = 1;
            this.txtRadioTxDelay.Leave += new System.EventHandler(this.txtRadioTxDelay_Leave);
            // 
            // cmboRadioType
            // 
            this.cmboRadioType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRadioType.Enabled = false;
            this.cmboRadioType.FormattingEnabled = true;
            this.cmboRadioType.Items.AddRange(new object[] {
            "Standard Transmitter (HX-1 or External)",
            "SA/DRA818V Module"});
            this.cmboRadioType.Location = new System.Drawing.Point(161, 50);
            this.cmboRadioType.Margin = new System.Windows.Forms.Padding(2);
            this.cmboRadioType.Name = "cmboRadioType";
            this.cmboRadioType.Size = new System.Drawing.Size(315, 21);
            this.cmboRadioType.TabIndex = 0;
            this.cmboRadioType.SelectedIndexChanged += new System.EventHandler(this.cmboRadioType_SelectedIndexChanged);
            // 
            // txtRadioFreqTx
            // 
            this.txtRadioFreqTx.Location = new System.Drawing.Point(180, 120);
            this.txtRadioFreqTx.Margin = new System.Windows.Forms.Padding(2);
            this.txtRadioFreqTx.Name = "txtRadioFreqTx";
            this.txtRadioFreqTx.Size = new System.Drawing.Size(76, 20);
            this.txtRadioFreqTx.TabIndex = 2;
            this.txtRadioFreqTx.Leave += new System.EventHandler(this.txtRadioFreqTx_Leave);
            // 
            // txtRadioFreqRx
            // 
            this.txtRadioFreqRx.Location = new System.Drawing.Point(180, 142);
            this.txtRadioFreqRx.Margin = new System.Windows.Forms.Padding(2);
            this.txtRadioFreqRx.Name = "txtRadioFreqRx";
            this.txtRadioFreqRx.Size = new System.Drawing.Size(76, 20);
            this.txtRadioFreqRx.TabIndex = 3;
            this.txtRadioFreqRx.Leave += new System.EventHandler(this.txtRadioFreqRx_Leave);
            // 
            // chkRadioCourtesyTone
            // 
            this.chkRadioCourtesyTone.AutoSize = true;
            this.chkRadioCourtesyTone.Location = new System.Drawing.Point(51, 170);
            this.chkRadioCourtesyTone.Margin = new System.Windows.Forms.Padding(2);
            this.chkRadioCourtesyTone.Name = "chkRadioCourtesyTone";
            this.chkRadioCourtesyTone.Size = new System.Drawing.Size(92, 17);
            this.chkRadioCourtesyTone.TabIndex = 4;
            this.chkRadioCourtesyTone.Text = "CourtesyTone";
            this.chkRadioCourtesyTone.UseVisualStyleBackColor = true;
            this.chkRadioCourtesyTone.CheckedChanged += new System.EventHandler(this.chkRadioCourtesyTone_CheckedChanged);
            // 
            // cmboGPSType
            // 
            this.cmboGPSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGPSType.Enabled = false;
            this.cmboGPSType.FormattingEnabled = true;
            this.cmboGPSType.Items.AddRange(new object[] {
            "Generic NMEA GPS",
            "Ublox GPS Module (ptFlex, ArduinoTrack)",
            "ATGM336H GPS Module (ptSolar)"});
            this.cmboGPSType.Location = new System.Drawing.Point(161, 267);
            this.cmboGPSType.Name = "cmboGPSType";
            this.cmboGPSType.Size = new System.Drawing.Size(202, 21);
            this.cmboGPSType.TabIndex = 5;
            this.cmboGPSType.SelectedIndexChanged += new System.EventHandler(this.cmboGPSType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SkyBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(384, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 72);
            this.label10.TabIndex = 19;
            this.label10.Text = "Default settings for tracker is uBlox GPS, 9600 baud, NOT inverted.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmboGPSSerialBaud
            // 
            this.cmboGPSSerialBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGPSSerialBaud.Enabled = false;
            this.cmboGPSSerialBaud.FormattingEnabled = true;
            this.cmboGPSSerialBaud.Items.AddRange(new object[] {
            "300",
            "1,200",
            "2,400",
            "4,800",
            "9,600",
            "19,200"});
            this.cmboGPSSerialBaud.Location = new System.Drawing.Point(161, 293);
            this.cmboGPSSerialBaud.Name = "cmboGPSSerialBaud";
            this.cmboGPSSerialBaud.Size = new System.Drawing.Size(202, 21);
            this.cmboGPSSerialBaud.TabIndex = 6;
            this.cmboGPSSerialBaud.SelectedIndexChanged += new System.EventHandler(this.cmboGPSSerialBaud_SelectedIndexChanged);
            // 
            // chkGPSSerialInvert
            // 
            this.chkGPSSerialInvert.AutoSize = true;
            this.chkGPSSerialInvert.Enabled = false;
            this.chkGPSSerialInvert.Location = new System.Drawing.Point(62, 322);
            this.chkGPSSerialInvert.Name = "chkGPSSerialInvert";
            this.chkGPSSerialInvert.Size = new System.Drawing.Size(140, 17);
            this.chkGPSSerialInvert.TabIndex = 7;
            this.chkGPSSerialInvert.Text = "Invert Serial Data Signal";
            this.chkGPSSerialInvert.UseVisualStyleBackColor = true;
            this.chkGPSSerialInvert.CheckedChanged += new System.EventHandler(this.chkGPSSerialInvert_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "GPS Serial Settings";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolReadConfig,
            this.toolWriteConfig,
            this.toolCommPort,
            this.toolRefreshCommPorts,
            this.toolStripSeparator1,
            this.toolExercise,
            this.toolTestTransmitter,
            this.toolConsole,
            this.toolStripSeparator2,
            this.toolAboutConfigurator});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolReadConfig
            // 
            this.toolReadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolReadConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolReadConfig.Image")));
            this.toolReadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReadConfig.Name = "toolReadConfig";
            this.toolReadConfig.Size = new System.Drawing.Size(24, 24);
            this.toolReadConfig.Text = "Read Config";
            this.toolReadConfig.Click += new System.EventHandler(this.toolReadConfig_Click);
            // 
            // toolWriteConfig
            // 
            this.toolWriteConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWriteConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolWriteConfig.Image")));
            this.toolWriteConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWriteConfig.Name = "toolWriteConfig";
            this.toolWriteConfig.Size = new System.Drawing.Size(24, 24);
            this.toolWriteConfig.Text = "Write Config";
            this.toolWriteConfig.Click += new System.EventHandler(this.toolWriteConfig_Click);
            // 
            // toolCommPort
            // 
            this.toolCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCommPort.Name = "toolCommPort";
            this.toolCommPort.Size = new System.Drawing.Size(200, 27);
            this.toolCommPort.Click += new System.EventHandler(this.toolCommPort_Click);
            // 
            // toolRefreshCommPorts
            // 
            this.toolRefreshCommPorts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRefreshCommPorts.Image = ((System.Drawing.Image)(resources.GetObject("toolRefreshCommPorts.Image")));
            this.toolRefreshCommPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRefreshCommPorts.Name = "toolRefreshCommPorts";
            this.toolRefreshCommPorts.Size = new System.Drawing.Size(24, 24);
            this.toolRefreshCommPorts.Text = "Refresh Comm Port List";
            this.toolRefreshCommPorts.Click += new System.EventHandler(this.toolRefreshCommPorts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolExercise
            // 
            this.toolExercise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolExercise.Image = ((System.Drawing.Image)(resources.GetObject("toolExercise.Image")));
            this.toolExercise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExercise.Name = "toolExercise";
            this.toolExercise.Size = new System.Drawing.Size(24, 24);
            this.toolExercise.Text = "Exercise the Tracker";
            this.toolExercise.ToolTipText = "Puts the Flight Controller through a set of exercises to test all functionality.";
            this.toolExercise.Click += new System.EventHandler(this.toolExercise_Click);
            // 
            // toolTestTransmitter
            // 
            this.toolTestTransmitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTestTransmitter.Image = ((System.Drawing.Image)(resources.GetObject("toolTestTransmitter.Image")));
            this.toolTestTransmitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTestTransmitter.Name = "toolTestTransmitter";
            this.toolTestTransmitter.Size = new System.Drawing.Size(24, 24);
            this.toolTestTransmitter.Text = "Test Transmitter";
            this.toolTestTransmitter.ToolTipText = "Exercise the transmitter.  Warning, the antenna connection should always be conne" +
    "cted to a propper antenna or dummy load during any transmission!";
            this.toolTestTransmitter.Click += new System.EventHandler(this.toolTestTransmitter_Click);
            // 
            // toolConsole
            // 
            this.toolConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolConsole.Image = ((System.Drawing.Image)(resources.GetObject("toolConsole.Image")));
            this.toolConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolConsole.Name = "toolConsole";
            this.toolConsole.Size = new System.Drawing.Size(24, 24);
            this.toolConsole.Text = "toolStripButton1";
            this.toolConsole.Visible = false;
            this.toolConsole.Click += new System.EventHandler(this.toolConsole_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolAboutConfigurator
            // 
            this.toolAboutConfigurator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAboutConfigurator.Image = ((System.Drawing.Image)(resources.GetObject("toolAboutConfigurator.Image")));
            this.toolAboutConfigurator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAboutConfigurator.Name = "toolAboutConfigurator";
            this.toolAboutConfigurator.Size = new System.Drawing.Size(24, 24);
            this.toolAboutConfigurator.Text = "About ptConfigurator";
            this.toolAboutConfigurator.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // timerAttn
            // 
            this.timerAttn.Enabled = true;
            this.timerAttn.Interval = 500;
            this.timerAttn.Tick += new System.EventHandler(this.timerAttn_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConfigVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 597);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusConfigVersion
            // 
            this.statusConfigVersion.Name = "statusConfigVersion";
            this.statusConfigVersion.Size = new System.Drawing.Size(152, 17);
            this.statusConfigVersion.Text = "Config Version: UNKNOWN";
            // 
            // chkDelayXmitWithoutGPS
            // 
            this.chkDelayXmitWithoutGPS.AutoSize = true;
            this.chkDelayXmitWithoutGPS.Location = new System.Drawing.Point(51, 377);
            this.chkDelayXmitWithoutGPS.Name = "chkDelayXmitWithoutGPS";
            this.chkDelayXmitWithoutGPS.Size = new System.Drawing.Size(170, 17);
            this.chkDelayXmitWithoutGPS.TabIndex = 46;
            this.chkDelayXmitWithoutGPS.Text = "Delay Transmit until GPS Lock";
            this.chkDelayXmitWithoutGPS.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.SkyBlue;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Location = new System.Drawing.Point(399, 385);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(170, 87);
            this.label34.TabIndex = 45;
            this.label34.Text = "The default GPS threshold is 3500mV, and the default transmit threshold is 4100mV" +
    ". ";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 619);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ptConfigurator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort commTracker;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolReadConfig;
        private System.Windows.Forms.ToolStripButton toolWriteConfig;
        private System.Windows.Forms.ToolStripComboBox toolCommPort;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmboPath2SSID;
        private System.Windows.Forms.ComboBox cmboPath1SSID;
        private System.Windows.Forms.ComboBox cmboDestinationSSID;
        private System.Windows.Forms.ComboBox cmboCallsignSSID;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmboSymbol;
        private System.Windows.Forms.RadioButton radBeacon0;
        private System.Windows.Forms.RadioButton radBeacon3;
        private System.Windows.Forms.RadioButton radBeacon2;
        private System.Windows.Forms.RadioButton radBeacon1;
        private System.Windows.Forms.Label lblBeacon0A;
        private System.Windows.Forms.TextBox txtBeacon0Delay;
        private System.Windows.Forms.Label lblBeacon1D;
        private System.Windows.Forms.Label lblBeacon1E;
        private System.Windows.Forms.TextBox txtBeacon1DelayMid;
        private System.Windows.Forms.Label lblBeacon1C;
        private System.Windows.Forms.TextBox txtBeacon1DelayLow;
        private System.Windows.Forms.Label lblBeacon1B;
        private System.Windows.Forms.TextBox txtBeacon1SpeedLow;
        private System.Windows.Forms.Label lblBeacon1A;
        private System.Windows.Forms.Label lblBeacon1H;
        private System.Windows.Forms.Label lblBeacon1G;
        private System.Windows.Forms.Label lblBeacon1F;
        private System.Windows.Forms.TextBox txtBeacon1DelayHigh;
        private System.Windows.Forms.TextBox txtBeacon1SpeedHigh;
        private System.Windows.Forms.Label lblBeacon2H;
        private System.Windows.Forms.Label lblBeacon2G;
        private System.Windows.Forms.Label lblBeacon2F;
        private System.Windows.Forms.Label lblBeacon2E;
        private System.Windows.Forms.Label lblBeacon2D;
        private System.Windows.Forms.Label lblBeacon2C;
        private System.Windows.Forms.Label lblBeacon2B;
        private System.Windows.Forms.Label lblBeacon2A;
        private System.Windows.Forms.TextBox txtBeacon2DelayMid;
        private System.Windows.Forms.TextBox txtBeacon2DelayLow;
        private System.Windows.Forms.TextBox txtBeacon2DelayHigh;
        private System.Windows.Forms.TextBox txtBeacon2AltitudeLow;
        private System.Windows.Forms.TextBox txtBeacon2AltitudeHigh;
        private System.Windows.Forms.TextBox txtBeacon3Slot2;
        private System.Windows.Forms.TextBox txtBeacon3Slot1;
        private System.Windows.Forms.Label lblBeacon3C;
        private System.Windows.Forms.Label lblBeacon3B;
        private System.Windows.Forms.Label lblBeacon3A;
        private System.Windows.Forms.CheckBox chkXmitAirTemp;
        private System.Windows.Forms.CheckBox chkXmitBatteryVoltage;
        private System.Windows.Forms.CheckBox chkXmitGPSQuality;
        private System.Windows.Forms.CheckBox chkXmitBurstAltitude;
        private System.Windows.Forms.TextBox txtStatusMessage;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Timer timerAttn;
        private System.Windows.Forms.ToolStripButton toolRefreshCommPorts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDisablePathAboveAltitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmboAnnouceMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkXmitAirPressure;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusConfigVersion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmboGPSType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmboGPSSerialBaud;
        private System.Windows.Forms.CheckBox chkGPSSerialInvert;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkXmitCustom;
        private System.Windows.Forms.TextBox txtRadioTxDelay;
        private System.Windows.Forms.ComboBox cmboRadioType;
        private System.Windows.Forms.TextBox txtRadioFreqTx;
        private System.Windows.Forms.TextBox txtRadioFreqRx;
        private System.Windows.Forms.CheckBox chkRadioCourtesyTone;
        private System.Windows.Forms.Label lblRadioFreqRxB;
        private System.Windows.Forms.Label lblRadioFreqTxB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblRadioFreqRx;
        private System.Windows.Forms.Label lblRadioFreqTx;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAboutConfigurator;
        private System.Windows.Forms.ToolStripButton toolExercise;
        private System.Windows.Forms.ToolStripButton toolTestTransmitter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblBeacon4A;
        private System.Windows.Forms.TextBox txtBeacon4MinDelay;
        private System.Windows.Forms.RadioButton radBeacon4;
        private System.Windows.Forms.TextBox txtBeacon4VoltThreshGPS;
        private System.Windows.Forms.Label lblBeacon4B;
        private System.Windows.Forms.Label lblBeacon4E;
        private System.Windows.Forms.TextBox txtBeacon4VoltThreshXmit;
        private System.Windows.Forms.Label lblBeacon4D;
        private System.Windows.Forms.Label lblBeacon4C;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox chkEnableBME280;
        private System.Windows.Forms.CheckBox chkRadioGlobalFreq;
        private System.Windows.Forms.ToolStripButton toolConsole;
        private System.Windows.Forms.CheckBox chkXmitSeconds;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkTrackerRebootHourly;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox chkGPSDisableDuringXmit;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox chkDelayXmitWithoutGPS;
        private System.Windows.Forms.Label label34;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ptConfigurator
{
    public partial class frmMain : Form
    {
        public string currentConfigVersion;

        public enum StatusModes
        {
            Stopped,
            GetAttnRead,
            GetAttnWrite,
            GetAttnTransmit,
            GetAttnTransmitShort,
            GetAttnWSPRTxPacketA,
            GetAttnWSPRTxPacketB,
            FindReadInfo,
            FindWritePrompt,
            ExerciseStart,
            ExerciseEnd,
            TransmitStart,
            TransmitShortStart,
            WSPRTxPacketA,
            WSPRTxPacketB,
            TransmitEnd,
            Disconnect
        };

        public struct udtTxRxStatus
        {
            public StatusModes Mode;
            public int Timeout;
        }
        public udtTxRxStatus TxRxStatus;

        private byte[] _byReceived;     //incoming byte array


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Program.writeToProgramLog("ptConfigurator Starting", "Launching the Configurator");



            List<Symbol> symbols;
            symbols = new List<Symbol>();
            symbols.Add(new Symbol("/!", "Police Department"));
            symbols.Add(new Symbol("/'", "Jet Airplane"));
            symbols.Add(new Symbol("/(", "Red Car"));
            symbols.Add(new Symbol("/*", "Snow Mobile"));
            symbols.Add(new Symbol("/.", "House"));
            symbols.Add(new Symbol("/0", "Number 0"));
            symbols.Add(new Symbol("/1", "Number 1"));
            symbols.Add(new Symbol("/2", "Number 2"));
            symbols.Add(new Symbol("/3", "Number 3"));
            symbols.Add(new Symbol("/4", "Number 4"));
            symbols.Add(new Symbol("/5", "Number 5"));
            symbols.Add(new Symbol("/6", "Number 6"));
            symbols.Add(new Symbol("/7", "Number 7"));
            symbols.Add(new Symbol("/8", "Number 8"));
            symbols.Add(new Symbol("/9", "Number 9"));
            symbols.Add(new Symbol("/:", "Fire"));
            symbols.Add(new Symbol("/;", "Tent"));
            symbols.Add(new Symbol("/<", "Motorcycle"));
            symbols.Add(new Symbol("/=", "Train"));
            symbols.Add(new Symbol("/>", "Red Car 2"));
            symbols.Add(new Symbol("/C", "Canoe"));
            symbols.Add(new Symbol("/F", "Tractor"));
            symbols.Add(new Symbol("/O", "Balloon"));
            symbols.Add(new Symbol("/P", "Blue Car"));
            symbols.Add(new Symbol("/R", "RV"));
            symbols.Add(new Symbol("/S", "Space Shuttle"));
            symbols.Add(new Symbol("/U", "Schoo Bus"));
            symbols.Add(new Symbol("/X", "Helicopter"));
            symbols.Add(new Symbol("/Y", "Sailboat"));
            symbols.Add(new Symbol("/\\", "Runner"));
            symbols.Add(new Symbol("/^", "Jet Airplane 2"));
            symbols.Add(new Symbol("/a", "Ambulance"));
            symbols.Add(new Symbol("/b", "Bicycle"));
            symbols.Add(new Symbol("/f", "Fire Truck"));
            symbols.Add(new Symbol("/g", "Hang Glider"));
            symbols.Add(new Symbol("/j", "Green Jeep"));
            symbols.Add(new Symbol("/k", "Red Truck"));
            symbols.Add(new Symbol("/s", "Boat"));
            symbols.Add(new Symbol("/u", "Semi-truck"));
            symbols.Add(new Symbol("\\-", "House with Beam"));
            symbols.Add(new Symbol("\\O", "Rocket"));
            symbols.Add(new Symbol("\\S", "Satelite"));
            symbols.Add(new Symbol("\\^", "Jet Airplane 3"));
            symbols.Add(new Symbol("\\k", "Red Bus"));
            symbols.Add(new Symbol("\\u", "Red Cargo Van"));
            symbols.Add(new Symbol("\\v", "Blue Car"));




            BindingSource bs = new BindingSource();
            bs.DataSource = symbols;

            cmboSymbol.DataSource = bs.DataSource;
            cmboSymbol.DisplayMember = "Description";
            cmboSymbol.ValueMember = "SymbolChars";

            //Populate the frequencies for WSPR Transmissions
            cmboWSPRFrequencyTx1.Items.Add("Select a Frequency");
            cmboWSPRFrequencyTx2.Items.Add("Select a Frequency");
            cmboWSPRFrequencyTx1.Items.Add("10m - 28,124,600");
            cmboWSPRFrequencyTx2.Items.Add("10m - 28,124,600");
            cmboWSPRFrequencyTx1.Items.Add("12m - 24,924,600");
            cmboWSPRFrequencyTx2.Items.Add("12m - 24,924,600");
            cmboWSPRFrequencyTx1.Items.Add("15m - 21,094,600");
            cmboWSPRFrequencyTx2.Items.Add("15m - 21,094,600");
            cmboWSPRFrequencyTx1.Items.Add("17m - 18,104,600");
            cmboWSPRFrequencyTx2.Items.Add("17m - 18,104,600");

            this.showHideBeaconOptions(0);
            Program.ATConfig.BeaconType = 0;

            enumCommPorts();
            this.TxRxStatus.Mode = StatusModes.Stopped;
            this.TxRxStatus.Timeout = 0;

            cmboTargetFreq.SelectedIndex = 2;       //default to the third item in the list, which is "30MHz"

            this.populateFields();
        }

        private string GetPortDescriptions(string PortName)
        {
            try
            {
                string query = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(" + PortName + ")%'";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject port in searcher.Get())
                    {
                        return port["Description"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                return "Unknown Port Description";
            }

            return "No Description Found";

        }
        private void enumCommPorts()
        {
            toolCommPort.Items.Clear();

            //Get the comm port name/descriptions for the comms available on this computer
            string[] strPorts = System.IO.Ports.SerialPort.GetPortNames();

            //Populate with all 50 com ports. Denote the ones that are actually alive
            for (int i = 1; i <= 50; i++)
            {
                string comName = "COM" + i.ToString();
                bool bFound = false;
                foreach (string strPort in strPorts)
                {
                    if (strPort == comName)
                    {
                        bFound = true;
                        break;
                    }
                }
                if (bFound)
                {
                    comName += " - " + this.GetPortDescriptions(comName);
                }

                toolCommPort.Items.Add(comName);
            }

            
            string savedPort = Config.LoadSetting("CommPort");
            if (!string.IsNullOrEmpty(savedPort))
            {
                for (int i = 0; i < toolCommPort.Items.Count; i++)
                {
                    if (toolCommPort.Items[i].ToString().StartsWith(savedPort))
                    {
                        toolCommPort.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void populateFields()
        {
            // --- CALLS AND PATHS TAB ---
            txtCallsign.Text = Program.ATConfig.Callsign;
            cmboSymbol.SelectedValue = Program.ATConfig.SymbolChars;
            cmboCallsignSSID.SelectedIndex = Program.ATConfig.CallsignSSID;
            txtDestination.Text = Program.ATConfig.Destination;
            cmboDestinationSSID.SelectedIndex = Program.ATConfig.DestinationSSID;
            txtPath1.Text = Program.ATConfig.Path1;
            cmboPath1SSID.SelectedIndex = Program.ATConfig.Path1SSID;
            txtPath2.Text = Program.ATConfig.Path2;
            cmboPath2SSID.SelectedIndex = Program.ATConfig.Path2SSID;
            txtDisablePathAboveAltitude.Text = Program.ATConfig.DisablePathAboveAltitude.ToString();


            // --- BEACON TAB ---

            switch (Program.ATConfig.BeaconType)
            {
                case 0:
                    radBeacon0.Checked = true;
                    break;
                case 1:
                    radBeacon1.Checked = true;
                    break;
                case 2:
                    radBeacon2.Checked = true;
                    break;
                case 3:
                    radBeacon3.Checked = true;
                    break;
                case 4:
                    radBeacon4.Checked = true;
                    break;
            }

            // Simple Delay Beacon
            txtBeacon0Delay.Text = Program.ATConfig.BeaconSimpleDelay.ToString();


            // Speed Based Beaconing
            txtBeacon1SpeedLow.Text = Program.ATConfig.BeaconSpeedThreshLow.ToString();
            txtBeacon1SpeedHigh.Text = Program.ATConfig.BeaconSpeedThreshHigh.ToString();
            txtBeacon1DelayLow.Text = Program.ATConfig.BeaconSpeedDelayLow.ToString();
            txtBeacon1DelayMid.Text = Program.ATConfig.BeaconSpeedDelayMid.ToString();
            txtBeacon1DelayHigh.Text = Program.ATConfig.BeaconSpeedDelayHigh.ToString();
            this.setSpeedLabel();


            // Altitude Based Beaconing
            txtBeacon2AltitudeLow.Text = Program.ATConfig.BeaconAltitudeThreshLow.ToString();
            txtBeacon2AltitudeHigh.Text = Program.ATConfig.BeaconAltitudeThreshHigh.ToString();
            txtBeacon2DelayLow.Text = Program.ATConfig.BeaconAltitudeDelayLow.ToString();
            txtBeacon2DelayMid.Text = Program.ATConfig.BeaconAltitudeDelayMid.ToString();
            txtBeacon2DelayHigh.Text = Program.ATConfig.BeaconAltitudeDelayHigh.ToString();
            this.setAltitudeLabel();

            // Time-slot Based Beaconing
            txtBeacon3Slot1.Text = Program.ATConfig.BeaconSlot1.ToString();
            txtBeacon3Slot2.Text = Program.ATConfig.BeaconSlot2.ToString();

            // Low Power Beaconing
            txtBeacon4MinDelay.Text = Program.ATConfig.MinTimeBetweenXmits.ToString();
            txtBeacon4VoltThreshGPS.Text = Program.ATConfig.VoltThreshGPS.ToString();
            txtBeacon4VoltThreshXmit.Text = Program.ATConfig.VoltThreshXmit.ToString();
            chkDelayXmitWithoutGPS.Checked = Program.ATConfig.DelayXmitUntilGPSFix;


            // --- TELEMETRY TAB ---
            txtStatusMessage.Text = Program.ATConfig.StatusMessage;
            chkXmitGPSQuality.Checked = Program.ATConfig.StatusXmitGPSFix;
            chkXmitBurstAltitude.Checked = Program.ATConfig.StatusXmitBurstAltitude;
            chkXmitBatteryVoltage.Checked = Program.ATConfig.StatusXmitBatteryVoltage;
            chkXmitAirTemp.Checked = Program.ATConfig.StatusXmitTemp;
            chkXmitAirPressure.Checked = Program.ATConfig.StatusXmitPressure;
            chkXmitSeconds.Checked = Program.ATConfig.StatusXmitSeconds;
            chkXmitCustom.Checked = Program.ATConfig.StatusXmitCustom;

            cmboAnnouceMode.SelectedIndex = Program.ATConfig.AnnounceMode;

            chkEnableBME280.Checked = Program.ATConfig.I2cBME280;

            // --- TRACKER TAB ---
            // Radio Settings
            cmboRadioType.SelectedIndex = Program.ATConfig.RadioType;
            txtRadioTxDelay.Text = Program.ATConfig.RadioTxDelay.ToString();
            txtRadioFreqTx.Text = Program.ATConfig.RadioFreqTx;
            txtRadioFreqRx.Text = Program.ATConfig.RadioFreqRx;
            chkRadioGlobalFreq.Checked = Program.ATConfig.UseGlobalFrequency;
            chkRadioCourtesyTone.Checked = Program.ATConfig.RadioCourtesyTone;

            // GPS Settings
            cmboGPSType.SelectedIndex = Program.ATConfig.GPSType;
            cmboGPSSerialBaud.SelectedIndex = Program.ATConfig.GPSSerialBaud - 1;
            chkGPSSerialInvert.Checked = Program.ATConfig.GPSSerialInvert;
            chkGPSDisableDuringXmit.Checked = Program.ATConfig.DisableGPSDuringXmit;
            chkTrackerRebootHourly.Checked = Program.ATConfig.HourlyReboot;


            // --- WSPR TAB ---
            txtWSPRCallsign.Text = Program.ATConfig.WSPRCallsign;
            switch (Program.ATConfig.WSPRMessageType)
            {
                case 1:
                    cmboWSPRMessageType.SelectedIndex = 0;
                    break;
                case 2:
                    cmboWSPRMessageType.SelectedIndex = 1;
                    break;
                case 129:
                    cmboWSPRMessageType.SelectedIndex = 2;
                    break; 
                case 130:
                    cmboWSPRMessageType.SelectedIndex = 3;
                    break;
                default:
                    cmboWSPRMessageType.SelectedIndex = 0;
                    break;
            }

            cmboWSPRFrequencyTx1.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx1);
            cmboWSPRFrequencyTx2.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx2);
            chkWSPRFineAltitudeModulation.Checked = Program.ATConfig.WSPRFineAltitudeModulation;

            txtWSPRToneOffset.Enabled = !Program.ATConfig.WSPRFineAltitudeModulation;       //disable the Tone Offset if the checkbox is checked
            

            txtWSPRToneOffset.Text = Program.ATConfig.WSPRToneOffset.ToString();
            //txtWSPRCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();

            switch (Program.ATConfig.WSPRTxMod)
            {
                case 2:
                    cmboWSPRTxMod.SelectedIndex = 0;
                    break;
                case 4:
                    cmboWSPRTxMod.SelectedIndex = 1;
                    break;
                case 6:
                    cmboWSPRTxMod.SelectedIndex = 2;
                    break;
                case 8:
                    cmboWSPRTxMod.SelectedIndex = 3;
                    break;
                case 10:
                    cmboWSPRTxMod.SelectedIndex = 4;
                    break;
                case 12:
                    cmboWSPRTxMod.SelectedIndex = 5;
                    break;
                case 14:
                    cmboWSPRTxMod.SelectedIndex = 6;
                    break;
                default:
                    cmboWSPRTxMod.SelectedIndex = 0;
                    break;
            }

            switch (Program.ATConfig.WSPRTxModOffset)
            {
                case 0:
                    cmboWSPRTxModOffset.SelectedIndex = 0;
                    break;
                case 2:
                    cmboWSPRTxModOffset.SelectedIndex = 1;
                    break;
                case 4:
                    cmboWSPRTxModOffset.SelectedIndex = 2;
                    break;
                case 6:
                    cmboWSPRTxModOffset.SelectedIndex = 3;
                    break;
                case 8:
                    cmboWSPRTxModOffset.SelectedIndex = 4;
                    break;
                case 10:
                    cmboWSPRTxModOffset.SelectedIndex = 5;
                    break;
                default:
                    cmboWSPRTxModOffset.SelectedIndex = 0;
                    break;

            }

            cmboWSPRAnnounceMode.SelectedIndex = Program.ATConfig.WSPRAnnounceMode;
            chkWSPRHourlyReboot.Checked = Program.ATConfig.WSPRHourlyReboot;
            txtWSPRVoltThreshGPS.Text = Program.ATConfig.WSPRVoltThreshGPS.ToString();
            txtWSPRVoltThreshXmit.Text = Program.ATConfig.WSPRVoltThreshXmit.ToString();

            // -- WSPR Calibration Tab
            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();

            // --- TAB VISIBILITY ---
            bool aprs = Program.ATConfig.IsAPRSTracker;
            bool wspr = Program.ATConfig.IsWSPRTracker;

            tabPage1.Enabled = aprs;
            tabPage2.Enabled = aprs;
            tabPage3.Enabled = aprs;
            tabPage4.Enabled = aprs;
            tabPage5.Enabled = wspr;
            tabPage6.Enabled = wspr;

            // Swap SkyBlue info-label backgrounds to muted gray when the tab is disabled
            Color aprsInfoColor = aprs ? Color.SkyBlue : Color.Silver;
            Color wsprInfoColor = wspr ? Color.SkyBlue : Color.Silver;

            // tabPage1 info labels
            label13.BackColor = aprsInfoColor;
            label12.BackColor = aprsInfoColor;
            label11.BackColor = aprsInfoColor;
            label28.BackColor = aprsInfoColor;
            // tabPage2 info labels
            label34.BackColor = aprsInfoColor;
            label14.BackColor = aprsInfoColor;
            // tabPage3 info labels
            label26.BackColor = aprsInfoColor;
            label15.BackColor = aprsInfoColor;
            // tabPage4 info labels
            label32.BackColor = aprsInfoColor;
            label31.BackColor = aprsInfoColor;
            label29.BackColor = aprsInfoColor;
            label25.BackColor = aprsInfoColor;
            label10.BackColor = aprsInfoColor;
            // tabPage5 info labels
            label20.BackColor = wsprInfoColor;

            // Redirect the selected tab if it is now disabled
            TabPage current = tabControl1.SelectedTab;
            if (aprs && (current == tabPage5 || current == tabPage6))
                tabControl1.SelectedTab = tabPage1;
            else if (wspr && (current == tabPage1 || current == tabPage2 || current == tabPage3 || current == tabPage4))
                tabControl1.SelectedTab = tabPage5;

        }

        private int getIndexOfFrequency(double targetFreq)
        {
            int iIndex = 0;
            for (int i = 1; i < cmboWSPRFrequencyTx1.Items.Count; i++)
            {
                //Get the last 8 characters of the string and see if it matches the frequency we're looking for
                string strItem = cmboWSPRFrequencyTx1.Items[i].ToString().Trim();

                double itemFreq = 0;
                try
                {
                    //Split this string on the '-' character and try to convert the second part to a float. If it matches the frequency we're looking for, return this index
                    itemFreq = Convert.ToSingle(strItem.Substring(strItem.IndexOf("-") + 1).Trim());  //Convert to intger and compare to the frequency we're looking for
                    itemFreq = itemFreq / 1000000; //convert to MHz
                }
                catch { }
                if (itemFreq == targetFreq)
                {
                    iIndex = i;
                    break;
                }
            }
            return iIndex;
        }

        private void setSpeedLabel()
        {
            lblBeacon1D.Text = "Between " + Program.ATConfig.BeaconSpeedThreshLow.ToString()
                + " knots and " + Program.ATConfig.BeaconSpeedThreshHigh.ToString()
                + " knots, transmit every";
        }
        private void setAltitudeLabel()
        {
            lblBeacon2D.Text = "Between " + Program.ATConfig.BeaconAltitudeThreshLow.ToString()
                + " meters and " + Program.ATConfig.BeaconAltitudeThreshHigh.ToString()
                + " meters, transmit every";
        }

        private void radBeacon0_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(0);
            Program.ATConfig.BeaconType = 0;
            CheckWarning();
        }

        private void showHideBeaconOptions(int iBeaconTypes)
        {
            switch (iBeaconTypes)
            {
                case 0:
                    txtBeacon0Delay.Enabled = true;
                    lblBeacon0A.Enabled = true;

                    txtBeacon1SpeedLow.Enabled = false;
                    txtBeacon1SpeedHigh.Enabled = false;
                    txtBeacon1DelayLow.Enabled = false;
                    txtBeacon1DelayMid.Enabled = false;
                    txtBeacon1DelayHigh.Enabled = false;
                    lblBeacon1A.Enabled = false;
                    lblBeacon1B.Enabled = false;
                    lblBeacon1C.Enabled = false;
                    lblBeacon1D.Enabled = false;
                    lblBeacon1E.Enabled = false;
                    lblBeacon1F.Enabled = false;
                    lblBeacon1G.Enabled = false;
                    lblBeacon1H.Enabled = false;

                    txtBeacon2AltitudeLow.Enabled = false;
                    txtBeacon2AltitudeHigh.Enabled = false;
                    txtBeacon2DelayLow.Enabled = false;
                    txtBeacon2DelayMid.Enabled = false;
                    txtBeacon2DelayHigh.Enabled = false;
                    lblBeacon2A.Enabled = false;
                    lblBeacon2B.Enabled = false;
                    lblBeacon2C.Enabled = false;
                    lblBeacon2D.Enabled = false;
                    lblBeacon2E.Enabled = false;
                    lblBeacon2F.Enabled = false;
                    lblBeacon2G.Enabled = false;
                    lblBeacon2H.Enabled = false;

                    txtBeacon3Slot1.Enabled = false;
                    txtBeacon3Slot2.Enabled = false;
                    lblBeacon3A.Enabled = false;
                    lblBeacon3B.Enabled = false;
                    lblBeacon3C.Enabled = false;

                    txtBeacon4MinDelay.Enabled = false;
                    txtBeacon4VoltThreshGPS.Enabled = false;
                    txtBeacon4VoltThreshXmit.Enabled = false;
                    lblBeacon4A.Enabled = false;
                    lblBeacon4B.Enabled = false;
                    lblBeacon4C.Enabled = false;
                    lblBeacon4D.Enabled = false;
                    lblBeacon4E.Enabled = false;
                    break;
                case 1:
                    txtBeacon0Delay.Enabled = false;
                    lblBeacon0A.Enabled = false;

                    txtBeacon1SpeedLow.Enabled = true;
                    txtBeacon1SpeedHigh.Enabled = true;
                    txtBeacon1DelayLow.Enabled = true;
                    txtBeacon1DelayMid.Enabled = true;
                    txtBeacon1DelayHigh.Enabled = true;
                    lblBeacon1A.Enabled = true;
                    lblBeacon1B.Enabled = true;
                    lblBeacon1C.Enabled = true;
                    lblBeacon1D.Enabled = true;
                    lblBeacon1E.Enabled = true;
                    lblBeacon1F.Enabled = true;
                    lblBeacon1G.Enabled = true;
                    lblBeacon1H.Enabled = true;

                    txtBeacon2AltitudeLow.Enabled = false;
                    txtBeacon2AltitudeHigh.Enabled = false;
                    txtBeacon2DelayLow.Enabled = false;
                    txtBeacon2DelayMid.Enabled = false;
                    txtBeacon2DelayHigh.Enabled = false;
                    lblBeacon2A.Enabled = false;
                    lblBeacon2B.Enabled = false;
                    lblBeacon2C.Enabled = false;
                    lblBeacon2D.Enabled = false;
                    lblBeacon2E.Enabled = false;
                    lblBeacon2F.Enabled = false;
                    lblBeacon2G.Enabled = false;
                    lblBeacon2H.Enabled = false;

                    txtBeacon3Slot1.Enabled = false;
                    txtBeacon3Slot2.Enabled = false;
                    lblBeacon3A.Enabled = false;
                    lblBeacon3B.Enabled = false;
                    lblBeacon3C.Enabled = false;

                    txtBeacon4MinDelay.Enabled = false;
                    txtBeacon4VoltThreshGPS.Enabled = false;
                    txtBeacon4VoltThreshXmit.Enabled = false;
                    lblBeacon4A.Enabled = false;
                    lblBeacon4B.Enabled = false;
                    lblBeacon4C.Enabled = false;
                    lblBeacon4D.Enabled = false;
                    lblBeacon4E.Enabled = false;
                    break;
                case 2:
                    txtBeacon0Delay.Enabled = false;
                    lblBeacon0A.Enabled = false;

                    txtBeacon1SpeedLow.Enabled = false;
                    txtBeacon1SpeedHigh.Enabled = false;
                    txtBeacon1DelayLow.Enabled = false;
                    txtBeacon1DelayMid.Enabled = false;
                    txtBeacon1DelayHigh.Enabled = false;
                    lblBeacon1A.Enabled = false;
                    lblBeacon1B.Enabled = false;
                    lblBeacon1C.Enabled = false;
                    lblBeacon1D.Enabled = false;
                    lblBeacon1E.Enabled = false;
                    lblBeacon1F.Enabled = false;
                    lblBeacon1G.Enabled = false;
                    lblBeacon1H.Enabled = false;

                    txtBeacon2AltitudeLow.Enabled = true;
                    txtBeacon2AltitudeHigh.Enabled = true;
                    txtBeacon2DelayLow.Enabled = true;
                    txtBeacon2DelayMid.Enabled = true;
                    txtBeacon2DelayHigh.Enabled = true;
                    lblBeacon2A.Enabled = true;
                    lblBeacon2B.Enabled = true;
                    lblBeacon2C.Enabled = true;
                    lblBeacon2D.Enabled = true;
                    lblBeacon2E.Enabled = true;
                    lblBeacon2F.Enabled = true;
                    lblBeacon2G.Enabled = true;
                    lblBeacon2H.Enabled = true;

                    txtBeacon3Slot1.Enabled = false;
                    txtBeacon3Slot2.Enabled = false;
                    lblBeacon3A.Enabled = false;
                    lblBeacon3B.Enabled = false;
                    lblBeacon3C.Enabled = false;

                    txtBeacon4MinDelay.Enabled = false;
                    txtBeacon4VoltThreshGPS.Enabled = false;
                    txtBeacon4VoltThreshXmit.Enabled = false;
                    lblBeacon4A.Enabled = false;
                    lblBeacon4B.Enabled = false;
                    lblBeacon4C.Enabled = false;
                    lblBeacon4D.Enabled = false;
                    lblBeacon4E.Enabled = false;
                    break;
                case 3:
                    txtBeacon0Delay.Enabled = false;
                    lblBeacon0A.Enabled = false;

                    txtBeacon1SpeedLow.Enabled = false;
                    txtBeacon1SpeedHigh.Enabled = false;
                    txtBeacon1DelayLow.Enabled = false;
                    txtBeacon1DelayMid.Enabled = false;
                    txtBeacon1DelayHigh.Enabled = false;
                    lblBeacon1A.Enabled = false;
                    lblBeacon1B.Enabled = false;
                    lblBeacon1C.Enabled = false;
                    lblBeacon1D.Enabled = false;
                    lblBeacon1E.Enabled = false;
                    lblBeacon1F.Enabled = false;
                    lblBeacon1G.Enabled = false;
                    lblBeacon1H.Enabled = false;

                    txtBeacon2AltitudeLow.Enabled = false;
                    txtBeacon2AltitudeHigh.Enabled = false;
                    txtBeacon2DelayLow.Enabled = false;
                    txtBeacon2DelayMid.Enabled = false;
                    txtBeacon2DelayHigh.Enabled = false;
                    lblBeacon2A.Enabled = false;
                    lblBeacon2B.Enabled = false;
                    lblBeacon2C.Enabled = false;
                    lblBeacon2D.Enabled = false;
                    lblBeacon2E.Enabled = false;
                    lblBeacon2F.Enabled = false;
                    lblBeacon2G.Enabled = false;
                    lblBeacon2H.Enabled = false;

                    txtBeacon3Slot1.Enabled = true;
                    txtBeacon3Slot2.Enabled = true;
                    lblBeacon3A.Enabled = true;
                    lblBeacon3B.Enabled = true;
                    lblBeacon3C.Enabled = true;

                    txtBeacon4MinDelay.Enabled = false;
                    txtBeacon4VoltThreshGPS.Enabled = false;
                    txtBeacon4VoltThreshXmit.Enabled = false;
                    lblBeacon4A.Enabled = false;
                    lblBeacon4B.Enabled = false;
                    lblBeacon4C.Enabled = false;
                    lblBeacon4D.Enabled = false;
                    lblBeacon4E.Enabled = false;
                    break;
                case 4:
                    txtBeacon0Delay.Enabled = false;
                    lblBeacon0A.Enabled = false;

                    txtBeacon1SpeedLow.Enabled = false;
                    txtBeacon1SpeedHigh.Enabled = false;
                    txtBeacon1DelayLow.Enabled = false;
                    txtBeacon1DelayMid.Enabled = false;
                    txtBeacon1DelayHigh.Enabled = false;
                    lblBeacon1A.Enabled = false;
                    lblBeacon1B.Enabled = false;
                    lblBeacon1C.Enabled = false;
                    lblBeacon1D.Enabled = false;
                    lblBeacon1E.Enabled = false;
                    lblBeacon1F.Enabled = false;
                    lblBeacon1G.Enabled = false;
                    lblBeacon1H.Enabled = false;

                    txtBeacon2AltitudeLow.Enabled = false;
                    txtBeacon2AltitudeHigh.Enabled = false;
                    txtBeacon2DelayLow.Enabled = false;
                    txtBeacon2DelayMid.Enabled = false;
                    txtBeacon2DelayHigh.Enabled = false;
                    lblBeacon2A.Enabled = false;
                    lblBeacon2B.Enabled = false;
                    lblBeacon2C.Enabled = false;
                    lblBeacon2D.Enabled = false;
                    lblBeacon2E.Enabled = false;
                    lblBeacon2F.Enabled = false;
                    lblBeacon2G.Enabled = false;
                    lblBeacon2H.Enabled = false;

                    txtBeacon3Slot1.Enabled = false;
                    txtBeacon3Slot2.Enabled = false;
                    lblBeacon3A.Enabled = false;
                    lblBeacon3B.Enabled = false;
                    lblBeacon3C.Enabled = false;

                    txtBeacon4MinDelay.Enabled = true;
                    txtBeacon4VoltThreshGPS.Enabled = true;
                    txtBeacon4VoltThreshXmit.Enabled = true;
                    lblBeacon4A.Enabled = true;
                    lblBeacon4B.Enabled = true;
                    lblBeacon4C.Enabled = true;
                    lblBeacon4D.Enabled = true;
                    lblBeacon4E.Enabled = true;

                    break;
            }
        }

        private void radBeacon1_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(1);
            Program.ATConfig.BeaconType = 1;
            CheckWarning();
        }

        private void radBeacon3_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(3);
            Program.ATConfig.BeaconType = 3;
            CheckWarning();
        }

        private void radBeacon2_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(2);
            Program.ATConfig.BeaconType = 2;
            CheckWarning();
        }

        private void txtCallsign_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboCallsignSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.CallsignSSID = cmboCallsignSSID.SelectedIndex;
            CheckWarning();
        }

        private void txtDestination_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboDestinationSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.DestinationSSID = cmboDestinationSSID.SelectedIndex;
            CheckWarning();
        }

        private void txtPath1_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboPath1SSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.Path1SSID = cmboPath1SSID.SelectedIndex;
            CheckWarning();
        }

        private void txtPath2_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboPath2SSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.Path2SSID = cmboPath2SSID.SelectedIndex;
            CheckWarning();
        }

        private void txtBeacon0Delay_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon1SpeedLow_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon1DelayLow_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon1DelayMid_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon1DelayHigh_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon1SpeedHigh_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon2AltitudeLow_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon2AltitudeHigh_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon2DelayLow_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon2DelayMid_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon2DelayHigh_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon3Slot1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBeacon3Slot2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCallsign_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Callsign = txtCallsign.Text;
            txtCallsign.Text = Program.ATConfig.Callsign;
            CheckWarning();
        }

        private void txtDestination_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Destination = txtDestination.Text;
            txtDestination.Text = Program.ATConfig.Destination;
            CheckWarning();
        }

        private void txtPath1_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Path1 = txtPath1.Text;
            txtPath1.Text = Program.ATConfig.Path1;
            CheckWarning();
        }

        private void txtPath2_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Path2 = txtPath2.Text;
            txtPath2.Text = Program.ATConfig.Path2;
            CheckWarning();
        }

        private void txtBeacon0Delay_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.BeaconSimpleDelay = Convert.ToInt16(txtBeacon0Delay.Text);
            }
            catch { }
            txtBeacon0Delay.Text = Program.ATConfig.BeaconSimpleDelay.ToString();
            CheckWarning();
        }

        private void txtBeacon1SpeedLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedThreshLow = Convert.ToInt16(txtBeacon1SpeedLow.Text); }
            catch { }

            txtBeacon1SpeedLow.Text = Program.ATConfig.BeaconSpeedThreshLow.ToString();
            this.setSpeedLabel();
            CheckWarning();
        }

        private void txtBeacon1DelayLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayLow = Convert.ToInt16(txtBeacon1DelayLow.Text); }
            catch { }

            txtBeacon1DelayLow.Text = Program.ATConfig.BeaconSpeedDelayLow.ToString();
            CheckWarning();
        }

        private void txtBeacon1DelayMid_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayMid = Convert.ToInt16(txtBeacon1DelayMid.Text); }
            catch { }

            txtBeacon1DelayMid.Text = Program.ATConfig.BeaconSpeedDelayMid.ToString();
            CheckWarning();
        }

        private void txtBeacon1DelayHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayHigh = Convert.ToInt16(txtBeacon1DelayHigh.Text); }
            catch { }

            txtBeacon1DelayHigh.Text = Program.ATConfig.BeaconSpeedDelayHigh.ToString();
            CheckWarning();
        }

        private void txtBeacon1SpeedHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedThreshHigh = Convert.ToInt16(txtBeacon1SpeedHigh.Text); }
            catch { }

            txtBeacon1SpeedHigh.Text = Program.ATConfig.BeaconSpeedThreshHigh.ToString();
            this.setSpeedLabel();
            CheckWarning();
        }

        private void txtBeacon2AltitudeLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeThreshLow = Convert.ToInt16(txtBeacon2AltitudeLow.Text); }
            catch { }

            txtBeacon2AltitudeLow.Text = Program.ATConfig.BeaconAltitudeThreshLow.ToString();
            this.setAltitudeLabel();
            CheckWarning();
        }

        private void txtBeacon2AltitudeHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeThreshHigh = Convert.ToInt16(txtBeacon2AltitudeHigh.Text); }
            catch { }

            txtBeacon2AltitudeHigh.Text = Program.ATConfig.BeaconAltitudeThreshHigh.ToString();
            this.setAltitudeLabel();
            CheckWarning();
        }

        private void txtBeacon2DelayLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayLow = Convert.ToInt16(txtBeacon2DelayLow.Text); }
            catch { }

            txtBeacon2DelayLow.Text = Program.ATConfig.BeaconAltitudeDelayLow.ToString();
            CheckWarning();
        }

        private void txtBeacon2DelayMid_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayMid = Convert.ToInt16(txtBeacon2DelayMid.Text); }
            catch { }

            txtBeacon2DelayMid.Text = Program.ATConfig.BeaconAltitudeDelayMid.ToString();
            CheckWarning();
        }

        private void txtBeacon2DelayHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayHigh = Convert.ToInt16(txtBeacon2DelayHigh.Text); }
            catch { }

            txtBeacon2DelayHigh.Text = Program.ATConfig.BeaconAltitudeDelayHigh.ToString();
            CheckWarning();
        }

        private void txtBeacon3Slot1_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSlot1 = Convert.ToInt16(txtBeacon3Slot1.Text); }
            catch { }

            txtBeacon3Slot1.Text = Program.ATConfig.BeaconSlot1.ToString();
            CheckWarning();
        }

        private void txtBeacon3Slot2_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSlot2 = Convert.ToInt16(txtBeacon3Slot2.Text); }
            catch { }

            txtBeacon3Slot2.Text = Program.ATConfig.BeaconSlot2.ToString();
            CheckWarning();
        }

        private void txtStatusMessage_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.StatusMessage = txtStatusMessage.Text;
            txtStatusMessage.Text = Program.ATConfig.StatusMessage;
            CheckWarning();
        }



        private void toolWriteConfig_Click(object sender, EventArgs e)
        {
            //make sure that all of the fields have been updated into the configuraiton object

            // --- CALLS AND PATHS TAB ---
            Program.ATConfig.Callsign = txtCallsign.Text;
            txtCallsign.Text = Program.ATConfig.Callsign;

            Program.ATConfig.Destination = txtDestination.Text;
            txtDestination.Text = Program.ATConfig.Destination;

            Program.ATConfig.Path1 = txtPath1.Text;
            txtPath1.Text = txtPath1.Text;

            Program.ATConfig.Path2 = txtPath2.Text;
            txtPath2.Text = Program.ATConfig.Path2;

            try
            {
                Program.ATConfig.DisablePathAboveAltitude = Convert.ToInt16(txtDisablePathAboveAltitude.Text);
            }
            catch { }
            txtDisablePathAboveAltitude.Text = Program.ATConfig.DisablePathAboveAltitude.ToString();

            // --- BEACONING TAB ---
            try
            {
                Program.ATConfig.BeaconSimpleDelay = Convert.ToInt16(txtBeacon0Delay.Text);
            }
            catch { }
            txtBeacon0Delay.Text = Program.ATConfig.BeaconSimpleDelay.ToString();

            // speed-based beaconing
            try
            {
                Program.ATConfig.BeaconSpeedThreshLow = Convert.ToInt16(txtBeacon1SpeedLow.Text);
            }
            catch { }
            txtBeacon1SpeedLow.Text = Program.ATConfig.BeaconSpeedThreshLow.ToString();

            try
            {
                Program.ATConfig.BeaconSpeedDelayLow = Convert.ToInt16(txtBeacon1DelayLow.Text);
            }
            catch { }
            txtBeacon1DelayLow.Text = Program.ATConfig.BeaconSpeedDelayLow.ToString();

            try
            {
                Program.ATConfig.BeaconSpeedDelayMid = Convert.ToInt16(txtBeacon1DelayMid.Text);
            }
            catch { }
            txtBeacon1DelayMid.Text = Program.ATConfig.BeaconSpeedDelayMid.ToString();

            try
            {
                Program.ATConfig.BeaconSpeedThreshHigh = Convert.ToInt16(txtBeacon1SpeedHigh.Text);
            }
            catch { }
            txtBeacon1SpeedHigh.Text = Program.ATConfig.BeaconSpeedThreshHigh.ToString();

            try
            {
                Program.ATConfig.BeaconSpeedDelayHigh = Convert.ToInt16(txtBeacon1DelayHigh.Text);
            }
            catch { }
            txtBeacon1DelayHigh.Text = Program.ATConfig.BeaconSpeedDelayHigh.ToString();



            // altitude-based beaconing
            try
            {
                Program.ATConfig.BeaconAltitudeThreshLow = Convert.ToInt16(txtBeacon2AltitudeLow.Text);
            }
            catch { }
            txtBeacon2AltitudeLow.Text = Program.ATConfig.BeaconAltitudeThreshLow.ToString();

            try
            {
                Program.ATConfig.BeaconAltitudeDelayLow = Convert.ToInt16(txtBeacon2DelayLow.Text);
            }
            catch { }
            txtBeacon2DelayLow.Text = Program.ATConfig.BeaconAltitudeDelayLow.ToString();

            try
            {
                Program.ATConfig.BeaconAltitudeDelayMid = Convert.ToInt16(txtBeacon2DelayMid.Text);
            }
            catch { }
            txtBeacon2DelayMid.Text = Program.ATConfig.BeaconAltitudeDelayMid.ToString();

            try
            {
                Program.ATConfig.BeaconAltitudeThreshHigh = Convert.ToInt16(txtBeacon2AltitudeHigh.Text);
            }
            catch { }
            txtBeacon2AltitudeHigh.Text = Program.ATConfig.BeaconAltitudeThreshHigh.ToString();

            try
            {
                Program.ATConfig.BeaconAltitudeDelayHigh = Convert.ToInt16(txtBeacon2DelayHigh.Text);
            }
            catch { }
            txtBeacon2DelayHigh.Text = Program.ATConfig.BeaconAltitudeDelayHigh.ToString();

            // time-slots
            try
            {
                Program.ATConfig.BeaconSlot1 = Convert.ToInt16(txtBeacon3Slot1.Text);
            }
            catch { }
            txtBeacon3Slot1.Text = Program.ATConfig.BeaconSlot1.ToString();

            try
            {
                Program.ATConfig.BeaconSlot2 = Convert.ToInt16(txtBeacon3Slot2.Text);
            }
            catch { }
            txtBeacon3Slot2.Text = Program.ATConfig.BeaconSlot2.ToString();

            // Low Power Beacons
            try
            {
                Program.ATConfig.MinTimeBetweenXmits = Convert.ToInt16(txtBeacon4MinDelay.Text);
            }
            catch { }
            txtBeacon4MinDelay.Text = Program.ATConfig.MinTimeBetweenXmits.ToString();

            try
            {
                Program.ATConfig.VoltThreshGPS = Convert.ToInt16(txtBeacon4VoltThreshGPS.Text);
            }
            catch { }
            txtBeacon4VoltThreshGPS.Text = Program.ATConfig.VoltThreshGPS.ToString();

            try
            {
                Program.ATConfig.VoltThreshXmit = Convert.ToInt16(txtBeacon4VoltThreshXmit.Text);
            }
            catch { }
            txtBeacon4VoltThreshXmit.Text = Program.ATConfig.VoltThreshXmit.ToString();




            // --- TELEMETRY TAB ---
            Program.ATConfig.StatusMessage = txtStatusMessage.Text;
            txtStatusMessage.Text = Program.ATConfig.StatusMessage;


            // --- TRACKER TAB ---
            try
            {
                Program.ATConfig.RadioTxDelay = Convert.ToInt16(txtRadioTxDelay.Text);
            }
            catch { }
            txtRadioTxDelay.Text = Program.ATConfig.RadioTxDelay.ToString();

            Program.ATConfig.RadioFreqTx = txtRadioFreqTx.Text;
            txtRadioFreqTx.Text = Program.ATConfig.RadioFreqTx;

            Program.ATConfig.RadioFreqRx = txtRadioFreqRx.Text;
            txtRadioFreqRx.Text = Program.ATConfig.RadioFreqRx;



            // --- WSPR TAB ---
            Program.ATConfig.WSPRCallsign = txtWSPRCallsign.Text;
            txtWSPRCallsign.Text = Program.ATConfig.WSPRCallsign;

            switch (cmboWSPRMessageType.SelectedIndex)
            {
                case 0:
                    Program.ATConfig.WSPRMessageType = 1;
                    break;
                case 1:
                    Program.ATConfig.WSPRMessageType = 2;
                    break;
                case 2:
                    Program.ATConfig.WSPRMessageType = 129;
                    break;
                case 3:
                    Program.ATConfig.WSPRMessageType = 130;
                    break;
                default:
                    Program.ATConfig.WSPRMessageType = 2;
                    break;
            }

            try
            {
                string strFreq = cmboWSPRFrequencyTx1.SelectedItem.ToString();
                strFreq = strFreq.Substring(strFreq.IndexOf("-") + 1).Trim();
                double freq = Convert.ToDouble(strFreq);
                freq = freq / 1000000; //convert to MHz

                Program.ATConfig.WSPRFrequencyTx1 = Convert.ToDouble(freq);
            }
            catch { }
            cmboWSPRFrequencyTx1.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx1);

            try
            {
                string strFreq = cmboWSPRFrequencyTx2.SelectedItem.ToString();
                strFreq = strFreq.Substring(strFreq.IndexOf("-") + 1).Trim();
                double freq = Convert.ToDouble(strFreq);
                freq = freq / 1000000; //convert to MHz

                Program.ATConfig.WSPRFrequencyTx2 = Convert.ToDouble(freq);
            }
            catch { }
            cmboWSPRFrequencyTx2.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx2);

            try
            {
                Program.ATConfig.WSPRToneOffset = Convert.ToInt16(txtWSPRToneOffset.Text);
            }
            catch { }
            txtWSPRToneOffset.Text = Program.ATConfig.WSPRToneOffset.ToString();

            //try
            //{
            //    Program.ATConfig.WSPRCorrection = Convert.ToInt32(txtWSPRCorrection.Text);
            //}
            //catch { }
            //txtWSPRCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();

            switch (cmboWSPRTxMod.SelectedIndex)
            {
                case 0:
                    Program.ATConfig.WSPRTxMod = 2;
                    break;
                case 1:
                    Program.ATConfig.WSPRTxMod = 4;
                    break;
                case 2:
                    Program.ATConfig.WSPRTxMod = 6;
                    break;
                case 3:
                    Program.ATConfig.WSPRTxMod = 8;
                    break;
                case 4:
                    Program.ATConfig.WSPRTxMod = 10;
                    break;
                case 5:
                    Program.ATConfig.WSPRTxMod = 12;
                    break;
                case 6:
                    Program.ATConfig.WSPRTxMod = 14;
                    break;
                default:
                    Program.ATConfig.WSPRTxMod = 2;
                    break;
            }

            switch (cmboWSPRTxModOffset.SelectedIndex)
            {
                case 0:
                    Program.ATConfig.WSPRTxModOffset = 0;
                    break;
                case 1:
                    Program.ATConfig.WSPRTxModOffset = 2;
                    break;
                case 2:
                    Program.ATConfig.WSPRTxModOffset = 4;
                    break;
                case 3:
                    Program.ATConfig.WSPRTxModOffset = 6;
                    break;
                case 4:
                    Program.ATConfig.WSPRTxModOffset = 8;
                    break;
                case 5:
                    Program.ATConfig.WSPRTxModOffset = 10;
                    break;
                default:
                    Program.ATConfig.WSPRTxModOffset = 0;
                    break;
            }


            Program.ATConfig.WSPRAnnounceMode = cmboWSPRAnnounceMode.SelectedIndex;

            Program.ATConfig.WSPRHourlyReboot = chkWSPRHourlyReboot.Checked;

            try
            {
                Program.ATConfig.WSPRVoltThreshGPS = Convert.ToInt16(txtWSPRVoltThreshGPS.Text);
            }
            catch { }
            txtWSPRVoltThreshGPS.Text = Program.ATConfig.WSPRVoltThreshGPS.ToString();

            try
            {
                Program.ATConfig.WSPRVoltThreshXmit = Convert.ToInt16(txtWSPRVoltThreshXmit.Text);
            }
            catch { }
            txtWSPRVoltThreshXmit.Text = Program.ATConfig.WSPRVoltThreshXmit.ToString();


            // -- WSPR Calibration Tab ---
            try
            {
                Program.ATConfig.WSPRCorrection = Convert.ToInt32(txtFreqCorrection.Text);
            }
            catch { }
            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();



            // Check for a valid comm port
            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                ShowNoCommPortSelectedError();

                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnWrite;
                this.TxRxStatus.Timeout = 20;           //get it 20 cycles to get the attention
            }
            else
            {
                //there was a problem opening the comm port
                ShowCommPortOpenError();
            }
        }



        frmConnect ConnectForm;
        //public Action ReadCompleteCallback;

        private void toolReadConfig_Click(object sender, EventArgs e)
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                ShowNoCommPortSelectedError();

                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnRead;
                this.TxRxStatus.Timeout = 20;       //wait 20 half-second cycles before giving up
            }
            else
            {
                //there was a problem opening the comm port
                ShowCommPortOpenError();
            }

        }

        private bool openCommPort()
        {
            if (!commTracker.IsOpen)
            {
                //configure the settings
                commTracker.BaudRate = 19200;
                //commTracker.DataBits = 8;
                //commTracker.Parity = System.IO.Ports.Parity.None;
                //commTracker.ReadBufferSize = 4096;
                //commTracker.ReadTimeout = -1;
                //commTracker.ReadBufferSize = 1;
                //commTracker.WriteBufferSize = 2048;
                //commTracker.WriteTimeout = -1;
                //commTracker.Handshake = System.IO.Ports.Handshake.None;


                //determine the comm port that is selected
                string strTemp = "";
                try
                {
                    strTemp = toolCommPort.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    //no port selected
                    ShowNoCommPortSelectedError();
                    return false;
                }

                string strCommNumber = Regex.Replace(strTemp, @"\D", "");
                Console.WriteLine("Comm port selected in dropdown: {0}", strCommNumber);

                commTracker.PortName = "COM" + strCommNumber;


                try
                {
                    commTracker.Open();     //open the comm port
                }
                catch (Exception)
                {
                    return false;
                }

                if (commTracker.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }


        private void commTracker_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {



        }

        private void rxBufferAppend(byte[] byIncoming)
        {


            byte[] byTemp;
            int iOldSize = 0;

            if (_byReceived == null)
            {
                //hasn't been initialized yet

                _byReceived = new byte[byIncoming.Length];
            }
            else
            {
                byTemp = _byReceived;
                iOldSize = _byReceived.Length;
                Array.Resize(ref _byReceived, _byReceived.Length + byIncoming.Length);
                Array.Copy(byTemp, _byReceived, byTemp.Length);

            }


            //concat the incoming data with the existing buffer
            for (int i = iOldSize; i < _byReceived.Length; i++)
            {
                _byReceived[i] = byIncoming[i - iOldSize];
            }

            string strBuffer = Encoding.ASCII.GetString(_byReceived, 0, _byReceived.Length);
            Console.WriteLine(strBuffer);



        }



        private void timerAttn_Tick(object sender, EventArgs e)
        {
            //Go read in the most current comm data
            if (commTracker.IsOpen)
            {
                byte[] buffer = new byte[commTracker.BytesToRead];

                //There is no accurate method for checking how many bytes are read 
                //unless you check the return from the Read method 
                int bytesRead = commTracker.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string strOutput = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                    Program.writeToProgramLog("Timer Tick", strOutput);
                    this.rxBufferAppend(buffer);        //append this new data to the buffer
                }
            }



            switch (TxRxStatus.Mode)
            {
                case StatusModes.GetAttnRead:
                    Console.WriteLine("GetAttnRead:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        sendToArduino("!");


                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            sendToArduino("R");         //request the current configuration


                            TxRxStatus.Mode = StatusModes.FindReadInfo;
                            TxRxStatus.Timeout = 6;         //we have four ticks to get the config data (2 is not enough)

                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;
                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();

                    }

                    break;
                case StatusModes.GetAttnWrite:
                    //same as GetAttnRead, except drops to FindWritePrompt when complete

                    Console.WriteLine("GetAttnWrite:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        sendToArduino("!");         //send ! to get the tracker's attention


                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            sendToArduino("W");         //request to write a new config

                            TxRxStatus.Mode = StatusModes.FindWritePrompt;
                            TxRxStatus.Timeout = 4;         //we have four ticks to get the prompt

                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;

                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();

                    }

                    break;
                case StatusModes.GetAttnTransmit:
                    Console.WriteLine("GetAttnTransmit:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        sendToArduino("!");         //send ! to get the tracker's attention

                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            TxRxStatus.Mode = StatusModes.TransmitStart;
                            TxRxStatus.Timeout = 4;
                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;

                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();
                    }

                    break;
                case StatusModes.GetAttnTransmitShort:
                    Console.WriteLine("GetAttnTransmitShort:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        sendToArduino("!");         //send ! to get the tracker's attention

                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            TxRxStatus.Mode = StatusModes.TransmitShortStart;
                            TxRxStatus.Timeout = 4;
                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;

                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();
                    }

                    break;
                case StatusModes.GetAttnWSPRTxPacketA:

                    Console.WriteLine("GetAttnWSPRTxPacketA:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;
                        sendToArduino("!");         //send ! to get the tracker's attention
                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            TxRxStatus.Mode = StatusModes.WSPRTxPacketA;        //we have the attention, now transmit packet A
                            TxRxStatus.Timeout = 4;
                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;
                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();
                    }
                    break;
                case StatusModes.GetAttnWSPRTxPacketB:
                    Console.WriteLine("GetAttnWSPRTxPacketB:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;
                        sendToArduino("!");         //send ! to get the tracker's attention
                        //look for the # prompt
                        if (this.findNeedle(new byte[] { 0x0a, 0x23, 0x20 }))
                        {
                            TxRxStatus.Mode = StatusModes.WSPRTxPacketB;        //we have the attention, now transmit packet B
                            TxRxStatus.Timeout = 4;
                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;
                        ConnectForm.Close();
                        ShowConfigModeTimeoutError();
                    }
                    break;
                case StatusModes.FindReadInfo:
                    Console.WriteLine("FindReadInfo:");

                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        byte[] byConfig = this.extractConfigFromBuffer();

                        if (byConfig != null)
                        {
                            //we got a config - parse it out!

                            string strBuffer = Encoding.ASCII.GetString(byConfig, 0, byConfig.Length);
                            Console.WriteLine("Found a Config string from the Arduino.");
                            Console.WriteLine(strBuffer);

                            Program.ATConfig.DecodeConfigString(byConfig);
                            this.populateFields();

                            this.currentConfigVersion = Program.ATConfig.ConfigVersion; //keep track of the version of config that we're working with
                            statusConfigVersion.Text = "Config Version: " + this.currentConfigVersion;

                            TxRxStatus.Mode = StatusModes.Disconnect;
                            TxRxStatus.Timeout = 0;
                            ConnectForm.Close();

                            Config.SaveSetting("CommPort", commTracker.PortName);


                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;

                        ConnectForm.Close();
                        MessageBox.Show("The Tracker entered configuration mode, but the current config could not be read.  Be sure the serial cable it attached to the programming port, and that the reset button was pressed after the Read Config button is pressed.", "ptConfigurator");

                    }

                    break;
                case StatusModes.FindWritePrompt:
                    Console.WriteLine("FindWritePrompt:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;

                        //Looking for "mode...\r\n"
                        if (this.findNeedle(new byte[] { 0x6d, 0x6f, 0x64, 0x65, 0x2e, 0x2e, 0x2e, 0x0d, 0x0a }))
                        {
                            byte[] byConfig;

                            byConfig = Program.ATConfig.EncodeConfigString(this.currentConfigVersion);

                            string strBuffer = Encoding.ASCII.GetString(byConfig, 0, byConfig.Length);
                            Console.WriteLine("Config String Built:");
                            Console.WriteLine(strBuffer);


                            this._byReceived = null;            //flush out the receive buffer

                            sendToArduino(byConfig);




                            TxRxStatus.Mode = StatusModes.Disconnect;
                            TxRxStatus.Timeout = 0;

                            ConnectForm.Close();
                            MessageBox.Show("The configuration was successfully written to the tracker.", "ptConfigurator");
                        }
                    }
                    else
                    {
                        //didn't get the attention - disconnect
                        TxRxStatus.Mode = StatusModes.Disconnect;
                        TxRxStatus.Timeout = 0;

                        ConnectForm.Close();
                        MessageBox.Show("The configuration could not be written to the tracker in time.  Be sure the serial cable it attached to the programming port, and that the reset button was pressed after the Write Config button is pressed.", "ptConfigurator");

                    }

                    break;
                case StatusModes.ExerciseStart:
                    Console.WriteLine("Exercise:");

                    if (TxRxStatus.Timeout > 0)
                    {
                        sendToArduino("E");         //request to write a new config

                        TxRxStatus.Mode = StatusModes.ExerciseEnd;
                        TxRxStatus.Timeout = 20;         //we have four ticks to get the prompt

                        this._byReceived = null;        //clear the receive buffer
                    }

                    break;
                case StatusModes.ExerciseEnd:
                    if (TxRxStatus.Timeout > 0)
                    {
                        TxRxStatus.Timeout--;
                    }
                    else
                    {
                        TxRxStatus.Mode = StatusModes.Stopped;
                        TxRxStatus.Timeout = 0;

                        frmExerciseOutput frm = new frmExerciseOutput();
                        frm.Show();

                        frm.setResults(Encoding.UTF8.GetString(this._byReceived));
                    }
                    break;
                case StatusModes.TransmitStart:
                    Console.WriteLine("Transmit:");

                    if (TxRxStatus.Timeout > 0)
                    {
                        sendToArduino("T");         //request to run the transmit exercising

                        TxRxStatus.Mode = StatusModes.Stopped;
                        ConnectForm.Close();
                    }

                    break;

                case StatusModes.TransmitShortStart:
                    Console.WriteLine("TransmitShort:");

                    if (TxRxStatus.Timeout > 0)
                    {
                        sendToArduino("t");         //request to run a short transmit

                        TxRxStatus.Mode = StatusModes.Stopped;
                        ConnectForm.Close();
                    }

                    break;
                case StatusModes.WSPRTxPacketA:
                    Console.WriteLine("WSPRTxPacketA:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        sendToArduino("p");         //send a packet on frequency A
                        TxRxStatus.Mode = StatusModes.Stopped;
                        ConnectForm.Close();
                    }
                    break;
                case StatusModes.WSPRTxPacketB:
                    Console.WriteLine("WSPRTxPacketB:");
                    if (TxRxStatus.Timeout > 0)
                    {
                        sendToArduino("P");         //send a packet on frequency B
                        TxRxStatus.Mode = StatusModes.Stopped;
                        ConnectForm.Close();
                    }
                    break;
                case StatusModes.Disconnect:
                    Console.WriteLine("Disconnect:");
                    if (commTracker.IsOpen)
                    {
                        commTracker.Close();
                    }

                    TxRxStatus.Mode = StatusModes.Stopped;
                    TxRxStatus.Timeout = 0;

                    break;
                case StatusModes.Stopped:
                    //We're done - do nothing here
                    break;
            }
        }
        private void sendToArduino(string Out)
        {
            Program.writeToProgramLog("Sending Data", Out);
            try
            {
                commTracker.Write(Out);
            }
            catch (TimeoutException)
            {
                //do nothing
            }
        }
        private void sendToArduino(byte[] Out)
        {
            string strOut = Encoding.ASCII.GetString(Out, 0, Out.Length);

            Program.writeToProgramLog("Sending Data", strOut);
            commTracker.Write(Out, 0, Out.Length);
        }

        private void ShowCommPortOpenError()
        {
            MessageBox.Show("There was a problem opening the communication port. Please verify that the correct port is selected and that it is not in use by another application.", "ptConfigurator", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowNoCommPortSelectedError()
        {
            MessageBox.Show("No communication port has been selected. Please select a COM port from the dropdown menu.", "ptConfigurator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowConfigModeTimeoutError()
        {
            MessageBox.Show("The tracker did not enter configuration mode in time. Please ensure the serial cable is attached to the programming port and press the reset button when prompted.", "ptConfigurator", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private byte[] extractConfigFromBuffer()
        {
            byte[] byConfig = null;

            //nothing received.
            if (this._byReceived == null) return null;

            int iStartOfText = Array.IndexOf<byte>(this._byReceived, 0x01);
            int iEndOfText = Array.IndexOf<byte>(this._byReceived, 0x04);

            if (iStartOfText >= 0 && iEndOfText >= 0 && iStartOfText < iEndOfText)
            {
                //we found a start and end in the buffer - extract that data

                Console.WriteLine("We found a Start and End of text that all matches up.");

                byConfig = new byte[iEndOfText - iStartOfText + 1];

                for (int i = iStartOfText; i <= iEndOfText; i++)
                {
                    Console.Write("{0}.  ", i);

                    //extract the data byte by byte.
                    byConfig[i - iStartOfText] = this._byReceived[i];
                }
                Console.WriteLine("");
                Console.WriteLine("Found a block of received config text.  Length: {0}", byConfig.Length);

                this._byReceived = null;        //reset the  receive buffer to null and prepare for new data
            }

            return byConfig;
        }



        private bool findNeedle(byte[] Needle)
        {
            //looks through the incoming buffer for the byte array string specified.  If it finds one, returns
            //  true and truncates the first part of the buffer off.

            if (this._byReceived == null)
            {
                return false;
            }


            int iStart = 0;
            int iFoundAt;

            iFoundAt = Array.IndexOf<byte>(this._byReceived, Needle[0], iStart);
            while (iFoundAt >= 0)
            {

                //make sure it's possible that we could have a complete needle
                if (this._byReceived.Length >= iFoundAt + Needle.Length)
                {
                    bool bFoundNeedle = true;       //assume we found it

                    for (int i = 0; i < Needle.Length; i++)
                    {
                        if (this._byReceived[iFoundAt + i] != Needle[i])
                        {
                            //we found a MISmatch
                            bFoundNeedle = false;
                        }
                    }

                    if (bFoundNeedle)
                    {

                        //trim the input buffer accordinly
                        if (this._byReceived.Length == iFoundAt + Needle.Length)
                        {
                            //the last character in the buffer was the end of the needle - eliminate the buffer
                            this._byReceived = null;
                        }
                        else
                        {
                            //there's still more stuff after the needle - preserve it
                            Console.WriteLine("Buffer Length: {0}", this._byReceived.Length);
                            Console.WriteLine("iFoundAt:      {0}", iFoundAt);
                            Console.WriteLine("Needle Length: {0}", Needle.Length);

                            byte[] byTemp = new byte[(this._byReceived.Length - iFoundAt - Needle.Length)];
                            //for (int j = (iFoundAt + Needle.Length); j < this._byReceived.Length; j++)
                            for (int j = 0; j < byTemp.Length; j++)
                            {
                                byTemp[j] = this._byReceived[j + iFoundAt + Needle.Length];
                            }

                            this._byReceived = byTemp;      //copy the temp buffer back to the global buffer
                        }

                        Console.WriteLine("Found the Needle in the Receive Buffer.");
                        return true;
                    }

                }
                iStart = iFoundAt + 1;
                iFoundAt = Array.IndexOf<byte>(this._byReceived, Needle[0], iStart);

            }
            Console.WriteLine("Didn't find the Needle...");
            return false;
        }


        private void chkXmitBurstAltitude_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitBurstAltitude = chkXmitBurstAltitude.Checked;
            CheckWarning();
        }

        private void chkXmitGPSQuality_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitGPSFix = chkXmitGPSQuality.Checked;
            CheckWarning();
        }

        private void chkXmitBatteryVoltage_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitBatteryVoltage = chkXmitBatteryVoltage.Checked;
            CheckWarning();
        }

        private void chkXmitAirTemp_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitTemp = chkXmitAirTemp.Checked;
            CheckWarning();
        }

        private void toolRefreshCommPorts_Click(object sender, EventArgs e)
        {
            this.enumCommPorts();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmboGPSSerialBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.GPSSerialBaud = cmboGPSSerialBaud.SelectedIndex + 1;
            CheckWarning();
        }

        private void chkGPSSerialInvert_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.GPSSerialInvert = chkGPSSerialInvert.Checked;
            CheckWarning();
        }

        private void cmboAnnouceMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.AnnounceMode = cmboAnnouceMode.SelectedIndex;
            CheckWarning();
        }

        private void txtDisablePathAboveAltitude_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisablePathAboveAltitude_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.DisablePathAboveAltitude = Convert.ToInt16(txtDisablePathAboveAltitude.Text);
            }
            catch { }
            txtDisablePathAboveAltitude.Text = Program.ATConfig.DisablePathAboveAltitude.ToString();
            CheckWarning();
        }

        private void cmboSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Symbol sym = (Symbol)cmboSymbol.SelectedItem;

            Program.ATConfig.SymbolChars = sym.SymbolChars;
            CheckWarning();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmboGPSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.GPSType = cmboGPSType.SelectedIndex;       //zero-based results
            CheckWarning();
        }


        private void cmboRadioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.RadioType = cmboRadioType.SelectedIndex;
            CheckWarning();
        }



        private void txtRadioTxDelay_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.RadioTxDelay = Convert.ToInt16(txtRadioTxDelay.Text);
            }
            catch { }
            txtRadioTxDelay.Text = Program.ATConfig.RadioTxDelay.ToString();
            CheckWarning();
        }

        private void txtRadioFreqTx_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.RadioFreqTx = txtRadioFreqTx.Text;
            txtRadioFreqTx.Text = Program.ATConfig.RadioFreqTx;
            CheckWarning();
        }



        private void txtRadioFreqRx_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.RadioFreqRx = txtRadioFreqRx.Text;
            txtRadioFreqRx.Text = Program.ATConfig.RadioFreqRx;
            CheckWarning();
        }

        private void chkRadioCourtesyTone_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.RadioCourtesyTone = chkRadioCourtesyTone.Checked;
            CheckWarning();
        }

        private void chkXmitCustom_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitCustom = chkXmitCustom.Checked;
            CheckWarning();
        }

        private void chkXmitAirPressure_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitPressure = chkXmitAirPressure.Checked;
            CheckWarning();
        }

        private void toolCommPort_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void toolExercise_Click(object sender, EventArgs e)
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                ShowNoCommPortSelectedError();

                return;
            }

            if (this.openCommPort())
            {


                this.TxRxStatus.Mode = StatusModes.ExerciseStart;
                this.TxRxStatus.Timeout = 20;       //wait 20 half-second cycles before giving up
            }
            else
            {
                //there was a problem opening the comm port
                ShowCommPortOpenError();
            }
        }

        private void toolTestTransmitter_Click(object sender, EventArgs e)
        {

        }

        public void StartWriteConfig()
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnWrite;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }

        public void StartReadConfig(Action onComplete = null)
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {

                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnRead;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }

        public void StartWSPRLongTone()
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnTransmit;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }

        public void StartWSPRShortTone()
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnTransmitShort;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }

        public void StartWSPRPacketA()
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnWSPRTxPacketA;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }
        public void StartWSPRPacketB()
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                ShowNoCommPortSelectedError();
                return;
            }

            if (this.openCommPort())
            {
                ConnectForm = new frmConnect();
                ConnectForm.Show(this);

                this.TxRxStatus.Mode = StatusModes.GetAttnWSPRTxPacketB;
                this.TxRxStatus.Timeout = 20;
            }
            else
            {
                ShowCommPortOpenError();
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void txtBeacon4MinDelay_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.MinTimeBetweenXmits = Convert.ToInt16(txtBeacon4MinDelay.Text);
            txtBeacon4MinDelay.Text = Program.ATConfig.MinTimeBetweenXmits.ToString();
            CheckWarning();
        }

        private void txtBeacon4VoltThreshGPS_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.VoltThreshGPS = Convert.ToInt16(txtBeacon4VoltThreshGPS.Text);
            txtBeacon4VoltThreshGPS.Text = Program.ATConfig.VoltThreshGPS.ToString();
            CheckWarning();
        }

        private void txtBeacon4VoltThreshXmit_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.VoltThreshXmit = Convert.ToInt16(txtBeacon4VoltThreshXmit.Text);
            txtBeacon4VoltThreshXmit.Text = Program.ATConfig.VoltThreshXmit.ToString();
            CheckWarning();
        }

        private void chkEnableBME280_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.I2cBME280 = chkEnableBME280.Checked;
            CheckWarning();
        }

        private void radBeacon4_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(4);
            Program.ATConfig.BeaconType = 4;
            CheckWarning();
        }

        private void chkRadioGlobalFreq_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.UseGlobalFrequency = chkRadioGlobalFreq.Checked;

            //If it's checked, disable the frequency text boxes
            if (chkRadioGlobalFreq.Checked)
            {
                lblRadioFreqTx.Enabled = false;
                lblRadioFreqTxB.Enabled = false;
                txtRadioFreqTx.Enabled = false;

                lblRadioFreqRx.Enabled = false;
                lblRadioFreqRxB.Enabled = false;
                txtRadioFreqRx.Enabled = false;
            }
            else
            {
                lblRadioFreqTx.Enabled = true;
                lblRadioFreqTxB.Enabled = true;
                txtRadioFreqTx.Enabled = true;

                lblRadioFreqRx.Enabled = true;
                lblRadioFreqRxB.Enabled = true;
                txtRadioFreqRx.Enabled = true;
            }
            CheckWarning();
        }

        private void toolConsole_Click(object sender, EventArgs e)
        {
            //find an existing console of this type that is already open
            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == "Console")
                {
                    frm.BringToFront();
                    return;
                }
            }

            frmConsole f = new frmConsole();
            f.Show();
        }

        private void chkTrackerRebootHourly_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.HourlyReboot = chkTrackerRebootHourly.Checked;
            CheckWarning();
        }

        private void chkGPSDisableDuringXmit_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.DisableGPSDuringXmit = chkGPSDisableDuringXmit.Checked;
            CheckWarning();
        }

        private void chkXmitSeconds_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitSeconds = chkXmitSeconds.Checked;
            CheckWarning();
        }

        private void chkBeacon4DelayXmit_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.DelayXmitUntilGPSFix = chkDelayXmitWithoutGPS.Checked;
            CheckWarning();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtWSPRCallsign_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.WSPRCallsign = txtWSPRCallsign.Text;
            txtWSPRCallsign.Text = Program.ATConfig.WSPRCallsign;
            CheckWarning();
        }

        private void txtWSPRFrequencyTx1_Leave(object sender, EventArgs e)
        {
            try
            {
                string strFreq = cmboWSPRFrequencyTx1.SelectedItem.ToString();
                strFreq = strFreq.Substring(strFreq.IndexOf("-") + 1).Trim();
                double freq = Convert.ToDouble(strFreq);
                freq = freq / 1000000; //convert to MHz

                Program.ATConfig.WSPRFrequencyTx1 = Convert.ToDouble(freq);
            }
            catch { }
            cmboWSPRFrequencyTx1.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx1);
            CheckWarning();
        }

        private void txtWSPRFrequencyTx2_Leave(object sender, EventArgs e)
        {
            try
            {
                string strFreq = cmboWSPRFrequencyTx2.SelectedItem.ToString();
                strFreq = strFreq.Substring(strFreq.IndexOf("-") + 1).Trim();
                double freq = Convert.ToDouble(strFreq);
                freq = freq / 1000000; //convert to MHz

                Program.ATConfig.WSPRFrequencyTx2 = Convert.ToDouble(freq);
            }
            catch { }
            cmboWSPRFrequencyTx2.SelectedIndex = this.getIndexOfFrequency(Program.ATConfig.WSPRFrequencyTx2);
            CheckWarning();
        }

        private void txtWSPRCorrection_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRCorrection = Convert.ToInt32(txtWSPRCorrection.Text);
            }
            catch
            {
            }
            txtWSPRCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();
            CheckWarning();
        }

        private void txtWSPRVoltThreshGPS_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRVoltThreshGPS = Convert.ToInt16(txtWSPRVoltThreshGPS.Text);
            }
            catch
            {
            }
            txtWSPRVoltThreshGPS.Text = Program.ATConfig.WSPRVoltThreshGPS.ToString();
            CheckWarning();
        }

        private void txtWSPRVoltThreshXmit_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRVoltThreshXmit = Convert.ToInt16(txtWSPRVoltThreshXmit.Text);
            }
            catch
            {
            }
            txtWSPRVoltThreshXmit.Text = Program.ATConfig.WSPRVoltThreshXmit.ToString();
            CheckWarning();

        }

        private void txtWSPRCorrection_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmboWSPRMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void txtWSPRToneOffset_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRToneOffset = Convert.ToInt32(txtWSPRToneOffset.Text);
            }
            catch
            {
            }
        }

        private void chkWSPRFineAltitudeModulation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWSPRFineAltitudeModulation.Checked)
            {
                Program.ATConfig.WSPRToneOffset = 1400;
                txtWSPRToneOffset.Text = Program.ATConfig.WSPRToneOffset.ToString();
                txtWSPRToneOffset.Enabled = false;
                Program.ATConfig.WSPRFineAltitudeModulation = true;
            }
            else
            {
                Program.ATConfig.WSPRToneOffset = 1500;
                txtWSPRToneOffset.Text = Program.ATConfig.WSPRToneOffset.ToString();
                txtWSPRToneOffset.Enabled = true;
                Program.ATConfig.WSPRFineAltitudeModulation = false;
            }
            CheckWarning();
        }

        private void cmboWSPRFrequencyTx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckWarning()
        {
            string warning = Program.ATConfig.GetWarning();
            if (warning != null)
                SetWarning(warning);
            else
                ClearWarning();
        }

        private void SetWarning(string message)
        {
            lblWarning.Text = message;
            panelWarning.Visible = true;
        }

        private void ClearWarning()
        {
            lblWarning.Text = string.Empty;
            panelWarning.Visible = false;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double actualFreq, targetFreq;
            //convert the text to integer
            try
            {
                actualFreq = Convert.ToDouble(txtActualFreq.Text);
                //Update the txtActualFreq to show the frequency in Hz with commas as thousand separators
                txtActualFreq.Text = actualFreq.ToString("N0");

                targetFreq = (cmboTargetFreq.SelectedIndex + 1) * 10000000;      //converted into Hz


            }
            catch
            {
                //just trim the text to remove any non-numeric characters
                txtActualFreq.Text = new string(txtActualFreq.Text.Where(c => char.IsDigit(c)).ToArray());

                txtFreqCorrection.Text = "";
                return;
            }

            //verify that the actual frequency is within a reasonable range of the target frequency (e.g., within 2000 Hz)
            if (Math.Abs(actualFreq - targetFreq) > 2000)
            {
                MessageBox.Show("Actual frequency is too far from the target frequency. Please check your measurements and try again.", "Frequency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFreqCorrection.Text = "";
                return;
            }



            //calculate the correction factor based on the target frequency and the actual frequency

            double correction = ((actualFreq - targetFreq) * 1000000000) / targetFreq;
            Program.ATConfig.WSPRCorrection = (int)correction;

            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString("N0");
        }

        private void btnWSPRToneLong_Click(object sender, EventArgs e)
        {
            StartWSPRLongTone();
        }

        private void btnWSPRToneShort_Click(object sender, EventArgs e)
        {
            StartWSPRShortTone();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void txtFreqCorrection_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRCorrection = Convert.ToInt32(txtFreqCorrection.Text);
            }
            catch
            {
            }
            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();
        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void txtFreqCorrection_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
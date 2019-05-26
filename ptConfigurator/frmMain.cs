using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

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
            FindReadInfo,
            FindWritePrompt,
            ExerciseStart,
            ExerciseEnd,
            TransmitStart,
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

            this.showHideBeaconOptions(0);
            Program.ATConfig.BeaconType = 0;

            enumCommPorts();
            this.TxRxStatus.Mode = StatusModes.Stopped;
            this.TxRxStatus.Timeout = 0;

            this.populateFields();
        }

        private void enumCommPorts()
        {
            string[] aryCommPortsAvail = System.IO.Ports.SerialPort.GetPortNames();
            toolCommPort.Items.Clear();
            //toolCommPort.Items.AddRange(aryCommPortsAvail);

            //extract the comm port numbers from the list
            int[] aryCommNumbers = new int[aryCommPortsAvail.Length];

            for (int i = 0; i < aryCommPortsAvail.Length; i++)
            {


                string strCommNumber = Regex.Replace(aryCommPortsAvail[i], @"\D", "");
                Console.WriteLine(strCommNumber);
                aryCommNumbers[i] = Int32.Parse(strCommNumber);

                
            }

            //sort the list of raw numbers
            Array.Sort(aryCommNumbers);


            //recombine the comm numbers into a human-readable list
            string[] aryCleanedList = new string[aryCommPortsAvail.Length + 1];
            aryCleanedList[0] = "Select a Comm Port";

            for (int i = 0; i < aryCommNumbers.Length; i++)
            {

                aryCleanedList[i + 1] = "Comm " + aryCommNumbers[i];
            }

            toolCommPort.Items.Clear();
            toolCommPort.Items.AddRange(aryCleanedList);

            toolCommPort.SelectedIndex = 0;


        }

        private void populateFields()
        {

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
         

            switch (Program.ATConfig.BeaconType) {
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
            }

            txtBeacon0Delay.Text = Program.ATConfig.BeaconSimpleDelay.ToString();

            txtBeacon1SpeedLow.Text = Program.ATConfig.BeaconSpeedThreshLow.ToString();
            txtBeacon1SpeedHigh.Text = Program.ATConfig.BeaconSpeedThreshHigh.ToString();
            txtBeacon1DelayLow.Text = Program.ATConfig.BeaconSpeedDelayLow.ToString();
            txtBeacon1DelayMid.Text = Program.ATConfig.BeaconSpeedDelayMid.ToString();
            txtBeacon1DelayHigh.Text = Program.ATConfig.BeaconSpeedDelayHigh.ToString();
            this.setSpeedLabel();

            txtBeacon2AltitudeLow.Text = Program.ATConfig.BeaconAltitudeThreshLow.ToString();
            txtBeacon2AltitudeHigh.Text = Program.ATConfig.BeaconAltitudeThreshHigh.ToString();
            txtBeacon2DelayLow.Text = Program.ATConfig.BeaconAltitudeDelayLow.ToString();
            txtBeacon2DelayMid.Text = Program.ATConfig.BeaconAltitudeDelayMid.ToString();
            txtBeacon2DelayHigh.Text = Program.ATConfig.BeaconAltitudeDelayHigh.ToString();
            this.setAltitudeLabel();

            txtBeacon3Slot1.Text = Program.ATConfig.BeaconSlot1.ToString();
            txtBeacon3Slot2.Text = Program.ATConfig.BeaconSlot2.ToString();


            txtStatusMessage.Text = Program.ATConfig.StatusMessage;
            chkXmitGPSQuality.Checked = Program.ATConfig.StatusXmitGPSFix;
            chkXmitBurstAltitude.Checked = Program.ATConfig.StatusXmitBurstAltitude;
            chkXmitBatteryVoltage.Checked = Program.ATConfig.StatusXmitBatteryVoltage;
            chkXmitAirTemp.Checked = Program.ATConfig.StatusXmitTemp;
            chkXmitAirPressure.Checked = Program.ATConfig.StatusXmitPressure;
            chkXmitCustom.Checked = Program.ATConfig.StatusXmitCustom;

            cmboRadioType.SelectedIndex = Program.ATConfig.RadioType;
            txtRadioTxDelay.Text = Program.ATConfig.RadioTxDelay.ToString();
            txtRadioFreqTx.Text = Program.ATConfig.RadioFreqTx;
            txtRadioFreqRx.Text = Program.ATConfig.RadioFreqRx;
            chkRadioCourtesyTone.Checked = Program.ATConfig.RadioCourtesyTone;

            cmboGPSSerialBaud.SelectedIndex = Program.ATConfig.GPSSerialBaud - 1;
            chkGPSSerialInvert.Checked = Program.ATConfig.GPSSerialInvert;
            cmboGPSType.SelectedIndex = Program.ATConfig.GPSType;

            cmboAnnouceMode.SelectedIndex = Program.ATConfig.AnnounceMode;

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

                    break;

            }

        }

        private void radBeacon1_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(1);
            Program.ATConfig.BeaconType = 1;
        }

        private void radBeacon3_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(3);
            Program.ATConfig.BeaconType = 3;
        }

        private void radBeacon2_CheckedChanged(object sender, EventArgs e)
        {
            this.showHideBeaconOptions(2);
            Program.ATConfig.BeaconType = 2;
        }

        private void txtCallsign_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboCallsignSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.CallsignSSID = cmboCallsignSSID.SelectedIndex;
        }

        private void txtDestination_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboDestinationSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.DestinationSSID = cmboDestinationSSID.SelectedIndex;
        }

        private void txtPath1_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboPath1SSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.Path1SSID = cmboPath1SSID.SelectedIndex;
        }

        private void txtPath2_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmboPath2SSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.Path2SSID = cmboPath2SSID.SelectedIndex;
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
        }

        private void txtDestination_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Destination = txtDestination.Text;
            txtDestination.Text = Program.ATConfig.Destination;
        }

        private void txtPath1_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Path1 = txtPath1.Text;
            txtPath1.Text = Program.ATConfig.Path1;
        }

        private void txtPath2_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.Path2 = txtPath2.Text;
            txtPath2.Text = Program.ATConfig.Path2;
        }

        private void txtBeacon0Delay_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.BeaconSimpleDelay = Convert.ToInt16(txtBeacon0Delay.Text);
            }
            catch { }   
            txtBeacon0Delay.Text = Program.ATConfig.BeaconSimpleDelay.ToString();
        }

        private void txtBeacon1SpeedLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedThreshLow = Convert.ToInt16(txtBeacon1SpeedLow.Text); }
            catch { }   

            txtBeacon1SpeedLow.Text = Program.ATConfig.BeaconSpeedThreshLow.ToString();
            this.setSpeedLabel();
        }

        private void txtBeacon1DelayLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayLow = Convert.ToInt16(txtBeacon1DelayLow.Text); }
            catch { }   

            txtBeacon1DelayLow.Text = Program.ATConfig.BeaconSpeedDelayLow.ToString();
        }

        private void txtBeacon1DelayMid_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayMid = Convert.ToInt16(txtBeacon1DelayMid.Text); }
            catch { }   

            txtBeacon1DelayMid.Text = Program.ATConfig.BeaconSpeedDelayMid.ToString();
        }

        private void txtBeacon1DelayHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedDelayHigh = Convert.ToInt16(txtBeacon1DelayHigh.Text); }
            catch { }   

            txtBeacon1DelayHigh.Text = Program.ATConfig.BeaconSpeedDelayHigh.ToString();
        }

        private void txtBeacon1SpeedHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSpeedThreshHigh = Convert.ToInt16(txtBeacon1SpeedHigh.Text); }
            catch { }   

            txtBeacon1SpeedHigh.Text = Program.ATConfig.BeaconSpeedThreshHigh.ToString();
            this.setSpeedLabel();
        }

        private void txtBeacon2AltitudeLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeThreshLow = Convert.ToInt16(txtBeacon2AltitudeLow.Text); }
            catch { }   

            txtBeacon2AltitudeLow.Text = Program.ATConfig.BeaconAltitudeThreshLow.ToString();
            this.setAltitudeLabel();
        }

        private void txtBeacon2AltitudeHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeThreshHigh = Convert.ToInt16(txtBeacon2AltitudeHigh.Text); }
            catch { }   

            txtBeacon2AltitudeHigh.Text = Program.ATConfig.BeaconAltitudeThreshHigh.ToString();
            this.setAltitudeLabel();
        }

        private void txtBeacon2DelayLow_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayLow = Convert.ToInt16(txtBeacon2DelayLow.Text); }
            catch { }   

            txtBeacon2DelayLow.Text = Program.ATConfig.BeaconAltitudeDelayLow.ToString();
        }

        private void txtBeacon2DelayMid_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayMid = Convert.ToInt16(txtBeacon2DelayMid.Text); }
            catch { }   

            txtBeacon2DelayMid.Text = Program.ATConfig.BeaconAltitudeDelayMid.ToString();
        }

        private void txtBeacon2DelayHigh_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconAltitudeDelayHigh = Convert.ToInt16(txtBeacon2DelayHigh.Text); }
            catch { }   

            txtBeacon2DelayHigh.Text = Program.ATConfig.BeaconAltitudeDelayHigh.ToString();
        }

        private void txtBeacon3Slot1_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSlot1 = Convert.ToInt16(txtBeacon3Slot1.Text); }
            catch { }   

            txtBeacon3Slot1.Text = Program.ATConfig.BeaconSlot1.ToString();
        }

        private void txtBeacon3Slot2_Leave(object sender, EventArgs e)
        {
            try { Program.ATConfig.BeaconSlot2 = Convert.ToInt16(txtBeacon3Slot2.Text); }
            catch { }   

            txtBeacon3Slot2.Text = Program.ATConfig.BeaconSlot2.ToString();
        }

        private void txtStatusMessage_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.StatusMessage = txtStatusMessage.Text;
            txtStatusMessage.Text = Program.ATConfig.StatusMessage;
        }

        

        private void toolWriteConfig_Click(object sender, EventArgs e)
        {
            //make sure that all of the fields have been updated into the configuraiton object
            //Call/Paths tab of options
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

            //Beaconing Tab of options
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




            //Configuration tab of options
            Program.ATConfig.StatusMessage = txtStatusMessage.Text;
            txtStatusMessage.Text = Program.ATConfig.StatusMessage;





            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                MessageBox.Show("You must select the appropriate Comm Port from the toolbar before you can read or write data to the tracker.", "ptConfigurator");

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
                MessageBox.Show("There was an error opening the Comm Port.", "ptConfigurator");
            }
        }



        frmConnect ConnectForm;

        private void toolReadConfig_Click(object sender, EventArgs e)
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                MessageBox.Show("You must select the appropriate Comm Port from the toolbar before you can read or write data to the tracker.", "ptConfigurator");

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
                MessageBox.Show("There was an error opening the Comm Port.", "ptConfigurator");
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
                string strCommNumber = Regex.Replace(toolCommPort.SelectedItem.ToString(), @"\D", "");
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
                        MessageBox.Show("The tracker could not be put into configuration mode in time.  Be sure the serial cable it attached to the programming port, and that the reset button was pressed after the Read Config button is pressed.", "ptConfigurator");

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
                        MessageBox.Show("The tracker could not be put into configuration mode in time.  Be sure the serial cable it attached to the programming port, and that the reset button was pressed after the Read Config button is pressed.", "ptConfigurator");

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
                        if (this.findNeedle(new byte[] {0x6d, 0x6f, 0x64, 0x65, 0x2e, 0x2e, 0x2e, 0x0d, 0x0a}))
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

                    if (bFoundNeedle) {

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
                            for (int j=0; j<byTemp.Length; j++) 
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
        }

        private void chkXmitGPSQuality_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitGPSFix = chkXmitGPSQuality.Checked;
        }

        private void chkXmitBatteryVoltage_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitBatteryVoltage = chkXmitBatteryVoltage.Checked;
        }

        private void chkXmitAirTemp_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitTemp = chkXmitAirTemp.Checked;
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
        }

        private void chkGPSSerialInvert_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.GPSSerialInvert = chkGPSSerialInvert.Checked;
        }

        private void cmboAnnouceMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.AnnounceMode = cmboAnnouceMode.SelectedIndex;
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
        }

        private void cmboSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Symbol sym = (Symbol)cmboSymbol.SelectedItem;

            Program.ATConfig.SymbolChars = sym.SymbolChars;
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
        }


        private void cmboRadioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ATConfig.RadioType = cmboRadioType.SelectedIndex;
        }



        private void txtRadioTxDelay_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.RadioTxDelay = Convert.ToInt16(txtRadioTxDelay.Text);
            }
            catch { }
            txtRadioTxDelay.Text = Program.ATConfig.RadioTxDelay.ToString();
        }

        private void txtRadioFreqTx_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.RadioFreqTx = txtRadioFreqTx.Text;
            txtRadioFreqTx.Text = Program.ATConfig.RadioFreqTx;
        }

       

        private void txtRadioFreqRx_Leave(object sender, EventArgs e)
        {
            Program.ATConfig.RadioFreqRx = txtRadioFreqRx.Text;
            txtRadioFreqRx.Text = Program.ATConfig.RadioFreqRx;
        }

        private void chkRadioCourtesyTone_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.RadioCourtesyTone = chkRadioCourtesyTone.Checked;
        }

        private void chkXmitCustom_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitCustom = chkXmitCustom.Checked;
        }

        private void chkXmitAirPressure_CheckedChanged(object sender, EventArgs e)
        {
            Program.ATConfig.StatusXmitPressure = chkXmitAirPressure.Checked;
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
                MessageBox.Show("You must select the appropriate Comm Port from the toolbar before you can read or write data to the tracker.", "ptConfigurator");

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
                MessageBox.Show("There was an error opening the Comm Port.", "ptConfigurator");
            }
        }

        private void toolTestTransmitter_Click(object sender, EventArgs e)
        {
            if (toolCommPort.SelectedIndex == 0)
            {
                //no port selected.
                MessageBox.Show("You must select the appropriate Comm Port from the toolbar before you can read or write data to the tracker.", "ptConfigurator");
                return;
            }

            if (this.openCommPort())
            {
                this.TxRxStatus.Mode = StatusModes.TransmitStart;
                this.TxRxStatus.Timeout = 20;       //wait 20 half-second cycles before giving up
            }
            else
            {
                //there was a problem opening the comm port
                MessageBox.Show("There was an error opening the Comm Port.", "ptConfigurator");
            }
        }
    }
}
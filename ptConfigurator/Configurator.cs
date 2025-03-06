using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ptConfigurator
{
    class Configurator
    {
        string _ConfigVersion;

        string _Callsign;
        int _CallsignSSID;
        string _Destination;
        int _DestinationSSID;
        string _Path1;
        int _Path1SSID;
        string _Path2;
        int _Path2SSID;

        int _DisablePathAboveAltitude;
        string _SymbolChars;
        
        int _BeaconType;

        int _BeaconSimpleDelay;

        int _BeaconSpeedThreshHigh;
        int _BeaconSpeedThreshLow;
        int _BeaconSpeedDelayLow;
        int _BeaconSpeedDelayMid;
        int _BeaconSpeedDelayHigh;

        int _BeaconAltitudeDelayLow;
        int _BeaconAltitudeDelayMid;
        int _BeaconAltitudeDelayHigh;
        int _BeaconAltitudeThreshLow;
        int _BeaconAltitudeThreshHigh;

        int _BeaconSlot1;
        int _BeaconSlot2;

        string _StatusMessage;
        bool _StatusXmitGPSFix;
        bool _StatusXmitBatteryVoltage;
        bool _StatusXmitBurstAltitude;
        bool _StatusXmitTemp;
        bool _StatusXmitPressure;
        bool _StatusXmitCustom;

        int _RadioType;
        int _RadioTxDelay;
        bool _RadioCourtesyTone;
        string _RadioFreqTx;
        string _RadioFreqRx;

        int _GPSSerialBaud;
        bool _GPSSerialInvert;
        int _GPSType;

        int _AnnounceMode;

        bool _i2cBME280;

        int _VoltThreshGPS;      //Voltage Threshold for GPS in millivolts
        int _VoltThreshXmit;     //Voltage Threshold for Transmitting in millivolts
        int _MinTimeBetweenXmits;



        public Configurator()
        {
            //initialize the data set

            this._ConfigVersion = "PT0002";
            this._Callsign = "N0CALL";
            this._CallsignSSID = 1;
            this._Destination = "APRS";
            this._DestinationSSID = 0;
            this._Path1 = "WIDE1";
            this._Path1SSID = 1;
            this._Path2 = "";
            this._Path2SSID = 0;
            this._DisablePathAboveAltitude = 0;
            this._SymbolChars = "/O";
            this._BeaconType = 0;
            this._BeaconSimpleDelay = 60;
            this._BeaconSpeedThreshHigh = 45;
            this._BeaconSpeedThreshLow = 10;
            this._BeaconSpeedDelayLow = 300;
            this._BeaconSpeedDelayMid = 30;
            this._BeaconSpeedDelayHigh = 90;
            this._BeaconAltitudeDelayLow = 30;
            this._BeaconAltitudeDelayMid = 60;
            this._BeaconAltitudeDelayHigh = 45;
            this._BeaconAltitudeThreshLow = 3000;
            this._BeaconAltitudeThreshHigh = 30000;
            this._BeaconSlot1 = 15;
            this._BeaconSlot2 = 45;
            this._StatusMessage = "ArduinoTrack";
            this._StatusXmitGPSFix = true;
            this._StatusXmitBatteryVoltage = true;
            this._StatusXmitBurstAltitude = true;
            this._StatusXmitTemp = true;
            this._StatusXmitPressure = true;
            this._StatusXmitCustom = true;

            this._RadioType = 0;
            this._RadioTxDelay = 50;
            this._RadioCourtesyTone = false;
            this._RadioFreqTx = "144.3900";
            this._RadioFreqRx = "144.3900";

            this._GPSSerialBaud = 4;
            this._GPSSerialInvert = true;
            this._GPSType = 1;
            this._AnnounceMode = 2;

            this._i2cBME280 = false;

            this._VoltThreshGPS = 3500;
            this._VoltThreshXmit = 4000;
            this._MinTimeBetweenXmits =  30;
        }


        public string ConfigVersion
        {
            get { return this._ConfigVersion; }
            set
            {
                if (value == null) value = "";
                if (value.Length <= 6)
                {
                    //have a good length
                    this._ConfigVersion = value.Trim().ToUpper();
                }
            }
        }

        public string Callsign
        {
            get { return this._Callsign; }
            set
            {
                if (value == null) value = "";
                value = value.Trim().ToUpper();

                value = Regex.Replace(value, @"[^\dA-Z]", "");

                if (value.Length <= 6)
                {
                    //have a good length
                    this._Callsign = value;
                }
            }
        }

        public int CallsignSSID
        {
            get
            {
                return this._CallsignSSID;
            }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    this._CallsignSSID = value;
                }
                else
                {
                    this._CallsignSSID = 0;
                }
            }
        }

        public string Destination
        {
            get
            {
                return this._Destination;
            }
            set
            {
                if (value == null) value = "";
                value = value.Trim().ToUpper();

                value = Regex.Replace(value, @"[^\dA-Z]", "");

                if (value.Length <= 6)
                {
                    this._Destination = value;
                }
            }
        }

        public int DestinationSSID
        {
            get
            {
                return this._DestinationSSID;
            }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    this._DestinationSSID = value;
                }
                else
                {
                    this._DestinationSSID = 0;
                }
            }
        }

        public string Path1
        {
            get
            {
                return this._Path1;
            }
            set
            {
                if (value == null) value = "";
                value = value.Trim().ToUpper();

                value = Regex.Replace(value, @"[^\dA-Z]", "");

                if (value.Length <= 6)
                {
                    this._Path1 = value;
                }
            }
        }

        public int Path1SSID
        {
            get
            {
                return this._Path1SSID;
            }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    this._Path1SSID = value;
                }
                else
                {
                    this._Path1SSID = 0;
                }
            }
        }

        public string Path2
        {
            get
            {
                return this._Path2;
            }
            set
            {
                if (value == null) value = "";
                value = value.Trim().ToUpper();

                value = Regex.Replace(value, @"[^\dA-Z]", "");

                if (value.Length <= 6)
                {
                    this._Path2 = value;
                }
            }
        }

        public int Path2SSID
        {
            get
            {
                return this._Path2SSID;
            }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    this._Path2SSID = value;
                }
                else
                {
                    this._Path2SSID = 0;
                }
            }
        }

        public int DisablePathAboveAltitude
        {
            get
            {
                return this._DisablePathAboveAltitude;
            }
            set
            {
                if (value >= 0 && value <= 65535)
                {
                    this._DisablePathAboveAltitude = value;
                }
                else
                {
                    this._DisablePathAboveAltitude = 0;
                }
            }
        }
        public string SymbolChars
        {
            get
            {
                return this._SymbolChars;
            }
            set
            {
                this._SymbolChars = value;
            }
        }

        public int BeaconType
        {
            get { return this._BeaconType; }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    this._BeaconType = value;
                }
                else
                {
                    this._BeaconType = 0;
                }
            }
        }

        public int BeaconSimpleDelay
        {
            get
            {
                return this._BeaconSimpleDelay;
            }
            set
            {
                this._BeaconSimpleDelay = value;

                if (value < 10)
                {
                    this._BeaconSimpleDelay = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconSimpleDelay = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconSpeedThreshLow
        {
            get
            {
                return this._BeaconSpeedThreshLow;
            }
            set
            {
                this._BeaconSpeedThreshLow = value;

                if (value < 0)
                {
                    this._BeaconSpeedThreshLow = 0;       //default to a low of 0
                }
                if (value > 400)
                {
                    this._BeaconSpeedThreshLow = 25;      //If it's an unreasonibly high number default to 25
                }
            }
        }

        public int BeaconSpeedThreshHigh
        {
            get
            {
                return this._BeaconSpeedThreshHigh;
            }
            set
            {
                this._BeaconSpeedThreshHigh = value;

                if (value < 5)
                {
                    this._BeaconSpeedThreshHigh = 5;       //default to a low of 0
                }
                if (value > 600)
                {
                    this._BeaconSpeedThreshHigh = 600;      //If it's an unreasonibly high number set to the max
                }
            }
        }

        public int BeaconSpeedDelayLow
        {
            get
            {
                return this._BeaconSpeedDelayLow;
            }
            set
            {
                this._BeaconSpeedDelayLow = value;

                if (value < 10)
                {
                    this._BeaconSpeedDelayLow = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconSpeedDelayLow = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconSpeedDelayMid
        {
            get
            {
                return this._BeaconSpeedDelayMid;
            }
            set
            {
                this._BeaconSpeedDelayMid = value;

                if (value < 10)
                {
                    this._BeaconSpeedDelayMid = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconSpeedDelayMid = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconSpeedDelayHigh
        {
            get
            {
                return this._BeaconSpeedDelayHigh;
            }
            set
            {
                this._BeaconSpeedDelayHigh = value;

                if (value < 10)
                {
                    this._BeaconSpeedDelayHigh = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconSpeedDelayHigh = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconAltitudeDelayLow
        {
            get
            {
                return this._BeaconAltitudeDelayLow;
            }
            set
            {
                this._BeaconAltitudeDelayLow = value;

                if (value < 10)
                {
                    this._BeaconAltitudeDelayLow = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconAltitudeDelayLow = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconAltitudeDelayMid
        {
            get
            {
                return this._BeaconAltitudeDelayMid;
            }
            set
            {
                this._BeaconAltitudeDelayMid = value;

                if (value < 10)
                {
                    this._BeaconAltitudeDelayMid = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconAltitudeDelayMid = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconAltitudeDelayHigh
        {
            get
            {
                return this._BeaconAltitudeDelayHigh;
            }
            set
            {
                this._BeaconAltitudeDelayHigh = value;

                if (value < 10)
                {
                    this._BeaconAltitudeDelayHigh = 30;       //default to a low of 30
                }
                if (value > 600)
                {
                    this._BeaconAltitudeDelayHigh = 600;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconAltitudeThreshLow
        {
            get
            {
                return this._BeaconAltitudeThreshLow;
            }
            set
            {
                this._BeaconAltitudeThreshLow = value;

                if (value < 0)
                {
                    this._BeaconAltitudeThreshLow = 0;       //default to a low of 0
                }
                if (value > 35000)
                {
                    this._BeaconAltitudeThreshLow = 35000;      //max of 10 minutes (600 seconds)
                }
            }
        }

        public int BeaconAltitudeThreshHigh
        {
            get
            {
                return this._BeaconAltitudeThreshHigh;
            }
            set
            {
                this._BeaconAltitudeThreshHigh = value;

                if (value < 100)
                {
                    this._BeaconAltitudeThreshHigh = 100;       //default to a low of 100 meters MSL
                }
                if (value > 40000)
                {
                    this._BeaconAltitudeThreshHigh = 40000;      //40,000m MSL is over 125k'
                }
            }
        }

        public int BeaconSlot1
        {
            get
            {
                return this._BeaconSlot1;
            }
            set
            {
                this._BeaconSlot1 = value;

                if (value < 0)
                {
                    this._BeaconSlot1 = 0;       //default to a low of 0
                }
                if (value > 59)
                {
                    this._BeaconSlot1 = 59;      //End of the minute
                }
            }
        }

        public int BeaconSlot2
        {
            get
            {
                return this._BeaconSlot2;
            }
            set
            {
                this._BeaconSlot2 = value;

                if (value < 0)
                {
                    this._BeaconSlot2 = 0;       //default to a low of 0
                }
                if (value > 59)
                {
                    this._BeaconSlot2 = 59;      //End of the minute
                }
            }
        }

        public string StatusMessage
        {
            get
            {
                return this._StatusMessage;
            }
            set
            {
                if (value == null) value = "";

                if (value == null) value = "";
                
                //Comment fields can include any printable letter except '|' and '~'
                value = Regex.Replace(value, "[^a-zA-Z0-9!\"#$%&'()*+,-./:;<=>?@[\\]^_`{}\\\\]", "");
                
                //value = Regex.Replace(value, @"[^a-zA-Z0-9\-:`!@#$%\^&*()\[\]{};:'\",\. ]", "");
                //  \da-zA-Z\.@-: ]", "");
                value = value.Trim();

                if (value.Length <= 40)
                {
                    this._StatusMessage = value;
                }
                else
                {
                    this._StatusMessage = value.Substring(0, 40).Trim();       //grab the first 40 chars
                }
            }
        }

        public bool StatusXmitGPSFix
        {
            get
            {
                return this._StatusXmitGPSFix;
            }
            set
            {
                this._StatusXmitGPSFix = value;
            }
        }

        public bool StatusXmitBatteryVoltage
        {
            get
            {
                return this._StatusXmitBatteryVoltage;
            }
            set
            {
                this._StatusXmitBatteryVoltage = value;
            }
        }

        public bool StatusXmitBurstAltitude
        {
            get { return this._StatusXmitBurstAltitude; }
            set { this._StatusXmitBurstAltitude = value; }
        }

        public bool StatusXmitTemp
        {
            get
            {
                return this._StatusXmitTemp;
            }
            set
            {
                this._StatusXmitTemp = value;
            }
        }

        public bool StatusXmitPressure
        {
            get { return this._StatusXmitPressure; }
            set { this._StatusXmitPressure = value; }
        }

        public bool StatusXmitCustom
        {
            get { return this._StatusXmitCustom; }
            set { this._StatusXmitCustom = value; }
        }



        //Radio Settings
        public int RadioType
        {
            get { return this._RadioType; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    this._RadioType = value;
                }
                else
                {
                    this._RadioType = 0;      //default to Standard Radio
                }
            }
        }

        public int RadioTxDelay
        {
            get { return this._RadioTxDelay; }
            set
            {
                if (value >= 1 && value <= 1000)
                {
                    this._RadioTxDelay = value;
                }
                else
                {
                    this._RadioTxDelay = 50;      //default to 50
                }
            }
        }

        public bool RadioCourtesyTone
        {
            get { return this._RadioCourtesyTone; }
            set { this._RadioCourtesyTone = value; }
        }

        public string RadioFreqTx
        {
            get { return this._RadioFreqTx; }
            set
            {
                if (value == null) value = "144.3900";
                double d = double.Parse(value);
                if (d < 144.0 || d > 148.0) d = 144.39;

                value = d.ToString("f4");

                
                this._RadioFreqTx = value;
                
            }
        }

        public string RadioFreqRx
        {
            get { return this._RadioFreqRx; }
            set
            {
                if (value == null) value = "144.3900";
                double d = double.Parse(value);
                if (d < 144.0 || d > 148.0) d = 144.39;

                value = d.ToString("f4");


                this._RadioFreqRx = value;
            }
        }


        //GPS Settings
        public int GPSSerialBaud
        {
            get { return this._GPSSerialBaud; }
            set
            {
                if (value >= 1 && value <= 6)
                {
                    this._GPSSerialBaud = value;
                }
                else
                {
                    this._GPSSerialBaud = 4;      //default to 4800 baud
                }
            }
        }

        public bool GPSSerialInvert
        {
            get { return this._GPSSerialInvert; }
            set { this._GPSSerialInvert = value; }
        }

        public int GPSType
        {
            get { return this._GPSType; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    this._GPSType = value;
                }
                else
                {
                    this._GPSType = 1;      //default to UBlox GPS
                }
            }
        }

        public int AnnounceMode
        {
            get { return this._AnnounceMode; }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    this._AnnounceMode = value;
                }
                else
                {
                    this._AnnounceMode = 3;      //default both audio and visual
                }
            }
        }

        public bool i2cBME280
        {
            get { return this._i2cBME280; }
            set { this._i2cBME280 = value; }
        }

        public int VoltThreshGPS
        {
            get { return this._VoltThreshGPS; }
            set
            {
                if (value >= 0 && value <= 65000)
                {
                    this._VoltThreshGPS = value;
                }
                else
                {
                    this._VoltThreshGPS = 3500;      //default to 3.5V
                }
            }
        }

        public int VoltThreshXmit
        {
            get { return this._VoltThreshXmit; }
            set
            {
                if (value >= 0 && value <= 65000)
                {
                    this._VoltThreshXmit = value;
                }
                else
                {
                    this._VoltThreshXmit = 4000;      //default to 4.0V
                }
            }
        }

        public int MinTimeBetweenXmits
        {
            get { return this._MinTimeBetweenXmits; }
            set
            {
                if (value >= 10 && value <= 65535)
                {
                    this._MinTimeBetweenXmits = value;
                }
                else
                {
                    this._MinTimeBetweenXmits = 30;      //default to 30 seconds
                }
            }
        }

        public byte[] EncodeConfigString(string configVersion)
        {
            List<byte> listReturn = new List<byte>();

            switch (configVersion)
            {

                case "PT0001":
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);


                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0001")));
                    listReturn.Add(0x09);

                    //Callsign
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Callsign.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._CallsignSSID));      //convert the SSID number into a character based 0-?
                    listReturn.Add(0x09);

                    //Destination
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Destination.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._DestinationSSID));
                    listReturn.Add(0x09);

                    //Path1
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path1.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path1SSID));
                    listReturn.Add(0x09);

                    //Path2
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path2.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path2SSID));
                    listReturn.Add(0x09);

                    //Disable Path
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisablePathAboveAltitude.ToString())));
                    listReturn.Add(0x09);

                    //_Symbol;
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(1, 1))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(0, 1))));
                    listReturn.Add(0x09);

                    //BeaconType
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconType.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Simple
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSimpleDelay.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Speed
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayHigh.ToString())));
                    listReturn.Add(0x09);


                    //Beacon Altitude
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayHigh.ToString())));
                    listReturn.Add(0x09);



                    //Beacon Time Slot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot1.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot2.ToString())));
                    listReturn.Add(0x09);


                    //Status Message
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._StatusMessage.ToString())));
                    listReturn.Add(0x09);

                    //Misc Flags
                    listReturn.Add((byte)(this._StatusXmitGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBurstAltitude ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBatteryVoltage ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitTemp ? 0x31 : 0x30));
                    listReturn.Add(0x09);



                    //GPS Serial Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSSerialBaud.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._GPSSerialInvert ? 0x31 : 0x30));
                    listReturn.Add(0x09);



                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._AnnounceMode.ToString())));

                    listReturn.Add(0x04);       //end of file
                    break;
                case "PT0002":
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);


                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0002")));
                    listReturn.Add(0x09);

                    //Callsign
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Callsign.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._CallsignSSID));      //convert the SSID number into a character based 0-?
                    listReturn.Add(0x09);

                    //Destination
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Destination.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._DestinationSSID));
                    listReturn.Add(0x09);

                    //Path1
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path1.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path1SSID));
                    listReturn.Add(0x09);

                    //Path2
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path2.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path2SSID));
                    listReturn.Add(0x09);

                    //Disable Path
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisablePathAboveAltitude.ToString())));
                    listReturn.Add(0x09);

                    //_Symbol;
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(1, 1))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(0, 1))));
                    listReturn.Add(0x09);

                    //BeaconType
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconType.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Simple
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSimpleDelay.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Speed
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayHigh.ToString())));
                    listReturn.Add(0x09);


                    //Beacon Altitude
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayHigh.ToString())));
                    listReturn.Add(0x09);



                    //Beacon Time Slot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot1.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot2.ToString())));
                    listReturn.Add(0x09);


                    //Status Message
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._StatusMessage.ToString())));
                    listReturn.Add(0x09);

                    //Misc Flags
                    listReturn.Add((byte)(this._StatusXmitGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBurstAltitude ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBatteryVoltage ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitTemp ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitPressure ? 0x31 : 0x30));
                    listReturn.Add(0x09);


                    //GPS Serial Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSSerialBaud.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._GPSSerialInvert ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSType.ToString())));
                    listReturn.Add(0x09);


                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._AnnounceMode.ToString())));

                    listReturn.Add(0x04);       //end of file
                    break;
                case "PT0003":
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);


                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0003")));
                    listReturn.Add(0x09);

                    //Callsign
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Callsign.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._CallsignSSID));      //convert the SSID number into a character based 0-?
                    listReturn.Add(0x09);

                    //Destination
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Destination.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._DestinationSSID));
                    listReturn.Add(0x09);

                    //Path1
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path1.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path1SSID));
                    listReturn.Add(0x09);

                    //Path2
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path2.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path2SSID));
                    listReturn.Add(0x09);

                    //Disable Path
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisablePathAboveAltitude.ToString())));
                    listReturn.Add(0x09);

                    //_Symbol;
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(1, 1))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(0, 1))));
                    listReturn.Add(0x09);

                    //BeaconType
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconType.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Simple
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSimpleDelay.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Speed
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayHigh.ToString())));
                    listReturn.Add(0x09);


                    //Beacon Altitude
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayHigh.ToString())));
                    listReturn.Add(0x09);



                    //Beacon Time Slot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot1.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot2.ToString())));
                    listReturn.Add(0x09);


                    //Status Message
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._StatusMessage.ToString())));
                    listReturn.Add(0x09);

                    //Misc Flags
                    listReturn.Add((byte)(this._StatusXmitGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBurstAltitude ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBatteryVoltage ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitTemp ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitPressure ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitCustom ? 0x31 : 0x30));
                    listReturn.Add(0x09);

                    //Radio Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioType.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioTxDelay.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._RadioCourtesyTone ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqTx.PadRight(8))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqRx.PadRight(8))));
                    listReturn.Add(0x09);

                    //GPS Serial Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSSerialBaud.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._GPSSerialInvert ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSType.ToString())));
                    listReturn.Add(0x09);


                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._AnnounceMode.ToString())));

                    listReturn.Add(0x04);       //end of file
                    break;

                case "PT0100":      //ptSolar Configuration
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);


                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0100")));
                    listReturn.Add(0x09);

                    //Callsign
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Callsign.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._CallsignSSID));      //convert the SSID number into a character based 0-?
                    listReturn.Add(0x09);

                    //Destination
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Destination.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._DestinationSSID));
                    listReturn.Add(0x09);

                    //Path1
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path1.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path1SSID));
                    listReturn.Add(0x09);

                    //Path2
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._Path2.PadRight(6))));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(0x30 + this._Path2SSID));
                    listReturn.Add(0x09);

                    //Disable Path
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisablePathAboveAltitude.ToString())));
                    listReturn.Add(0x09);

                    //_Symbol;
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(1, 1))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this.SymbolChars.Substring(0, 1))));
                    listReturn.Add(0x09);

                    //BeaconType
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconType.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Simple
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSimpleDelay.ToString())));
                    listReturn.Add(0x09);

                    //Beacon Speed
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSpeedDelayHigh.ToString())));
                    listReturn.Add(0x09);


                    //Beacon Altitude
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeThreshHigh.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayLow.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayMid.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconAltitudeDelayHigh.ToString())));
                    listReturn.Add(0x09);



                    //Beacon Time Slot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot1.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._BeaconSlot2.ToString())));
                    listReturn.Add(0x09);


                    //Status Message
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._StatusMessage.ToString())));
                    listReturn.Add(0x09);

                    //Misc Flags
                    listReturn.Add((byte)(this._StatusXmitGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBurstAltitude ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitBatteryVoltage ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitTemp ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitPressure ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitCustom ? 0x31 : 0x30));
                    listReturn.Add(0x09);

                    //Radio Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioType.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioTxDelay.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._RadioCourtesyTone ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqTx.PadRight(8))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqRx.PadRight(8))));
                    listReturn.Add(0x09);

                    //GPS Serial Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSSerialBaud.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._GPSSerialInvert ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._GPSType.ToString())));
                    listReturn.Add(0x09);


                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._AnnounceMode.ToString())));
                    listReturn.Add(0x09);

                    //i2c Configurations
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._i2cBME280 ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Beacon Mode 4 Configurations
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshGPS.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshXmit.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._MinTimeBetweenXmits.ToString())));

                    listReturn.Add(0x04);       //end of file
                    break;
                default:
                    break;
            }


            return listReturn.ToArray();
        }


        public void DecodeConfigString(byte[] byIn)
        {
            string[] aryStrIn = new string[200];

            int iPtr = 0;
            int iParam = 0;

            if (byIn[iPtr] != 0x01)
            {
                //the first byte wasn't a start of header
                return;
            }
            iPtr++;

            while (byIn[iPtr] != 0x04) {
                if (byIn[iPtr] == 0x09)
                {
                    //found a tab - go to the next param
                    iParam++;
                    
                }
                else
                {
                    

                    aryStrIn[iParam] += (char)(byIn[iPtr]);
                    //System.Text.Encoding.UTF8.GetString
                }
                iPtr++;
            }

            if (iParam > 10)
            {
                //we will always have at least 10 parameters

                switch (aryStrIn[0])
                {
                    case "PT0001":

                        try {

                            this.ConfigVersion = aryStrIn[0];

                            this.Callsign = aryStrIn[1];
                            char[] czTemp;
                            
                            czTemp = aryStrIn[2].ToCharArray();
                            this.CallsignSSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            
                            this.Destination = aryStrIn[3];

                            czTemp = aryStrIn[4].ToCharArray();
                            this.DestinationSSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.DestinationSSID = Convert.ToInt16(aryStrIn[4]);

                            this.Path1 = aryStrIn[5];

                            czTemp = aryStrIn[6].ToCharArray();
                            this.Path1SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path1SSID = Convert.ToInt16(aryStrIn[6]);

                            this.Path2 = aryStrIn[7];
                            
                            czTemp = aryStrIn[8].ToCharArray();
                            this.Path2SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path2SSID = Convert.ToInt16(aryStrIn[8]);

                            //Disable Path above altitude
                            this.DisablePathAboveAltitude = Convert.ToInt32(aryStrIn[9]);

                            //10 and 11 are the symbol/page values
                            this.SymbolChars = aryStrIn[11] + aryStrIn[10];

                            //beacon type
                            this.BeaconType = Convert.ToInt32(aryStrIn[12]);
                            
                            //beacon delay
                            this.BeaconSimpleDelay = Convert.ToInt32(aryStrIn[13]);
                        
                            //beacon speed
                            this.BeaconSpeedThreshLow = Convert.ToInt32(aryStrIn[14]);
                            this.BeaconSpeedThreshHigh = Convert.ToInt32(aryStrIn[15]);
                            this.BeaconSpeedDelayLow = Convert.ToInt32(aryStrIn[16]);
                            this.BeaconSpeedDelayMid = Convert.ToInt32(aryStrIn[17]);
                            this.BeaconSpeedDelayHigh = Convert.ToInt32(aryStrIn[18]);

                            //beacon altitude
                            this.BeaconAltitudeThreshLow = Convert.ToInt32(aryStrIn[19]);
                            this.BeaconAltitudeThreshHigh = Convert.ToInt32(aryStrIn[20]);
                            this.BeaconAltitudeDelayLow = Convert.ToInt32(aryStrIn[21]);
                            this.BeaconAltitudeDelayMid = Convert.ToInt32(aryStrIn[22]);
                            this.BeaconAltitudeDelayHigh = Convert.ToInt32(aryStrIn[23]);
                            
                            //beacon time slot
                            this.BeaconSlot1 = Convert.ToInt32(aryStrIn[24]);
                            this.BeaconSlot2 = Convert.ToInt32(aryStrIn[25]);

                            //Status message
                            this.StatusMessage = aryStrIn[26];

                            //Misc flags
                            this.StatusXmitGPSFix = (aryStrIn[27] == "1" ? true : false);
                            this.StatusXmitBurstAltitude = (aryStrIn[28] == "1" ? true : false);
                            this.StatusXmitBatteryVoltage = (aryStrIn[29] == "1" ? true : false);
                            this.StatusXmitTemp = (aryStrIn[30] == "1" ? true : false);



                            //GPS Serial Settings
                            this.GPSSerialBaud = Convert.ToInt32(aryStrIn[31]);
                            this.GPSSerialInvert = (aryStrIn[32] == "1" ? true : false);


                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[33]);
                        }
                        catch { }  

                        break;

                    case "PT0002":
                        try
                        {
                            this.ConfigVersion = aryStrIn[0];

                            this.Callsign = aryStrIn[1];
                            char[] czTemp;

                            czTemp = aryStrIn[2].ToCharArray();
                            this.CallsignSSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            this.Destination = aryStrIn[3];

                            czTemp = aryStrIn[4].ToCharArray();
                            this.DestinationSSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.DestinationSSID = Convert.ToInt16(aryStrIn[4]);

                            this.Path1 = aryStrIn[5];

                            czTemp = aryStrIn[6].ToCharArray();
                            this.Path1SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path1SSID = Convert.ToInt16(aryStrIn[6]);

                            this.Path2 = aryStrIn[7];

                            czTemp = aryStrIn[8].ToCharArray();
                            this.Path2SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path2SSID = Convert.ToInt16(aryStrIn[8]);

                            //Disable Path above altitude
                            this.DisablePathAboveAltitude = Convert.ToInt32(aryStrIn[9]);

                            //10 and 11 are the symbol/page values
                            this.SymbolChars = aryStrIn[11] + aryStrIn[10];

                            //beacon type
                            this.BeaconType = Convert.ToInt32(aryStrIn[12]);

                            //beacon delay
                            this.BeaconSimpleDelay = Convert.ToInt32(aryStrIn[13]);

                            //beacon speed
                            this.BeaconSpeedThreshLow = Convert.ToInt32(aryStrIn[14]);
                            this.BeaconSpeedThreshHigh = Convert.ToInt32(aryStrIn[15]);
                            this.BeaconSpeedDelayLow = Convert.ToInt32(aryStrIn[16]);
                            this.BeaconSpeedDelayMid = Convert.ToInt32(aryStrIn[17]);
                            this.BeaconSpeedDelayHigh = Convert.ToInt32(aryStrIn[18]);

                            //beacon altitude
                            this.BeaconAltitudeThreshLow = Convert.ToInt32(aryStrIn[19]);
                            this.BeaconAltitudeThreshHigh = Convert.ToInt32(aryStrIn[20]);
                            this.BeaconAltitudeDelayLow = Convert.ToInt32(aryStrIn[21]);
                            this.BeaconAltitudeDelayMid = Convert.ToInt32(aryStrIn[22]);
                            this.BeaconAltitudeDelayHigh = Convert.ToInt32(aryStrIn[23]);

                            //beacon time slot
                            this.BeaconSlot1 = Convert.ToInt32(aryStrIn[24]);
                            this.BeaconSlot2 = Convert.ToInt32(aryStrIn[25]);

                            //Status message
                            this.StatusMessage = aryStrIn[26];

                            //Misc flags
                            this.StatusXmitGPSFix = (aryStrIn[27] == "1" ? true : false);
                            this.StatusXmitBurstAltitude = (aryStrIn[28] == "1" ? true : false);
                            this.StatusXmitBatteryVoltage = (aryStrIn[29] == "1" ? true : false);
                            this.StatusXmitTemp = (aryStrIn[30] == "1" ? true : false);
                            this.StatusXmitPressure = (aryStrIn[31] == "1" ? true : false);



                            //GPS Serial Settings
                            this.GPSSerialBaud = Convert.ToInt32(aryStrIn[32]);
                            this.GPSSerialInvert = (aryStrIn[33] == "1" ? true : false);
                            this.GPSType = Convert.ToInt32(aryStrIn[34]);

                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[35]);
                        }
                        catch { }

                        break;
                    case "PT0003":
                        try
                        {
                            this.ConfigVersion = aryStrIn[0];

                            this.Callsign = aryStrIn[1];
                            char[] czTemp;

                            czTemp = aryStrIn[2].ToCharArray();
                            this.CallsignSSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            this.Destination = aryStrIn[3];

                            czTemp = aryStrIn[4].ToCharArray();
                            this.DestinationSSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.DestinationSSID = Convert.ToInt16(aryStrIn[4]);

                            this.Path1 = aryStrIn[5];

                            czTemp = aryStrIn[6].ToCharArray();
                            this.Path1SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path1SSID = Convert.ToInt16(aryStrIn[6]);

                            this.Path2 = aryStrIn[7];

                            czTemp = aryStrIn[8].ToCharArray();
                            this.Path2SSID = Convert.ToInt32(czTemp[0]) - 0x30;
                            //this.Path2SSID = Convert.ToInt16(aryStrIn[8]);

                            //Disable Path above altitude
                            this.DisablePathAboveAltitude = Convert.ToInt32(aryStrIn[9]);

                            //10 and 11 are the symbol/page values
                            this.SymbolChars = aryStrIn[11] + aryStrIn[10];

                            //beacon type
                            this.BeaconType = Convert.ToInt32(aryStrIn[12]);

                            //beacon delay
                            this.BeaconSimpleDelay = Convert.ToInt32(aryStrIn[13]);

                            //beacon speed
                            this.BeaconSpeedThreshLow = Convert.ToInt32(aryStrIn[14]);
                            this.BeaconSpeedThreshHigh = Convert.ToInt32(aryStrIn[15]);
                            this.BeaconSpeedDelayLow = Convert.ToInt32(aryStrIn[16]);
                            this.BeaconSpeedDelayMid = Convert.ToInt32(aryStrIn[17]);
                            this.BeaconSpeedDelayHigh = Convert.ToInt32(aryStrIn[18]);

                            //beacon altitude
                            this.BeaconAltitudeThreshLow = Convert.ToInt32(aryStrIn[19]);
                            this.BeaconAltitudeThreshHigh = Convert.ToInt32(aryStrIn[20]);
                            this.BeaconAltitudeDelayLow = Convert.ToInt32(aryStrIn[21]);
                            this.BeaconAltitudeDelayMid = Convert.ToInt32(aryStrIn[22]);
                            this.BeaconAltitudeDelayHigh = Convert.ToInt32(aryStrIn[23]);

                            //beacon time slot
                            this.BeaconSlot1 = Convert.ToInt32(aryStrIn[24]);
                            this.BeaconSlot2 = Convert.ToInt32(aryStrIn[25]);

                            //Status message
                            this.StatusMessage = aryStrIn[26];

                            //Misc flags
                            this.StatusXmitGPSFix = (aryStrIn[27] == "1" ? true : false);
                            this.StatusXmitBurstAltitude = (aryStrIn[28] == "1" ? true : false);
                            this.StatusXmitBatteryVoltage = (aryStrIn[29] == "1" ? true : false);
                            this.StatusXmitTemp = (aryStrIn[30] == "1" ? true : false);
                            this.StatusXmitPressure = (aryStrIn[31] == "1" ? true : false);
                            this.StatusXmitCustom = (aryStrIn[32] == "1" ? true : false);

                            //Radio Settings
                            this.RadioType = Convert.ToInt32(aryStrIn[33]);
                            this.RadioTxDelay = Convert.ToInt32(aryStrIn[34]);
                            this.RadioCourtesyTone = (aryStrIn[35] == "1" ? true : false);
                            this.RadioFreqTx = aryStrIn[36];
                            this.RadioFreqRx = aryStrIn[37];


                            //GPS Serial Settings
                            this.GPSSerialBaud = Convert.ToInt32(aryStrIn[38]);
                            this.GPSSerialInvert = (aryStrIn[39] == "1" ? true : false);
                            this.GPSType = Convert.ToInt32(aryStrIn[40]);

                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[41]);
                        }
                        catch { }

                        break;

                    case "PT0100":      //ptSolar Configuration
                        try
                        {
                            this.ConfigVersion = aryStrIn[0];

                            this.Callsign = aryStrIn[1];
                            char[] czTemp;

                            czTemp = aryStrIn[2].ToCharArray();
                            this.CallsignSSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            this.Destination = aryStrIn[3];

                            czTemp = aryStrIn[4].ToCharArray();
                            this.DestinationSSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            this.Path1 = aryStrIn[5];

                            czTemp = aryStrIn[6].ToCharArray();
                            this.Path1SSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            this.Path2 = aryStrIn[7];

                            czTemp = aryStrIn[8].ToCharArray();
                            this.Path2SSID = Convert.ToInt32(czTemp[0]) - 0x30;

                            //Disable Path above altitude
                            this.DisablePathAboveAltitude = Convert.ToInt32(aryStrIn[9]);

                            //10 and 11 are the symbol/page values
                            this.SymbolChars = aryStrIn[11] + aryStrIn[10];

                            //beacon type
                            this.BeaconType = Convert.ToInt32(aryStrIn[12]);

                            //beacon delay
                            this.BeaconSimpleDelay = Convert.ToInt32(aryStrIn[13]);

                            //beacon speed
                            this.BeaconSpeedThreshLow = Convert.ToInt32(aryStrIn[14]);
                            this.BeaconSpeedThreshHigh = Convert.ToInt32(aryStrIn[15]);
                            this.BeaconSpeedDelayLow = Convert.ToInt32(aryStrIn[16]);
                            this.BeaconSpeedDelayMid = Convert.ToInt32(aryStrIn[17]);
                            this.BeaconSpeedDelayHigh = Convert.ToInt32(aryStrIn[18]);

                            //beacon altitude
                            this.BeaconAltitudeThreshLow = Convert.ToInt32(aryStrIn[19]);
                            this.BeaconAltitudeThreshHigh = Convert.ToInt32(aryStrIn[20]);
                            this.BeaconAltitudeDelayLow = Convert.ToInt32(aryStrIn[21]);
                            this.BeaconAltitudeDelayMid = Convert.ToInt32(aryStrIn[22]);
                            this.BeaconAltitudeDelayHigh = Convert.ToInt32(aryStrIn[23]);

                            //beacon time slot
                            this.BeaconSlot1 = Convert.ToInt32(aryStrIn[24]);
                            this.BeaconSlot2 = Convert.ToInt32(aryStrIn[25]);

                            //Status message
                            this.StatusMessage = aryStrIn[26];

                            //Misc flags
                            this.StatusXmitGPSFix = (aryStrIn[27] == "1" ? true : false);
                            this.StatusXmitBurstAltitude = (aryStrIn[28] == "1" ? true : false);
                            this.StatusXmitBatteryVoltage = (aryStrIn[29] == "1" ? true : false);
                            this.StatusXmitTemp = (aryStrIn[30] == "1" ? true : false);
                            this.StatusXmitPressure = (aryStrIn[31] == "1" ? true : false);
                            this.StatusXmitCustom = (aryStrIn[32] == "1" ? true : false);

                            //Radio Settings
                            this.RadioType = Convert.ToInt32(aryStrIn[33]);
                            this.RadioTxDelay = Convert.ToInt32(aryStrIn[34]);
                            this.RadioCourtesyTone = (aryStrIn[35] == "1" ? true : false);
                            this.RadioFreqTx = aryStrIn[36];
                            this.RadioFreqRx = aryStrIn[37];


                            //GPS Serial Settings
                            this.GPSSerialBaud = Convert.ToInt32(aryStrIn[38]);
                            this.GPSSerialInvert = (aryStrIn[39] == "1" ? true : false);
                            this.GPSType = Convert.ToInt32(aryStrIn[40]);

                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[41]);

                            //i2c Configurations
                            this.i2cBME280 = (aryStrIn[42] == "1" ? true : false);

                            //Beacon Mode 4 Configurations
                            this.VoltThreshGPS = Convert.ToInt32(aryStrIn[43]);
                            this.VoltThreshXmit = Convert.ToInt32(aryStrIn[44]);
                            this.MinTimeBetweenXmits = Convert.ToInt32(aryStrIn[45]);
                        }
                        catch { }

                        break;
                }

            }
            
        }
    }
}

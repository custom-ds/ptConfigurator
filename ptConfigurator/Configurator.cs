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

        //Various Status Message settings
        string _StatusMessage;
        bool _StatusXmitGPSFix;
        bool _StatusXmitBatteryVoltage;
        bool _StatusXmitBurstAltitude;
        bool _StatusXmitTemp;
        bool _StatusXmitPressure;
        bool _StatusXmitSeconds;        //output the Millis (in seconds) to aid in debugging
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

        bool _I2cBME280;
        bool _UseGlobalFrequency;
        bool _DisableGPSDuringXmit;
        bool _HourlyReboot;

        //Beacon 4 - low power settings
        int _VoltThreshGPS;      //Voltage Threshold for GPS in millivolts
        int _VoltThreshXmit;     //Voltage Threshold for Transmitting in millivolts
        int _MinTimeBetweenXmits;
        bool _DelayXmitUntilGPSFix;



        //WSPR Settings (ConfigVersion PT02xx)
        string _WSPRCallsign;    //10 digit callsign + Null
        int _WSPRVoltThreshGPS;    //The voltage threshold to activate the GPS and read a position (in millivolts)
        int _WSPRVoltThreshXmit;    //The voltage threshold to transmit a packet (in millivolts)
        double _WSPRFrequencyTx1;    //The transmit frequency in MHz
        double _WSPRFrequencyTx2;    //The transmit frequency in MHz (secondary, for dual frequency operation)
        int _WSPRToneOffset;        //The tone offset in Hz (default is 1500Hz, which is the standard WSPR tone spacing)
        bool _WSPRFineAltitudeModulation;    //If true, the tone offset will be 1400Hz and the altitude will be encoded in the least significant bits of the WSPR message
        int _WSPRCorrection;    //Frequency correction in parts per billion
        int _WSPRAnnounceMode;    //0=No annunciator, 1=LED only
        int _WSPRMessageType;    //Type of WSPR message to send - 0=Standard. Other types reserved for future use
        int _WSPRTxMod;    //How often to transmit = 2=every 2 minutes, 4=every 4 minutes, etc. Must be a multiple of 2
        int _WSPRTxModOffset;    //Offset within the TxMod to transmit on.  For example, if TxMod=4 and TxModOffset=2, it will transmit at minutes 2, 6, 10, etc.
        bool _WSPRHourlyReboot;



        public Configurator()
        {
            //initialize the data set

            this._ConfigVersion = "PT0002";
            this._Callsign = "N0CALL";
            this._CallsignSSID = 1;
            this._Destination = "APPRJ1";
            this._DestinationSSID = 0;
            this._Path1 = "WIDE2";
            this._Path1SSID = 1;
            this._Path2 = "";
            this._Path2SSID = 0;
            this._DisablePathAboveAltitude = 0;
            this._SymbolChars = "/O";

            this._BeaconType = 0;

            //Beacon Type 0 - Simple Beacons
            this._BeaconSimpleDelay = 60;

            //Beacon Type 1 - Speed Beacons
            this._BeaconSpeedThreshHigh = 45;
            this._BeaconSpeedThreshLow = 10;
            this._BeaconSpeedDelayLow = 300;
            this._BeaconSpeedDelayMid = 30;
            this._BeaconSpeedDelayHigh = 90;

            //Beacon Type 2 - Altitude Beacons
            this._BeaconAltitudeDelayLow = 30;
            this._BeaconAltitudeDelayMid = 60;
            this._BeaconAltitudeDelayHigh = 45;
            this._BeaconAltitudeThreshLow = 3000;
            this._BeaconAltitudeThreshHigh = 30000;

            //Beacon Type 3 - Time Slots
            this._BeaconSlot1 = 15;
            this._BeaconSlot2 = 45;

            //Beacon Type 4 - low power settings
            this._VoltThreshGPS = 3500;
            this._VoltThreshXmit = 4100;
            this._MinTimeBetweenXmits = 30;

            this._StatusMessage = "Project Traveler";
            this._StatusXmitGPSFix = true;
            this._StatusXmitBatteryVoltage = true;
            this._StatusXmitBurstAltitude = true;
            this._StatusXmitTemp = true;
            this._StatusXmitPressure = true;
            this._StatusXmitSeconds = false;
            this._StatusXmitCustom = true;

            this._RadioTxDelay = 25;
            this._RadioCourtesyTone = false;
            this._RadioFreqTx = "144.3900";
            this._RadioFreqRx = "144.3900";
            this._UseGlobalFrequency = false;


            this._AnnounceMode = 3;

            this._I2cBME280 = false;
            this._DisableGPSDuringXmit = false;
            this._HourlyReboot = false;
            this._DelayXmitUntilGPSFix = true;



            //WSPR Defaults
            this._WSPRCallsign = "N0CALL";    //10 digit callsign + Null
            this._WSPRVoltThreshGPS = 3600;    //The voltage threshold to activate the GPS and read a position (in millivolts)
            this._WSPRVoltThreshXmit = 3700;    //The voltage threshold to transmit a packet (in millivolts)
            this._WSPRFrequencyTx1 = 28.1246;    //The transmit frequency in MHz
            this._WSPRFrequencyTx2 = 21.0946;    //The transmit frequency in MHz (secondary, for dual frequency operation)
            this._WSPRToneOffset = 1400;        //The tone offset in Hz (normally 1500, but must be 1400 if Fine Altitude Modulation is enabled)
            this._WSPRFineAltitudeModulation = true;
            this._WSPRCorrection = 0;    //Frequency correction in parts per billion
            this._WSPRAnnounceMode = 1;    //0=No annunciator, 1=LED only
            this._WSPRMessageType = 2;    //Type of WSPR message to send - 0=Standard. Other types reserved for future use
            this._WSPRTxMod = 6;    //How often to transmit = 2=every 2 minutes, 4=every 4 minutes, etc. Must be a multiple of 2
            this._WSPRTxModOffset = 0;    //Offset within the TxMod to transmit on.  For example, if TxMod=4 and TxModOffset=2, it will transmit at minutes 2, 6, 10, etc.
            this._WSPRHourlyReboot = false;

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
                if (value >= 0 && value <= 4)
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
                value = Regex.Replace(value, "[^a-z A-Z0-9!\"#$%&'()*+,-./:;<=>?@[\\]^_`{}\\\\]", "");
                
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

        public bool StatusXmitSeconds
        {
            get { return this._StatusXmitSeconds; }
            set { this._StatusXmitSeconds = value; }
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
                if (value >= 0 && value <= 2)
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

        public bool I2cBME280
        {
            get { return this._I2cBME280; }
            set { this._I2cBME280 = value; }
        }

        public bool UseGlobalFrequency
        {
            get { return this._UseGlobalFrequency; }
            set { this._UseGlobalFrequency = value; }
        }
        public bool DisableGPSDuringXmit
        {
            get { return this._DisableGPSDuringXmit; }
            set { this._DisableGPSDuringXmit = value; }
        }
        public bool HourlyReboot
        {
            get { return this._HourlyReboot; }
            set { this._HourlyReboot = value; }
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
        public bool DelayXmitUntilGPSFix
        {
            get { return this._DelayXmitUntilGPSFix; }
            set { this._DelayXmitUntilGPSFix = value; }
        }

        //WSPR Settings
        public string WSPRCallsign
        {
            get { return this._WSPRCallsign; }
            set
            {
                if (value == null) value = "";
                value = value.Trim().ToUpper();

                value = Regex.Replace(value, @"[^\dA-Z/]", "");     //Alpha, numeric, and slash

                if (value.Length <= 10)
                {
                    //have a good length
                    this._WSPRCallsign = value;
                }
            }
        }

        public int WSPRVoltThreshGPS
        {
            get { return this._WSPRVoltThreshGPS; }
            set
            {
                if (value >= 0 && value <= 65000)
                {
                    this._WSPRVoltThreshGPS = value;
                }
                else
                {
                    this._WSPRVoltThreshGPS = 3600;      //default to 3.6V
                }
            }
        }

        public int WSPRVoltThreshXmit
        {
            get { return this._WSPRVoltThreshXmit; }
            set
            {
                if (value >= 0 && value <= 65000)
                {
                    this._WSPRVoltThreshXmit = value;
                }
                else
                {
                    this._WSPRVoltThreshXmit = 3700;      //default to 3.7V
                }
            }
        }

        public double WSPRFrequencyTx1
        {
            get { return this._WSPRFrequencyTx1; }
            set
            {
                if (value >= 21.001 && value <= 29.999)
                {
                    this._WSPRFrequencyTx1 = value;
                }
                else
                {
                    this._WSPRFrequencyTx1 = 28.1262;      //default to 28.1262 MHz
                }
            }
        }

        public double WSPRFrequencyTx2
        {
            get { return this._WSPRFrequencyTx2; }
            set
            {
                if (value >= 21.001 && value <= 29.999)
                {
                    this._WSPRFrequencyTx2 = value;
                }
                else
                {
                    this._WSPRFrequencyTx2 = 28.1261;      //default to 28.1261 MHz
                }
            }
        }

        public int WSPRToneOffset
        {
            get { return this._WSPRToneOffset; }
            set
            {
                if (value >= -3400 && value <= 3400)        //Allow negative, but I'm not sure where you'd want that
                {
                    this._WSPRToneOffset = value;
                }
                else
                {
                    this._WSPRToneOffset = 1500;      //default to 1500 Hz
                }
            }
        }

        public bool WSPRFineAltitudeModulation
        {
            get { return this._WSPRFineAltitudeModulation; }
            set 
            { 
                if (value)
                {
                    //the offset must be set to 1400 if this is flagged
                    this._WSPRToneOffset = 1400;

                }
                this._WSPRFineAltitudeModulation = value; 
            
            }
        }

        public int WSPRCorrection
        {
            get { return this._WSPRCorrection; }
            set
            {
                if (value >= -999999999 && value <= 999999999)
                {
                    this._WSPRCorrection = value;
                }
                else
                {
                    this._WSPRCorrection = 0;      //default to 0 ppb
                }
            }
        }

        public int WSPRAnnounceMode
        {
            get { return this._WSPRAnnounceMode; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    this._WSPRAnnounceMode = value;
                }
                else
                {
                    this._WSPRAnnounceMode = 1;      //default to LED only
                }
            }
        }

        public int WSPRMessageType
        {
            get { return this._WSPRMessageType; }
            set
            {
                if ((value >= 1 && value <= 2) || (value >= 129) && (value <= 130))
                {
                    this._WSPRMessageType = value;
                }
                else
                {
                    this._WSPRMessageType = 2;      //default to Type 2/3 combo
                }
            }
        }

        public int WSPRTxMod
        {
            get { return this._WSPRTxMod; }
            set
            {
                if (value >= 2 && value <= 60 && value % 2 == 0)
                {
                    this._WSPRTxMod = value;
                }
                else
                {
                    this._WSPRTxMod = 6;      //default to every 6 minutes
                }
            }
        }

        public int WSPRTxModOffset
        {
            get { return this._WSPRTxModOffset; }
            set
            {
                if (value >= 0 && value <= 16 && value % 2 == 0)
                {
                    this._WSPRTxModOffset = value;
                }
                else
                {
                    this._WSPRTxModOffset = 0;      //default to 0
                }
            }
        }

        public bool WSPRHourlyReboot
        {
            get { return this._WSPRHourlyReboot; }
            set { this._WSPRHourlyReboot = value; }
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
                    listReturn.Add((byte)(this._StatusXmitSeconds ? 0x31 : 0x30));
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
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._I2cBME280 ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Global Frequency
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._UseGlobalFrequency ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Disable GPS during Xmit
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisableGPSDuringXmit ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Hourly Reboot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._HourlyReboot ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Beacon Mode 4 Configurations
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshGPS.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshXmit.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._MinTimeBetweenXmits.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._DelayXmitUntilGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x04);       //end of file
                    break;

                case "PT0101":      //ptSolar Configuration
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);


                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0101")));
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

                    //Beacon Mode 4 Configurations
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshGPS.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._VoltThreshXmit.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._MinTimeBetweenXmits.ToString())));
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
                    listReturn.Add((byte)(this._StatusXmitSeconds ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._StatusXmitCustom ? 0x31 : 0x30));
                    listReturn.Add(0x09);

                    //Radio Settings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioTxDelay.ToString())));
                    listReturn.Add(0x09);
                    listReturn.Add((byte)(this._RadioCourtesyTone ? 0x31 : 0x30));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqTx.PadRight(8))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._RadioFreqRx.PadRight(8))));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._UseGlobalFrequency ? "1" : "0")));
                    listReturn.Add(0x09);


                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._AnnounceMode.ToString())));
                    listReturn.Add(0x09);

                    //i2c Configurations
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._I2cBME280 ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Disable GPS during Xmit
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._DisableGPSDuringXmit ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Hourly Reboot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._HourlyReboot ? "1" : "0")));
                    listReturn.Add(0x09);

                    //Delay Xmit until GPS Fix                    
                    listReturn.Add((byte)(this._DelayXmitUntilGPSFix ? 0x31 : 0x30));
                    listReturn.Add(0x04);       //end of file
                    break;


                case "PT0200":      //ptSolarHF WSPR Configuration
                    listReturn.AddRange(new List<byte>(0x01));       //start of "header"
                    listReturn.Add(0x01);

                    //Configuration version data
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes("PT0200")));
                    listReturn.Add(0x09);

                    //Callsign
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRCallsign)));    //Don't pad the callsign - it must terminate in a null after callsign
                    listReturn.Add(0x09);

                    ////For WSPR, it is important that the
                    //var bytes = System.Text.Encoding.ASCII.GetBytes(this._WSPRCallsign);
                    //if (bytes.Length > 10) Array.Resize(ref bytes, 10);

                    //var padded = new byte[10];
                    //Buffer.BlockCopy(bytes, 0, padded, 0, bytes.Length); // rest are 0x00 by default

                    //listReturn.AddRange(padded);


                    //Voltage thresholds
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRVoltThreshGPS.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRVoltThreshXmit.ToString())));
                    listReturn.Add(0x09);

                    //Transmit Frequencies
                    int freqHz;
                    freqHz = (int)(this.WSPRFrequencyTx1 * 1000000.0);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(freqHz.ToString())));
                    listReturn.Add(0x09);

                    freqHz = (int)(this.WSPRFrequencyTx2 * 1000000.0);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(freqHz.ToString())));
                    listReturn.Add(0x09);

                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRToneOffset.ToString())));
                    listReturn.Add(0x09);

                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRCorrection.ToString())));
                    listReturn.Add(0x09);

                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRFineAltitudeModulation.ToString())));
                    listReturn.Add(0x09);

                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRAnnounceMode.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRMessageType.ToString())));
                    listReturn.Add(0x09);

                    //Transmit Timings
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRTxMod.ToString())));
                    listReturn.Add(0x09);
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRTxModOffset.ToString())));
                    listReturn.Add(0x09);


                    //Hourly Reboot
                    listReturn.AddRange(new List<byte>(System.Text.Encoding.UTF8.GetBytes(this._WSPRHourlyReboot ? "1" : "0")));
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
                            this.StatusXmitSeconds = (aryStrIn[32] == "1" ? true : false);
                            this.StatusXmitCustom = (aryStrIn[33] == "1" ? true : false);

                            //Radio Settings
                            this.RadioType = Convert.ToInt32(aryStrIn[34]);
                            this.RadioTxDelay = Convert.ToInt32(aryStrIn[35]);
                            this.RadioCourtesyTone = (aryStrIn[36] == "1" ? true : false);
                            this.RadioFreqTx = aryStrIn[37];
                            this.RadioFreqRx = aryStrIn[38];


                            //GPS Serial Settings
                            this.GPSSerialBaud = Convert.ToInt32(aryStrIn[39]);
                            this.GPSSerialInvert = (aryStrIn[40] == "1" ? true : false);
                            this.GPSType = Convert.ToInt32(aryStrIn[41]);

                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[42]);

                            //i2c Configurations
                            this.I2cBME280 = (aryStrIn[43] == "1" ? true : false);

                            //Global Frequency
                            this.UseGlobalFrequency = (aryStrIn[44] == "1" ? true : false);

                            //Disable GPS during Xmit
                            this.DisableGPSDuringXmit = (aryStrIn[45] == "1" ? true : false);

                            //Hourly Reboot
                            this.HourlyReboot = (aryStrIn[46] == "1" ? true : false);

                            //Beacon Mode 4 Configurations
                            this.VoltThreshGPS = Convert.ToInt32(aryStrIn[47]);
                            this.VoltThreshXmit = Convert.ToInt32(aryStrIn[48]);
                            this.MinTimeBetweenXmits = Convert.ToInt32(aryStrIn[49]);
                            this.DelayXmitUntilGPSFix = (aryStrIn[50] == "1" ? true : false);

                        }
                        catch { }

                        break;
                    case "PT0101":      //ptSolar/ptFlex Configuration
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

                            //beacon type 0 - simple delay
                            this.BeaconSimpleDelay = Convert.ToInt32(aryStrIn[13]);

                            //beacon type 1 - speed
                            this.BeaconSpeedThreshLow = Convert.ToInt32(aryStrIn[14]);
                            this.BeaconSpeedThreshHigh = Convert.ToInt32(aryStrIn[15]);
                            this.BeaconSpeedDelayLow = Convert.ToInt32(aryStrIn[16]);
                            this.BeaconSpeedDelayMid = Convert.ToInt32(aryStrIn[17]);
                            this.BeaconSpeedDelayHigh = Convert.ToInt32(aryStrIn[18]);

                            //beacon type 2 - altitude
                            this.BeaconAltitudeThreshLow = Convert.ToInt32(aryStrIn[19]);
                            this.BeaconAltitudeThreshHigh = Convert.ToInt32(aryStrIn[20]);
                            this.BeaconAltitudeDelayLow = Convert.ToInt32(aryStrIn[21]);
                            this.BeaconAltitudeDelayMid = Convert.ToInt32(aryStrIn[22]);
                            this.BeaconAltitudeDelayHigh = Convert.ToInt32(aryStrIn[23]);

                            //beacon type 3 - time slots
                            this.BeaconSlot1 = Convert.ToInt32(aryStrIn[24]);
                            this.BeaconSlot2 = Convert.ToInt32(aryStrIn[25]);

                            //Beacon Mode 4 Configurations
                            this.VoltThreshGPS = Convert.ToInt32(aryStrIn[26]);
                            this.VoltThreshXmit = Convert.ToInt32(aryStrIn[27]);
                            this.MinTimeBetweenXmits = Convert.ToInt32(aryStrIn[28]);

                            //Status message
                            this.StatusMessage = aryStrIn[29];

                            //Misc flags
                            this.StatusXmitGPSFix = (aryStrIn[30] == "1" ? true : false);
                            this.StatusXmitBurstAltitude = (aryStrIn[31] == "1" ? true : false);
                            this.StatusXmitBatteryVoltage = (aryStrIn[32] == "1" ? true : false);
                            this.StatusXmitTemp = (aryStrIn[33] == "1" ? true : false);
                            this.StatusXmitPressure = (aryStrIn[34] == "1" ? true : false);
                            this.StatusXmitSeconds = (aryStrIn[35] == "1" ? true : false);
                            this.StatusXmitCustom = (aryStrIn[36] == "1" ? true : false);

                            //Radio Settings
                            this.RadioTxDelay = Convert.ToInt32(aryStrIn[37]);
                            this.RadioCourtesyTone = (aryStrIn[38] == "1" ? true : false);
                            this.RadioFreqTx = aryStrIn[39];
                            this.RadioFreqRx = aryStrIn[40];
                            this.UseGlobalFrequency = (aryStrIn[41] == "1" ? true : false); //Global Frequency

                            //Announce Mode
                            this.AnnounceMode = Convert.ToInt32(aryStrIn[42]);

                            //i2c Configurations
                            this.I2cBME280 = (aryStrIn[43] == "1" ? true : false);

                            //Disable GPS during Xmit
                            this.DisableGPSDuringXmit = (aryStrIn[44] == "1" ? true : false);

                            //Hourly Reboot
                            this.HourlyReboot = (aryStrIn[45] == "1" ? true : false);

                            //Wait up to 50 seconds for GPS Fix before transmitting
                            this.DelayXmitUntilGPSFix = (aryStrIn[46] == "1" ? true : false);

                        }
                        catch { }

                        break;
                    case "PT0200":      //ptSolarHF WSPR Configuration
                        try
                        {
                            this.ConfigVersion = aryStrIn[0];
                            this.WSPRCallsign = aryStrIn[1];
                            this.WSPRVoltThreshGPS = Convert.ToInt32(aryStrIn[2]);
                            this.WSPRVoltThreshXmit = Convert.ToInt32(aryStrIn[3]);
                            this.WSPRFrequencyTx1 = Convert.ToDouble(aryStrIn[4]) / 1000000.0;
                            this.WSPRFrequencyTx2 = Convert.ToDouble(aryStrIn[5]) / 1000000.0;
                            this.WSPRToneOffset = Convert.ToInt32(aryStrIn[6]);
                            this.WSPRFineAltitudeModulation = (aryStrIn[7] == "1" ? true : false);
                            this.WSPRCorrection = Convert.ToInt32(aryStrIn[8]);
                            this.WSPRAnnounceMode = Convert.ToInt32(aryStrIn[9]);
                            this.WSPRMessageType = Convert.ToInt32(aryStrIn[10]);
                            this.WSPRTxMod = Convert.ToInt32(aryStrIn[11]);
                            this.WSPRTxModOffset = Convert.ToInt32(aryStrIn[12]);
                            this.HourlyReboot = (aryStrIn[13] == "1" ? true : false);       //Hourly Reboot
                        }
                        catch
                        {
                        }

                        break;
                }
            }
        }
    }
}

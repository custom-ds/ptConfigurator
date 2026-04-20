# ptConfigurator

## Overview

The ptConfigurator serves as the software utility for configuring settings stored in non-volatile EEPROM on ptFlex and ptSolar flight controllers. Users should download and install it on a Windows PC before launching.

## Setup Instructions

### Selecting the Communication Port

From the dropdown menu at the top of the window, choose the COM port corresponding to your TTL-level serial configuration cable. If the port doesn't appear, click the blue refresh button to rescan available ports.

### Connecting the Cable

Connect the configuration cable to the tracker, paying careful attention to cable orientation. The black ground wire must align with the "GND" marking on the circuit board.

### Downloading Current Configuration

1. Select your port
2. Press the blue down-arrow (Download) button
3. Immediately press the reset button on the flight controller (only applicable for the older ArduinoTrack boards)
4. The existing EEPROM configuration will display across the Configurator tabs

### Making Adjustments and Uploading

After modifying settings as needed, press the up-arrow (Upload) button to save your configuration back to the controller.

## Download

Download the latest installer from the [Releases](https://github.com/custom-ds/ptConfigurator/releases/latest) page. Under **Assets**, download `ptConfigurator.msi`.

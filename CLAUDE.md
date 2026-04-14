# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Project Is

ptConfigurator is a Windows Forms configuration utility for the Project: Traveler (PT) series APRS/WSPR radio tracker hardware. It connects to tracker devices over serial/USB, reads and writes binary configuration packets, and exposes those settings through a tabbed GUI.

Supported devices:
- **PT0002** – legacy APRS tracker
- **PT0100 / PT0101** – ptSolar board variant
- **PT0200** – ptSolarHF tracker (WSPR support)

## Build

This is a .NET Framework 4.8 Windows Forms application. Open `ptConfigurator.sln` in Visual Studio and press F7 (Build Solution), or from the command line:

```
msbuild ptConfigurator.sln /p:Configuration=Release
```

Output: `ptConfigurator\bin\Release\ptConfigurator.exe`

There are no unit tests — testing is manual via the GUI with real hardware or simulated serial input.

## Architecture

### Key Classes

| File | Role |
|------|------|
| `Program.cs` | Entry point; single-instance mutex; exposes static `ATConfig` (Configurator) and `ATSerialData` (SerialData) globals; file-based error logging |
| `Configurator.cs` | **Central data model** — all device configuration properties; `EncodeConfigString()` serializes to binary for transmission; `DecodeConfigString()` parses binary responses; branching logic for each config version |
| `SerialData.cs` | Serial port I/O; maintains a FIFO history buffer of raw bytes from the device |
| `frmMain.cs` | Primary tabbed UI; event handlers sync UI controls ↔ `Program.ATConfig`; toolbar actions trigger read/write operations |

### Data Flow

1. UI events (TextChanged, SelectedIndexChanged, Leave) update `Program.ATConfig` properties
2. "Read Config" toolbar button: serial read → `SerialData` buffer → `Configurator.DecodeConfigString()` → populate UI
3. "Write Config" toolbar button: `Configurator.EncodeConfigString()` → binary packet → serial write to device

### Config Version Branching

`Configurator.configVersion` drives all version-specific behavior. When adding support for a new hardware revision, trace the version switch/if-else chains in `EncodeConfigString()` and `DecodeConfigString()` — both must stay in sync with each other and with the firmware's expected packet layout.

### UI Structure

`frmMain` uses a tab control:
1. **Basic APRS** — callsign, destination, path, symbol
2. **Beacon Types** — beacon mode (simple / speed / altitude / time-slot / low-power) and its parameters
3. **Status Message** — status text and what telemetry to include
4. **Radio** — radio type, TX frequency, TX delay, courtesy tone
5. **WSPR** — WSPR callsign, dual TX frequencies, tone offset, altitude modulation, frequency correction

Controls related to the currently-selected beacon type are shown/hidden dynamically on tab 2.

## Conventions

- **Form prefix**: `frm` (e.g., `frmMain`, `frmConsole`)
- **Control prefixes**: `txt` TextBox, `cmbo` ComboBox, `rad` RadioButton, `lbl` Label, `btn` Button, `tool` ToolStripButton
- **Private fields**: `_PascalCase` (e.g., `_Callsign`, `_BeaconType`)
- **Validation** lives in property setters inside `Configurator` — use regex and range checks there, not in the form
- **Error logging**: `Program.writeToProgramLog()` writes to `%APPDATA%\ptConfigurator\Logs\Error Log.txt`
- **COM port enumeration** uses WMI (`System.Management`) to get human-readable port descriptions alongside the port name
- No external NuGet packages — only .NET Framework 4.8 BCL

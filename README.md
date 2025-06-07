# SelfishNetV3

Control your internet bandwidth with SelfishNet v3.
[Currently in development]

It features an updated graphical interface.

## Prerequisites

To build and run SelfishNetV3 from source, you will need:

- **Microsoft Visual Studio:** A version capable of opening `.sln` files and building C# projects targeting .NET Framework 3.5 (e.g., Visual Studio 2010-2015 or newer versions with relevant components installed).
- **Npcap:** This is required for packet capture. WinPcap, mentioned in older project documentation, is deprecated and no longer maintained. Npcap is the recommended modern alternative.
    - Download Npcap from [https://npcap.com/](https://npcap.com/).
    - **Important:** During installation, ensure you select the "WinPcap API-compatible mode" option.
- **Compatible Wi-Fi Chipset:** Your Wi-Fi chipset must support monitor mode for some features to work.

## Building from Source

1.  **Navigate to the repository's root directory:**
    Ensure your terminal is in the root directory of the cloned SelfishNetV3 repository.
2.  **Open the solution:**
    Open the `SelfishNetv3.sln` file in Visual Studio.
3.  **Configure the build:**
    - Select the **Debug** configuration from the Solution Configurations dropdown (usually found in the toolbar).
    - Ensure the platform is set to **x86**. The project targets .NET Framework 3.5 and uses x86-specific libraries (like PcapNet.dll). While the `Debug` configuration for `AnyCPU` platform in this project defaults to `x86`, explicitly selecting `x86` for the Solution Platform is good practice.
4.  **Build the project:**
    - In Visual Studio, right-click on the `SelfishNetV3` project in the Solution Explorer.
    - Select **Build** (or **Rebuild**).
5.  **Locate the executable:**
    - After a successful build, the main executable `SelfishNetv3.exe` will be located in the following directory:
      `SelfishNetV3\bin\Debug\SelfishNetv3.exe\SelfishNetv3.exe`
    - Note the nested `SelfishNetv3.exe` folder in the path.

## Dependency Handling

- **Core Libraries (DLLs):**
  The necessary DLL files (`DataGridViewNumericUpDownElements.dll`, `ExpandableGridView.dll`, `PcapNet.dll`) are located in the `LIB` folder at the root of the repository. These are referenced by the project and should be automatically copied to the output directory (`SelfishNetV3\bin\Debug\SelfishNetv3.exe\`) by Visual Studio (MSBuild) during the build process. You do not need to copy these manually.

- **Font (Computerfont.ttf):**
  The application uses a specific font, `Computerfont.ttf`, which is also found in the `LIB` folder. For the application to display correctly when built from source, copy `Computerfont.ttf` from the `LIB` folder to the application's output directory:
  `SelfishNetV3\bin\Debug\SelfishNetv3.exe\`

- **Packet Driver (npf.sys):**
  The `npf.sys` file is the core packet capture driver. This driver is installed as part of **Npcap** (which replaced the older WinPcap). You do **not** need to copy the `npf.sys` file from the `LIB` folder. The version in the `LIB` folder was likely included for the legacy installer or for reference. Ensure Npcap is installed correctly as per the 'Prerequisites' section.

## Current Functions
- Mac Spoofing.
- See how many devices are connected to your network.
- Check the IP's and Mac addresses of the devices on your network.
- Easily control the internet bandwidth of each device connected to your network.
- Block devices from your network.

## Future Functions
- Mac addresses database.


![alt tag](https://i.imgur.com/rKbZLld.png)

![alt tag](https://i.imgur.com/vGtqzBV.png)
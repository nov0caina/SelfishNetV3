# macOS SelfishNet-like Prototypes

## Introduction

This repository contains Python-based prototype scripts that demonstrate functionalities similar to SelfishNet, focusing on network device discovery, ARP spoofing, and traffic control on macOS. These scripts were developed as a proof-of-concept and for educational purposes to explore macOS networking capabilities.

**These are prototypes and not a full port of SelfishNetV3.** For production use, a more robust implementation in a language like C or Swift using `libpcap` directly would be recommended for performance and efficiency.

## Scripts

1.  **`macos_selfishnet_poc.py`**:
    *   Network interface listing and selection.
    *   ARP scan for device discovery on the local network.
2.  **`mitm_prototype.py`**:
    *   ARP spoofing between a target device and the gateway.
    *   Packet forwarding for the spoofed traffic.
    *   Basic traffic blocking capability.
    *   ARP table restoration upon exit.

## Features (Prototypes)

*   List available network interfaces.
*   Discover devices (IP and MAC addresses) on the local network via ARP scan.
*   Perform ARP spoofing to position the script's host as a Man-in-the-Middle (MitM).
*   Forward IP packets between the target and gateway.
*   Simulate blocking of traffic for a target device.
*   Attempt to restore ARP tables upon script termination.

## Disclaimer & Ethical Warning

**WARNING:** These tools can be used to intercept and manipulate network traffic. Unauthorized use of such tools on networks you do not own or have explicit permission to test is illegal and unethical. These scripts are provided for educational and research purposes only. The user assumes all responsibility for any actions performed using these scripts. Always respect privacy and obtain proper authorization before testing on any network.

## Prerequisites

*   **macOS:** These scripts are intended for macOS.
*   **Python 3:** Ensure Python 3 is installed.
*   **Scapy:** The Scapy library is used for packet manipulation.
*   **Root Privileges:** These scripts require root privileges to perform raw socket operations (packet sniffing and injection).
*   **libpcap development libraries:** Scapy might require `libpcap` headers. On some systems, you might need to install `libpcap-dev` or ensure XCode Command Line Tools are installed (which usually include libpcap).

## Installation

1.  **Clone the repository (if applicable).**
2.  **Install Python 3:** If not already installed, download from [python.org](https://www.python.org) or use Homebrew.
3.  **Install Scapy:**
    ```bash
    sudo pip3 install scapy
    ```
    If you encounter issues during Scapy installation, especially related to `libpcap`, ensure you have the necessary development tools. For macOS, installing Xcode Command Line Tools (`xcode-select --install`) often resolves this.

## Usage Instructions

**Always run these scripts with `sudo python3`.**

### 1. `macos_selfishnet_poc.py` (Device Discovery PoC)

This script helps you discover devices on your local network.

```bash
sudo python3 macos_selfishnet_poc.py
```

**Execution:**
1.  The script will list available network interfaces with their details.
2.  It will prompt you to choose an interface by name (e.g., `en0`).
3.  After selecting an interface, it will perform an ARP scan on that network.
4.  Finally, it will print a list of discovered devices (IP and MAC addresses).

### 2. `mitm_prototype.py` (ARP Spoofing & Traffic Control Prototype)

This script performs ARP spoofing and allows basic traffic control.

```bash
sudo python3 mitm_prototype.py
```

**Execution:**
1.  The script will prompt you for:
    *   The network interface to use (e.g., `en0`).
    *   The IP address of the **target device** (the device whose traffic you want to control).
    *   The IP address of the **gateway/router**.
2.  It will then attempt to resolve the MAC addresses for the target and gateway.
3.  If successful, it will start ARP spoofing, displaying details of the attacker, target, and gateway.
4.  Packets between the target and gateway will now be routed through the machine running the script.
    *   The script will print messages when it forwards or (conceptually) blocks packets.
    *   The `is_blocked` variable in the script can be manually changed if you wish to test blocking (default is `False`).
5.  Press `Ctrl+C` to stop the script. This will trigger ARP restoration to try and fix the ARP tables of the target and gateway.

## Important Notes

*   **Host IP Forwarding:**
    *   For `mitm_prototype.py` to correctly control and forward traffic itself, IP forwarding should generally be **disabled** on the machine running the script.
    *   On macOS, you can check forwarding status with: `sysctl net.inet.ip.forwarding`
    *   To disable: `sudo sysctl -w net.inet.ip.forwarding=0`
    *   To enable: `sudo sysctl -w net.inet.ip.forwarding=1`
    *   If IP forwarding is enabled on the host, the OS might forward packets independently of the script, which could interfere with the script's intended traffic manipulation (especially for blocking/limiting).
*   **Network Impact:** ARP spoofing can be disruptive to a network if not handled correctly or if the script terminates unexpectedly without restoring ARP tables. Use with caution.
*   **Wireless Networks:** ARP spoofing effectiveness can vary on wireless networks, especially those with client isolation features.
*   **Performance:** These Python/Scapy prototypes are not optimized for high-performance packet processing. Significant traffic loads might lead to packet loss or high latency.

## Future Development (Beyond Prototypes)

For a more feature-rich and performant tool, development would typically involve:
*   Rewriting the core logic in C or Swift using `libpcap` directly.
*   Developing a native macOS GUI.
*   Implementing more sophisticated bandwidth shaping algorithms.
*   Adding features like MAC address database, hostname resolution, etc.

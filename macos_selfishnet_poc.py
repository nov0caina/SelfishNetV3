#!/usr/bin/env python3

# macos_selfishnet_poc.py
#
# Proof-of-concept for network device discovery and ARP packet sending using Scapy.
# IMPORTANT: This script requires root privileges to send/receive raw packets.
# Run with sudo: sudo python3 macos_selfishnet_poc.py

try:
    from scapy.all import conf, get_if_list, get_if_addr, get_if_hwaddr, Ether, ARP, srp, send
    from scapy.arch import get_if_addr, get_if_hwaddr, get_if_list # For macOS compatibility
    import ipaddress
except ImportError:
    print("Scapy library is not installed. Please install it first.")
    print("You can typically install it using: pip3 install scapy")
    print("If you are using a virtual environment, activate it before installing.")
    exit(1)

def list_interfaces():
    """Lists available network interfaces with their details."""
    print("Available Interfaces:")
    interfaces = []
    # Filter out loopback and tunnel interfaces for clarity in this PoC
    # Scapy's get_if_list() provides names, but we need more details
    # We'll iterate through all interfaces known to the system via Scapy's conf.ifaces

    # Using scapy's internal interface list which is more comprehensive
    # for iface_name in get_if_list(): # This often gives limited results or just names

    # Using conf.ifaces which holds more detailed interface objects
    # We need to ensure this is populated correctly. Sometimes a call to update_interfaces() is needed
    # However, direct iteration over conf.ifaces.data should work if Scapy has initialized correctly.

    # On macOS, it's often better to use scapy.arch.get_if_list() for names
    # and then get details for those specific names.

    idx = 1
    if not conf.ifaces or len(conf.ifaces.data) == 0:
        print("Scapy could not list interfaces. Trying to refresh.")
        conf.route.resync() # Try to resync routing table which might populate interfaces

    # Iterate through scapy's known interfaces
    # The `conf.ifaces` object holds interface information.
    # Each key in `conf.ifaces.data` can be an interface name or index.
    # We want to get the name, IP, and MAC for each.

    # Scapy's cross-platform way to get detailed interface info can be tricky.
    # `get_if_list()` returns names. `get_if_addr(name)`, `get_if_hwaddr(name)` get details.

    iface_names = get_if_list()

    for if_name in iface_names:
        ip_addr = get_if_addr(if_name)
        mac_addr = get_if_hwaddr(if_name)

        # We are interested in interfaces that have both IP and MAC addresses
        # and are not loopback (typically 'lo0' on macOS)
        if ip_addr and mac_addr and ip_addr != "0.0.0.0" and mac_addr != "00:00:00:00:00:00":
            # Filter out common loopback and non-ethernet interfaces for this PoC
            if not if_name.startswith("lo") and not if_name.startswith("gif") and not if_name.startswith("stf"):
                 interfaces.append({'name': if_name, 'ip': ip_addr, 'mac': mac_addr})

    if not interfaces:
        print("No suitable network interfaces found or Scapy is unable to access them.")
        print("Make sure you are running the script with root privileges (sudo).")
        print("Scapy's interface detection might also need Npcap/WinPcap (Windows) or libpcap (macOS/Linux).")
        return None

    for i, iface in enumerate(interfaces, 1):
        print(f"{i}: {iface['name']} ({iface['ip']}, {iface['mac']})")

    while True:
        try:
            choice = input("Choose interface (e.g., en0): ").strip()
            # Find the chosen interface in our collected list
            selected_iface_details = next((iface for iface in interfaces if iface['name'] == choice), None)
            if selected_iface_details:
                # Set scapy's default interface
                conf.iface = choice # Critical for srp to use the right interface
                return selected_iface_details
            else:
                print("Invalid interface name. Please choose from the list.")
        except ValueError:
            print("Invalid input.")
        except Exception as e:
            print(f"An error occurred: {e}")
            return None

def get_network_range(ip_addr_str, netmask_str):
    """Determines the network range (e.g., 192.168.1.0/24) from IP and netmask."""
    try:
        # Create a network interface object
        iface_obj = ipaddress.ip_interface(f"{ip_addr_str}/{netmask_str}")
        # Get the network object
        network_obj = iface_obj.network
        return str(network_obj)
    except ValueError as e:
        print(f"Error calculating network range: {e}")
        print(f"IP: {ip_addr_str}, Mask: {netmask_str}")
        # Fallback for common /24 if netmask is problematic or typical home network
        if ip_addr_str and ip_addr_str.count('.') == 3:
             base_ip = ".".join(ip_addr_str.split('.')[:3]) + ".0/24"
             print(f"Attempting fallback to {base_ip}")
             return base_ip
        return None


def arp_scan(interface_details, network_cidr):
    """Performs ARP scan on the given network CIDR and interface."""
    if not network_cidr:
        print("Cannot perform ARP scan without a valid network range.")
        return

    print(f"\nScanning {network_cidr} on interface {interface_details['name']}...")

    # Ensure Scapy uses the correct interface for sending packets
    conf.iface = interface_details['name']

    # Craft ARP request packet
    # We are asking "who has" for each IP in our network
    # The destination MAC address in the Ethernet frame is broadcast (ff:ff:ff:ff:ff:ff)
    arp_request = Ether(dst="ff:ff:ff:ff:ff:ff")/ARP(pdst=network_cidr)

    # srp sends packets at layer 2 (Ethernet) and returns answered and unanswered packets
    # timeout is in seconds
    # verbose=False to suppress Scapy's own output for each packet sent/received
    answered, unanswered = srp(arp_request, timeout=2, verbose=False)

    print("Discovered devices:")
    if answered:
        for sent_packet, received_packet in answered:
            # received_packet[ARP].psrc is the IP address of the respondent
            # received_packet[ARP].hwsrc is the MAC address of the respondent
            print(f"{received_packet[ARP].psrc} - {received_packet[ARP].hwsrc}")
    else:
        print("No devices found on the network via ARP scan.")
        print("This could be due to firewall settings, the network being empty,")
        print("or issues with packet sniffing permissions (run as root).")

def specific_arp_request(interface_name):
    """Sends a single ARP 'who-has' request to a user-specified IP."""
    target_ip = input("Enter target IP for ARP request (e.g., 192.168.1.1): ").strip()
    if not target_ip:
        print("No target IP entered.")
        return

    print(f"\nSending ARP request to {target_ip} via {interface_name}...")

    # Ensure Scapy uses the correct interface
    conf.iface = interface_name

    # Craft ARP request for the specific IP
    # Ether()/ARP() is a common way to build it.
    # pdst is the protocol destination address (the IP we're querying)
    # hwdst can be '00:00:00:00:00:00' for requests, or ff:ff:ff:ff:ff:ff for broadcast ethernet frame
    arp_pkt = Ether(dst="ff:ff:ff:ff:ff:ff")/ARP(pdst=target_ip)

    # Send the packet at layer 2. sendp for layer 2, send for layer 3
    # We expect a reply, but for this function, we'll just send.
    # For receiving, srp (send and receive packets) would be used as in the scan.
    send(arp_pkt, verbose=False) # Send at layer 3, scapy will handle layer 2 if iface is set
    # Actually, for ARP, which is layer 2.5, sendp is more appropriate if we specify full Ether frame
    # from scapy.all import sendp
    # sendp(arp_pkt, verbose=False)

    print(f"ARP 'who-has {target_ip}?' packet sent on {interface_name}.")
    print("(Note: This function only sends the request, it does not show the reply.)")


def main():
    print("macOS SelfishNet PoC - Network Scanner")
    print("=" * 40)
    print("NOTE: This script needs root privileges (sudo) to run correctly.")

    selected_interface = list_interfaces()

    if not selected_interface:
        print("Exiting due to interface selection issues.")
        return

    # Determine netmask for the selected interface
    # Scapy's conf.iface object might have netmask info after being set.
    # Let's try to get it from the interface object itself.
    # Note: Scapy's way of getting netmask can be platform-dependent or require Nmap/libpcap correctly configured.

    # A more robust way to get netmask for a specific interface:
    # Iterate through conf.ifaces to find our selected interface by name
    # and then access its netmask attribute.

    iface_obj_for_netmask = None
    for iface_scapy_obj in conf.ifaces:
        if conf.ifaces[iface_scapy_obj].name == selected_interface['name']:
            iface_obj_for_netmask = conf.ifaces[iface_scapy_obj]
            break

    netmask = "255.255.255.0" # Default fallback
    if iface_obj_for_netmask and hasattr(iface_obj_for_netmask, 'netmask') and iface_obj_for_netmask.netmask:
        # Convert netmask from potential integer format (like on Linux for Scapy) to dotted decimal
        # Scapy stores netmask as an IPV4Address object, so we can convert it to string.
        # However, sometimes it might be an int (prefix length).
        # The ipaddress module handles prefix length better.
        # For now, let's assume it's available in a format ipaddress module can use, or use a default.

        # Let's try to get it in a standard way using ipaddress module with the IP
        try:
            # This gets the interface object which includes netmask
            ip_iface = ipaddress.ip_interface(f"{selected_interface['ip']}/{iface_obj_for_netmask.netmask}", strict=False)
            netmask = str(ip_iface.netmask)
        except Exception as e:
            print(f"Could not determine netmask accurately for {selected_interface['name']} using Scapy's data ({iface_obj_for_netmask.netmask}). Error: {e}")
            print("Falling back to default netmask 255.255.255.0. ARP scan might be inaccurate.")
    else:
        print(f"Warning: Could not retrieve netmask for {selected_interface['name']} directly from Scapy's interface object.")
        print("This can happen if Scapy's interface information is incomplete.")
        print("Falling back to default netmask 255.255.255.0. ARP scan might be inaccurate.")
        print("Ensure libpcap is correctly installed and Scapy has permissions.")


    network_to_scan = get_network_range(selected_interface['ip'], netmask)

    if network_to_scan:
        arp_scan(selected_interface, network_to_scan)
    else:
        print("Could not determine network to scan. Aborting ARP scan.")

    # Optional: Test specific ARP request
    print("-" * 40)
    if input("Do you want to send a single ARP request to a specific IP? (y/n): ").lower() == 'y':
        specific_arp_request(selected_interface['name'])

    print("\nScan finished.")

if __name__ == "__main__":
    # Check for root privileges (very basic check, not foolproof)
    import os
    if os.geteuid() != 0:
        print("WARNING: This script typically requires root privileges to perform network sniffing and sending raw packets.")
        print("Please run with 'sudo python3 macos_selfishnet_poc.py'")
        # For a PoC, we might allow it to proceed, but Scapy operations will likely fail.
        # For actual use, exiting might be better:
        # exit("Please run as root.")

    main()

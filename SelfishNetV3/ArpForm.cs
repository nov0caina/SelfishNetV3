using AdvancedDataGridView;
using PcapNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SelfishNetv3
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public delegate void delegateOnNewPC(PC pc);

    public delegate void DelUpdateName(PC pc, string str);
    public partial class ArpForm : Form
    {
     
        public int timerStatCount;
        public Driver driver;
        public PcList pcs;
        public CArp cArp;    
        public CAdapter cAdapter;
        public byte[] routerIP;
        public object[] resolvState;
        public NetworkInterface nicNet;
        public static ArpForm instance;
        public ArpForm()
        {
            InitializeComponent();
            ArpForm.instance = this;
            this.timerStatCount = 0;
            this.driver = new Driver();
        }
        public void licenseAccepted()
        {
            if (!this.driver.create())
            {
                int num = (int)MessageBox.Show("problem installing the drivers, do you have administrator privileges?");
                if (this == null)
                    return;
                this.Dispose();
            }
            else
            {
                CAdapter cadapter = new CAdapter();
                this.cAdapter = cadapter;
                cadapter.Show((IWin32Window)this);
            }
        }
        public void NicIsSelected(NetworkInterface nic)
        {
            this.pcs = new PcList();
            this.pcs.SetCallBackOnNewPC(new delegateOnNewPC(this.callbackOnNewPC));
            this.pcs.SetCallBackOnPCRemove(new delegateOnNewPC(this.callbackOnPCRemove));
            this.nicNet = nic;
            CArp carp = new CArp(nic, this.pcs);
            this.cArp = carp;
            carp.startArpListener();
            this.cArp.findMacRouter();
            PC pc = new PC();
            pc.ip = new IPAddress(this.cArp.localIP);
            pc.mac = new PhysicalAddress(this.cArp.localMAC);
            pc.capDown = 0;
            pc.capUp = 0;
            pc.isLocalPc = true;
            pc.name = string.Empty;
            pc.nbPacketReceivedSinceLastReset = 0;
            pc.nbPacketSentSinceLastReset = 0;
            pc.redirect = false;
            DateTime now = DateTime.Now;
            pc.timeSinceLastRarp = (ValueType)now;
            pc.totalPacketReceived = 0;
            pc.totalPacketSent = 0;
            pc.isGateway = false;
            this.pcs.addPcToList(pc);
            this.timer2.Interval = 5000;
            this.timer2.Start();
            this.treeGridView1.Nodes[0].Expand();
        }

        [Obsolete]
        private void callbackOnNewPC(PC pc)
        {
            object[] objArray = new object[1] { (object)pc };
            ArpForm arpForm = this;
            arpForm.Invoke((Delegate)new delegateOnNewPC(arpForm.AddPc), objArray);
            Dns.BeginResolve(pc.ip.ToString(), new AsyncCallback(this.EndResolvCallBack), pc);
        }

        [Obsolete]
        private void EndResolvCallBack(IAsyncResult re)
        {
            string str = (string)null;
            PC asyncState = (PC)re.AsyncState;
            try
            {
                str = Dns.EndResolve(re).HostName;
              if (str == (string)null)
                str = "noname";
            object[] objArray = new object[2];
            this.resolvState = objArray;
            objArray[0] = (object)asyncState;
            this.resolvState[1] = (object)str;
            this.Invoke((Delegate)new DelUpdateName(this.updateTreeViewNameCallBack), this.resolvState);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }

        private void updateTreeViewNameCallBack(PC pc, string str)
        {
            if (pc.isGateway)
            {
                this.treeGridView1.Nodes[0].Cells[0].Value = (object)str;
                this.treeGridView1.Nodes[0].ImageIndex = 1;
            }
            else
            {
                int index = 1;
                if (1 >= this.treeGridView1.Nodes[0].Nodes.Count)
                    return;
                while (this.treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString().CompareTo(pc.ip.ToString()) != 0)
                {
                    ++index;
                    if (index >= this.treeGridView1.Nodes[0].Nodes.Count)
                        return;
                }
                this.treeGridView1.Nodes[0].Nodes[index].Cells[0].Value = (object)str;
            }
        }

        private void callbackOnPCRemove(PC pc)
        {
            int index = 1;
            if (1 >= this.treeGridView1.Nodes[0].Nodes.Count)
                return;
            while (this.treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString().CompareTo(pc.ip.ToString()) != 0)
            {
                ++index;
                if (index >= this.treeGridView1.Nodes[0].Nodes.Count)
                    return;
            }
            this.treeGridView1.Nodes[0].Nodes.RemoveAt(index);
        }

        private void AddPc(PC pc)
        {
            if (pc.isGateway)
            {
                this.treeGridView1.Nodes[0].Cells[1].Value = (object)pc.ip.ToString();
                this.treeGridView1.Nodes[0].Cells[2].Value = (object)pc.mac.ToString();
                this.treeGridView1.Nodes[0].Cells[5].ReadOnly = true;
                this.treeGridView1.Nodes[0].Cells[6].ReadOnly = true;
                this.treeGridView1.Nodes[0].Cells[7].ReadOnly = true;
                this.treeGridView1.Nodes[0].Cells[8].ReadOnly = true;
                this.treeGridView1.Nodes[0].Cells[5].Value = (object)0;
                this.treeGridView1.Nodes[0].Cells[6].Value = (object)0;
                this.treeGridView1.Nodes[0].Cells[7].ReadOnly = true;
                this.treeGridView1.Nodes[0].Cells[8].ReadOnly = true;
            }
            else if (pc.isLocalPc)
            {
                TreeGridNode treeGridNode = this.treeGridView1.Nodes[0].Nodes.Add((object)"Your PC", (object)pc.ip, (object)pc.mac.ToString());
                treeGridNode.ImageIndex = 0;
                treeGridNode.Cells[5].Value = (object)0;
                treeGridNode.Cells[6].Value = (object)0;
                treeGridNode.Cells[5].ReadOnly = true;
                treeGridNode.Cells[6].ReadOnly = true;
                treeGridNode.Cells[7].Value = (object)false;
                treeGridNode.Cells[8].Value = (object)false;
                treeGridNode.Cells[7].ReadOnly = true;
                treeGridNode.Cells[8].ReadOnly = true;
            }
            else
            {
                TreeGridNode treeGridNode = this.treeGridView1.Nodes[0].Nodes.Add((object)string.Empty, (object)pc.ip, (object)pc.mac.ToString(), (object)string.Empty, (object)string.Empty, (object)0, (object)0, (object)false, (object)true);
                treeGridNode.ImageIndex = 0;
                treeGridNode.Cells[5].ReadOnly = false;
                treeGridNode.Cells[6].ReadOnly = false;
            }
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.cArp.startArpDiscovery();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.toolStripButton2.Checked)
                return;
            this.cArp.startRedirector();
            this.toolStripButton2.Checked = true;
            this.timer1.Interval = 1000;
            this.timer1.Start();
            this.timerSpoof.Start();
            this.timerSpoof.Interval = 2000;
            this.toolStripButton2.Checked = true;
            this.toolStripButton2.Enabled = false;
            this.timerDiscovery.Start();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (!this.toolStripButton2.Checked)
                return;
            this.cArp.stopRedirector();
            this.cArp.completeUnspoof();
            this.timer1.Stop();
            this.timerSpoof.Stop();
            int index = 0;
            if (0 < this.treeGridView1.Nodes[0].Nodes.Count)
            {
                do
                {
                    this.treeGridView1.Nodes[0].Nodes[index].Cells[3].Value = (object)string.Empty;
                    this.treeGridView1.Nodes[0].Nodes[index].Cells[4].Value = (object)string.Empty;
                    ++index;
                }
                while (index < this.treeGridView1.Nodes[0].Nodes.Count);
            }
            this.toolStripButton2.Checked = false;
            this.toolStripButton2.Enabled = true;
            this.timerDiscovery.Stop();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("hlpindex.html"))
            {
                Process.Start("hlpindex.html");
            }
            else
            {
                int num = (int)MessageBox.Show("help file is missing !");
            }
        }

        private void TreeGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.treeGridView1.CurrentCell.ColumnIndex < 7 && (this.treeGridView1.CurrentCell.ColumnIndex < 8 || !this.treeGridView1.IsCurrentCellDirty))
                return;
            this.treeGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void TreeGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5 && e.RowIndex >= 2)
                {
                    IPAddress ipAddress = tools.getIpAddress(this.treeGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    if (this.treeGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().CompareTo(string.Empty) != 0)
                    {
                        PC pcFromIp = this.pcs.getPCFromIP(ipAddress.GetAddressBytes());
                        if (pcFromIp != null)
                        {
                            Monitor.Enter((object)pcFromIp);
                            pcFromIp.capDown = Convert.ToInt32(this.treeGridView1.Rows[e.RowIndex].Cells[5].Value) * 1024;
                            Monitor.Exit((object)pcFromIp);
                        }
                    }
                }
                if (e.ColumnIndex == 6 && e.RowIndex >= 2)
                {
                    IPAddress ipAddress = tools.getIpAddress(this.treeGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    if (this.treeGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().CompareTo(string.Empty) != 0)
                    {
                        PC pcFromIp = this.pcs.getPCFromIP(ipAddress.GetAddressBytes());
                        if (pcFromIp != null)
                        {
                            Monitor.Enter((object)pcFromIp);
                            pcFromIp.capUp = Convert.ToInt32(this.treeGridView1.Rows[e.RowIndex].Cells[6].Value) * 1024;
                            Monitor.Exit((object)pcFromIp);
                        }
                    }
                }
                if (e.ColumnIndex == 7 && e.RowIndex >= 2)
                {
                    IPAddress ipAddress = tools.getIpAddress(this.treeGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    if (this.treeGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().CompareTo(string.Empty) != 0)
                    {
                        PC pcFromIp = this.pcs.getPCFromIP(ipAddress.GetAddressBytes());
                        if (pcFromIp != null)
                        {
                            Monitor.Enter((object)pcFromIp);
                            int num = !pcFromIp.redirect ? 1 : 0;
                            pcFromIp.redirect = num != 0;
                            Monitor.Exit((object)pcFromIp);
                        }
                    }
                }
                if (e.ColumnIndex != 8 || e.RowIndex < 2 || this.treeGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().CompareTo(string.Empty) == 0)
                    return;
                IPAddress ipAddress1 = tools.getIpAddress(this.treeGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                if (this.treeGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().CompareTo("False") != 0)
                    return;
                for (int index = 0; index < 35; ++index)
                    this.cArp.UnSpoof(ipAddress1, new IPAddress(this.cArp.routerIP));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private unsafe void ArpForm_Load(object sender, EventArgs e)
        {
            if ((IntPtr)this.driver.openDeviceDriver((sbyte*)(void*)Marshal.StringToHGlobalAnsi("npf")) == IntPtr.Zero)
            {
                if (System.IO.File.Exists("license.txt"))
                {
                    CWizard cwizard = new CWizard();
                    cwizard.Show((IWin32Window)this);
                    Decoder decoder = Encoding.UTF7.GetDecoder();
                    FileStream fileStream = System.IO.File.OpenRead("license.txt");
                    byte[] numArray = new byte[(int)fileStream.Length];
                    fileStream.Read(numArray, 0, (int)fileStream.Length);
                    char[] chars = new char[decoder.GetCharCount(numArray, 0, numArray.Length)];
                    decoder.GetChars(numArray, 0, numArray.Length, chars, 0);
                    cwizard.richTextBox1.Text = new string(chars);
                    fileStream.Close();
                }
                else
                    this.licenseAccepted();
            }
            else
            {
                int num = (int)MessageBox.Show("Driver WinPcap already installed");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ++this.timerStatCount;
            for (int index = 0; index < this.treeGridView1.Nodes[0].Nodes.Count; ++index)
            {
                try
                {
                    PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString()).GetAddressBytes());
                    string str1 = ((float)pcFromIp.nbPacketReceivedSinceLastReset * 0.0009765625f / (float)(this.timer1.Interval / 1000) / (float)this.timerStatCount).ToString();
                    string str2 = ((float)pcFromIp.nbPacketSentSinceLastReset * 0.0009765625f / (float)(this.timer1.Interval / 1000) / (float)this.timerStatCount).ToString();
                    if (str1.Length - str1.IndexOf(".") > 1)
                    {
                        int num = -2 - str1.IndexOf(".");
                        string str3 = str1;
                        str1 = str3.Remove(str3.IndexOf(".") + 1, str1.Length + num);
                    }
                    if (str2.Length - str2.IndexOf(".") > 1)
                    {
                        int num = -2 - str2.IndexOf(".");
                        string str3 = str2;
                        str2 = str3.Remove(str3.IndexOf(".") + 1, str2.Length + num);
                    }
                    this.treeGridView1.Nodes[0].Nodes[index].Cells[3].Value = (object)str1;
                    this.treeGridView1.Nodes[0].Nodes[index].Cells[4].Value = (object)str2;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            this.pcs.ResetAllPacketsCount();
            this.timerStatCount = 0;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            int index1 = 0;
            if (0 < this.treeGridView1.Nodes[0].Nodes.Count)
            {
                do
                {
                    PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index1].Cells[1].Value.ToString()).GetAddressBytes());
                    if (pcFromIp != null && !pcFromIp.isGateway && !pcFromIp.isLocalPc && DateTime.Now.Ticks - ((DateTime)pcFromIp.timeSinceLastRarp).Ticks > 3500000000L)
                    {
                        this.pcs.removePcFromList(pcFromIp);
                        index1 = 0;
                    }
                    ++index1;
                }
                while (index1 < this.treeGridView1.Nodes[0].Nodes.Count);
            }
            int index2 = 0;
            if (0 >= this.treeGridView1.Nodes[0].Nodes.Count)
                return;
            do
            {
                PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index2].Cells[1].Value.ToString()).GetAddressBytes());
                if (pcFromIp != null && DateTime.Now.Ticks - ((DateTime)pcFromIp.timeSinceLastRarp).Ticks > 200000000L)
                    this.cArp.findMac(pcFromIp.ip.ToString());
                ++index2;
            }
            while (index2 < this.treeGridView1.Nodes[0].Nodes.Count);
        }

        private void TimerSpoof_Tick(object sender, EventArgs e)
        {
            this.timerSpoof.Interval = 5000;
            int index = 0;
            if (0 >= this.treeGridView1.Nodes[0].Nodes.Count)
                return;
            do
            {
                if (this.treeGridView1.Nodes[0].Nodes[index].Cells[8].Value.ToString().CompareTo("True") == 0)
                {
                    PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString()).GetAddressBytes());
                    if (!pcFromIp.isLocalPc)
                        this.cArp.Spoof(pcFromIp.ip, new IPAddress(this.cArp.routerIP));
                }
                ++index;
            }
            while (index < this.treeGridView1.Nodes[0].Nodes.Count);
        }

       


        private void ViewMenuIP_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColPCIP.Visible = this.ViewMenuIP.Checked;
        }

        private void ViewMenuMAC_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColPCMac.Visible = this.ViewMenuMAC.Checked;
        }

        private void ViewMenuDownload_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColDownload.Visible = this.ViewMenuDownload.Checked;
        }

        private void ViewMenuUpload_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColUpload.Visible = this.ViewMenuUpload.Checked;
        }

        private void ViewMenuDownloadCap_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColDownCap.Visible = this.ViewMenuDownloadCap.Checked;
        }

        private void ViewMenuUploadCap_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColUploadCap.Visible = this.ViewMenuUploadCap.Checked;
        }



        private void ViewMenuBlock_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColBlock.Visible = this.ViewMenuBlock.Checked;
        }

        private void ViewMenuSpoof_CheckStateChanged(object sender, EventArgs e)
        {
            this.ColSpoof.Visible = this.ViewMenuSpoof.Checked;
        }

        private void SelfishNetTrayIcon_DoubleClick(object sender, EventArgs e)
        {

        }

        private void SelfishNetTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;                      
        }

        private void ArpForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) Hide();
            this.SelfishNetTrayIcon.ShowBalloonTip(2000);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show(this, "Quit?", "Quit", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes) Environment.Exit(0);
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
         
        }      

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
}

using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SelfishNetv3
{
#pragma warning disable  // Falta el comentario XML para el tipo o miembro visible públicamente
    public partial class CAdapter : Form
    {
        private NetworkInterface[] nics;

        private IEnumerator nicsEnum;

        public NetworkInterface selectedNic;

        public bool packetsHaveToBeRedirected;
        public CAdapter()
        {
            InitializeComponent();
            nics = NetworkInterface.GetAllNetworkInterfaces();
            buttonOK.Enabled = false;
            packetsHaveToBeRedirected = false;
            buttonCancel.Text = "Quit";
        }

        private void CAdapter_Load(object sender, EventArgs e)
        {
            this.Icon = SelfishNetv3.Properties.Resources.SN2_result;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(nicsEnum = nics.GetEnumerator()).MoveNext())
            {
                return;
            }
            NetworkInterface networkInterface;
            while (true)
            {
                networkInterface = (NetworkInterface)nicsEnum.Current;
                if (networkInterface.Description.CompareTo(comboBox1.SelectedItem.ToString()) == 0)
                {
                    break;
                }
                if (!nicsEnum.MoveNext())
                {
                    return;
                }
            }
            labelTypeText.Text = ((NetworkInterfaceType)(object)networkInterface.NetworkInterfaceType).ToString();
            int num = 0;
            if (0 < networkInterface.GetIPProperties().UnicastAddresses.Count)
            {
                do
                {
                    if (Convert.ToString(networkInterface.GetIPProperties().UnicastAddresses[num].Address.AddressFamily).EndsWith("V6"))
                    {
                        num++;
                        continue;
                    }
                    labelIpText.Text = networkInterface.GetIPProperties().UnicastAddresses[num].Address.ToString();
                    break;
                }
                while (num < networkInterface.GetIPProperties().UnicastAddresses.Count);
            }
            if (networkInterface.GetIPProperties().GatewayAddresses.Count > 0 && networkInterface.GetIPProperties().GatewayAddresses[0].Address.ToString().CompareTo("0.0.0.0") != 0)
            {
                labelGWText.Text = networkInterface.GetIPProperties().GatewayAddresses[0].Address.ToString();
                buttonOK.Enabled = true;
                selectedNic = networkInterface;
            }
            else
            {
                labelGWText.Text = "No Gateway !";
                buttonOK.Enabled = false;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {


            if (!ArpForm.systemShutdown)
            {

                System.Windows.Forms.DialogResult result = MessageBox.Show("Are you sure you want to close the App?", "Application Closing!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        if (WindowState == FormWindowState.Minimized)
                        {
                            Show();
                        }
                        if (buttonCancel.Text.CompareTo("Quit") == 0)
                        {
                            ((IDisposable)ArpForm.instance).Dispose();
                            return;
                        }
                        ArpForm.instance.Enabled = true;
                        Close();
                        break;
                }

            }
            else
            {
                if (buttonCancel.Text.CompareTo("Quit") == 0)
                {
                    ((IDisposable)ArpForm.instance).Dispose();
                    return;
                }
                ArpForm.instance.Enabled = true;
                Close();

            }








        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            buttonCancel.Text = "Cancel";
            ArpForm.instance.Enabled = true;
            ArpForm.instance.NicIsSelected(selectedNic);
            Close();

        }

        private void CAdapter_Shown(object sender, EventArgs e)
        {
            Opacity = 100;
            ArpForm.instance.Enabled = false;
            (nicsEnum = nics.GetEnumerator()).MoveNext();
            if (((NetworkInterface)nicsEnum.Current).GetIPProperties().GetIPv4Properties().IsForwardingEnabled)
            {
                labelRedirectInfo.Text = "Windows does redirect packet,\n internal redirection will be turned off";
                packetsHaveToBeRedirected = false;
            }
            else
            {
                labelRedirectInfo.Text = "Windows does not redirect packet,\n internal redirection will be turned on";
                packetsHaveToBeRedirected = true;
            }
            nicsEnum.Reset();
            if (nicsEnum.MoveNext())
            {
                do
                {
                    NetworkInterface networkInterface = (NetworkInterface)nicsEnum.Current;
                    if (networkInterface.GetIPProperties().GatewayAddresses.Count > 0 && networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        comboBox1.Items.Add(((NetworkInterface)nicsEnum.Current).Description);
                    }
                }
                while (nicsEnum.MoveNext());
            }
            if (comboBox1.Items.Count > 1)
            {
                int num = 0;
                nicsEnum.Reset();
                if (nicsEnum.MoveNext())
                {
                    do
                    {
                        NetworkInterface networkInterface2 = (NetworkInterface)nicsEnum.Current;
                        if (networkInterface2.GetIPProperties().GatewayAddresses.Count <= 0 || networkInterface2.GetIPProperties().GatewayAddresses[0].Address.ToString().CompareTo("0.0.0.0") == 0)
                        {
                            num++;
                            continue;
                        }
                        comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                        return;
                    }
                    while (nicsEnum.MoveNext());
                }
            }
            if (comboBox1.Items.Count == 1)
            {
                comboBox1.SelectedIndex = 0;
                return;
            }
            MessageBox.Show("No network card with a gateway has been found!");
            ((IDisposable)ArpForm.instance).Dispose();

        }
    }
#pragma warning restore  // Falta el comentario XML para el tipo o miembro visible públicamente
}

using System;
using System.IO;
using System.Windows.Forms;

namespace SelfishNetv0
{
    public partial class CWizard : Form
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public CWizard()

        {
            InitializeComponent();
            ArpForm.instance.Enabled = false;
        }

        private void CWizard_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.CompareTo("Quit") == 0)
            {
                ((IDisposable)ArpForm.instance)?.Dispose();
            }
            else
            {
                if (File.Exists("license.txt"))
                {
                    File.Move("license.txt", "LicenseYouAccepted.txt");
                }
                ArpForm.instance.Enabled = true;
                ArpForm.instance.licenseAccepted();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Text = "Next";
            }
            else
            {
                button1.Text = "Quit";
            }
        }
    }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
}

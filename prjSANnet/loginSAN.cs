using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjSANnet
{
    public partial class loginSAN : Form
    {
        public string user;
        public string passwd;
        public string ipUsed;
        public string ambiente;

        public loginSAN()
        {
            InitializeComponent();
        }

        private void loginToSAN_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;
            string customOutput;

            customOutput = "";
            user = userName.Text;
            passwd = password.Text;

            cmdRun = "version";
            strCmdText = "-ssh -batch " + user + "@" + ipUsed + " -pw " + passwd + " \"" + cmdRun + "\"";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "plink.exe";
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            customOutput = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            //Access denied

            if (customOutput != "Access denied" && customOutput != "")
            {
                this.Hide();
            }
            else
            {
                //process.Kill();
                MessageBox.Show("Autenticazione fallita... Reinserisci le credenziali");
            }

            /*
            if (!process.WaitForExit(6000))
            {
                process.Kill();
                MessageBox.Show("Autenticazione fallita... Reinserisci le credenziali");
            } else
            {
                this.Hide();
            }*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginSAN_Load(object sender, EventArgs e)
        {
            selAmbiente.Items.Add("SAN PSM");
            selAmbiente.Items.Add("SAN TO");
            selAmbiente.Items.Add("SAN IOL SZ");
            selAmbiente.Items.Add("SAN IOL TO");
            selAmbiente.Items.Add("SAN VI");
            selAmbiente.Text = "SAN PSM";
        }

        private void selAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selAmbiente.Text == "SAN PSM")
            {
                ambiente = "SAN PSM";
                ipUsed = "172.31.41.26";
            }
            else if (selAmbiente.Text == "SAN TO")
            {
                ambiente = "SAN TO";
                ipUsed = "172.30.32.18";
            }
            else if (selAmbiente.Text == "SAN IOL SZ")
            {
                ambiente = "SAN IOL SZ";
                ipUsed = "10.174.224.75";
            }
            else if (selAmbiente.Text == "SAN VI")
            {
                ambiente = "SAN VI";
                ipUsed = "172.24.35.110";
            }
            else
            {
                ambiente = "SAN IOL TO";
                ipUsed = "10.174.10.102";
            }
        }

        private void loginSAN_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void loginSAN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

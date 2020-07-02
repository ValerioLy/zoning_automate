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

    public partial class customCMDform : Form
    {

        public string username;
        public string password;
        public string ipUsed;

        public customCMDform()
        {
            InitializeComponent();
        }

        private void customBt_Click(object sender, EventArgs e)
        {
            string cmdRun;
            string strCmdText;

            cmdRun = customCMD.Text;
            strCmdText = "-ssh " + username + "@" + ipUsed + " -pw " + password + " \"" + cmdRun + "\"";            

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "plink.exe";
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            customOutput.Text = process.StandardOutput.ReadToEnd();
        }

        private void customCMDform_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(username);
        }
    }
}

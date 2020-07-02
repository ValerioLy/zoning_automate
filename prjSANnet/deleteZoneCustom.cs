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
    public partial class deleteZoneCustom : Form
    {

        public int varReturn;

        public deleteZoneCustom()
        {
            InitializeComponent();
        }

        private void returnBack_Click(object sender, EventArgs e)
        {
            this.varReturn = 0;
            this.Close();
        }

        private void removeCfg_Click(object sender, EventArgs e)
        {
            this.varReturn = 1;
            this.Close();
        }

        private void deleteZone_Click(object sender, EventArgs e)
        {
            this.varReturn = 2;
            this.Close();
        }

        private void allFlow_Click(object sender, EventArgs e)
        {
            this.varReturn = 3;
            this.Close();
        }
    }
}

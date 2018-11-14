using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMB
{
    public partial class MAIN_CAP_Bank : Form
    {
        public MAIN_CAP_Bank()
        {
            InitializeComponent();
        }

        private void All_Click(object sender, EventArgs e)
        {
            Roofs con = new Roofs();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void Standardization_Click(object sender, EventArgs e)
        {
            CapacitorBanks_sheet cs = new CapacitorBanks_sheet();
            this.Visible = false;

            cs.ShowDialog();
            this.Visible = true;
        }

        private void MAIN_CAP_Bank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

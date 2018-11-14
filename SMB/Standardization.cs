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
    public partial class Standardization : Form
    {
        public Standardization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Standard_Sheets ss = new Standard_Sheets();
            this.Visible = false;

            ss.ShowDialog();
            this.Visible = true;

           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapacitorBanks_sheet cs = new CapacitorBanks_sheet();
            this.Visible = false;

            cs.ShowDialog();
            this.Visible=true;
            
        }

        private void Standardization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

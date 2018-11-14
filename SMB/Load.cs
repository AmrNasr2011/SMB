using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMB
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private void Load_Load(object sender, EventArgs e)
        {
            AccessDBC a = new AccessDBC();
            CB_Order.DataSource = a.GetData(null, "usersave","order");

        }

        private void BTN_Load_Click(object sender, EventArgs e)
        {
            if (CB_Order.Text != "")
            {
                AccessDBC.Load_order = CB_Order.Text;
                this.Close();

            }
            else
            {
                MessageBox.Show("Item No. must not be empty");
                return;
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

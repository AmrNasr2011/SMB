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
    public partial class Save : Form
    {
        public Save()
        {
            InitializeComponent();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (TB_item.Text != "")
            {
                AccessDBC.ORDER = TB_item.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Item No cannot be empty ");
                return;
            }
        }

        private void BRN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

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
    
    public partial class Commnet : Form
    {
        static public string comment_t = "";
        public Commnet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comment_t = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comment_t = comtext.Text;
            this.Close();
        }

        private void Commnet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

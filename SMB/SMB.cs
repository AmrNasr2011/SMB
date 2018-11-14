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
    public partial class SMB : Form
    {
        public SMB()
        {
            InitializeComponent();
            this.SetDesktopLocation(20 , 20);
        }

      

        private void start_Click(object sender, EventArgs e)
        {
            Main_introduction_Tab x = new Main_introduction_Tab();
            if (UpdateTool.Update())
            {
                this.Close();
            }
            this.Visible = false;
            x.ShowDialog();
            this.Close();

        }

     
    }
}

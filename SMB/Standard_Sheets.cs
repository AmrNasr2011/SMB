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
    public partial class Standard_Sheets : Form
    {
        static public Standard_Sheets obj;
        static public bool exist = false;
        public Standard_Sheets()
        {
            InitializeComponent();
        }

        private void Standard_Sheets_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DOL con = new DOL();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
           
          
        }

        private void Standard_Sheets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}

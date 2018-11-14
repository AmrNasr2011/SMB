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
    public partial class Main_General_tab : Form
    {
        public Main_General_tab()
        {
            InitializeComponent();
        }

        private void All_Click(object sender, EventArgs e)
        {           
            Spaces con = new Spaces();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void Standardization_Click(object sender, EventArgs e)
        {
            DOL con = new DOL();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void MAIN_DOL_SD_REV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MAIN_DOL_SD_REV_Load(object sender, EventArgs e)
        {

        }

        private void Doors_Click(object sender, EventArgs e)
        {
            Doors con = new Doors();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void Special_Requests_Click(object sender, EventArgs e)
        {
            Special_Requests con = new Special_Requests();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void Mounting_Click(object sender, EventArgs e)
        {
            Mountings con = new Mountings();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }

        private void Roofs_Click(object sender, EventArgs e)
        {

            Roofs con = new Roofs();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }
    }   
}

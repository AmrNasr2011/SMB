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
    public partial class Help : Form
    {
        public Help(string loc,string header)
        {
            InitializeComponent();
            webBrowser1.Navigate(Application.StartupPath + "\\"+ loc);
            this.Text = header;
           
        }

       
     
    }
}

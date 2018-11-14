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
    public partial class CapacitorBanks_sheet : Form
    {
        static public bool exist = false;
        static public CapacitorBanks_sheet obj;
        public string CapacitorsheetM1;
        public string CapacitorsheetM2;
        public int count = 0;
        public bool Locker =false;
        public DataTable table = new DataTable();
        int EIndex;
        public CapacitorBanks_sheet()
        {
            InitializeComponent();
      
            groupBox3.BackColor = Color.Transparent;
            table.Columns.Add(CB_1.Tag.ToString());
            table.Columns.Add(CB_2.Tag.ToString());
            table.Columns.Add(CB_3.Tag.ToString());
            table.Columns.Add(CB_4.Tag.ToString());
            table.Columns.Add(CB_5.Tag.ToString());

            table.Columns.Add(CB_6.Tag.ToString());
            table.Columns.Add(CB_7.Tag.ToString());
            table.Columns.Add("Quantity");
            
            
            
       
            table.Columns.Add(TB_3.Tag.ToString());
            
            table.Columns.Add(TB_1.Tag.ToString());
           
            dataGridView1.DataSource = table;
            dataGridView1.Columns[TB_1.Tag.ToString()].HeaderText = "Description";
            dataGridView1.Columns[TB_3.Tag.ToString()].HeaderText = "Reference";

        }

       
        private void export_to_excel()
        {
            Dictionary<string, double> Data = new Dictionary<string, double>();
            // here i will check whick is not empty and show it
            //foreach (DataRow row in table.Rows)
            //{
            //    //check key exist before in dictionary

            //  //  check_and_ADD(ref Data, row[TB_1.Tag.ToString()].ToString(), row[TB_2.Tag.ToString()].ToString());
            // //   check_and_ADD(ref Data, row[TB_3.Tag.ToString()].ToString(), row[TB_4.Tag.ToString()].ToString());
            //}
            ToExcelC.rowcounts = EIndex;
            ToExcelC.rowcounts = EIndex;
            ToExcelC a = new ToExcelC();
            //saveFileDialog.Filter = "xlsx file|*.xlsx";
            //saveFileDialog.Title = "Capacitorsheet Metering Save To";
            //saveFileDialog.ShowDialog();
            //if (saveFileDialog.FileName != "")
            //{
                a.export(table, "");
            //}

            saveFileDialog.FileName = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SetDesktopLocation(0, 0);
            export_to_excel();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {//required to define location for database here 
            EIndex = ToExcelC.rowcounts;
            AccessDBC.connection_str = AccessDBC.Database_LOC("SMB.accdb");
            //@@## nead to add database check module that if remote database not reachable close application
             
            AccessDBC a = new AccessDBC();
            CB_1.DataSource = a.GetData(null, "Capacitorsheet", CB_1.Tag.ToString());
           
        }

        private void CB_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_1.Text == "")
                {
                    CB_2.DataSource = null;
                    CB_2.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);

                    CB_2.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_2.Tag.ToString());//data source accept list

                }
               

            }
           
        }

        private void CB_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_2.Text == "")
                {
                    CB_3.DataSource = null;
                    CB_3.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                    aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                    CB_3.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_3.Tag.ToString());//data source accept list
                }
            }

        }

        private void CB_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_3.Text == "")
                {
                    CB_4.DataSource = null;
                    CB_4.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                    aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                    aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                    List<string> x = new List<string>();
                    List<double> q = new List<double>();
                    double pp;
                    x = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_4.Tag.ToString());//data source accept list
                    q = x.Select(n => !double.TryParse(n, out pp) ? double.NaN : Convert.ToDouble(n)).ToList();
                    q.Sort();
                    x = q.Select(c => c == double.NaN || c.ToString() == "NaN" ? "N/A" : Convert.ToString(c)).ToList();
                    x[0] = "";
                    CB_4.DataSource = x;
                }
            }
           
        }

        private void CB_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_4.Text == "")
                {
                    CB_5.DataSource = null;
                    CB_5.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                    aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                    aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                    aa.Dic_in.Add(CB_4.Tag.ToString(), CB_4.Text);
          
                    CB_5.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_5.Tag.ToString());

                }
            }

        }

        private void CB_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_5.Text == "")
                {
                    CB_6.DataSource = null;
                    CB_6.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                    aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                    aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                    aa.Dic_in.Add(CB_4.Tag.ToString(), CB_4.Text);
                    aa.Dic_in.Add(CB_5.Tag.ToString(), CB_5.Text);
                  
                    CB_6.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_6.Tag.ToString());

                }
            }
        }
        private void CB_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                if (CB_6.Text == "")
                {
                    CB_7.DataSource = null;
                    CB_7.Text = "";
                }
                else
                {
                    AccessDBC aa = new AccessDBC();
                    aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                    aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                    aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                    aa.Dic_in.Add(CB_4.Tag.ToString(), CB_4.Text);
                    aa.Dic_in.Add(CB_5.Tag.ToString(), CB_5.Text);
                    aa.Dic_in.Add(CB_6.Tag.ToString(), CB_6.Text);
                  
                    List<string> x = new List<string>();
                    List<double> q = new List<double>();
                    double pp;
                    x = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_7.Tag.ToString());
                    q = x.Select(n => !double.TryParse(n, out pp) ? double.NaN : Convert.ToDouble(n)).ToList();
                    q.Sort();
                    x = q.Select(c => c == double.NaN || c.ToString() == "NaN"? "" : Convert.ToString(c)).ToList();
                    x[0] = "";
                    CB_7.DataSource  = x;//data source accept list
                }
            }

        }

        private void CB_7_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> temp_l = new List<string>();
            if (!Locker)
            {
                AccessDBC aa = new AccessDBC();
                aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                aa.Dic_in.Add(CB_4.Tag.ToString(), CB_4.Text);
                aa.Dic_in.Add(CB_5.Tag.ToString(), CB_5.Text);
                aa.Dic_in.Add(CB_6.Tag.ToString(), CB_6.Text);
                aa.Dic_in.Add(CB_7.Tag.ToString(), CB_7.Text);
                if (CB_7.SelectedIndex > 0 && CB_7.Text != "")

                {
                    TB_1.Text = aa.GetData(aa.Dic_in, "Capacitorsheet", TB_1.Tag.ToString())[1];
                    TB_3.Text = aa.GetData(aa.Dic_in, "Capacitorsheet", TB_3.Tag.ToString())[1];


                }
                else
                {
                    TB_1.Text = "";

                    TB_3.Text = "";

                }
            }

            Qty_update();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if (TB_1.Text == "")
            {
                return;
            }
            if (count == table.Rows.Count )
            {
                DataRow row = table.NewRow();
                row[CB_1.Tag.ToString()] = CB_1.Text;
                row[CB_2.Tag.ToString()] = CB_2.Text;
                row[CB_3.Tag.ToString()] = CB_3.Text;
                row[CB_4.Tag.ToString()] = CB_4.Text;
                row[CB_6.Tag.ToString()] = CB_6.Text;
                row[CB_7.Tag.ToString()] = CB_7.Text;
                row["Quantity"] = TB_Qty.Text;
                row[CB_5.Tag.ToString()] = CB_5.Text;
                row[TB_1.Tag.ToString()] = TB_1.Text;
               
                row[TB_3.Tag.ToString()] = TB_3.Text;
                
                table.Rows.Add(row);
                count++;
                TB_Count.Text = count.ToString();

                //CB_1.Text = "";
                //CB_2.Text = "";
                //CB_3.Text = "";
                //CB_4.Text = "";
                CB_7.Text = "";
                //TB_1.Text = "";
              
                //TB_3.Text = "";
               
                TB_Qty.Text = "";


            }
            else
            {
                table.Rows[count][CB_1.Tag.ToString()] = CB_1.Text;
                table.Rows[count][CB_2.Tag.ToString()] = CB_2.Text;
                table.Rows[count][CB_3.Tag.ToString()] = CB_3.Text;
                table.Rows[count]["Quantity"] = TB_Qty.Text;
                table.Rows[count][CB_4.Tag.ToString()] = CB_4.Text;
                table.Rows[count][CB_5.Tag.ToString()] = CB_5.Text;
                table.Rows[count][CB_6.Tag.ToString()] = CB_6.Text;
                table.Rows[count][CB_7.Tag.ToString()] = CB_7.Text;
                table.Rows[count][TB_1.Tag.ToString()] = TB_1.Text;
               
                table.Rows[count][TB_3.Tag.ToString()] = TB_3.Text;
               

            }

            AccessDBC.Save_required = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (count <= 0)
            {
                return;
            }
            else
            {
                BTN_Delete.Visible = true;
                count--;
                updateview();
            }
        }
        void updateview()
        {
            Locker = true;
            TB_Count.Text = count.ToString();
            CB_1.Text = table.Rows[count][CB_1.Tag.ToString()].ToString();
            CB_2.Text = table.Rows[count][CB_2.Tag.ToString()].ToString();
            CB_3.Text = table.Rows[count][CB_3.Tag.ToString()].ToString();
            CB_4.Text = table.Rows[count][CB_4.Tag.ToString()].ToString();
            CB_6.Text = table.Rows[count][CB_6.Tag.ToString()].ToString();
            CB_7.Text = table.Rows[count][CB_7.Tag.ToString()].ToString();
            TB_Qty.Text = table.Rows[count]["Quantity"].ToString();
            CB_5.Text = table.Rows[count][CB_5.Tag.ToString()].ToString();
            TB_1.Text = table.Rows[count][TB_1.Tag.ToString()].ToString();

            TB_3.Text = table.Rows[count][TB_3.Tag.ToString()].ToString();

  
            Locker = false;
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (count + 1 == table.Rows.Count)
            {
                BTN_Delete.Visible = false;
                count++;
                TB_Count.Text = count.ToString();
                Locker = true;
                //CB_1.Text = "";
                //CB_2.Text = "";
                //CB_3.Text = "";
                //CB_4.Text = "";
                CB_7.Text = "";
                TB_1.Text = "";

                TB_3.Text = "";

                TB_Qty.Text = "";

                Locker = false;
            }
            else if (count >= table.Rows.Count)
            {
                BTN_Delete.Visible = false;
                Locker = true;
                //CB_1.Text = "";
                //CB_2.Text = "";
                //CB_3.Text = "";
                //CB_4.Text = "";
                CB_7.Text = "";
                TB_1.Text = "";

                TB_3.Text = "";

                TB_Qty.Text = "";
 
                Locker = false;
                return;
            }
            else
            {
                count++;
                updateview();
            }
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            DataRow dr = table.Rows[count];
            dr.Delete();
            count = 0;
            if (table.Rows.Count == 0)
            {
                BTN_Delete.Visible = false;
                TB_Count.Text = "";
                Locker = true;
                CB_1.Text = "";
                CB_2.Text = "";
                CB_3.Text = "";
                CB_4.Text = "";
                CB_5.Text = "";
                CB_6.Text = "";
                CB_7.Text = "";
                TB_1.Text = "";

                TB_3.Text = "";

                TB_Qty.Text = "";

                Locker = false;
            }
            else
            {
                updateview();
            }
            AccessDBC.Save_required = true;
        }
        private void check_and_ADD( ref Dictionary<string, double> Dic, string D_key,string D_val)
        {
            if (D_key == "" || D_val == "" || D_val == "0")
            {
                return ;

            }
            if (Dic.ContainsKey(D_key))
            {
                try
                {
                    Dic[D_key] += double.Parse(D_val);
                }
                catch (Exception)
                {

                    return;
                }

            }
            else
            {
                try
                {
                    Dic.Add(D_key, double.Parse(D_val));
                }
                catch (Exception)
                {

                    return;
                }
               
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            // only allow one decimal point
           
        }

        private void TB_Qty_TextChanged(object sender, EventArgs e)
        {
            if (!Locker)
            {
                Qty_update();
            }
            
          
        }
        private void Qty_update()
        {
           

        }

        private void CB_2_DropDown(object sender, EventArgs e)
        {
            if (CB_2.DataSource == null && CB_1.Text !="")
            {
                AccessDBC aa = new AccessDBC();
                aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);

                CB_2.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_2.Tag.ToString());//data source accept list
            }
        }

        private void CB_3_DropDown(object sender, EventArgs e)
        {
            if (CB_3.DataSource == null && CB_1.Text != ""&& CB_2.Text != "")
            {
                AccessDBC aa = new AccessDBC();
                aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                CB_3.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_3.Tag.ToString());//data source accept list
            }
        }

        private void CB_4_DropDown(object sender, EventArgs e)
        {
            if (CB_4.DataSource == null && CB_1.Text != "" && CB_2.Text != "" && CB_3.Text != "")
            {
                AccessDBC aa = new AccessDBC();
                aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                CB_4.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_4.Tag.ToString());//data source accept list
            }
        }

        private void CB_5_DropDown(object sender, EventArgs e)
        {
            if (CB_5.DataSource == null && CB_1.Text != "" && CB_2.Text != "" && CB_3.Text != "" && CB_4.Text != "")
            {
                AccessDBC aa = new AccessDBC();
                aa.Dic_in.Add(CB_1.Tag.ToString(), CB_1.Text);
                aa.Dic_in.Add(CB_2.Tag.ToString(), CB_2.Text);
                aa.Dic_in.Add(CB_3.Tag.ToString(), CB_3.Text);
                aa.Dic_in.Add(CB_4.Tag.ToString(), CB_4.Text);
                CB_5.DataSource = aa.GetData(aa.Dic_in, "Capacitorsheet", CB_5 .Tag.ToString());//data source accept list
            }
        }

    
        private void Save_data(string order)
        {
            //here i will create new table and copy table data to it
            DataTable copytable;
            copytable = table.Copy();
            copytable.Columns.Add("order");
            //here i will append order 
            for (int i = 0; i < copytable.Rows.Count; i++)
            {
                copytable.Rows[i]["order"] = order;
            }
            AccessDBC a = new AccessDBC();
            Dictionary<string, string> z = new Dictionary<string, string>();
            z.Add("order", order);
            a.Upload_table(copytable, "usersave", z);
        }

        private DataTable Load_data(string order)
        {
            AccessDBC a = new AccessDBC();
            Dictionary<string, string> z = new Dictionary<string, string>();

           z.Add("order", order);
           DataTable tb = a.Read_DataSet(z, "usersave", "*").Copy();
            tb.Columns.Remove("order");
            tb.Columns.Remove("ID");
            return tb;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccessDBC.Save_required = false;
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to save!!");
                return;
            }
            Save SA = new Save();
            SA.ShowDialog();
            if (AccessDBC.ORDER != "")
            {
                Save_data(AccessDBC.ORDER);
                AccessDBC.ORDER = "";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessDBC.Save_required)
            {
                DialogResult dialogResult = MessageBox.Show("Your unsaved data could be lost. Do you want to save first.", "Data missing warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save_DGV();
                }
                else if (dialogResult == DialogResult.No)
                {
                    AccessDBC.Save_required = false;
                }
            }
            Load LO = new Load();
            LO.ShowDialog();
            if (AccessDBC.Load_order != "")
            {
                table = Load_data(AccessDBC.Load_order);
                dataGridView1.DataSource = table;
                count = 0;
                AccessDBC.Load_order = "";
                updateview();

            }
            else
            {
                return;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessDBC.Save_required)
            {
                DialogResult dialogResult = MessageBox.Show("Your unsaved data could be lost. Do you want to save first.", "Data missing warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save_DGV();
                }
                else if (dialogResult == DialogResult.No)
                {
                    AccessDBC.Save_required = false;
                }
            }
            try
            {
                table.Clear();
                dataGridView1.DataSource = table;
                count = 0;
                TB_Count.Text = "";
                Locker = true;
                CB_1.Text = "";
                CB_2.Text = "";
                CB_3.Text = "";
                CB_4.Text = "";
                CB_5.Text = "";
                CB_6.Text = "";
                CB_7.Text = "";
                TB_1.Text = "";

                TB_3.Text = "";

                TB_Qty.Text = "";

                Locker = false;
            }
            catch (Exception)
            {

               
            }
            
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Schneider BK7 Capacitorsheet length estimator.\nDesigned by Schneider Egypt.", "About App");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessDBC.Save_required)
            {
                DialogResult dialogResult = MessageBox.Show("Your unsaved data could be lost. Do you want to save first.", "Data missing warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save_DGV();
                }
                else if (dialogResult == DialogResult.No)
                {
                    AccessDBC.Save_required = false;
                }
            }
            this.Close();
        }
        private void Save_DGV()
        {
            AccessDBC.Save_required = false;
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to save!!");
                return;
            }
            Save SA = new Save();
            SA.ShowDialog();
            if (AccessDBC.ORDER != "")
            {
                Save_data(AccessDBC.ORDER);
                AccessDBC.ORDER = "";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (AccessDBC.Save_required)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Your unsaved data could be lost. Do you want to save first.", "Capacitorsheet Metering", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        Save_DGV();
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        AccessDBC.Save_required = false;
            //    }
            //}
        }

        private void Configurator_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Commnet a = new Commnet();
            a.ShowDialog();
            if (Commnet.comment_t != "")
            {
                Excel_interface x = new Excel_interface();
                x.Add_new_Comment(Commnet.comment_t);
                Commnet.comment_t = "";
            }
        }

        private void Configurator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                BTN_Add.PerformClick();
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AccessDBC a = new AccessDBC();

            ToExcelC c = new ToExcelC();
            DataTable tablex = new DataTable();

            tablex = a.Read_DataSet(null, "Capacitorsheet", "*");
            c.ExportToExcel(tablex, "Capacitorsheet");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help aa = new Help(Properties.Settings.Default.CapacitorHelp2, "Standard Coordination Concept");
            aa.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help aa = new Help(Properties.Settings.Default.CapacitorHelp1, "Reference & Description Legend");
            aa.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMB
{
    public partial class Main_introduction_Tab : Form
    {
        public Main_introduction_Tab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterpactNW con = new MasterpactNW();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Compact_NS con = new Compact_NS();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Compact_NSX con = new Compact_NSX();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MiniatureCircuit con = new MiniatureCircuit();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main_General_tab con = new Main_General_tab();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
        }



 

        private void button8_Click(object sender, EventArgs e)
        {
            MAIN_CAP_Bank con = new MAIN_CAP_Bank();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Doors con = new Doors();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;

          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AccessoriesOfCompactNSX_NS80H_GV2 con = new AccessoriesOfCompactNSX_NS80H_GV2();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Spaces con = new Spaces();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
            
        }

        private void General_Click(object sender, EventArgs e)
        {
            Main_General_tab con = new Main_General_tab();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;

           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            VigilohmCables con = new VigilohmCables();
            this.Visible = false;

            con.ShowDialog();
            this.Visible = true;
         
        }

        private void button14_Click(object sender, EventArgs e)
        {

            Standardization std = new Standardization();
            this.Visible = false;
            std.ShowDialog();
           
            this.Visible = true;
            /* if (Configurator.exist)
             {
                 Configurator.obj.Activate();
                 Configurator.obj.WindowState = FormWindowState.Normal;
             }
             else
             {
                 Configurator.obj = new Configurator();
                 Configurator.exist = true;
                 Configurator.obj.Show();
             }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Version.Text = Properties.Settings.Default.UpdateVersion;
            int x;
            do
            {
                x = check_DB();
            } while (x == 1);
            if (x == 3)
            {
                this.Close();
            }
        }
        void update_DB()
        {
            int current_version;
            int remote_version;
            //check current Database index
            current_version = AccessDBC.version_num(Properties.Settings.Default.LocalDB);
            if (current_version <= 0)
            {
                MessageBox.Show("error in geting currrent DB index");

            }
            else
            {
                DB_index.Text = current_version.ToString();
            }

            //check remote Database index
            remote_version = AccessDBC.version_num(Properties.Settings.Default.RemoteDB);
            //check if two are the same
            if (remote_version <= 0 || remote_version == current_version)
            {
                //do nothing you are in recent updated verion
                MessageBox.Show("No Update Happened you are in last index");
            }
            else if (remote_version > current_version)
            {//here you need to update your database
                //copy and replace
                string local_file = Application.StartupPath + "\\SMB.accdb";
                string remote_file = Properties.Settings.Default.Remote_file;
                File.Delete(local_file);
                File.Copy(remote_file,local_file, true);
                MessageBox.Show("DataBase update From index: " + DB_index.Text + "to index: " + remote_version.ToString());
                DB_index.Text = remote_version.ToString();

            }
        }

        private void btnversion_Click(object sender, EventArgs e)
        {
            DB_Location DB_loc = new DB_Location();
            DB_Location.status = "normal";
            DB_loc.ShowDialog();
            if (DB_Location.save_pressed == 1)
            {
                DB_Location.save_pressed = 0;
                loop_DB_check();
            }
        }
        void loop_DB_check()
        {
            int x;
            do
            {
                x = check_DB();
            } while (x == 1);
        }
        int check_DB()
        {
            //here i should test if local db exist by check its index
            int current_version;
            int remote_version;
            //below function will return -1 in case of error
            current_version = AccessDB.version_num(Properties.Settings.Default.LocalDB);
            if (current_version < 0)
            {   //check if no link to remote DB exist
                if (Properties.Settings.Default.Remote_file == "")
                {
                    //call DB_location form with close status
                    DB_Location.status = "close";
                    DB_Location.comment = "Local Database is not exist, and no valid link to remote database. Note if you press cancel or close this window application will automatically close.";
                    DB_Location DB_loc = new DB_Location();
                    DB_loc.ShowDialog();
                    if (DB_Location.app_close == 1)
                    {
                        return 3;
                    }
                    return 1;
                }
                else
                {
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.Remote_file + Properties.Settings.Default.password;
                    //check if we can access remote DB
                    remote_version = AccessDB.version_num(connectionString);
                    if (remote_version < 0)
                    {
                        //not valid link 
                        DB_Location.status = "close";
                        DB_Location.comment = "Local Database is not exist, and current link to remote database is not valid. Note if you press cancel or close this window application will automatically close.";
                        DB_Location DB_loc = new DB_Location();
                        DB_loc.ShowDialog();
                        if (DB_Location.app_close == 1)
                        {
                            return 3;
                        }
                        return 1;
                    }
                    else
                    {
                        //here i should copy remote database to local directory.
                        string local_file = Application.StartupPath + "\\SMB.accdb";
                        string remote_file = Properties.Settings.Default.Remote_file;
                        try
                        {
                            File.Copy(remote_file, local_file, true);
                        }
                        catch (Exception)
                        {
                            //incase of error in copying aplication should close
                            MessageBox.Show("Error happen while updating local Database, Please make sure you run this application as adminstrator");
                            this.Close();
                        }
                        DB_index.Text = remote_version.ToString();
                        DB_status.Text = "Online";
                        MessageBox.Show("DataBase update to index: " + remote_version.ToString());
                        return 0;
                    }

                }
            }
            else
            {
                //if local database exist,check if link exist
                if (Properties.Settings.Default.Remote_file == "")
                {
                    DB_status.Text = "Offline";
                    DB_index.Text = current_version.ToString();
                    MessageBox.Show("No valid link for remote DB, Please update link from (DB Location) Button below. You now can work with local database, but it may be not the last update!!");
                    return 0;
                }
                else
                {
                    //link exist let's check if it works
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.Remote_file+ Properties.Settings.Default.password;
                    //check if we can access remote DB
                    remote_version = AccessDB.version_num(connectionString);
                    if (remote_version < 0)
                    {
                        DB_status.Text = "Offline";
                        DB_index.Text = current_version.ToString();
                        MessageBox.Show("error in connection to Database, Please update link from (DB Location) button below or check your network connection. You now can work with local database, but it may be not the last update!!");
                        return 0;
                    }
                    else
                    {
                        //here local DB exist and remote DB exist
                        //lets validate
                        if (remote_version > current_version)
                        {
                            //here should replace local database
                            string local_file = Application.StartupPath + "\\SMB.accdb";
                            string remote_file = Properties.Settings.Default.Remote_file;
                            try
                            {
                                File.Delete(local_file);
                                File.Copy(remote_file, local_file, true);

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error happen while updating local Database, Please make sure you run this application as adminstrator");
                                this.Close();
                            }

                            MessageBox.Show("DataBase update From index: " + current_version.ToString() + " to index: " + remote_version.ToString());
                            DB_index.Text = remote_version.ToString();
                            DB_status.Text = "Online";
                            return 0;
                        }
                        else
                        {
                            DB_index.Text = remote_version.ToString();
                            DB_status.Text = "Online";
                            return 0;
                        }
                    }

                }
            }
        }

      
    }
}

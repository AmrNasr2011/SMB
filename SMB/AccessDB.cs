using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMB
{
    class AccessDB
    {
        private string connectionString;
        public Dictionary<string, string> Dic_in = new Dictionary<string, string>();
        static public string connection_str;
        public AccessDB()
        {
            string app_loc = Application.StartupPath;
            //try
            //{
            //    connection_str = System.IO.File.ReadAllText(app_loc + "\\Data");
            //}
            //catch (Exception)
            //{
                connection_str = app_loc + "\\SMB.accdb";
                //MessageBox.Show("Missing connection string file");
            //}
            //connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Study\Personal Work\schnider\tasks\SMB\SMB_Application\SMB.accdb";
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connection_str + Properties.Settings.Default.password;
        }
        public List<string> GetData(Dictionary<string, string> dict, string table_name, string col_name)
        {//this function will take 
            /*
            as input ductionary represent filter col-value
            also table name
            also return col name
            and return list of value 
            function will create sql string based on received data  
            */
            string command_str = dic_to_string(dict, table_name, col_name);
            OleDbConnection con = new OleDbConnection(connectionString);
            List<string> str_list = new List<string>();
            //here i will do something to make this code more dynamic
            //I will make selection will based on 
            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {

                con.Open();

                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object x = rdr.GetValue(0);
                    var z = x as string;
                    if (z != null)
                    { str_list.Add(rdr.GetString(0)); }

                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();
            if (str_list.Count>0)
            {
                if (str_list[0] == "N/A")
                {
                    return str_list.Distinct().ToList();
                }
            }
            str_list.Insert(0, ""); // this to add empty line at first
            if (str_list.Count < 2) { str_list.Add(" "); str_list.Add("  "); }
            return str_list.Distinct().ToList();
        }


        public List<string> GetDataAsNumber(Dictionary<string, string> dict, string table_name, string col_name)
        {//this function will take 
            /*
            as input ductionary represent filter col-value
            also table name
            also return col name
            and return list of value 
            function will create sql string based on received data  
            return sorted data as number
            */
            List<string> x = new List<string>();
            List<double> q = new List<double>();
            string command_str = dic_to_string(dict, table_name, col_name);
            OleDbConnection con = new OleDbConnection(connectionString);
            List<string> str_list = new List<string>();
            //here i will do something to make this code more dynamic
            //I will make selection will based on 
            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {

                con.Open();

                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object xx = rdr.GetValue(0);
                    var z = xx as string;
                    if (z != null)
                    { str_list.Add(rdr.GetString(0)); }

                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();
            double pp;
            str_list.Insert(0, ""); // this to add empty line at first
            if (str_list.Count < 2) { str_list.Add(" "); str_list.Add("  "); }
            x= str_list.Distinct().ToList();
            q = x.Select(n => !double.TryParse(n, out pp) ? double.NaN : Convert.ToDouble(n)).ToList();
            q.Sort();
            x = q.Select(c => c == double.NaN || c.ToString() == "NaN" ? "" : Convert.ToString(c)).ToList();
            x[0] = "";
            return x;
        }
        public List<string> GetTableColumnNames(string tableName)
        {
            string command_str = "SELECT * FROM [" + tableName + "]";
            using (var connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(command_str, connection);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }

                OleDbDataReader rdr = cmd.ExecuteReader();
                var table = rdr.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                //var schemaTable = connection.GetOleDbSchemaTable(
                //  OleDbSchemaGuid.Columns,
                //  new Object[] { null, null, tableName });
                //if (schemaTable == null)
                //    return null;


                List<string> str_list = new List<string>();
                foreach (DataRow r in table.Rows)
                {
                    str_list.Add(r[nameCol].ToString());
                }
                return str_list;
            }
        }


        public string dic_to_string(Dictionary<string, string> dic_in, string table_str, string From_col_string)
        {
            string re_value = "";
            if (dic_in.Count() == 0)
            {
                return "SELECT [" + From_col_string + "] FROM [" + table_str + "]" + " ORDER BY [ID] ASC";
            }
            else
            {
                foreach (KeyValuePair<string, string> item in dic_in)
                {
                    if (re_value != "")
                    {
                        re_value = re_value + " AND ";
                    }
                    re_value = re_value + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }
                return "SELECT [" + From_col_string + "] FROM [" + table_str + "] WHERE " + re_value + " ORDER BY [ID] ASC";
            }

        }
        public static int version_num(string constr)
        {
            //here i will return -1 incase not reachable DB
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand cmd = new OleDbCommand("select count(*) from version", con);
            try
            {

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }

    }
}

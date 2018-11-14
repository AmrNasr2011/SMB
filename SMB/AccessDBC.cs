using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMB
{
    class AccessDBC
    {
        private string connectionStringW;
        public static string ORDER="";
        public static Boolean Save_required = false;
        public static string Load_order = "";
        private string connectionStringR;
        public Dictionary<string, string> Dic_in = new Dictionary<string, string>();
        static public string connection_str = "";
        static public string User_Name = "";
        //static public Dictionary<string, DataTable> data_Dic;
        //static public Dictionary<string, Dictionary<string, string>> status_dic;
        //static public string SQL_command_str;
        public AccessDBC()
        {//I need to specify whay of connection (read only or write) through each function
            connectionStringW = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +  connection_str + Properties.Settings.Default.password;
            connectionStringR = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +   connection_str + Properties.Settings.Default.password;
        }


        //@@@need function to return datatable based of string filter
        public DataTable Get_table_withFilter(string filter)
        {
            OleDbConnection con = new OleDbConnection(connectionStringR);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";

            OleDbDataAdapter da = new OleDbDataAdapter(filter, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;

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
            string command_str = dic_to_string_Read(dict, table_name, col_name);

            OleDbConnection con = new OleDbConnection(connectionStringR);
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
                MessageBox.Show(e.Message);
            }

            con.Close();
            str_list.Insert(0, ""); // this to add empty line at first
            return str_list.Distinct().ToList();
        }
       
        public List<string> GetTableColumnNames(string tableName)
        {
            string command_str = "SELECT * FROM [" + tableName + "]";
            using (var connection = new OleDbConnection(connectionStringR))
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
        public static string Database_LOC(string database_name)
        {
            string app_loc = Application.StartupPath;
        
                //MessageBox.Show(e.Message);
                return  app_loc + "\\" + database_name;
                //MessageBox.Show("Missing connection string file");
           

        }

        /// <summary>
        /// this function return string equivelent to SQL command to read a specific colomn with dictionary based filter
        /// </summary>
        /// <param name="dic_in"></param>
        /// <param name="table_str"></param>
        /// <param name="From_col_string"></param>
        /// <returns></returns>
        public string dic_to_string_Read(Dictionary<string, string> dic_in, string table_str, string From_col_string)
        {
            string re_value = "";
            if (dic_in == null)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]" ; 
                }

            }
            if (dic_in.Count() == 0)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]" ;
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]" ;
                }
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
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "] WHERE " + re_value + " ORDER BY [ID] ASC ";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "] WHERE " + re_value + " ORDER BY [ID] ASC ";
                }

            }

        }
        public string dic_to_string_append(Dictionary<string, string> dic_in, string table_str)
        {
            string vals = "";
            string key_s = "";
            foreach (KeyValuePair<string, string> item in dic_in)
            {
                if (key_s == "")
                {
                    key_s = "( [" + item.Key + "]";
                }
                else
                {
                    key_s = key_s + " , " + "[" + item.Key + "]";
                }

                if (vals == "")
                {
                    vals = "( '" + item.Value + "'";
                }
                else
                {
                    vals = vals + " , " + "'" + item.Value + "'";
                }


            }
            if (key_s != "")
            {
                key_s = key_s + ")";
            }
            if (vals != "")
            {
                vals = vals + ")";
            }

            return "INSERT INTO " + "[" + table_str + "] " + key_s + " VALUES " + vals;

        }

        public string dic_to_string_appendWO(Dictionary<string, string> dic_in, string table_str)
        {
            string vals = "";
            string key_s = "";
            foreach (KeyValuePair<string, string> item in dic_in)
            {
                if (key_s == "")
                {
                    key_s = "( [" + item.Key + "]";
                }
                else
                {
                    key_s = key_s + " , " + "[" + item.Key + "]";
                }

                if (vals == "")
                {
                    vals = "( " + item.Value + "";
                }
                else
                {
                    vals = vals + " , " + "" + item.Value + "";
                }


            }
            if (key_s != "")
            {
                key_s = key_s + ")";
            }
            if (vals != "")
            {
                vals = vals + ")";
            }

            return "INSERT INTO " + "[" + table_str + "] " + key_s + " VALUES " + vals;

        }
        public void append_data(Dictionary<string, string> dic_in, string table_str)
        {

            string command_str = dic_to_string_append(dic_in, table_str);
            OleDbConnection con = new OleDbConnection(connectionStringW);

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            con.Close();

        }

        public void Update_data(Dictionary<string, string> dic_set, Dictionary<string, string> dic_where, string table_str)
        {

            string command_str = dic_to_string_Update(dic_set, dic_where, table_str);
            OleDbConnection con = new OleDbConnection(connectionStringW);

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public void Apply_data(string command)
        {


            OleDbConnection con = new OleDbConnection(connectionStringW);


            try
            {
                con.Open();
                foreach (string item in command.Split(';'))
                {
                    if (item == "")
                    {
                        continue;
                    }
                    OleDbCommand cmd = new OleDbCommand(item, con);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public void Delete_data(Dictionary<string, string> dic_where, string table_str)
        {

            string command_str = dic_to_string_delete(dic_where, table_str);
            OleDbConnection con = new OleDbConnection(connectionStringW);

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public string dic_to_string_Update(Dictionary<string, string> dic_SET, Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            string re_SET = "";
            if (dic_WHERE == null || dic_SET == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0 || dic_SET.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }

                foreach (KeyValuePair<string, string> item in dic_SET)
                {
                    if (re_SET != "")
                    {
                        re_SET = re_SET + " , ";
                    }
                    re_SET = re_SET + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }

                return "UPDATE [" + table_str + "] SET" + re_SET + " WHERE " + re_WHERE;

            }

        }

        public string dic_to_string_UpdateWO(Dictionary<string, string> dic_SET, Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            string re_SET = "";
            if (dic_WHERE == null || dic_SET == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0 || dic_SET.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " " + item.Value + "";

                }

                foreach (KeyValuePair<string, string> item in dic_SET)
                {
                    if (re_SET != "")
                    {
                        re_SET = re_SET + " , ";
                    }
                    re_SET = re_SET + " [" + item.Key + "] =" + " " + item.Value + "";

                }

                return "UPDATE [" + table_str + "] SET" + re_SET + " WHERE " + re_WHERE;

            }

        }
        public string dic_to_string_delete(Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            if (dic_WHERE == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }



                return "DELETE FROM [" + table_str + "] " + " WHERE " + re_WHERE;
            }


        }

        public string dic_to_string_deleteWO(Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            if (dic_WHERE == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " " + item.Value + "";

                }



                return "DELETE FROM [" + table_str + "] " + " WHERE " + re_WHERE;
            }


        }
        //using Dataset way
        //return dataset object contain all user data 
        //this is not ageneric function
        public DataTable Dataset_select(string table_str, string user_id, string Date)
        {
            OleDbConnection con = new OleDbConnection(connectionStringR);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";
            string asd = string.Format("SELECT * FROM {0}  WHERE User='{1}' AND Date1= #{2}#", table_str, user_id, Date);
            OleDbDataAdapter da = new OleDbDataAdapter(asd, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public DataTable Read_DataSet(Dictionary<string, string> dic_where, string table_str, string Column_str)
        {
            string select_str;
            OleDbConnection con = new OleDbConnection(connectionStringR);
            select_str = dic_to_string_Read(dic_where, table_str, Column_str);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";

            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public void Upload_table(DataTable D_table, string table_str, Dictionary<string, string> dic_where)
        {
            string select_str;
            //create select statment to use in build
            select_str = dic_to_string_Read(dic_where, table_str, "*");
            //start build commands
            OleDbConnection con = new OleDbConnection(connectionStringW);
            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
            da.UpdateCommand = builder.GetUpdateCommand();
            da.InsertCommand = builder.GetInsertCommand();
            //builder.GetDeleteCommand();
            //builder.GetInsertCommand();
            //builder.GetUpdateCommand();
            //think of how to force update statment to update specific colomns only
            try
            {
                da.Update(D_table);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                con.Close();
                throw;
            }

        }
        /// <summary>
        /// this used to add column "status" to this table
        /// </summary>
        /// <param name="table"></param>
        public static void table_with_status_col(ref DataTable table)
        {
            table.Columns.Add("status", typeof(System.String));

        }
        static public string time_str(DateTime time)
        {
            return "#" + time.Date.ToString("MM/dd/yyyy") + "#";
        }

        static public string obj_str(string item)
        {
            return "'" + item + "'";
        }
        public DataTable Read_DataSet(Dictionary<string, string> dic_where, string table_str, List<string> Column_str_list)
        {
            string select_str;
            string Column_str = "";
            bool flag = true;
            OleDbConnection con = new OleDbConnection(connectionStringR);
            foreach (string item in Column_str_list)
            {
                if (flag)
                {
                    Column_str = item;
                    flag = false;
                }
                else
                {
                    Column_str = Column_str + "], " + " [" + item;
                }

            }
            select_str = dic_to_string_Read(dic_where, table_str, Column_str);
            select_str = select_str + " WHERE [" + Column_str_list[0] + "] IS NOT NULL";
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";

            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public static int version_num(string constr)
        {
            //here i will return -1 incase not reachable DB
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand cmd = new OleDbCommand("select count(*) from version", con);
            try
            {
                
                con.Open();
                return  (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();            }
        }
    }
}

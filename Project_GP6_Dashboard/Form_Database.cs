using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;



using System.Diagnostics;
using System.Net.Mail;
using SnmpSharpNet;

using System.Configuration;
using System.Net;
using Oracle.ManagedDataAccess.Client;

namespace Project_GP6_Dashboard
{
    public partial class Form_Database : Form
    {
        public Form_Database()
        {
            InitializeComponent();
        }

        private void Database_Form_Load(object sender, EventArgs e)
        {
            // Get_MySQL_performance_schema("192.168.1.94", "performance_schema", "performance_timers");


            //read_data_base_MySQL("192.168.1.94", "Students", "COE");

            //read_data_base_MySQL_performance_io_waits_summary("192.168.1.94", "username", "password");
            //read_data_base_MySQL_performance_accounts("192.168.1.94", "username", "password");

        }

        //https://docs.oracle.com/database/121/ODPNT/featConnecting.htm#ODPNT187
        public static void connect_data_base_Oracle(string address, string name_data_base, string table)
        { 
        OracleConnection con = new OracleConnection();

        //Open a connection using ConnectionString attributes
        //related to connection pooling.
        con.ConnectionString = 
      "User Id=scott;Password=tiger;Data Source=oracle;" + 
      "Min Pool Size=10;Connection Lifetime=100000;Connection Timeout=60;" + 
      "Incr Pool Size=5; Decr Pool Size=2";
    con.Open();
    Console.WriteLine("Connection pool successfully created");
 
    // Close and Dispose OracleConnection object
    con.Close();
    con.Dispose();
    Console.WriteLine("Connection is placed back into the pool.");
  }



        //#todo change name
        public static string Get_MySQL_performance_schema(string address, string name_data_base, string table)
        {
            //string [] array_Table = new string[4];
            //array_Table[0] =  { "performance_timers" };

            //array_Table[1] =  {"table_io_waits_summary_by_table" };

            //array_Table[2] =  { "table_io_waits_summary_by_table" };

            //array_Table[3] =  { "table_io_waits_summary_by_table" };


            // Declaration of the array
          //  string[] str1, array_Table;

            // Initialization of array
            //   str1 = new string[5] { “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };

         //   array_Table = new string[] { "performance_timers" , "table_io_waits_summary_by_table" };


            //configure database connection
            string connectionString = "datasource=" + address + ";port=3306;username=username;password=password;database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    
            // Query
            string query = "SELECT * FROM " + table;
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;//MYA
            string temp = "";
            try
            {
                // Open the database
                databaseConnection.Open();

                //MySqlTrace trace = new MySqlTrace();

                //MySqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ConnectionOpened);


                //    databaseConnection.CreateCommand;
                // Execute the query
                reader = commandDatabase.ExecuteReader();

                //performance_timers :

                while (reader.Read())
                {
                    temp = temp + "TIMER_NAME :  " + reader["TIMER_NAME"].ToString() + "\n"
                        + "TIMER_FREQUENCY : " + reader["TIMER_FREQUENCY"].ToString() + "\n"
                        + "TIMER_RESOLUTION  " + reader["TIMER_RESOLUTION"].ToString() + "\n"
                        + "TIMER_OVERHEAD   " + reader["TIMER_OVERHEAD"].ToString() + "\n"
                    ;




                    //table_io_waits_summary_by_table:

                    //while (reader.Read())
                    //{
                    //    temp += "OBJECT_TYPE  :  " + reader["OBJECT_TYPE  "].ToString() + "\n"
                    //        + "TIMER_FREQUENCY : " + reader["TIMER_FREQUENCY "].ToString() + "\n"
                    //        + "TIMER_RESOLUTION  " + reader["TIMER_RESOLUTION "].ToString() + "\n"
                    //        + "TIMER_OVERHEAD   " + reader["TIMER_OVERHEAD  "].ToString() + "\n";
                    //    ;

                   // MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }//while
                MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "read_data_base_MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);// Show any error message.
            }
            return temp;
        }//read DB

        //  public static string read_data_base_MySQL(string address, string name_data_base, string table)
        public static string read_data_base_MySQL(string address, string name_data_base, string table, string username, string password)
        {
            //configure database connection
            //  string connectionString = "datasource=" + address + ";port=3306;username=username;password=password;database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

              string connectionString = "datasource=" + address + ";port=3306;username="+username+";password="+password+";database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

           // MessageBox.Show(connectionString);

            // Query
            string query = "SELECT * FROM " + table;
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;//MYA
            string temp = null;
            try
            {
                // Open the database
                databaseConnection.Open();

                //MySqlTrace trace = new MySqlTrace();

                //MySqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ConnectionOpened);


                //    databaseConnection.CreateCommand;
                // Execute the query
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    temp = temp + "Name:  " + reader["Name"].ToString() + "\n"
                        + "ID: " + reader["ID"].ToString() + "\n"
                        + "Level " + reader["Level"].ToString() + "\n";
                }//while
                //MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Available";

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "read_data_base_MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);// Show any error message.

                return ex.Message;
            }
           // return temp;
        }//read DB


        public void read_data_base_MySQL_performance_io_waits_summary(string address, string username, string password)
        {
            //configure database connection
            string name_data_base = "performance_schema";

            string connectionString = "datasource=" + address + ";port=3306;username=" + username + ";password=" + password + ";database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

            // Query
            string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = 'COE'";
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;//MYA
            try
            {
                // Open the database
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    string COUNT_STAR = reader["COUNT_STAR"].ToString();
                    string COUNT_FETCH = reader["COUNT_FETCH"].ToString();
                    string AVG_TIMER_WAIT = reader["AVG_TIMER_WAIT"].ToString();
                    string AVG_TIMER_WRITE = reader["AVG_TIMER_WRITE"].ToString();
                    string AVG_TIMER_READ = reader["AVG_TIMER_READ"].ToString();
                    string AVG_TIMER_FETCH = reader["AVG_TIMER_FETCH"].ToString();
                    string AVG_TIMER_INSERT = reader["AVG_TIMER_INSERT"].ToString();

                    

                    Database_listView.Items.Add(new ListViewItem(new String[] {address, name_data_base , "Available", COUNT_STAR, COUNT_FETCH, AVG_TIMER_WAIT, AVG_TIMER_WRITE, AVG_TIMER_READ, AVG_TIMER_FETCH , AVG_TIMER_INSERT }));
                  
                    
                   // MessageBox.Show(COUNT_STAR + " " + COUNT_FETCH + " " + AVG_TIMER_WAIT + " " + AVG_TIMER_WRITE + " " + AVG_TIMER_READ +" " + AVG_TIMER_INSERT);


                }//while
                //MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return "Available";

            }
            catch (Exception ex)
            {
                Database_listView.Items.Add(new ListViewItem(new String[] { address, name_data_base, ex.Message }));

           //     MessageBox.Show(ex.Message, "read_data_base_MySQL_performance_io_waits_summary", MessageBoxButtons.OK, MessageBoxIcon.Error);// Show any error message.

                //return ex.Message;
            }
            // return temp;
        }//read read_data_base_MySQL_performance_io_waits_summary


        public void read_data_base_MySQL_performance_io_waits_summary2(string address, string username, string password)
        {
            //configure database connection
            string name_data_base = "performance_schema";

            string connectionString = "datasource=" + address + ";port=3306;username=" + username + ";password=" + password + ";database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

            // Query
            string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = 'COE'";
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;//MYA
            try
            {
                // Open the database
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    string COUNT_STAR = reader["COUNT_STAR"].ToString();
                    string COUNT_FETCH = reader["COUNT_FETCH"].ToString();
                    string AVG_TIMER_WAIT = reader["AVG_TIMER_WAIT"].ToString();
                    string AVG_TIMER_WRITE = reader["AVG_TIMER_WRITE"].ToString();
                    string AVG_TIMER_READ = reader["AVG_TIMER_READ"].ToString();
                    string AVG_TIMER_FETCH = reader["AVG_TIMER_FETCH"].ToString();
                    string AVG_TIMER_INSERT = reader["AVG_TIMER_INSERT"].ToString();



                    Database_listView.Items.Add(new ListViewItem(new String[] { address, name_data_base, "Available", COUNT_STAR, COUNT_FETCH, AVG_TIMER_WAIT, AVG_TIMER_WRITE, AVG_TIMER_READ, AVG_TIMER_FETCH, AVG_TIMER_INSERT }));


                    // MessageBox.Show(COUNT_STAR + " " + COUNT_FETCH + " " + AVG_TIMER_WAIT + " " + AVG_TIMER_WRITE + " " + AVG_TIMER_READ +" " + AVG_TIMER_INSERT);


                }//while
                //MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return "Available";

            }
            catch (Exception ex)
            {
                Database_listView.Items.Add(new ListViewItem(new String[] { address, name_data_base, ex.Message }));

                //     MessageBox.Show(ex.Message, "read_data_base_MySQL_performance_io_waits_summary", MessageBoxButtons.OK, MessageBoxIcon.Error);// Show any error message.

                //return ex.Message;
            }
            // return temp;
        }//read read_data_base_MySQL_performance_io_waits_summary


        public void read_data_base_MySQL_performance_accounts(string address, string username, string password)
        {
            //configure database connection
            string name_data_base = "performance_schema"; 

            string connectionString = "datasource=" + address + ";port=3306;username=" + username + ";password=" + password + ";database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

            // Query
            string query = "SELECT * FROM `accounts`";
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;//MYA
            try
            {
                // Open the database
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    string USER = reader["USER"].ToString();
                    string HOST = reader["HOST"].ToString();
                    string CURRENT_CONNECTIONS = reader["CURRENT_CONNECTIONS"].ToString();
                    string TOTAL_CONNECTIONS = reader["TOTAL_CONNECTIONS"].ToString();


                    users_listView.Items.Add(new ListViewItem(new String[] { address, name_data_base, USER, HOST, CURRENT_CONNECTIONS, TOTAL_CONNECTIONS}));


                    // MessageBox.Show(COUNT_STAR + " " + COUNT_FETCH + " " + AVG_TIMER_WAIT + " " + AVG_TIMER_WRITE + " " + AVG_TIMER_READ +" " + AVG_TIMER_INSERT);


                }//while
                //MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return "Available";

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "read_data_base_MySQL_performance_io_waits_summary", MessageBoxButtons.OK, MessageBoxIcon.Error);// Show any error message.
                users_listView.Items.Add(new ListViewItem(new String[] { address, name_data_base, ex.Message }));

                //return ex.Message;
            }
            // return temp;
        }//read read_data_base_MySQL_performance_io_waits_summary

        public static bool IsConnectedToInternet() //beta
        {
            string host = "http://www.google.com";
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 100);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ConnectedToInternet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public static String IsConnectedToInternet_string()
        {
            bool result = IsConnectedToInternet();
            if (result == true)
            {
                return "Available";
            }
            else
            {
                return "Not available";
            }
        }

        //WITH AHMED 5/3/2021
        public static void DNS_SNMP()
        {
            //1.3.6.1.3.43

            //https://snmpsharpnet.com/index.php/walk-operation-with-snmp-version-1-and-2c/
            // SNMP community name
            OctetString community = new OctetString("public");
            // Define agent parameters class
            AgentParameters param = new AgentParameters(community);
            // Set SNMP version to 2 (GET-BULK only works with SNMP ver 2 and 3)
            param.Version = SnmpVersion.Ver2;
            // Construct the agent address object
            // IpAddress class is easy to use here because
            //  it will try to resolve constructor parameter if it doesn't
            //  parse to an IP address
            IpAddress agent = new IpAddress("192.168.1.90");
            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Define Oid that is the root of the MIB
            //  tree you wish to retrieve

            //http://oid-info.com/get/1.3.6.1.3.43

            //http://oid-info.com/get/1.3.6.1.2.1.32
            Oid rootOid = new Oid("	1.3.6.1.4.1.22610.2.4.2.9.1.2"); // ifDescr
            // This Oid represents last Oid returned by
            //  the SNMP agent
            Oid lastOid = (Oid)rootOid.Clone();
            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.GetBulk);
            // In this example, set NonRepeaters value to 0
            pdu.NonRepeaters = 0;
            // MaxRepetitions tells the agent how many Oid/Value pairs to return
            // in the response.
            pdu.MaxRepetitions = 5;
            // Loop through results
            while (lastOid != null)
            {
                // When Pdu class is first constructed, RequestId is set to 0
                // and during encoding id will be set to the random value
                // for subsequent requests, id will be set to a value that
                // needs to be incremented to have unique request ids for each
                // packet
                if (pdu.RequestId != 0)
                {
                    pdu.RequestId += 1;
                }
                // Clear Oids from the Pdu class.
                pdu.VbList.Clear();
                // Initialize request PDU with the last retrieved Oid
                pdu.VbList.Add(lastOid);
                // Make SNMP request
                SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);
                // You should catch exceptions in the Request if using in real application.
                // If result is null then agent didn't reply or we couldn't parse the reply.
                if (result != null)
                {
                    // ErrorStatus other then 0 is an error returned by
                    // the Agent - see SnmpConstants for error definitions
                    if (result.Pdu.ErrorStatus != 0)
                    {
                        // agent reported an error with the request
                        Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                            result.Pdu.ErrorStatus,
                            result.Pdu.ErrorIndex);
                        lastOid = null;
                        break;
                    }
                    else
                    {
                        // Walk through returned variable bindings
                        foreach (Vb v in result.Pdu.VbList)
                        {
                            // Check that retrieved Oid is "child" of the root OID
                            if (rootOid.IsRootOf(v.Oid))
                            {
                                Console.WriteLine("{0} ({1}): {2}",
                                    v.Oid.ToString(),
                                    SnmpConstants.GetTypeName(v.Value.Type),
                                    v.Value.ToString());
                                if (v.Value.Type == SnmpConstants.SMI_ENDOFMIBVIEW)
                                    lastOid = null;
                                else
                                    lastOid = v.Oid;
                            }
                            else
                            {
                                // we have reached the end of the requested
                                // MIB tree. Set lastOid to null and exit loop
                                lastOid = null;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No response received from SNMP agent.");
                }
            }
            target.Close();
        }

        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            this.Hide();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            //string state = read_data_base_MySQL(ipadressbox.Text, table_textBox.Text, table_textBox.Text, username_textBox.Text, password_textBox.Text);
            //Database_listView.Items.Add(new ListViewItem(new String[] { ipadressbox.Text, table_textBox.Text, state }));

            //  Database_listView
        }

        private void username_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_scan_OOP_Click(object sender, EventArgs e)
        {
            Database_Monitoring obj_DB = new Database_Monitoring(ipadressbox.Text, username_textBox.Text, password_textBox.Text, table_textBox.Text);
            //Database_listView.Items.Add(new ListViewItem(new String[] { obj_DB.get_ip_address(), table_textBox.Text,obj_DB.Connection ,
            //    obj_DB.COUNT_STAR, obj_DB.COUNT_FETCH, obj_DB.AVG_TIMER_WAIT, obj_DB.AVG_TIMER_WRITE, obj_DB.AVG_TIMER_READ,
            //    obj_DB.AVG_TIMER_FETCH, obj_DB.AVG_TIMER_INSERT }));


            List<string[]> performance_IO__DB_list_temp = obj_DB.performance_IO_DB_list;


            foreach (string[] i in performance_IO__DB_list_temp)
            {
                Database_listView.Items.Add(new ListViewItem(i));
            }


            List<string[]> Users_DB_list_temp = obj_DB.Users_DB_list;


            foreach (string[] i in Users_DB_list_temp)
            {

                users_listView.Items.Add(new ListViewItem(i));

            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.Rest.Azure.OData;
using MySqlConnector;
//https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp
using Microsoft.WindowsAzure;
using MySql.Data.MySqlClient.Memcached;
using System.Data.SqlClient;

namespace Project_GP6_Dashboard
{
    public partial class Form_Cloud : Form
    {
        public Form_Cloud()
        {
            InitializeComponent();
        }

        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }


        private void Form_Cloud_Load(object sender, EventArgs e)
        {
            //check_Azure_table_io_waits_summary_by_table();


            //check_Azure_table_io_waits_summary_by_table2();


            //check_Azure_accounts();
            //insert_table_azure();

            //  check_Azure2();

            //Connection();
        }


        public static void Connection()
        {
            SqlConnection connection = new SqlConnection("Server:studenttestsql.mysql.database.azure.com,Port:3306,Database:studenttestsql,UserID:studenttest@studenttestsql,Password:ST@172839");
            connection.Open();
            MessageBox.Show("Open");
                
                }

        //Eng. maher
        //https://docs.microsoft.com/en-us/azure/mysql/connect-csharp

        //https://docs.microsoft.com/en-us/azure/mysql/connect-csharp
        public void check_Azure_table_io_waits_summary_by_table()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",


                //Server = "studenttestsql.mysql.database.azure.com",
                //Database = "studenttestsql",
                //UserID = "studenttest@studenttestsql",
                //Password = "ST@172839",




            Server = "studenttestsql.mysql.database.azure.com",
            Port = 3306,
                  //Database = "studenttestsql",
                  Database = "performance_schema",

                UserID = "studenttest@studenttestsql",
           Password = "ST@172839",
                SslMode = MySqlSslMode.Preferred,


          //  SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                conn.Open();

                using (var command = conn.CreateCommand())
                {

                    //command.CommandText = "SELECT * FROM inventory;";

                    // command.CommandText = "SELECT* FROM `table_io_waits_summary_by_table`";

                    //

                    Console.WriteLine("user");


                    string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = 'user'";

                    command.CommandText = query;

                    //Moahmmad

                    // command.CommandText = "SELECT * performance_schema";
                    using (var reader =  command.ExecuteReader())
                    {
                        while ( reader.Read())
                        {
                            //Console.WriteLine(string.Format(
                            //    "Reading from table=({0}, {1}, {2}, {3}, {4})",
                            //    reader.GetString(0),
                            //    reader.GetString(1),
                            //    reader.GetString(2),
                            //    reader.GetInt32(3),
                            //                                    reader.GetInt32(4)


                            //    ));


                            string COUNT_STAR = reader["COUNT_STAR"].ToString();
                            string COUNT_FETCH = reader["COUNT_FETCH"].ToString();
                            string AVG_TIMER_WAIT = reader["AVG_TIMER_WAIT"].ToString();
                            string AVG_TIMER_WRITE = reader["AVG_TIMER_WRITE"].ToString();
                            string AVG_TIMER_READ = reader["AVG_TIMER_READ"].ToString();
                            string AVG_TIMER_FETCH = reader["AVG_TIMER_FETCH"].ToString();
                            string AVG_TIMER_INSERT = reader["AVG_TIMER_INSERT"].ToString();

                            Console.WriteLine("COUNT_STAR " + COUNT_STAR);
                            Console.WriteLine("COUNT_FETCH " + COUNT_FETCH);
                            Console.WriteLine("AVG_TIMER_WAIT " + AVG_TIMER_WAIT);
                            Console.WriteLine("AVG_TIMER_WRITE "+AVG_TIMER_WRITE);
                            Console.WriteLine("AVG_TIMER_READ " + AVG_TIMER_READ);
                            Console.WriteLine("AVG_TIMER_FETCH " + AVG_TIMER_FETCH);
                            Console.WriteLine("AVG_TIMER_INSERT " + AVG_TIMER_INSERT);


                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            //Console.ReadLine();
        }


        public void check_Azure_table_io_waits_summary_by_table2()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",

                //  SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                conn.Open();

                using (var command = conn.CreateCommand())
                {

                    //command.CommandText = "SELECT * FROM inventory;";

                    // command.CommandText = "SELECT* FROM `table_io_waits_summary_by_table`";

                    //
                    Console.WriteLine("sys_config");
                    string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = 'sys_config'";

                    command.CommandText = query;

                    //Moahmmad

                    // command.CommandText = "SELECT * performance_schema";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine(string.Format(
                            //    "Reading from table=({0}, {1}, {2}, {3}, {4})",
                            //    reader.GetString(0),
                            //    reader.GetString(1),
                            //    reader.GetString(2),
                            //    reader.GetInt32(3),
                            //                                    reader.GetInt32(4)


                            //    ));


                            string COUNT_STAR = reader["COUNT_STAR"].ToString();
                            string COUNT_FETCH = reader["COUNT_FETCH"].ToString();
                            string AVG_TIMER_WAIT = reader["AVG_TIMER_WAIT"].ToString();
                            string AVG_TIMER_WRITE = reader["AVG_TIMER_WRITE"].ToString();
                            string AVG_TIMER_READ = reader["AVG_TIMER_READ"].ToString();
                            string AVG_TIMER_FETCH = reader["AVG_TIMER_FETCH"].ToString();
                            string AVG_TIMER_INSERT = reader["AVG_TIMER_INSERT"].ToString();

                            Console.WriteLine("COUNT_STAR " + COUNT_STAR);
                            Console.WriteLine("COUNT_FETCH " + COUNT_FETCH);
                            Console.WriteLine("AVG_TIMER_WAIT " + AVG_TIMER_WAIT);
                            Console.WriteLine("AVG_TIMER_WRITE " + AVG_TIMER_WRITE);
                            Console.WriteLine("AVG_TIMER_READ " + AVG_TIMER_READ);
                            Console.WriteLine("AVG_TIMER_FETCH " + AVG_TIMER_FETCH);
                            Console.WriteLine("AVG_TIMER_INSERT " + AVG_TIMER_INSERT);


                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
           // Console.ReadLine();
        }


        public void check_Azure_accounts()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",


                //  SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                conn.Open();

                using (var command = conn.CreateCommand())
                {

                    //command.CommandText = "SELECT * FROM inventory;";

                    // command.CommandText = "SELECT* FROM `table_io_waits_summary_by_table`";

                    //

                    Console.WriteLine("accounts");
                    string query = "SELECT* FROM `accounts`";

                    command.CommandText = query;

                    //Moahmmad

                    // command.CommandText = "SELECT * performance_schema";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            //Console.WriteLine(string.Format(
                            //    "Reading from table=({0}, {1}, {2}, {3}, {4})",
                            //    reader.GetString(0),
                            //    reader.GetString(1),
                            //    reader.GetString(2),
                            //    reader.GetInt32(3),
                            //                                    reader.GetInt32(4)


                            //    ));

                            string USER = reader["USER"].ToString();
                            string HOST = reader["HOST"].ToString();
                            string CURRENT_CONNECTIONS = reader["CURRENT_CONNECTIONS"].ToString();
                            string TOTAL_CONNECTIONS = reader["TOTAL_CONNECTIONS"].ToString();

                            Console.WriteLine("USER " + USER);
                            Console.WriteLine("HOST " + HOST);
                            Console.WriteLine("CURRENT_CONNECTIONS " + CURRENT_CONNECTIONS);
                            Console.WriteLine("TOTAL_CONNECTIONS " + TOTAL_CONNECTIONS);
               


                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
           // Console.ReadLine();
        }

        public void insert_table_azure()
        {
       //     SqlConnection con;
         //   SqlCommand cmd;
            /*creating or openning database*/
            //   con = new SqlConnection("server=.; Initial Catalog = MyDatabase; Integrated Security = SSPI");

            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",


                //  SslMode = MySqlSslMode.Required,
            };


            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    //https://www.csharp-console-examples.com/database/create-table-in-sql-server-using-c/
                    string sql = @"IF NOT EXISTS (SELECT * FROM studenttestsql WHERE name='Student')
                            CREATE TABLE [studenttestsql].[Student_COE](
	                        [FirstName] [nchar](10) NULL,
	                        [LastName] [nchar](10) NULL,
                            )";

                    command.CommandText = sql;



                    //conn.Open();
                  //  command = new SqlCommand(sql, conn);
                   // command.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    conn.Close();
                    Console.ReadKey();
                }
            }
        }

        public async void check_Azure2()
        {

            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",
               // SslMode = MySqlSslMode.Required,


            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM inventory;";

                    //Moahmmad
                    
                   //command.CommandText = "SELECT * FROM performance_schema;";


                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Console.WriteLine(string.Format(
                                "Reading from table=({0}, {1}, {2})",
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2)));
                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        

    }

            //Ahmed 
            //19-3-2021


            //https://docs.microsoft.com/en-us/samples/azure-samples/monitor-dotnet-metrics-api/monitor-dotnet-metrics-api/


            //Ant library ???

            /*
            public void List_metrics()
            {
                // Build the service credentials and Monitor client
                var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(Tenant, Client, secret);
                var monitorClient = new MonitorClient(serviceCreds);
                monitorClient.SubscriptionId = subscriptionId;



                // The comma-separated list of metric names must be present if a filter is used
                var metricNames = "name.value eq 'CpuPercentage'"; // could be concatenated with " or name.value eq '<another name>'" ...

                // Time grain is optional when metricNames is present
                string timeGrain = " and timeGrain eq duration'PT5M'";

                // Defaulting to 3 hours before the time of execution for these datetimes
                string startDate = string.Format(" and startTime eq {0}", DateTime.Now.AddHours(-3).ToString("o"));
                string endDate = string.Format(" and endTime eq {0}", DateTime.Now.ToString("o"));

                var odataFilterMetrics = new ODataQuery<Metric>(
                    string.Format(
                        "{0}{1}{2}{3}",
                        metricNames,
                        timeGrain,
                        startDate,
                        endDate));

              //  Write("Call with filter parameter (i.e. $filter = {0})", odataFilterMetrics);
            //    metrics = await readOnlyClient.Metrics.ListAsync(resourceUri: resourceUri, odataQuery: odataFilterMetrics, cancellationToken: CancellationToken.None);
            }
            */







            //https://stackoverflow.com/questions/48099715/get-metrics-of-an-azure-vm-in-c-sharp
            public void metrics_azure()
        {
        var azureTenantId = "tenant id";
        var azureSecretKey = "secret key";
        var azureAppId = "client id";
        var subscriptionId = "subscription id";
        var resourceGroup = "resource group";
        var machineName = "machine name";
        var serviceCreds = ApplicationTokenProvider.LoginSilentAsync(azureTenantId, azureAppId, azureSecretKey).Result;
       // MonitorClient monitorClient = new MonitorClient(serviceCreds) { SubscriptionId = subscriptionId };
        var resourceUrl = $"subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachines/{machineName}";
        var metricNames = "(name.value eq 'Disk Write Operations/Sec' or  name.value eq 'Percentage CPU' or  name.value eq 'Network In' or  name.value eq 'Network Out' or  name.value eq 'Disk Read Operations/Sec' or  name.value eq 'Disk Read Bytes' or  name.value eq 'Disk Write Bytes')";
        string timeGrain = " and timeGrain eq duration'PT5M'";
        string startDate = " and startTime eq 2017-10-26T05:28:34.919Z";
        string endDate = " and endTime eq 2017-10-26T05:33:34.919Z";
        var odataFilterMetrics = new ODataQuery<MetricInner>(
                       $"{metricNames}{timeGrain}{startDate}{endDate}");

     //   var metrics = monitorClient.Metrics.ListWithHttpMessagesAsync(resourceUrl, odataFilterMetrics).Result;
    }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            Cloud_Monitoring obj = new Cloud_Monitoring(ipadressbox.Text, username_textBox.Text, password_textBox.Text,table_textBox.Text);



            List<string[]> performance_IO_Cloud_list_temp = obj.performance_IO_Cloud_list;


            foreach (string[] i in performance_IO_Cloud_list_temp)
            {
                Database_listView.Items.Add(new ListViewItem(i));
            }


            List<string[]> Users_Azure_list_temp = obj.Users_Azure_list;


            foreach (string[] i in Users_Azure_list_temp)
            {
                users_listView.Items.Add(new ListViewItem(i));
            }

            Cloud_listView.Items.Add(new ListViewItem(new String[] {  obj .get_ip_address() , obj.Connection}));
        }

        //private static async Task<MonitorClient> AuthenticateWithReadOnlyClient(string tenantId, string clientId, string secret, string subscriptionId)
        //{
        //    // Build the service credentials and Monitor client            
        //    var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, secret);
        //    var monitorClient = new MonitorClient(serviceCreds);
        //    monitorClient.SubscriptionId = subscriptionId;
        //    return monitorClient;
        //}

    }

}

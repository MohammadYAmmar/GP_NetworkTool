using System;
using System.Collections.Generic;
using System.Data;

using System.Windows.Forms;

using System.IO;

using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;

// Include the required namespace of LiveCharts

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



//Design and limk code by ahmed 31/1/2021 :)
//edit by mohammad 31/1/2021 after meet




////edit by Ahmed & mohammad 18/2/2021 with meet

//Add DNS by Mohammad 22/2/2021

//Add DNS by Mohammad 23/2/2021 by URL by Ahmed


////Add username and password to CSV by Ahmed & mohammad 4/3/2021 with meet

//move to dashboard 16/3/2021 by mohammad

//Parallel programming to scan WMI and file () 24/3/2021  by Mohammad

//Parallel programming to read files 25/3/2021 by mohammad
namespace Project_GP6_Dashboard
{

        public partial class Form_IIS_DNS : Form
        {
            static string ping_info = "";
            static string http_info = "";

            static string dns_info = "";


            static bool one_time = true;
            //  string path_folder = "C:\\Users\\world\\source\\repos\\GUI_GP6_SNMP_DB_V20_GP1\\GUI_GP6_SNMP_DB";


            //Data to WMI 
            public static string name = "";

            public static int TotalGetRequests = 0;
            public static int TotalHeadRequests = 0;
            public static int FilesSentPerSec = 0;
            public static int FilesReceivedPerSec = 0;
            public static int AnonymousUsersPerSec = 0;
            public static int CurrentNonAnonymousUsers = 0;
            public static int CGIRequestsPerSec = 0;
            public static int GetRequestsPerSec = 0;
            public static int PostRequestsPerSec = 0;
            public static int NotFoundErrorsPerSec = 0;


            List<string> IP_list = new List<string>(new string[] { });


            //idea https://github.com/zacharyreese/NetworkScanner/blob/master/NetworkScanner/Form1.cs

            Thread Automatic_Update_Thread = null;


            private System.Windows.Forms.NotifyIcon notifyIcon1;

            static int TotalGetRequests_total = 0;

            public Form_IIS_DNS()
            {
                InitializeComponent();
            }

            private void panel2_Paint(object sender, PaintEventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            //From GP1
            private void read_csv_automatically()//edit with group to auto :) 15/nov/2020 
            {
                int count = 0;
                try
                {

                    //https://stackoverflow.com/questions/13762338/read-files-from-a-folder-present-in-project

                    // string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Names.txt");

                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"IP_Website.csv");

                    //string[] files = File.ReadAllLines(path);

                    // string path = @path_folder + "\\IP_database.csv";//Name of file
                    //  string path =  "\\IP_database.csv";//Name of file 

                    var lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        count = count + 1;
                        var parts = line.Split(',');
                        //  ListViewItem lvi = new ListViewItem(parts[0]);//parts[0] Name , 1 IP , 2 website
                        // scan_pooling_csv(parts[1]);
                        //Pooling_listView.Items.Add(new ListViewItem(new String[] { parts[0], parts[1], ping_state, "soon", database_state }));


                        //old 
                        //  scan_http(parts[1], parts[2]);// with IIS_W3SVC_WebService_WMI if avalible
                        //   IIS_W3SVC_WebService_WMI(parts[1], parts[2]);

                        //new with ahmed 3/3/2021
                        scan_http(parts[1], parts[2], parts[3], parts[4]);// with IIS_W3SVC_WebService_WMI if avalible

                        IP_list.Add(parts[1]); //parts[1] IP address
                    }
                    MessageBox.Show("From csv file: " + (count + " rows imported.")); // update count

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void read_csv_automatically_P()//edit with group to auto :) 15/nov/2020 and 24/3/2021
        {
            int count = 0;
            try
            {

                //https://stackoverflow.com/questions/13762338/read-files-from-a-folder-present-in-project

                // string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Names.txt");

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"IP_IIS_Website.csv");

                //string[] files = File.ReadAllLines(path);

                // string path = @path_folder + "\\IP_database.csv";//Name of file
                //  string path =  "\\IP_database.csv";//Name of file 

                var lines = File.ReadAllLines(path);

                //25/3/2021
                Parallel.ForEach(lines, line =>          
                {
                    count = count + 1;
                    var parts = line.Split(',');

                    //new with ahmed 3/3/2021
                    // scan_http(parts[1], parts[2], parts[3], parts[4]);// with IIS_W3SVC_WebService_WMI if avalible
                    //24/3/2021
                    //  IIS_W3SVC_WebService_WMI_Parallel(parts[1], parts[3], parts[4]);

                    MessageBox.Show(parts[1] + " " + parts[3] + " " + parts[4], "read_csv_automatically_P", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    //    IP_list.Add(parts[1]); //parts[1] IP address
                });


                //serial
                //foreach (string line in lines)
                //{
                //    count = count + 1;
                //    var parts = line.Split(',');

                //    //new with ahmed 3/3/2021
                //    // scan_http(parts[1], parts[2], parts[3], parts[4]);// with IIS_W3SVC_WebService_WMI if avalible
                //    //24/3/2021
                //    IIS_W3SVC_WebService_WMI_Parallel(parts[1], parts[3], parts[4]);



                //    IP_list.Add(parts[1]); //parts[1] IP address
                //}
                MessageBox.Show("From csv file: " + (count + " rows imported.")); // update count

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        //Load_csv_manual_button

        private void read_csv_manual()
            {
                OpenFileDialog ofDialog = new OpenFileDialog();
                ofDialog.Filter = @"CSV Files|*.csv";
                ofDialog.Title = @"Select your CSV file...";
                ofDialog.FileName = "IP_Website.csv";
                int count = 0;
                if (ofDialog.ShowDialog() == DialogResult.Cancel)            // is cancel pressed?
                    return;
                try
                {
                    string filename = ofDialog.FileName;
                    var lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        count = count + 1;
                        var parts = line.Split(',');
                        //ListViewItem lvi = new ListViewItem(parts[0]);
                        //lvi.SubItems.Add(parts[1]);
                        // Pooling_listView.Items.Add(lvi);
                        // IIS_W3SVC_WebService_WMI(parts[1], parts[2]);

                        scan_http(parts[1], parts[2], parts[3], parts[4]);// with IIS_W3SVC_WebService_WMI if avalible

                        IP_list.Add(parts[1]); //parts[1] IP address

                    }
                    MessageBox.Show("From csv file: " + (count + " rows imported."));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {


                //string ip = ipadressbox.Text;
                //string web = websitebox.Text;

                //string result_availability = available_string(PingHost(ip));

                //string result_website_availability = " ";

                //if (result_availability != "Available")
                //{
                //    result_website_availability = "Not available";
                //}
                //else
                //{
                //    result_website_availability = available_string(WebSiteIsAvailable(web));
                //}
                //listView1.Items.Add(new ListViewItem(new String[] { ip, web, result_availability, result_website_availability, ping_info, http_info }));

                //Up comment ; DRY ( don't repeat code :) ) Mohammad 15-2-2021





                //  scan_http(ipadressbox.Text, websitebox.Text); //with IIS_W3SVC_WebService_WMI
                // IIS_W3SVC_WebService_WMI(ipadressbox.Text, websitebox.Text);


                check_to_scan();
                //            PingHost_GP1(ip);


            }
            //https://stackoverflow.com/questions/186894/test-if-a-website-is-alive-from-a-c-sharp-application



            //with G1 
            public void check_to_scan() // edit to all income !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                //Catch empty IP addresses

                //https://github.com/zacharyreese/NetworkScanner/blob/master/NetworkScanner/Form1.cs

                //Catch empty IP addresses

                if (ipadressbox.Text == string.Empty && websitebox.Text == string.Empty)
                {
                    //  MessageBox.Show("Please enter IP address in the text box");

                    //https://stackoverflow.com/questions/2109441/how-to-show-error-warning-message-box-in-net-how-to-customize-messagebox
                    //  MessageBox.Show("Some text", "Some title",    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please enter IP address and Website in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ipadressbox.Text == string.Empty)
                {
                    DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, DNS_info_to_IP(websitebox.Text), measure_HTTP_info(websitebox.Text) }));

                    MessageBox.Show("Please enter IP address in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (websitebox.Text == string.Empty)
                {

                    MessageBox.Show("Please enter Website in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // scan_event_log(ip_textBox.Text, "All");
                    //   scan_event_log(ip_textBox.Text, filter_event);

                    scan_http(ipadressbox.Text, websitebox.Text, username_textBox.Text, password_textBox.Text); //with IIS_W3SVC_WebService_WMI

                    DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, DNS_info_to_IP(websitebox.Text), measure_HTTP_info(websitebox.Text) }));



                }

            }

            // public void scan_http(string ip, string web)
            public void scan_http(string ip, string web, string username, string password)

            {
                //string ip = ipadressbox.Text;
                //string web = websitebox.Text;

                string result_availability = available_string(PingHost(ip));

                string result_website_availability = " ";

                // if (result_availability != "Available")
                //It took me a lot of time (20 M) to discover it
                if (string.Equals(result_availability, "Available"))
                {
                    result_website_availability = available_string(WebSiteIsAvailable(web));
                    //  IIS_W3SVC_WebService_WMI(ip, web);

                    IIS_W3SVC_WebService_WMI(ip, web, username, password);

                }
                else
                {

                    result_website_availability = "Not available";
                    //It took me a lot of time (20 M) to discover it
                    ping_info = "Not available";
                    http_info = "Not available";

                }
                HTTP_listview.Items.Add(new ListViewItem(new String[] { ip, web, result_availability, result_website_availability, ping_info, http_info }));

            }



            public static string available_string(bool temp)
            {
                if (temp == true)
                {
                    return "Available";

                }
                else
                {
                    return "Not available";

                }
            }



            public static bool WebSiteIsAvailable(string Url)
            {
                string Message = string.Empty;

                //with ahmed 23-2-2021
               // string url_new = "http://" + Url;

                //  HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

                // Set the credentials to the current user account
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.Method = "GET";

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        // Do nothing; we're only testing to see if we can get the response

                        http_info = http_info + " LastModified " + response.LastModified.ToString();
                        //  http_info = http_info + " Cookies " + response.Cookies.ToString();
                        // http_info = http_info + " SupportsHeaders  " + response.SupportsHeaders.ToString();
                        http_info = http_info + " & Server:  " + response.Server.ToString();
                        http_info = http_info + " & Protocol Version:  " + response.ProtocolVersion.ToString();
                        //  http_info = http_info + " & Status Code:  " + response.StatusCode.ToString();

                        //BY AHMED 6/2/2021
                        http_info = http_info + " & Status Code:  " + response.StatusCode.ToString();
                        http_info = http_info + " & Status Description:  " + response.StatusDescription.ToString();


                    }
                }
                catch (WebException ex)
                {
                    Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
                }

                //MYA:
                //Future work add more catch 

                return (Message.Length == 0);
            }

            public static bool PingHost(string nameOrAddress)
            {
                bool pingable = false;
                Ping pinger = null;


                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(nameOrAddress);
                    //gp6 edit

                    // ping_info = ping_info + "Address: " + reply.Address + "\r";
                    ping_info = ping_info + "Roundtrip Time: " + reply.RoundtripTime;
                    //      label += "TTL (Time To Live): " + pingreply.Options.Ttl + "\r";
                    ping_info = ping_info + " & Buffer Size: " + reply.Buffer.Length.ToString();
                    // ping_info = ping_info + " & Status: " + reply.Status.ToString();


                    //  MessageBox.Show(ping_info);
                    //


                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }

                return pingable;
            }





            //https://stackoverflow.com/questions/11800958/using-ping-in-c-sharp
            public static bool PingHost_GP1(string nameOrAddress)
            {
                bool pingable = false;
                Ping pinger = null;

                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == IPStatus.Success;
                    //MessageBox.Show(reply.RoundtripTime.ToString());

                    //  MessageBox.Show(reply.Status.ToString());

                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }

                return pingable;
            }
            //15-2-2021

            //NEW
            //https://forums.iis.net/t/1158703.aspx?Getting+IIS+Performance+information+from+C
            //  public XmlDocument GetHostCPUInfo(String hostingId, Int32 minutes)

            //EDIT 5/2/2021 without XmlDocument
            public static void GetHostCPUInfo(String hostingId, Int32 minutes)

            {

                //gp6 add try 

                try
                {
                    DataTable dt = new DataTable("CPUInfo");
                    dt.Columns.Add(new DataColumn("Name"));
                    dt.Columns.Add(new DataColumn("Value"));

                    DataRow dr;
                    // Win32_DiskDrive
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + hostingId + "\\root\\cimv2", "SELECT * FROM Win32_Processor");

                    //MYA
                    // ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + hostingId + "\\root\\cimv2", "SELECT *");

                    MessageBox.Show("conect");

                    foreach (ManagementObject obj in searcher.Get())
                    {
                        dr = dt.NewRow();
                        dr["Name"] = "Description";
                        dr["value"] = obj["Description"];
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr["Name"] = "Family";
                        dr["value"] = obj["Family"];
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr["Name"] = "Manufacturer";
                        dr["value"] = obj["Manufacturer"];
                        dt.Rows.Add(dr);
                        MessageBox.Show("for each");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);


                }

                // return getXmlDocument(dt);
            }



            //https://stackoverflow.com/questions/46441242/get-windows-server-status-using-wmi-in-c-sharp
            public static void wmi()
            {
                //string FullComputerName = "<Name of Remote Computer>";
                string FullComputerName = "192.168.1.15";

                //    string FullComputerName = "WIN - IMRMAKHGRHE";
                //      WIN - IMRMAKHGRHE
                ConnectionOptions options = new ConnectionOptions();
                ManagementScope scope = new ManagementScope("\\\\" + FullComputerName + "\\root\\cimv2", options);
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_TerminalService");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                string temp = "";
                string temp2 = "";

                foreach (ManagementObject queryObj in queryCollection)
                {
                    /*
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_TerminalService instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Started: {0}", queryObj["Started"]);
                    Console.WriteLine("State: {0}", queryObj["State"]);
                    Console.WriteLine("Status: {0}", queryObj["Status"]);
                    */

                    temp = temp + ("-----------------------------------");
                    temp = temp + ("Win32_TerminalService instance");
                    temp = temp + ("-----------------------------------");
                    temp = temp + ("Started: {0}", queryObj["Started"]);
                    temp = temp + ("State: {0}", queryObj["State"]);
                    temp = temp + ("Status: {0}", queryObj["Status"]);



                }
            }//wmi


            //https://stackoverflow.com/questions/25380420/how-to-control-windows-services-from-remote-computer-in-local-network
            public static void wmi2()
            {
                ConnectionOptions options = new ConnectionOptions();
                // options.Password = "password";
                options.Password = "Abcd@1234";

                options.Username = "Administrator";
                options.Impersonation =
                    System.Management.ImpersonationLevel.Impersonate;
                options.EnablePrivileges = true;
                // options.Authority = "NTLMDOMAIN:IQ-HOME";
                options.Authentication = AuthenticationLevel.PacketPrivacy;

                ManagementScope scope =
                 //     new ManagementScope(@"\\RTOKEN-SERVER\root\cimv2", options);
                 new ManagementScope(@"\\192.168.1.15\root\cimv2", options);
                //192.168.1.15


                scope.Connect();        //checked its connected

                MessageBox.Show("GP6 : CONNECT");

                // Make a connection to a remote computer. 
                // Replace the "FullComputerName" section of the
                // string "\\\\FullComputerName\\root\\cimv2" with
                // the full computer name or IP address of the 
                // remote computer.


                //gP6 to comment : NO

                //ServiceController service = new ServiceController("Recharger Token", "RTOKEN-SERVER");
                // ServiceController service = new ServiceController("Recharger Token", "192.168.1.15");

                //   service.Refresh();


                //MessageBox.Show(service.Status.ToString()); //Error raised: {"Cannot open Service Control Manager on computer 'rToken-server'. This operation might require other privileges."}

            }//WMI 2



           

            //OS info


            //https://docs.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-remotely-with-c-
            public static void OS_info()

            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                //MYA
                options.Password = "Abcd@1234";

                options.Username = "Administrator";
                //

                ManagementScope scope = new ManagementScope("\\\\192.168.1.15\\root\\cimv2", options);
                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();

                string temp_2 = " ";
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    //temp_2 = temp_2 + ("Computer Name     : {0}", m["csname"]);
                    //temp_2 = temp_2 + ("Windows Directory : {0}", m["WindowsDirectory"]);
                    //temp_2 = temp_2 + ("Operating System  : {0}", m["Caption"]);
                    //temp_2 = temp_2 + ("Version           : {0}", m["Version"]);
                    //temp_2 = temp_2 + ("Manufacturer      : {0}", m["Manufacturer"]);

                    //MessageBox.Show(temp_2);


                    temp_2 = temp_2 + ("Computer Name     : {0}", m["csname"]);
                    MessageBox.Show(temp_2);

                    temp_2 = "";

                    temp_2 = temp_2 + ("Windows Directory : {0}", m["WindowsDirectory"]);
                    MessageBox.Show(temp_2);
                    temp_2 = "";


                    temp_2 = temp_2 + ("Operating System  : {0}", m["Caption"]);
                    MessageBox.Show(temp_2);

                    temp_2 = "";

                    temp_2 = temp_2 + ("Version           : {0}", m["Version"]);
                    MessageBox.Show(temp_2);

                    temp_2 = "";

                    temp_2 = temp_2 + ("Manufacturer      : {0}", m["Manufacturer"]);
                    MessageBox.Show(temp_2);


                    // MessageBox.Show(temp_2);

                }
            }








            //By MYA | 9/2/2021
            //https://www.datadoghq.com/blog/iis-monitoring-tools/
            //https://docs.microsoft.com/en-us/previous-versions/aa394298(v=vs.85)
            //  public static void IIS_W3SVC_WebService_WMI()  //

            public void IIS_W3SVC_WebService_WMI(string ip, string website, string username, string password)  //

            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                //MYA
                //options.Password = "Abcd@1234";

                //options.Username = "Administrator";
                //

                //New with Ahmed 4/3/2021

                options.Password = password;

                options.Username = username;

                //  ManagementScope scope = new ManagementScope("\\\\192.168.1.15\\root\\cimv2", options);

                ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);

                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

            //   string temp_2 = " ";

           // List<ManagementObject> managementList = managementObjects.Cast<ManagementObject>().ToList();

            foreach (ManagementObject m in queryCollection)
                {
                    //Name
                    name = m["Name"].ToString();

                    //to Form2
                    //  TotalGetRequests = TotalGetRequests +  int.Parse(m["TotalGetRequests"].ToString());
                    TotalGetRequests = int.Parse(m["TotalGetRequests"].ToString());

                    //                TotalGetRequests_total = TotalGetRequests_total + TotalGetRequests;

                    if (string.Equals(name, "_Total"))
                    {
                        TotalGetRequests_total = TotalGetRequests;
                    }

                    //to Form2
                    TotalHeadRequests = int.Parse(m["TotalHeadRequests"].ToString());

                    ////https://www.paessler.com/iis-monitoring

                    //to Form2
                    FilesSentPerSec = int.Parse(m["FilesSentPerSec"].ToString());

                    //temp_2 = temp_2 + ("FilesReceivedPerSec	  : {0}", m["FilesReceivedPerSec"]);
                    //////MessageBox.Show(temp_2);
                    //to Form2
                    FilesReceivedPerSec = int.Parse(m["FilesReceivedPerSec"].ToString());
                    //////  temp_2 = "";


                    //to Form2
                    AnonymousUsersPerSec = int.Parse(m["AnonymousUsersPerSec"].ToString());

                    //to Form2
                    CurrentNonAnonymousUsers = int.Parse(m["CurrentNonAnonymousUsers"].ToString());

                    //to Form2
                    CGIRequestsPerSec = int.Parse(m["CGIRequestsPerSec"].ToString());

                    //to Form2
                    GetRequestsPerSec = int.Parse(m["GetRequestsPerSec"].ToString());

                    //to Form2
                    PostRequestsPerSec = int.Parse(m["PostRequestsPerSec"].ToString());

                    //to Form2
                    NotFoundErrorsPerSec = int.Parse(m["NotFoundErrorsPerSec"].ToString());
                    // MessageBox.Show(temp_2);


                    //
                    //    Form2.fillChart_dynamic(m["Name"].ToString(), m["TotalGetRequests"].ToString(), m["TotalGetRequests"].ToString());

                    IIS_WMI_listView.Items.Add(new ListViewItem(new String[] { ip, m["Name"].ToString(), m["TotalGetRequests"].ToString(), m["TotalHeadRequests"].ToString(), m["FilesSentPerSec"].ToString(), m["FilesReceivedPerSec"].ToString(), m["AnonymousUsersPerSec"].ToString(), m["CurrentNonAnonymousUsers"].ToString(), m["CGIRequestsPerSec"].ToString(), m["GetRequestsPerSec"].ToString(), m["PostRequestsPerSec"].ToString(), m["NotFoundErrorsPerSec"].ToString() }));



                    //chart title  
                    //  chart1.Titles.Add("IIS monitoring");




                    //to chart
                    //sol Error CS0120  An object reference is required for the non-static field, method, or property 'Form2.update_fillChart()'	GP6 IIS with GUI    C:\Users\Mohammad Yaser Ammar\source\repos\GP6\Form1.cs	1144	Active
                    //https://stackoverflow.com/questions/498400/cs0120-an-object-reference-is-required-for-the-nonstatic-field-method-or-prop?rq=1

                    //Form2 frm2 = new Form2();
                    //frm2.update_fillChart();




                    //AddXY value in chart1 in series named as Salary  
                    chart1.Series["TotalGetRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalGetRequests);
                    chart1.Series["TotalHeadRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalHeadRequests);

                    chart1.Series["FilesSentPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesSentPerSec);
                    chart1.Series["FilesReceivedPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesReceivedPerSec);
                    chart1.Series["AnonymousUsersPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.AnonymousUsersPerSec);
                    chart1.Series["CurrentNonAnonymousUsers"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CurrentNonAnonymousUsers);
                    chart1.Series["CGIRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CGIRequestsPerSec);
                    chart1.Series["GetRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.GetRequestsPerSec);
                    chart1.Series["PostRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.PostRequestsPerSec);
                    chart1.Series["NotFoundErrorsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.NotFoundErrorsPerSec);

                    //chart title  

                    if (one_time)
                    {
                        chart1.Titles.Add("IIS monitoring");
                        one_time = false;
                    }


                //23/3/2021

                ////AddXY value in chart1 in series named as Salary  
                //Dashboard_Form.chart1.Series["TotalGetRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalGetRequests);
                //chart1.Series["TotalHeadRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalHeadRequests);

                //chart1.Series["FilesSentPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesSentPerSec);
                //chart1.Series["FilesReceivedPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesReceivedPerSec);
                //chart1.Series["AnonymousUsersPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.AnonymousUsersPerSec);
                //chart1.Series["CurrentNonAnonymousUsers"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CurrentNonAnonymousUsers);
                //chart1.Series["CGIRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CGIRequestsPerSec);
                //chart1.Series["GetRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.GetRequestsPerSec);
                //chart1.Series["PostRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.PostRequestsPerSec);
                //chart1.Series["NotFoundErrorsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.NotFoundErrorsPerSec);


            }

            Displaynotify_custom("Beware of server " + ip +
                     "; TotalGetRequests :  " + TotalGetRequests_total);
                // IIS_WMI_listView.Items.Add(new ListViewItem(new String[] { ip, web, result_availability, result_website_availability, ping_info, http_info }));

            }



        //Write manual by Mohammad Y. Ammar | 6-2-2021



        //21-3-2021


        public void IIS_W3SVC_WebService_WMI_Parallel(string ip, string username, string password)  //

        {

            try
            {


                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;


                //New with Ahmed 4/3/2021

                options.Password = password;

                options.Username = username;


                ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);

                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();



                //https://stackoverflow.com/questions/187913/fastest-convert-from-collection-to-listt


                //ManagementObjectCollection managementObjects = m.GetInstances();

                // List<ManagementObject> managementList = new List<ManagementObject>();

                List<ManagementObject> IIS_List = queryCollection.Cast<ManagementObject>().ToList();


                // foreach (ManagementObject m in queryCollection)
                Parallel.ForEach(IIS_List, m =>
                {



                //



                //Name
                name = m["Name"].ToString();

                //to Form2
                //  TotalGetRequests = TotalGetRequests +  int.Parse(m["TotalGetRequests"].ToString());
                TotalGetRequests = int.Parse(m["TotalGetRequests"].ToString());

                //                TotalGetRequests_total = TotalGetRequests_total + TotalGetRequests;

                if (string.Equals(name, "_Total"))
                    {
                        TotalGetRequests_total = TotalGetRequests;
                    }

                //to Form2
                TotalHeadRequests = int.Parse(m["TotalHeadRequests"].ToString());

                ////https://www.paessler.com/iis-monitoring

                //to Form2
                FilesSentPerSec = int.Parse(m["FilesSentPerSec"].ToString());

                //temp_2 = temp_2 + ("FilesReceivedPerSec	  : {0}", m["FilesReceivedPerSec"]);
                //////MessageBox.Show(temp_2);
                //to Form2
                FilesReceivedPerSec = int.Parse(m["FilesReceivedPerSec"].ToString());
                //////  temp_2 = "";


                //to Form2
                AnonymousUsersPerSec = int.Parse(m["AnonymousUsersPerSec"].ToString());

                //to Form2
                CurrentNonAnonymousUsers = int.Parse(m["CurrentNonAnonymousUsers"].ToString());

                //to Form2
                CGIRequestsPerSec = int.Parse(m["CGIRequestsPerSec"].ToString());

                //to Form2
                GetRequestsPerSec = int.Parse(m["GetRequestsPerSec"].ToString());

                //to Form2
                PostRequestsPerSec = int.Parse(m["PostRequestsPerSec"].ToString());

                //to Form2
                NotFoundErrorsPerSec = int.Parse(m["NotFoundErrorsPerSec"].ToString());
                // MessageBox.Show(temp_2);


                //
                //    Form2.fillChart_dynamic(m["Name"].ToString(), m["TotalGetRequests"].ToString(), m["TotalGetRequests"].ToString());


                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
                // IIS_WMI_listView.Items.Add(new ListViewItem(new String[] { ip, m["Name"].ToString(), m["TotalGetRequests"].ToString(), m["TotalHeadRequests"].ToString(), m["FilesSentPerSec"].ToString(), m["FilesReceivedPerSec"].ToString(), m["AnonymousUsersPerSec"].ToString(), m["CurrentNonAnonymousUsers"].ToString(), m["CGIRequestsPerSec"].ToString(), m["GetRequestsPerSec"].ToString(), m["PostRequestsPerSec"].ToString(), m["NotFoundErrorsPerSec"].ToString() }));


                add_to_list_P_IIS_WMI(ip, m["Name"].ToString(), m["TotalGetRequests"].ToString(),
                        m["TotalHeadRequests"].ToString(), m["FilesSentPerSec"].ToString(),
                        m["FilesReceivedPerSec"].ToString(), m["AnonymousUsersPerSec"].ToString(),
                        m["CurrentNonAnonymousUsers"].ToString(), m["CGIRequestsPerSec"].ToString(),
                        m["GetRequestsPerSec"].ToString(), m["PostRequestsPerSec"].ToString(),
                        m["NotFoundErrorsPerSec"].ToString());







                //to chart
                //sol Error CS0120  An object reference is required for the non-static field, method, or property 'Form2.update_fillChart()'	GP6 IIS with GUI    C:\Users\Mohammad Yaser Ammar\source\repos\GP6\Form1.cs	1144	Active
                //https://stackoverflow.com/questions/498400/cs0120-an-object-reference-is-required-for-the-nonstatic-field-method-or-prop?rq=1

                //Form2 frm2 = new Form2();
                //frm2.update_fillChart();

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                //AddXY value in chart1 in series named as Salary  
                //chart1.Series["TotalGetRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalGetRequests);
                //chart1.Series["TotalHeadRequests"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.TotalHeadRequests);

                //chart1.Series["FilesSentPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesSentPerSec);
                //chart1.Series["FilesReceivedPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.FilesReceivedPerSec);
                //chart1.Series["AnonymousUsersPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.AnonymousUsersPerSec);
                //chart1.Series["CurrentNonAnonymousUsers"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CurrentNonAnonymousUsers);
                //chart1.Series["CGIRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.CGIRequestsPerSec);
                //chart1.Series["GetRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.GetRequestsPerSec);
                //chart1.Series["PostRequestsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.PostRequestsPerSec);
                //chart1.Series["NotFoundErrorsPerSec"].Points.AddXY(Form_IIS_DNS.name, Form_IIS_DNS.NotFoundErrorsPerSec);


                add_to_chart_P_IIS_WMI(m["Name"].ToString(), m["TotalGetRequests"].ToString(),
                 m["TotalHeadRequests"].ToString(), m["FilesSentPerSec"].ToString(),
                 m["FilesReceivedPerSec"].ToString(), m["AnonymousUsersPerSec"].ToString(),
                 m["CurrentNonAnonymousUsers"].ToString(), m["CGIRequestsPerSec"].ToString(),
                 m["GetRequestsPerSec"].ToString(), m["PostRequestsPerSec"].ToString(),
                 m["NotFoundErrorsPerSec"].ToString());


                //chart title  

                //if (one_time)
                //{
                //    chart1.Titles.Add("IIS monitoring");
                //    one_time = false;
                //}



            });//eachfor P


                Displaynotify_custom("Beware of server " + ip +
                     "; TotalGetRequests :  " + TotalGetRequests_total);
                // IIS_WMI_listView.Items.Add(new ListViewItem(new String[] { ip, web, result_availability, result_website_availability, ping_info, http_info }));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "IIS_W3SVC_WebService_WMI_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                add_to_list_P_IIS_WMI(ip, ex.Message, "",
                 "", "",
                "", "",
                 "", "","","","");


             //   IIS_WMI_listView.Items.Add(new ListViewItem(new String[] { ip, ex.Message }));
            }
        }


        //https://stackoverflow.com/questions/36813127/how-to-add-items-in-listview-using-thread





        //add_to_list_P_IIS_WMI(ip, m["Name"].ToString(), m["TotalGetRequests"].ToString(),
        //          m["TotalHeadRequests"].ToString(), m["FilesSentPerSec"].ToString(),
        //          m["FilesReceivedPerSec"].ToString(), m["AnonymousUsersPerSec"].ToString(),
        //          m["CurrentNonAnonymousUsers"].ToString(), m["CGIRequestsPerSec"].ToString(),
        //          m["GetRequestsPerSec"].ToString(), m["PostRequestsPerSec"].ToString(),
        //          m["NotFoundErrorsPerSec"].ToString() );

        public void add_to_list_P_IIS_WMI(string ip_address, string Name, string TotalGetRequests,
                        string TotalHeadRequests, string FilesSentPerSec, string FilesReceivedPerSec,
                        string AnonymousUsersPerSec, string CurrentNonAnonymousUsers
                        , string CGIRequestsPerSec,string GetRequestsPerSec, string PostRequestsPerSec
             , string NotFoundErrorsPerSec            )
        {


            try
            {

                String[] row = {ip_address,Name,  TotalGetRequests,
                         TotalHeadRequests,  FilesSentPerSec,  FilesReceivedPerSec,
                         AnonymousUsersPerSec,  CurrentNonAnonymousUsers
                        ,  CGIRequestsPerSec, GetRequestsPerSec ,PostRequestsPerSec
             ,  NotFoundErrorsPerSec  };

                ListViewItem item = new ListViewItem(row);




                if (IIS_WMI_listView.InvokeRequired)
                {
                    IIS_WMI_listView.Invoke(new MethodInvoker(delegate
                    {
                        IIS_WMI_listView.Items.Add(item);
                        item.Checked = true;

                    }));


                }
                else
                {
                    IIS_WMI_listView.Items.Add(item);
                    item.Checked = true;
                    //  MessageBox.Show("else", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            if (Thread.CurrentThread.ManagedThreadId == 1)
            {
                MessageBox.Show("Finish", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        //MYA 24/3/2021
        public void add_to_chart_P_IIS_WMI(string name, string TotalGetRequests,
                      string TotalHeadRequests, string FilesSentPerSec, string FilesReceivedPerSec,
                      string AnonymousUsersPerSec, string CurrentNonAnonymousUsers
                      , string CGIRequestsPerSec, string GetRequestsPerSec, string PostRequestsPerSec
           , string NotFoundErrorsPerSec)
        {


            try
            {

             //   String[] row = {TotalGetRequests,
             //            TotalHeadRequests,  FilesSentPerSec,  FilesReceivedPerSec,
             //            AnonymousUsersPerSec,  CurrentNonAnonymousUsers
             //           ,  CGIRequestsPerSec, GetRequestsPerSec ,PostRequestsPerSec
             //,  NotFoundErrorsPerSec  };

             //   ListViewItem item = new ListViewItem(row);




                if (chart1.InvokeRequired)
                {
                    chart1.Invoke(new MethodInvoker(delegate
                    {
                        //chart1.Items.Add(item);
                        //item.Checked = true;


                        chart1.Series["TotalGetRequests"].Points.AddXY(name, TotalGetRequests);
                        chart1.Series["TotalHeadRequests"].Points.AddXY(name, TotalHeadRequests);

                        chart1.Series["FilesSentPerSec"].Points.AddXY(name, FilesSentPerSec);
                        chart1.Series["FilesReceivedPerSec"].Points.AddXY(name, FilesReceivedPerSec);
                        chart1.Series["AnonymousUsersPerSec"].Points.AddXY(name, AnonymousUsersPerSec);
                        chart1.Series["CurrentNonAnonymousUsers"].Points.AddXY(name, CurrentNonAnonymousUsers);
                        chart1.Series["CGIRequestsPerSec"].Points.AddXY(name, CGIRequestsPerSec);
                        chart1.Series["GetRequestsPerSec"].Points.AddXY(name, GetRequestsPerSec);
                        chart1.Series["PostRequestsPerSec"].Points.AddXY(name, PostRequestsPerSec);
                        chart1.Series["NotFoundErrorsPerSec"].Points.AddXY(name, NotFoundErrorsPerSec);


                    }));


                }
                else
                {

                    chart1.Series["TotalGetRequests"].Points.AddXY(name, TotalGetRequests);
                    chart1.Series["TotalHeadRequests"].Points.AddXY(name, TotalHeadRequests);

                    chart1.Series["FilesSentPerSec"].Points.AddXY(name, FilesSentPerSec);
                    chart1.Series["FilesReceivedPerSec"].Points.AddXY(name, FilesReceivedPerSec);
                    chart1.Series["AnonymousUsersPerSec"].Points.AddXY(name, AnonymousUsersPerSec);
                    chart1.Series["CurrentNonAnonymousUsers"].Points.AddXY(name, CurrentNonAnonymousUsers);
                    chart1.Series["CGIRequestsPerSec"].Points.AddXY(name, CGIRequestsPerSec);
                    chart1.Series["GetRequestsPerSec"].Points.AddXY(name, GetRequestsPerSec);
                    chart1.Series["PostRequestsPerSec"].Points.AddXY(name, PostRequestsPerSec);
                    chart1.Series["NotFoundErrorsPerSec"].Points.AddXY(name, NotFoundErrorsPerSec);



                    //chart1.Items.Add(item);
                    //item.Checked = true;
                    //  MessageBox.Show("else", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "add_to_chart_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            if (Thread.CurrentThread.ManagedThreadId == 1)
            {
                MessageBox.Show("Finish", "add_to_chart_P", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chart1.Titles.Add("IIS monitoring");

            }

            //chart title  

            //if (one_time)
            //{
            //    chart1.Titles.Add("IIS monitoring");
            //    one_time = false;
            //}



        }
        private void label3_Click(object sender, EventArgs e)
            {

            }

            private void listView2_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            //private void button2_Click_1(object sender, EventArgs e)
            //{
            //    Form2 window = new Form2();
            //    window.Show();
            //}

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {
            }

   
          


            public void test_gp1_b()
            {
                double totalCapacity = 0;

                //string FullComputerName = "<Name of Remote Computer>";
                string FullComputerName = "192.168.1.10";

                //    string FullComputerName = "WIN - IMRMAKHGRHE";
                //      WIN - IMRMAKHGRHE
                ConnectionOptions options = new ConnectionOptions();

                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                //MYA
                options.Password = "Abcd@1234";

                options.Username = "Administrator";
                //

                ManagementScope scope = new ManagementScope("\\\\" + FullComputerName + "\\root\\cimv2", options);
                ObjectQuery objectQuery = new ObjectQuery("select * from Win32_PhysicalMemory");
                scope.Connect();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, objectQuery);


                ManagementObjectCollection vals = searcher.Get();

                foreach (ManagementObject val in vals)
                {
                    totalCapacity += System.Convert.ToDouble(val.GetPropertyValue("Capacity"));

                }

                Console.WriteLine("Total Machine Memory = " + totalCapacity.ToString() + " Bytes");
                Console.WriteLine("Total Machine Memory = " + (totalCapacity / 1024) + " KiloBytes");
                Console.WriteLine("Total Machine Memory = " + (totalCapacity / 1048576) + "    MegaBytes");
                Console.WriteLine("Total Machine Memory = " + (totalCapacity / 1073741824) + " GigaBytes");
                Console.ReadLine();
            }

            private static String getRAMsize()

            {

                ManagementClass mc = new ManagementClass("Win32_PhysicalMemory");

                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject item in moc)
                {

                    //MYA
                    Int64 gb = int.Parse(item.Properties["Capacity"].Value.ToString()) / 1073741824;

                    return gb.ToString() + " GB";
                }
                //return Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["Capacity"].Value) / 1073741824, 2)) + " GB";



                return "RAMsize";

            }

            private void button4_Click(object sender, EventArgs e)
            {
                test_gp1_b();
                MessageBox.Show(getRAMsize());
            }

            private void Automatic_check_button_Click(object sender, EventArgs e)
            {




                MessageBox.Show("Need maintenance", "GP6 IIS DNS ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                while (true)
                {

                    //listView1.Items.Clear();
                    IIS_WMI_listView.Items.Clear();
                    //      chart1.Series.Clear();

                    //https://stackoverflow.com/questions/11019086/net-chart-clear-and-re-add
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }


                    foreach (var item in IP_list)
                    {
                        Console.Write(" ");
                        Console.Write(item);

                        // Create new thread for pinging


                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        scan_http(item, websitebox.Text, "Administrator", "Abcd@1234"); //with IIS_W3SVC_WebService_WMI


                        MessageBox.Show("Website maintenance", "GP6 IIS DNS ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Create new thread for scan

                        //Automatic_Update_Thread
                        //Automatic_Update_Thread = new Thread(() => scan_http(item, "https://www.google.com"));
                        //Automatic_Update_Thread.Start();

                        //if (Automatic_Update_Thread.IsAlive == true)
                        //{
                        //    cmdStop.Enabled = true;
                        //    cmdScan.Enabled = false;
                        //    txtIP.Enabled = false;
                        //    txtIP2.Enabled = false;
                        //}

                    }
                    //https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-5.0
                    Console.WriteLine("Sleep for 15 seconds.");


                    Thread.Sleep(15000);
                    // Automatic_Update_Thread.Sleep(15000);
                    //    Thread.




                    //}

                    Console.WriteLine("Automatic_check_button_Click thread exits.");

                }
            }


            private void Displaynotify()
            {
                components = new System.ComponentModel.Container();
                notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
                try
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ICON_GP6_V2.ico");

                    //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@path_folder + "\\image\\ICON_GP6_V2.ico"));//icon

                    notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(path));//icon


                    notifyIcon1.Text = "Welcome to Ahmed & Mohammad project";
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = "Welcome";
                    notifyIcon1.BalloonTipText = "Click Here to see details";
                    notifyIcon1.ShowBalloonTip(100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//Displaynotify


            private void Displaynotify_custom(string notify_text) //by MYA edit
            {
                components = new System.ComponentModel.Container();
                notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
                try
                {
                    //  notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@path_folder + "\\image\\ICON_GP6_V2.ico"));//icon
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ICON_GP6_V2.ico");
                    notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(path));//icon

                    notifyIcon1.Text = "Welcome to Ahmed & Mohammad project";
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = notify_text;

                    // notifyIcon1.BalloonTipTitle = "18-2-2021";

                    notifyIcon1.BalloonTipText = "Click Here to see details";
                    notifyIcon1.ShowBalloonTip(100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//Displaynotify


            //22 - 2 - 2021
            private void dns_button_Click(object sender, EventArgs e)
            {
            //DNS_info_to_IP(websitebox.Text);

            //measure_HTTP_info(websitebox.Text);

             string info_http = measure_HTTP_info(websitebox.Text);
            //string info_http = "soon";

            string website_DNS_IP = DNS_info_to_IP(websitebox.Text);

            //   DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, DNS_info_to_IP(websitebox.Text), measure_HTTP_info(websitebox.Text) }));
            DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, website_DNS_IP, info_http }));


        }
         public string DNS_info_to_IP(string website)
          {
            string website_new = website;
            //new 1/4/2021
            if (website.Contains("https://www."))
            {
                website_new = website.Remove(website.IndexOf("https://"), "https://www.".Length);
            }

            else if (website.Contains("http://www."))
            {
                website_new = website.Remove(website.IndexOf("http://"), "http://www.".Length);
            }

            if (website.Contains("https://"))
            {
                website_new = website.Remove(website.IndexOf("https://"), "https://".Length);

            }

            else if (website.Contains("http://"))
            {
                website_new = website.Remove(website.IndexOf("http://"), "http://".Length);
            }

            if (website_new.Contains("/"))
            {
                website_new = website_new.Remove(website_new.IndexOf("/"), "/".Length);
            }


          //  MessageBox.Show(website_new);
            try
            {
                        //https://stackoverflow.com/questions/2462170/c-get-ip-address-from-domain-name

                        //     var address = Dns.GetHostAddresses("www.google.com")[0];

                        //http://gp6.local/
                     //   var address = Dns.GetHostAddresses(website)[0]; //old

                var address = Dns.GetHostAddresses(website_new)[0]; //old

               // IPHostEntry address = Dns.GetHostEntry(website_new);

                //Dns.GetHostEntry()
                //https://stackoverflow.com/questions/23961649/no-such-host-is-known-socket-connection
                //with Ahmed 32-2-2021
                //var address = Dns.GetHostEntry(website);

                //    var address = Dns.GetHostAddresses("gp6.local")[0];

                //http://192.168.1.10/GP6/

               // MessageBox.Show(address.ToString(), "Info DNS_info_to_IP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return address.ToString();
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }

                }
                //https://stackoverflow.com/questions/787622/how-can-i-measure-the-response-and-loading-time-of-a-webpage
                //    public void measure_HTTP_info()
                public string measure_HTTP_info(string website)

            {
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(website);


                try
                {



                    System.Diagnostics.Stopwatch timer = new Stopwatch();
                    timer.Start();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    timer.Stop();

                    TimeSpan timeTaken = timer.Elapsed;

                //    MessageBox.Show(timeTaken.ToString(), "Info measure_HTTP_info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return timeTaken.ToString();

                }
                catch (Exception e)//add by Mohammad
                {
                    return e.Message;

                }

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void DNS_listView_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void password_textBox_TextChanged(object sender, EventArgs e)
            {

            }

        private void back_home_button_Click(object sender, EventArgs e)
        {

            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button_scan_P_Click(object sender, EventArgs e)
        {
            //        public void IIS_W3SVC_WebService_WMI_Parallel(string ip, string username, string password)  //

            //IIS_W3SVC_WebService_WMI_Parallel("192.168.1.13", "Administrator", "Abcd@1234");
            IIS_W3SVC_WebService_WMI_Parallel("192.168.1.13", "Administrator", "Abcd@1234");

        }

        private void button_load_file_P_Click(object sender, EventArgs e)
        {
            read_csv_automatically_P();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            check_to_scan_OOP();
        }

        public void check_to_scan_OOP() // edit to all income !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            //Catch empty IP addresses

            //https://github.com/zacharyreese/NetworkScanner/blob/master/NetworkScanner/Form1.cs

            //Catch empty IP addresses

            if (ipadressbox.Text == string.Empty && websitebox.Text == string.Empty)
            {
                //  MessageBox.Show("Please enter IP address in the text box");

                //https://stackoverflow.com/questions/2109441/how-to-show-error-warning-message-box-in-net-how-to-customize-messagebox
                //  MessageBox.Show("Some text", "Some title",    MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please enter IP address and Website in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ipadressbox.Text == string.Empty)
            {
                IIS_Monitoring OBJ_IIS = new IIS_Monitoring(ipadressbox.Text, username_textBox.Text, password_textBox.Text, "IIS", websitebox.Text);

                DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, OBJ_IIS.DNS_info(), OBJ_IIS.HTTP_info() }));

                MessageBox.Show("Please enter IP address in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (websitebox.Text == string.Empty)
            {

                MessageBox.Show("Please enter Website in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // scan_event_log(ip_textBox.Text, "All");
                //   scan_event_log(ip_textBox.Text, filter_event);

                IIS_Monitoring OBJ_IIS = new IIS_Monitoring(ipadressbox.Text, username_textBox.Text, password_textBox.Text, "IIS", websitebox.Text);

                //scan_http(ipadressbox.Text, websitebox.Text, username_textBox.Text, password_textBox.Text); //with IIS_W3SVC_WebService_WMI

                DNS_listView.Items.Add(new ListViewItem(new String[] { websitebox.Text, OBJ_IIS.DNS_info(), OBJ_IIS.HTTP_info() }));



            }

        }

    }
}





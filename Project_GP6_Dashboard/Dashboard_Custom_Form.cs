using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://stackoverflow.com/questions/7749104/cannot-implicity-convert-type-string-to-system-windows-forms-columnheader
//using System.Text;  // + CSV


using System.IO; //CSV
                     //using CsvHelper; //csv

    using System.Globalization; //csv

    using System.Net.Mail;
using System.Management;
using SnmpSharpNet;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace Project_GP6_Dashboard
{

        public partial class Dashboard_Custom_Form : Form
        {
            //variable 
            string ping_state, database_state, snmp_state, IsNet, IsIS_localhost;

            //email 
            static MailMessage message;
            static SmtpClient smtp;
            //with group in 16 /nov
            static String massage_error;

            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon.icon?view=netcore-3.1


            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon?view=netcore-3.1
            private System.Windows.Forms.NotifyIcon notifyIcon1;


            //V11 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //  string path_folder = "C:\\Users\\world\\source\\repos\\GUI_GP6_SNMP_DB V19\\GUI_GP6_SNMP_DB";

            string path_folder = "C:\\Users\\world\\source\\repos\\dashboard V2\\dashboard";

            

            // end SNMP variables  , massage file 
            public Dashboard_Custom_Form()
            {
                InitializeComponent();
            }

        //With Ahmed 19/3/2021

        // public Dashboard_Custom_Form(string name, string ip_address)

        public Dashboard_Custom_Form(string name, string ip_address, string user_name, string pass_word, string user_DB, string pass_DB, string table_DB)
            {
                InitializeComponent();
            Database_Monitoring obj_DB = null;
            IIS_Monitoring obj_iis = null;
            pictureBox_windows.Visible = false;
            pictureBox_linux.Visible = false;
            pictureBox_ubuntu.Visible = false;

            Name_label.Text = name;
            IP_label.Text = ip_address;

            // MessageBox.Show(Detect_SW_SNMP(ip_address));

            string OS_info_SNMP = Detect_SW_SNMP(ip_address);


            //}

            //
          
             if (OS_info_SNMP.Contains("Windows") == true)
            {
             //   MessageBox.Show("Windows found!");
                pictureBox_windows.Visible = true;


                false_pictureBox_App.Visible = false;
                flase_pictureBox_Transport.Visible = false;
                flase_pictureBox_Network.Visible = false;
                false_pictureBox_Datalayer.Visible = false;
                flase_pictureBox_Physical.Visible = false;

                //Windows only

                OS_Monitoring obj_os = new OS_Monitoring(ip_address, user_name, pass_word, name,"Custom");

                if (name.Contains("Database") == true)
                {
                     obj_DB = new Database_Monitoring(ip_address, user_DB, pass_DB, table_DB);
                    Web_server_DB.Text = "Database(MySQL) Overview";
                    chart_iis.Visible = false;

                }
                else
                {
                    obj_iis = new IIS_Monitoring(ip_address, user_name, pass_word, name);
                    Web_server_DB.Text = "Web server (IIS) Overview";
                    Database_listView.Visible = false;
                    users_listView.Visible = false;
                }

                add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.Cpu_usage, "CPU");
                add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.Ratio_disk_size, "Disk size");
                add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.Ratio_ram_size, "RAM");

                label_CurrentVoltage.Text = "Current voltage: " + obj_os.Current_voltage;

                //#todo like another
                List<string[]> Network_details_temp = obj_os.Network_details;


                foreach (string[] i in Network_details_temp)
                {

                    Network_listView.Items.Add(new ListViewItem(i));

                }

           

                if (obj_os.get_alert().Equals("n/a") != true)
                {
                    var dt = DateTime.Now;
                    //#TODO
                    add_to_list_alert_P("Error", obj_os.get_ip_address(), obj_os.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

                }


                List<string[]> Processors_details_temp = obj_os.Processors_details;


                foreach (string[] i in Processors_details_temp)
                {

                    list_task_manger.Items.Add(new ListViewItem(i));

                }



                if (name.Contains("Database") == true)
                {

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
                else
                {

                   


                    add_to_chart_P_IIS_WMI(obj_iis.NameOfWebsite, obj_iis.TotalGetRequests.ToString(),
                      obj_iis.TotalHeadRequests.ToString(), obj_iis.FilesSentPerSec.ToString(),
                     obj_iis.FilesReceivedPerSec.ToString(), obj_iis.AnonymousUsersPerSec.ToString(),
                      obj_iis.CurrentNonAnonymousUsers.ToString(), obj_iis.CGIRequestsPerSec.ToString(),
                      obj_iis.GetRequestsPerSec.ToString(), obj_iis.PostRequestsPerSec.ToString(),
                      obj_iis.NotFoundErrorsPerSec.ToString());

                    //#todo ; dublicate
                    // node_listView.Items.Add(new ListViewItem(new String[] { obj_iis.get_name_in_database(), obj_iis.get_ip_address() }));

                    if (obj_iis.get_alert().Equals("n/a") != true)
                    {
                        var dt = DateTime.Now;
                        //#TODO
                        add_to_list_alert_P("Error", obj_iis.get_ip_address(), obj_iis.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

                    }
                }



            }//end windows
            else
            {
                pictureBox_linux.Visible = true;
                Web_server_DB.Text = "Web server (Apache) Overview";
                Database_listView.Visible = false;
                users_listView.Visible = false;
                //#todo
                pictureBox_ubuntu.Visible = true;


                if (OS_info_SNMP.Contains("ubuntu") == true)
                {
                    pictureBox_ubuntu.Visible = true;
                }

                true_pictureBox_Datalayer.Visible = false;
                true_pictureBox_Network.Visible = false;
                true_pictureBox_Transport.Visible = false;
                true_pictureBox_Physical.Visible = false;

                // false_pictureBox_App

                false_pictureBox_App.Visible = false;
                flase_pictureBox_Transport.Visible = true;
                flase_pictureBox_Network.Visible = true;
                false_pictureBox_Datalayer.Visible = true;
                flase_pictureBox_Physical.Visible = true;

            }


            





        }

        public void add_to_chart_P_IIS_WMI(string name, string TotalGetRequests,
                      string TotalHeadRequests, string FilesSentPerSec, string FilesReceivedPerSec,
                      string AnonymousUsersPerSec, string CurrentNonAnonymousUsers
                      , string CGIRequestsPerSec, string GetRequestsPerSec, string PostRequestsPerSec
           , string NotFoundErrorsPerSec)
        {


            try
            {



                if (chart_iis.InvokeRequired)
                {
                    chart_iis.Invoke(new MethodInvoker(delegate
                    {
                        //chart1.Items.Add(item);
                        //item.Checked = true;


                        chart_iis.Series["TotalGetRequests"].Points.AddXY(name, TotalGetRequests);
                        chart_iis.Series["TotalHeadRequests"].Points.AddXY(name, TotalHeadRequests);

                        chart_iis.Series["FilesSentPerSec"].Points.AddXY(name, FilesSentPerSec);
                        chart_iis.Series["FilesReceivedPerSec"].Points.AddXY(name, FilesReceivedPerSec);
                        chart_iis.Series["AnonymousUsersPerSec"].Points.AddXY(name, AnonymousUsersPerSec);
                        chart_iis.Series["CurrentNonAnonymousUsers"].Points.AddXY(name, CurrentNonAnonymousUsers);
                        chart_iis.Series["CGIRequestsPerSec"].Points.AddXY(name, CGIRequestsPerSec);
                        chart_iis.Series["GetRequestsPerSec"].Points.AddXY(name, GetRequestsPerSec);
                        chart_iis.Series["PostRequestsPerSec"].Points.AddXY(name, PostRequestsPerSec);
                        chart_iis.Series["NotFoundErrorsPerSec"].Points.AddXY(name, NotFoundErrorsPerSec);


                    }));


                }
                else
                {


                    chart_iis.Series["TotalGetRequests"].Points.AddXY(name, TotalGetRequests);
                    chart_iis.Series["TotalHeadRequests"].Points.AddXY(name, TotalHeadRequests);

                    chart_iis.Series["FilesSentPerSec"].Points.AddXY(name, FilesSentPerSec);
                    chart_iis.Series["FilesReceivedPerSec"].Points.AddXY(name, FilesReceivedPerSec);
                    chart_iis.Series["AnonymousUsersPerSec"].Points.AddXY(name, AnonymousUsersPerSec);
                    chart_iis.Series["CurrentNonAnonymousUsers"].Points.AddXY(name, CurrentNonAnonymousUsers);
                    chart_iis.Series["CGIRequestsPerSec"].Points.AddXY(name, CGIRequestsPerSec);
                    chart_iis.Series["GetRequestsPerSec"].Points.AddXY(name, GetRequestsPerSec);
                    chart_iis.Series["PostRequestsPerSec"].Points.AddXY(name, PostRequestsPerSec);
                    chart_iis.Series["NotFoundErrorsPerSec"].Points.AddXY(name, NotFoundErrorsPerSec);



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
                //#todo problem later???

                //  MessageBox.Show("Finish", "add_to_chart_P", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //#todo print one time
                //chart_iis.Titles.Add("IIS monitoring");

            }

            //chart title  

            chart_iis.Titles.Add("IIS monitoring");


            

        }



        public void add_to_list_alert_P(string alert_name, string related_node, string Message, string Date)
        {


            try
            {

                String[] row = { alert_name, related_node, Message, Date };

                ListViewItem item = new ListViewItem(row);




                if (alert_listView.InvokeRequired)
                {
                    alert_listView.Invoke(new MethodInvoker(delegate
                    {
                        alert_listView.Items.Add(item);
                        item.Checked = true;

                    }));


                }
                else
                {
                    alert_listView.Items.Add(item);
                    item.Checked = true;
                    //  MessageBox.Show("else", "add_to_list_alert_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            //    if (Thread.CurrentThread.ManagedThreadId != 1) { 

            //    MessageBox.Show("Finish", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Information);




            //}

        }
        public void add_to_chart_P_OS_CPU_WMI(string name, string usage, string series)
        {


            try
            {



                if (chart_OS.InvokeRequired)
                {
                    chart_OS.Invoke(new MethodInvoker(delegate
                    {
                        //chart1.Items.Add(item);
                        //item.Checked = true;


                        //   chart_OS.Series["CPU"].Points.AddXY(name, cpu_usage);


                        chart_OS.Series[series].Points.AddXY(name, usage);

                    }));


                }
                else
                {

                    chart_OS.Series[series].Points.AddXY(name, usage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "add_to_chart_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            // Why not run in OS!!!!!!!!!!!!!!!!!!!!!!!
            if (Thread.CurrentThread.ManagedThreadId >= 1)
            {
                //#todo problem later???

                // MessageBox.Show("Finish", "add_to_chart_P_OS_CPU_WMI", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


        }


        //detect software 31/3/2021 , with help from Ali 

        public string Detect_SW_SNMP(string ip_address)
        {
            string sysDescr = "n/a";
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress(ip_address);
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add("1.3.6.1.2.1.1.1.0"); //sysDescr
            pdu.VbList.Add("1.3.6.1.2.1.1.2.0"); //sysObjectID
            pdu.VbList.Add("1.3.6.1.2.1.1.3.0"); //sysUpTime
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);
            if (Monitoring_GP6_M_A_2021.PingHost(ip_address))
            {
                Console.WriteLine("Online by SNMP to: " + ip_address);
            }
            else
            {
                Console.WriteLine("ERROR: You have Some TIMEOUT issue");
            }
            if (result != null)
            {
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus,
                        result.Pdu.ErrorIndex);
                }
                else
                {
                    sysDescr = result.Pdu.VbList[0].Oid.ToString() +
                        SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) +
                        result.Pdu.VbList[0].Value.ToString();
                    label_uptime.Text =  "UpTime: " + result.Pdu.VbList[2].Value.ToString();
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
                sysDescr = "No response received from SNMP agent.";
            }
            return sysDescr;
        }//Method
            

        private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel8_Paint(object sender, PaintEventArgs e)
            {

            }

            private void node_listView_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            //from form 3 in gui
            public void scan_pooling_csv(String ip_line)
            {
                // MessageBox.Show(ip_line); // to check
                ping_state = Program.PingHost_string(ip_line);
                //   progressBar1.Value += 1;

                // public static string check_data_base(string address ,string name_data_base, string name_table, bool read)
                //   string database_state, snmp_state, IsNet, IsIS_localhost;
                // progressBar1.Value += 1;

                if (ping_state == "Available")
                {
                    //IsIS_localhost = Program.IsConnectedToIIS_string();
                    // progressBar1.Value += 1;

                    //Just test without box !!!!!!!!!!!!!!!!!!!!!!!!!!!! 
               //     database_state = Program.check_data_base(ip_line, "first_database_marks", "information_students");

                    // progressBar1.Value += 1;

                    //  IsNet = Program.IsConnectedToInternet_string();
                    // progressBar1.Value += 1;

                    //  snmp_state = Program.check_SNMP(ip_box_form3.Text);

                    // progressBar1.Value += 1;

                }
                else
                {
                    //progressBar1.Value += 1;
                    //IsIS_localhost = "Not connected in localhost";
                    //progressBar1.Value += 1;

                    database_state = "Not connected in SQL";
                    snmp_state = "Not Connected"; //check agin the logic to go !!!!!!!!!!!!!!!!!!1

                    // progressBar1.Value += 1;
                    IsNet = "Not Connected";
                    //progressBar1.Value += 1;

                }
                //end 
            }//scan_pooling_csv
            public void scan_pooling()
            {
                //check  ,!!! to methods ; same in form 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                //   ping_state = Program.PingHost_string(ip_box_form3.Text);//todo
                //   progressBar1.Value += 1;

                // public static string check_data_base(string address ,string name_data_base, string name_table, bool read)
                //   string database_state, snmp_state, IsNet, IsIS_localhost;
                // progressBar1.Value += 1;

                if (ping_state == "Available")
                {
                    // IsIS_localhost = Program.IsConnectedToIIS_string();
                    // progressBar1.Value += 1;

                    //Just test without box !!!!!!!!!!!!!!!!!!!!!!!!!!!! 

                    //todo
                    //    database_state = Program.check_data_base(ip_box_form3.Text, "first_database_marks", "information_students");

                    // progressBar1.Value += 1;

                    //  IsNet = Program.IsConnectedToInternet_string();
                    // progressBar1.Value += 1;

                    //  snmp_state = Program.check_SNMP(ip_box_form3.Text);

                    // progressBar1.Value += 1;

                }
                else
                {
                    //progressBar1.Value += 1;
                    IsIS_localhost = "Not connected in localhost";
                    //progressBar1.Value += 1;

                    database_state = "Not connected in SQL";
                    snmp_state = "Not Connected"; //check agin the logic to go !!!!!!!!!!!!!!!!!!1

                    // progressBar1.Value += 1;
                    IsNet = "Not Connected";
                    //progressBar1.Value += 1;

                }
                //end 
            }//scan pooling

            //CSV
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/80fa29cf-a56f-45c4-8694-13db45627f99/how-to-create-a-csv-file-in-c-?forum=netfxbcl
            private void write_csv(string name, string ip)
            {

                //  new string[]{ name , ip }

                string filePath = @path_folder + "\\database_names_ip.csv";

                //string filePath = Path.GetFullPath(@"image\testimage.csv");



                string delimiter = ",";

                string[][] output = new string[][]{
                 new string[]{ name , ip }
                // new string[]{"Col 1 Row 1", "Col 2 Row 1", "Col 3 Row 1"},
               //  new string[]{"Col1 Row 2", "Col2 Row 2", "Col3 Row 2"}
            };
                int length = output.GetLength(0);
                StringBuilder sb = new StringBuilder();
                for (int index = 0; index < length; index++)
                    sb.AppendLine(string.Join(delimiter, output[index]));

                //   File.WriteAllText(filePath, sb.ToString());

                File.AppendAllText(filePath, sb.ToString());


            }

            //https://stackoverflow.com/questions/24206566/csv-to-listview


            //https://stackoverflow.com/questions/31763864/importing-csv-file-in-to-listview


           

            //https://www.c-sharpcorner.com/UploadFile/deveshomar/notifyicon-in-C-Sharp-window-forms/
            //CALL by      Displaynotify();  

            private void Displaynotify()
            {
                components = new System.ComponentModel.Container();
                notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);

                try
                {

                    //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"image\graph.ico"));//icon

                    //ahmed design
                    notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@path_folder + "\\image\\ICON_GP6_V2.ico"));//icon


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

            private void Dashboard_Custom_Form_Load(object sender, EventArgs e)
            {
            //read_csv_automatic();

            //   pictureBox_windows.Visible = false;


            //  Processors_details_task_manager("192.168.1.13", "Administrator", "Abcd@1234");

            //Dashboard_Custom_Form t = new  Dashboard_Custom_Form("w", "192.168.1.92", "Administrator", "Abcd@1234");


        //    //test
        //    string name = "w";
        //    string ip_address = "192.168.1.92";
        //    string user_name = "Administrator";
        //    string pass_word = "Abcd@1234";

        //    pictureBox_windows.Visible = false;
        //    pictureBox_linux.Visible = false;
        //    pictureBox_ubuntu.Visible = false;

        //    Name_label.Text = name;
        //    IP_label.Text = ip_address;

        //    // MessageBox.Show(Detect_SW_SNMP(ip_address));

        //    string OS_info_SNMP = Detect_SW_SNMP(ip_address);
        ////    MessageBox.Show(OS_info_SNMP);
        //    if (OS_info_SNMP.Contains("Windows") == true)
        //    {
        //        //   MessageBox.Show("Windows found!");
        //        pictureBox_windows.Visible = true;

        //        //Windows only

        //        OS_Monitoring obj_os = new OS_Monitoring(ip_address, user_name, pass_word, name, "Custom");
        //        IIS_Monitoring obj_iis = new IIS_Monitoring(ip_address, user_name, pass_word, name);

        //        add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.cpu_usage, "CPU");
        //        add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.ratio_disk_size, "Disk size");
        //        add_to_chart_P_OS_CPU_WMI(obj_os.get_ip_address(), obj_os.ratio_ram_size, "RAM");

        //        label_CurrentVoltage.Text = "Current voltage: "+ obj_os.CurrentVoltage;


        //        //#todo like another
        //        Network_listView.Items.Add(new ListViewItem(new String[] { obj_os.get_ip_address(),obj_os.NameNetwork,  obj_os.BytesReceivedPerSec,
        //                obj_os.BytesSentPerSec , obj_os.BytesTotalPerSec,
        //           obj_os.CurrentBandwidth }));




        //        if (obj_os.get_alert().Equals("n/a") != true)
        //        {
        //            var dt = DateTime.Now;
        //            //#TODO
        //            add_to_list_alert_P("Error", obj_os.get_ip_address(), obj_os.get_ip_address(), dt.ToString("MM/dd/yyyy h:mm tt"));

        //        }


        //        List<string[]> Processors_details_temp = obj_os.Processors_details;


        //        foreach (string[] i in Processors_details_temp)
        //        {

        //            list_task_manger.Items.Add(new ListViewItem(i));

        //        }



        //        add_to_chart_P_IIS_WMI(obj_iis.name, obj_iis.TotalGetRequests.ToString(),
        //          obj_iis.TotalHeadRequests.ToString(), obj_iis.FilesSentPerSec.ToString(),
        //         obj_iis.FilesReceivedPerSec.ToString(), obj_iis.AnonymousUsersPerSec.ToString(),
        //          obj_iis.CurrentNonAnonymousUsers.ToString(), obj_iis.CGIRequestsPerSec.ToString(),
        //          obj_iis.GetRequestsPerSec.ToString(), obj_iis.PostRequestsPerSec.ToString(),
        //          obj_iis.NotFoundErrorsPerSec.ToString());

        //        //#todo ; dublicate
        //        // node_listView.Items.Add(new ListViewItem(new String[] { obj_iis.get_name_in_database(), obj_iis.get_ip_address() }));

        //        if (obj_iis.get_alert().Equals("n/a") != true)
        //        {
        //            var dt = DateTime.Now;
        //            //#TODO
        //            add_to_list_alert_P("Error", obj_iis.get_ip_address(), obj_iis.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

        //        }
        //    }//end windows
        //    else
        //    {
        //        pictureBox_linux.Visible = true;
        //        Web_server.Text = "Web server (Apache) Overview";

        //        if (OS_info_SNMP.Contains("ubuntu") == true)
        //        {
        //            pictureBox_ubuntu.Visible = true;
        //        }

        //        true_pictureBox_Datalayer.Visible = false;
        //        true_pictureBox_Network.Visible = false;
        //        true_pictureBox_Transport.Visible = false;
        //        true_pictureBox_Physical.Visible = false;


        //    }

        //    //

        }

        private void button5_Click(object sender, EventArgs e)
            {
                System_alerts_and_send_messages();
            }

            private void button4_Click(object sender, EventArgs e)
            {

            }

            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void panel10_Paint(object sender, PaintEventArgs e)
            {

            }

            private void Database_Click(object sender, EventArgs e)
            {
            Form_Database windows_event = new Form_Database();
            windows_event.Show();

            //Test
            this.Hide();
        }

            private void Sharepoint_Click(object sender, EventArgs e)
            {
            Form_Sharepoint windows_event = new Form_Sharepoint();
            windows_event.Show();

            //Test
            this.Hide();
        }

        private void EventLog_Click(object sender, EventArgs e)
        {
            Form_Event_log windows_event = new Form_Event_log();
            windows_event.Show();

            //Test
           this.Hide();
        }

        private void IISDNS_Click(object sender, EventArgs e)
        {
            Form_IIS_DNS windows_event = new Form_IIS_DNS();
            windows_event.Show();

            //Test
            this.Hide();
        }

   

        private void OS_Click(object sender, EventArgs e)
        {
            Form_OS windows_home = new Form_OS();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Application_Click(object sender, EventArgs e)
        {

            Form_Application windows_home = new Form_Application();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Firewall_Click(object sender, EventArgs e)
        {
            Form_Firewall windows_home = new Form_Firewall();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Syslog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Link with Event log ?" , "GP6", MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        private void Cetrix_Click(object sender, EventArgs e)
        {
            Form_Citrix windows_home = new Form_Citrix();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Cloud_Click(object sender, EventArgs e)
        {
            Form_Cloud windows_home = new Form_Cloud();
            windows_home.Show();

            //Test
            this.Hide();
        }


        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      

        public void Processors_details_task_manager(string Address, string username, string Password)
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = username;
                options.Password = Password; // you may want to avoid plain text password and use SecurePassword property instead Administrator
                ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
                scope.Connect();



                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");
                ManagementObjectSearcher cpus = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection cpu_queryCollection = cpus.Get();

                List<ManagementObject> cpusList = cpu_queryCollection.Cast<ManagementObject>().ToList();


                Parallel.ForEach(cpusList, queryObj =>
                {

                    //Console.WriteLine("-----------------------------------");
                    //Console.WriteLine("Name: {0}", queryObj["Name"]);
                    //Console.WriteLine("PercentProcessorTime: {0}", queryObj["PercentProcessorTime"] + "%");
                    //Console.WriteLine("HandleCount: {0}", queryObj["HandleCount"]);
                    //Console.WriteLine("ThreadCount: {0}", queryObj["ThreadCount"]);
                    //Console.WriteLine("WorkingSet: {0}", queryObj["WorkingSet"]);
                    //Console.WriteLine("ElapsedTime: {0}", queryObj["ElapsedTime"] + " s");



                    //listVAddr.Items.Add(new ListViewItem(new String[] {queryObj["Name"].ToString() , queryObj["PercentProcessorTime"] + " %" ,
                    // queryObj["HandleCount"].ToString() , queryObj["ThreadCount"].ToString() , queryObj["WorkingSet"].ToString() + " MB"
                    // ,queryObj["ElapsedTime"] + " s"  }));


                    add_to_list_P_basem(Address, queryObj["Name"].ToString(), queryObj["PercentProcessorTime"] + " %",
                     queryObj["HandleCount"].ToString(), queryObj["ThreadCount"].ToString(), queryObj["WorkingSet"].ToString() + " MB"
                     , queryObj["ElapsedTime"] + " s");

                });
            }
            catch (ManagementException ex)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + ex.Message);
                MessageBox.Show(ex.Message, "wmi_cpu error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void add_to_list_P_basem(string ip, string Name, string PercentProcessorTime,
                 string HandleCount, string ThreadCount, string WorkingSet,
                 string ElapsedTime)
        {


            try
            {

                String[] row = {ip,Name,  PercentProcessorTime,
                  HandleCount,  ThreadCount,  WorkingSet,
                  ElapsedTime};

                ListViewItem item = new ListViewItem(row);




                if (list_task_manger.InvokeRequired)
                {
                    list_task_manger.Invoke(new MethodInvoker(delegate
                    {
                        list_task_manger.Items.Add(item);
                        item.Checked = true;

                    }));


                }
                else
                {
                    list_task_manger.Items.Add(item);
                    item.Checked = true;
                    //  MessageBox.Show("else", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Processors_details_task_manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            //    if (Thread.CurrentThread.ManagedThreadId != 1) { 

            //    MessageBox.Show("Finish", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Information);




            //}

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_ubuntu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CSV_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Did Ahmed finish the data control work??", "GP6", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Database_Management_Form window = new Database_Management_Form();
            window.Show();

            this.Hide();
        }

        private void Network_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void alert_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Displaynotify_custom(string notify_text) //by MYA edit
            {
                components = new System.ComponentModel.Container();
                notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);

                try
                {

                    //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"image\graph.ico"));//icon

                    //ahmed design
                    notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@path_folder + "\\image\\ICON_GP6_V2.ico"));//icon


                    notifyIcon1.Text = "Welcome to Ahmed & Mohammad project";
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = notify_text;
                    notifyIcon1.BalloonTipText = "Click Here to see details";
                    notifyIcon1.ShowBalloonTip(100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }//Displaynotify
             ////https://www.c-sharpcorner.com/UploadFile/deepak.sharma00/send-email-from-C-Sharp-windows-application-using-gmail-smtp/

            //email 

            //static MailMessage message;
            //static SmtpClient smtp;
            public void Send_Email_Alert()
            {



                //Write the following code in the btnSend_Click event:

                //#TODO email

                try
                {
                    //btnSend.Enabled = false;

                    //btnCancel.Visible = true;

                    message = new MailMessage();

                    //if (IsValidEmail(email_textBox.Text))

                    //{

                    //    message.To.Add(email_textBox.Text);

                    //}



                    //if (IsValidEmail(txtCC.Text))

                    //{

                    //    message.CC.Add(txtCC.Text);

                    //}

                    //message.Subject = txtSubject.Text;
                    message.Subject = "Warning: Your network is in trouble!"; //mya :)

                    //message.From = new MailAddress("deepak.sharma009@gmail.com");

                    message.From = new MailAddress("ea.section2018@gmail.com");


                    //message.Body = txtBody.Text;

                    /*
                     Welcome, we would like to inform you that there is a network problem and it is issued by 
                    the device which is ()Please act quickly

                    This message was sent automatically from the graduation project program for students Ahmed and Muhammad
                     * */
                    //rfit with ahmed 16/nov
                    //string massage_gp6 = "Welcome, \n We would like to inform you that there is a network problem and it is issued by" +
                    //                    " the devices (" + testbox1_name_form3.Text + " with IP: " + ip_box_form3.Text + "),With the following problems: " + massage_error + " Please act quickly. \n" +
                    //                    "\n This message was sent automatically from the graduation project program by Ahmed and Mohammad";    //


                    //message.Body = massage_gp6;//12 / nov


                    // set smtp details

                    smtp = new SmtpClient("smtp.gmail.com");//relay from 

                    //smtp.Port = 465;

                    smtp.Port = 587; //eng maher : https://support.google.com/mail/answer/7126229?hl=en




                    // smtp.Port = 25;//No


                    smtp.EnableSsl = true;

                    //smtp.Credentials = new NetworkCredential("deepak.sharma009@gmail.com", "********");
                    smtp.Credentials = new System.Net.NetworkCredential("ea.section2018@gmail.com", "Easection2018");


                    smtp.SendAsync(message, message.Subject);

                    // smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //btnCancel.Visible = false;

                    //btnSend.Enabled = true;
                }
            }//send email 

            // https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }//IsValidEmail





            //new 24 /nov /2020

            private void System_alerts_and_send_messages()
            {
                int counter_to_email = 0;
                bool oneTimes = true; //mya
                while (true)
                {
                    //System.Threading.Thread.Sleep(30000);//30s
                    System.Threading.Thread.Sleep(5000); //5s

                    scan_pooling();
                    if (ping_state == "Not available" && database_state == "Not connected in SQL")//AND && from Ahmed idea 16/nov/2020
                    {
                        massage_error = "We lost the connection to the device (unavailable) and database";
                        Displaynotify_custom(massage_error);
                        counter_to_email = counter_to_email + 1;
                    }
                    else if (ping_state == "Not available")
                    {
                        massage_error = "We lost the connection to the device (unavailable)";
                        Displaynotify_custom(massage_error);
                        counter_to_email = counter_to_email + 1;
                    }
                    else if (database_state == "Not connected in SQL")
                    {
                        massage_error = "We lost the connection in the database";
                        Displaynotify_custom(massage_error);
                        counter_to_email = counter_to_email + 1;
                    }

                    //email


                    if (counter_to_email > 5 && oneTimes == true)
                    {
                        Send_Email_Alert();
                        MessageBox.Show("send email");
                        oneTimes = false;
                    }


                }
            }


        }//class
    }//namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    //using System.Text;  // + CSV


    using System.IO; //CSV
                     //using CsvHelper; //csv

    using System.Globalization; //csv

    using System.Net.Mail;
using System.Management;
using System.Threading;
using System.Reflection;
// Include the required namespace of LiveCharts
using LiveCharts;
using LiveCharts.Wpf;
using System.Net.NetworkInformation;
using System.Diagnostics;
using SnmpSharpNet;
using System.Net;

//Update design by Ahmed 5/4/2021

namespace Project_GP6_Dashboard
{



        public partial class Dashboard_Form : Form
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

        //OS
        string cpu_usage = "n/a";
        private bool WeAreDone = false;


        public Dashboard_Form()
            {
                InitializeComponent();

        }

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

        //with hadi 26/3/2021
        // https://stackoverflow.com/questions/12872740/doubleclick-on-a-row-in-listview
        private void node_listView_DoubleClick(object sender, EventArgs e)
        {

            //MessageBox.Show(node_listView.SelectedItems[0].SubItems[0].Text);

            // Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].SubItems[0].Text, node_listView.SelectedItems[0].SubItems[1].Text, node_listView.SelectedItems[0].SubItems[2].Text, node_listView.SelectedItems[0].SubItems[3].Text); // OOP !!!!!!!!!!!!!!!1

            Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].SubItems[0].Text, node_listView.SelectedItems[0].SubItems[1].Text, node_listView.SelectedItems[0].SubItems[2].Text, node_listView.SelectedItems[0].SubItems[3].Text, node_listView.SelectedItems[0].SubItems[4].Text, node_listView.SelectedItems[0].SubItems[5].Text, node_listView.SelectedItems[0].SubItems[6].Text); // OOP !!!!!!!!!!!!!!!1

            window.Show();


            this.Hide();

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


            //read_csv3_automatic
            private void read_csv_automatic()//edit with group to auto :) 15/nov/2020
            {
                //OpenFileDialog ofDialog = new OpenFileDialog();

                //ofDialog.Filter = @"CSV Files|*.csv";
                //ofDialog.Title = @"Select your backlink file...";
                //ofDialog.FileName = "backlinks.csv";
                int count = 0;
                //// is cancel pressed?
                //if (ofDialog.ShowDialog() == DialogResult.Cancel)
                //    return;
                try
                {
                    string path = @path_folder + "\\database_names_ip.csv";//edit name 
                    var lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        count = count + 1;
                        var parts = line.Split(',');
                        ListViewItem lvi = new ListViewItem(parts[0]);//MYA: parts[0] Name
                                                                      //lvi.SubItems.Add(parts[1]);
                                                                      //Pooling_listView.Items.Add(lvi);

                        //17/nov 
                        scan_pooling_csv(parts[1]); //MYA in 17/nov/2020 test the parts[1] is IP address

                        //todo
                        //  node_listView.Items.Add(new ListViewItem(new String[] { parts[0], parts[1], ping_state, "soon", database_state }));
                        node_listView.Items.Add(new ListViewItem(new String[] { parts[0], parts[1] }));

                    }
                    // update count
                    // MessageBox.Show(File.ReadAllLines(ofDialog.FileName).Count() + " rows imported.");
                    MessageBox.Show("From csv file: " + (count + " rows imported.")); //MYA edit

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//read_csv_automatic

            //manual
            private void read_csv3()
            {
                OpenFileDialog ofDialog = new OpenFileDialog();

                ofDialog.Filter = @"CSV Files|*.csv";
                ofDialog.Title = @"Select your backlink file...";
                ofDialog.FileName = "backlinks.csv";
                int count = 0;
                // is cancel pressed?
                if (ofDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                try
                {
                    string filename = ofDialog.FileName;
                    var lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        count = count + 1;
                        var parts = line.Split(',');
                        ListViewItem lvi = new ListViewItem(parts[0]);
                        lvi.SubItems.Add(parts[1]);
                        //todo
                        //   Pooling_listView.Items.Add(lvi);//orignal

                        //17-nov-2020
                        // Pooling_listView.Items.Add(new ListViewItem(new String[] { ping_state, "soon", database_state }));


                    }
                    // update count
                    // MessageBox.Show(File.ReadAllLines(ofDialog.FileName).Count() + " rows imported.");
                    MessageBox.Show("From csv file: " + (count + " rows imported.")); //MYA edit

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//read_csv3

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

            private void Form1_Load(object sender, EventArgs e)
            {
           // Displaynotify_custom("test", "test");

            //read_csv_automatic();

            //node_listView.Items.Add(new ListViewItem(new String[] { "Linux", "192.168.1.11" }));
            //node_listView.Items.Add(new ListViewItem(new String[] { "Windows server", "192.168.1.13" }));
            //node_listView.Items.Add(new ListViewItem(new String[] { "DB server", "192.168.1.90" }));
            //node_listView.Items.Add(new ListViewItem(new String[] { "Mohammad", "192.168.1.90"  }));
            //node_listView.Items.Add(new ListViewItem(new String[] { "Ahmed" ,  "192.168.1.91" }));

            //Sharepoint_Monitoring test = new Sharepoint_Monitoring();
            // test.test2();


            // Create new stopwatch.
         //   Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
         //   stopwatch.Start();


            //   read_csv_automatically_with_objects_P();

            // Stop timing
            // 
           // Send_Email_Alert();
       //     stopwatch.Stop();

            // Write result.

            //#todo RAM need more time ??
         //   MessageBox.Show("Time elapsed: {0}" + stopwatch.Elapsed);


            //with hadi 26/3/2021
            // https://stackoverflow.com/questions/12872740/doubleclick-on-a-row-in-listview
            node_listView.MouseDoubleClick += new MouseEventHandler(node_listView_DoubleClick);
            this.Load += new EventHandler(Form1_Load);


            //fill_chart_defulat();


            //add_to_chart_P_OS_CPU_WMI("M", "90", "CPU");
            //add_to_chart_P_OS_CPU_WMI("M", "90", "Disk size");


            //todo test
          // Send_Email_Alert();
         //   MessageBox.Show("Send_Email_Alert");

        }

        public void fill_chart_defulat()
        {
            // Define the label that will appear over the piece of the chart
            // in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection piechartData = new SeriesCollection
{
    new PieSeries
    {
        Title = "Up",
        Values = new ChartValues<double> {1},
        DataLabels = true,
        LabelPoint = labelPoint,

        // Define a custom Color 
        Fill = System.Windows.Media.Brushes.Green
    },
    new PieSeries
    {
        Title = "Warning",
        Values = new ChartValues<double> {1},
        DataLabels = true,
        LabelPoint = labelPoint,
        Fill = System.Windows.Media.Brushes.Yellow,
        PushOut = 15
    },
    new PieSeries
    {
        Title = "Critical",
        Values = new ChartValues<double> {1},
        DataLabels = true,
        LabelPoint = labelPoint,
        Fill = System.Windows.Media.Brushes.Gray
    }
};

            // You can add a new item dinamically with the add method of the collection
            piechartData.Add(
                new PieSeries
                {
                    Title = "Undefined",
                    Values = new ChartValues<double> { 1 },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Red
                }
            );

            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = piechartData;

            // Set the legend location to appear in the bottom of the chart
            pieChart1.LegendLocation = LegendLocation.Right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="up"></param>
        /// <param name="Critical"></param>
        public void fill_chart_custom(int up , int Critical)
        {
            // Define the label that will appear over the piece of the chart
            // in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection piechartData = new SeriesCollection
{
    new PieSeries
    {
        Title = "Up",
        Values = new ChartValues<double> {up},
        DataLabels = true,
        LabelPoint = labelPoint,

        // Define a custom Color 
        Fill = System.Windows.Media.Brushes.Green
    },
    new PieSeries
    {
        Title = "Warning",
        Values = new ChartValues<double> {2},//#todo
        DataLabels = true,
        LabelPoint = labelPoint,
        Fill = System.Windows.Media.Brushes.Yellow,
        PushOut = 15
    },
    new PieSeries
    {
        Title = "Critical",
        Values = new ChartValues<double> {Critical},
        DataLabels = true,
        LabelPoint = labelPoint,
        Fill = System.Windows.Media.Brushes.Gray
    }
};

            // You can add a new item dinamically with the add method of the collection
            piechartData.Add(
                new PieSeries
                {
                    Title = "Undefined",
                    Values = new ChartValues<double> { 2 }, //#todo
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Red
                }
            );

            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = piechartData;

            // Set the legend location to appear in the bottom of the chart
            pieChart1.LegendLocation = LegendLocation.Right;
        }
        //Context menu for information buttons
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //With Ahmed 19/3/2021
        private void node_listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (node_listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    conMenuStrip_Custom.Show(Cursor.Position);
                }
            }

            //if (e.Button == MouseButtons.Right)
            //{
            //    if (node_listView.FocusedItem.Bounds.Contains(e.Location) == true)
            //    {
            //     //   conMenuStrip_Custom.Show(Cursor.Position);

            //        Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].SubItems[0].Text, node_listView.SelectedItems[0].SubItems[1].Text); // OOP !!!!!!!!!!!!!!!1


            //        window.Show();


            //        this.Hide();
            //    }



           
            //}
        }

        private void Scan_polling_Click(object sender, EventArgs e)
            {
            //todo back to 
            //System_alerts_and_send_messages();

            read_csv_automatically_with_objects_PAsync(true , true);

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

        private void Discover_button_Click(object sender, EventArgs e)
        {
            Form_Discover windows_event = new Form_Discover();
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
            Form_Event_log windows_event = new Form_Event_log();
            windows_event.Show();

            //Test
            this.Hide();

            MessageBox.Show("Link with Event log ?" , "GP6", MessageBoxButtons.OK,MessageBoxIcon.Question);



            //test_with_GP1 test1 = new test_with_GP1();
            // test1.testing();
            
            
            //test_with_GP1 [] test_array = new  test_with_GP1[2];

            //test_array[0] = new test_with_GP1();
            //test_array[0].testing();

            //test_array[1] = new test_with_GP1();
            //test_array[1].testing();


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

        private void CSV_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Did Ahmed finish the data control work??", "GP6", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Database_Management_Form window = new Database_Management_Form();
            window.Show();

            this.Hide();
        }


        private void moreInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Dashboard_Custom_Form window = new Dashboard_Custom_Form(); // OOP !!!!!!!!!!!!!!!1


            //Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].Text.ToString(), "Soon"); // OOP !!!!!!!!!!!!!!!1


            //https://stackoverflow.com/questions/15091400/get-single-listview-selecteditem

            //Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].SubItems[0].Text, node_listView.SelectedItems[0].SubItems[1].Text, node_listView.SelectedItems[0].SubItems[2].Text, node_listView.SelectedItems[0].SubItems[3].Text); // OOP !!!!!!!!!!!!!!!1


            //DB
            Dashboard_Custom_Form window = new Dashboard_Custom_Form(node_listView.SelectedItems[0].SubItems[0].Text, node_listView.SelectedItems[0].SubItems[1].Text, node_listView.SelectedItems[0].SubItems[2].Text, node_listView.SelectedItems[0].SubItems[3].Text, node_listView.SelectedItems[0].SubItems[4].Text, node_listView.SelectedItems[0].SubItems[5].Text, node_listView.SelectedItems[0].SubItems[6].Text); // OOP !!!!!!!!!!!!!!!1

            window.Show();


            //            string host = listVAddr.SelectedItems[0].Text.ToString();



            this.Hide();

        }

   
        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void Displaynotify_custom(string ip_address, string notify_text) //by MYA edit
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


                //        public void add_to_list_alert_P(string alert_name, string related_node, string Message,  string Date)
                var dt = DateTime.Now;
                add_to_list_alert_P("Warning ?!", ip_address, notify_text, dt.ToString("MM/dd/yyyy h:mm tt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Displaynotify_custom",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

                //    if (IsValidEmail(email_textBox.Text))
                 if (IsValidEmail("world.m.y.a@gmail.com"))
                    //if (IsValidEmail("aligalal97@yahoo.com"))


                    {

                        //  message.To.Add(email_textBox.Text);
                      message.To.Add("world.m.y.a@gmail.com");
                        //message.To.Add("aligalal97@yahoo.com");


                    }



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

                message.Body = "Hi test with Ali and Abdurhman";//12 / nov

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

        private void chart_IIS_Click(object sender, EventArgs e)
        {

        }

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
                        Displaynotify_custom("IP ?",massage_error);
                        counter_to_email = counter_to_email + 1;
                    }
                    else if (ping_state == "Not available")
                    {
                        massage_error = "We lost the connection to the device (unavailable)";
                    Displaynotify_custom("IP ?", massage_error);
                    counter_to_email = counter_to_email + 1;
                    }
                    else if (database_state == "Not connected in SQL")
                    {
                        massage_error = "We lost the connection in the database";
                    Displaynotify_custom("IP ?", massage_error);
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



        //edit
        public void IIS_W3SVC_WebService_WMI_Parallel(string ip_address, string username, string password)  //

        {
        //    IIS_Monitoring test = new IIS_Monitoring(ip_address,  username,  password);

        //            add_to_chart_P_IIS_WMI(test.name, test.TotalGetRequests.ToString(),
        //             test.TotalHeadRequests.ToString(), test.FilesSentPerSec.ToString(),
        //             test.FilesReceivedPerSec.ToString(), test.AnonymousUsersPerSec.ToString(),
        //             test.CurrentNonAnonymousUsers.ToString(), test.CGIRequestsPerSec.ToString(),
        //             test.GetRequestsPerSec.ToString(), test.PostRequestsPerSec.ToString(),
        //             test.NotFoundErrorsPerSec.ToString());



                
        }

        private void load_run_button_Click(object sender, EventArgs e)
        {
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();


            read_csv_automatically_with_objects();

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            MessageBox.Show("Time elapsed: {0}" + stopwatch.Elapsed);

        }

        public bool PingHost(string ip_address)

        {
            bool pingable = false;
            Ping pinger = null;


            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip_address);

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
        }//method PingHost
        private void read_csv_automatically_with_objects()//edit with group to auto :) 15/nov/2020 and 24/3/2021
        {
            int count = 0;
            int count_size = 0;

            int up = 0, Critical = 0;
            try
            {


                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dataset_IP.csv");


                var lines = File.ReadAllLines(path);



            //#todo test
                foreach (string line in lines)
                {
                    count_size = count_size + 1;

                }
             //   MessageBox.Show("TEST: From csv file: " + (count_size + " rows imported.")); // update count


                IIS_Monitoring[] IIS_array = new IIS_Monitoring[count_size];
                OS_Monitoring[] OS_array = new OS_Monitoring[count_size];


                //IIS_Monitoring[] IIS_array = new IIS_Monitoring[3];
                //OS_Monitoring[] OS_array = new OS_Monitoring[3];



                //25/3/2021
                //  Parallel.ForEach(lines, line => //#todo
                foreach (string line in lines)
                    {
                        count = count + 1;
                        var parts = line.Split(',');

                     //   MessageBox.Show(count + " : " + parts[1] + " " + parts[2] + " " + parts[3], "read_csv_automatically_P_with_object", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (PingHost(parts[1]))
                        {

                 
                        IIS_array[count - 1] = new IIS_Monitoring(parts[1], parts[2], parts[3], parts[0]);
                        OS_array[count - 1] = new OS_Monitoring(parts[1], parts[2], parts[3], parts[0],"Dashboard"); 


                        //IIS
                      //  IIS_array[count - 1].Trafic_IIS_list);
                        add_to_chart_P_IIS_WMI(IIS_array[count - 1].NameOfWebsite, IIS_array[count - 1].TotalGetRequests.ToString(),
                        IIS_array[count - 1].TotalHeadRequests.ToString(), IIS_array[count - 1].FilesSentPerSec.ToString(),
                        IIS_array[count - 1].FilesReceivedPerSec.ToString(), IIS_array[count - 1].AnonymousUsersPerSec.ToString(),
                        IIS_array[count - 1].CurrentNonAnonymousUsers.ToString(), IIS_array[count - 1].CGIRequestsPerSec.ToString(),
                        IIS_array[count - 1].GetRequestsPerSec.ToString(), IIS_array[count - 1].PostRequestsPerSec.ToString(),
                        IIS_array[count - 1].NotFoundErrorsPerSec.ToString(), count - 1);



                        //OS

                        OS_array[count - 1].get_CPU_Parallel();

                        //#todo fix!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
                        OS_array[count - 1].get_Disk_space();

                    //    targetDire = targetDirectory.Substring("http://".Length);


                        add_to_chart_P_OS_CPU_WMI(OS_array[count - 1].get_ip_address(), OS_array[count - 1].Cpu_usage, "CPU");

                        //#todo fix!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11

                        add_to_chart_P_OS_CPU_WMI(OS_array[count - 1].get_ip_address(), OS_array[count - 1].Ratio_disk_size, "Disk size");


                   //     add_to_chart_P_OS_CPU_WMI(OS_array[count - 1].get_ip_address(), "100", "Disk size");

                        //  MessageBox.Show("Finish", "scan_p_button_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);




                        //    IP_list.Add(parts[1]); //parts[1] IP address
                        //    count = count + 1;


                        up = up + 1; 

                        // }); //#todo

                    }//ping
                    else
                    {
                        var dt = DateTime.Now;
                        add_to_list_alert_P("Error", parts[1], "not available", dt.ToString("MM/dd/yyyy h:mm tt"));
                        Critical = Critical +1;
                    }

                }

                MessageBox.Show("From csv file: " + (count + " rows imported.")); // update count


               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }

            fill_chart_custom(up, Critical);
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button_scan_all_P_Click(object sender, EventArgs e)
        {

            // Create new stopwatch.
            //  Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            //    stopwatch.Start();


            read_csv_automatically_with_objects_PAsync(false, false) ;

            // Stop timing.
          //  stopwatch.Stop();

            // Write result.

           //#todo RAM need more time ??
          //  MessageBox.Show("Time elapsed: {0}" + stopwatch.Elapsed);
        }
        //  private  void read_csv_automatically_with_objects_PAsync(bool scan_pooling_P)//edit with group to auto :) 15/nov/2020 and 24/3/2021
        private async Task read_csv_automatically_with_objects_PAsync(bool scan_pooling_P, bool action_mode)//edit with group to auto :) 15/nov/2020 and 24/3/2021

        {
            int count = 0;
            int up = 0, Critical = 0;
            try
            {


                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dataset_IP.csv");


                var lines = File.ReadAllLines(path);




                // foreach (string line in lines)
                List<OS_Monitoring> FilesList_OS = new List<OS_Monitoring>();
                List<IIS_Monitoring> FilesList_IIS = new List<IIS_Monitoring>();

                //#todo DB
                List<Database_Monitoring> FilesList_DB = new List<Database_Monitoring>();

                List<Unavailable_Devices> UnavailableList = new List<Unavailable_Devices>();

                List<string> AvailableList = new List<string>();


                Parallel.ForEach(lines, line =>
                {
                    count = count + 1;
                    //    count_size = count_size + 1;
                    var parts = line.Split(',');

                });
                //  OS_Monitoring[] OS_array = new OS_Monitoring[count_size];

                Parallel.ForEach(lines, line =>

                {
                    var parts = line.Split(',');

                    if (PingHost(parts[1]))
                    {

                        if (parts[0].Contains("Database") == true)
                        {
                            //#todo DB
                            FilesList_DB.Add(new Database_Monitoring(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[0], "Dashboard"));
                        }//end windows
                        else
                        {
                            FilesList_IIS.Add(new IIS_Monitoring(parts[1], parts[2], parts[3], parts[0]));
                        }

                        FilesList_OS.Add(new OS_Monitoring(parts[1], parts[2], parts[3], parts[0], "Dashboard"));




                        up = up + 1;//health

                        AvailableList.Add(parts[1]);//map


                    }
                    // FilesList.

                    else
                    {
                        UnavailableList.Add(new Unavailable_Devices(parts[1], parts[0], parts[2], parts[3]));



                        Critical = Critical + 1;
                    }


                });

                //to charts or listview , UI thread
                //Alert with basem 19/4/2021
                if (scan_pooling_P != true)
                {

                    foreach (var obj_os in FilesList_OS)
                    {
                        // Console.WriteLine("CPU usage: {0}", obj_os.cpu_usage);

                        if (obj_os.Cpu_usage.Equals("n/a") && obj_os.Ratio_disk_size.Equals("n/a") && obj_os.Ratio_ram_size.Equals("n/a"))
                        {

                        }
                        else
                        {
                            //#todo to subnet
                            string targetIP = obj_os.get_ip_address().Substring("192.168.1".Length);

                            //#todo new
                            add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Cpu_usage, "CPU");
                            add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Ratio_disk_size, "Disk size");
                            add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Ratio_ram_size, "RAM");

                            //alert
                            //Console.WriteLine("OS start timer 1");
                            //obj_os.check_alert("First");
                            //Console.WriteLine("OS  timer 2");
                            //obj_os.check_alert("Dashboard");


                            //Console.WriteLine("OS  timer 3");
                            //obj_os.check_alert("Dashboard");

                            //Console.WriteLine("OS  timer 4");
                            //obj_os.check_alert("Dashboard");
                        }



                        node_listView.Items.Add(new ListViewItem(new String[] { obj_os.get_name_in_database(), obj_os.get_ip_address(), obj_os.get_user_name(), obj_os.get_pass_word(), "", "", "" }));

                        if (obj_os.get_alert().Equals("n/a") != true)
                        {
                            var dt = DateTime.Now;
                            //#TODO
                            add_to_list_alert_P("Error", obj_os.get_ip_address(), obj_os.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

                        }
                    }

                    foreach (var obj_db in FilesList_DB)
                    {
                        // Console.WriteLine("CPU usage: {0}", obj_os.cpu_usage);

                        node_listView.Items.Add(new ListViewItem(new String[] { obj_db.get_name_in_database(), obj_db.get_ip_address(), obj_db.get_user_name(), obj_db.get_pass_word(), obj_db.User_name_DB, obj_db.Pass_word_DB, obj_db.Table }));

                        //if (obj_os.get_alert().Equals("n/a") != true)
                        //{
                        //    var dt = DateTime.Now;
                        //    //#TODO
                        //    add_to_list_alert_P("Error", obj_os.get_ip_address(), obj_os.get_ip_address(), dt.ToString("MM/dd/yyyy h:mm tt"));

                        //}
                    }
                    foreach (var obj_iis in FilesList_IIS)
                    {


                        //List<string[]> IIS_list_temp = obj_iis.Trafic_IIS_list;


                        //foreach (string[] IIS_array in IIS_list_temp)
                        //{

                        //    // users_listView.Items.Add(new ListViewItem(i));

                        //    add_to_chart_P_IIS_WMI(IIS_array[0], IIS_array[1],
                        //  IIS_array[2], IIS_array[3],
                        //IIS_array[4], IIS_array[5],
                        //  IIS_array[6], IIS_array[7],
                        // IIS_array[8], IIS_array[9],
                        // IIS_array[10] , count - 1);

                        //}

                        add_to_chart_P_IIS_WMI(obj_iis.NameOfWebsite, obj_iis.TotalGetRequests.ToString(),
                      obj_iis.TotalHeadRequests.ToString(), obj_iis.FilesSentPerSec.ToString(),
                     obj_iis.FilesReceivedPerSec.ToString(), obj_iis.AnonymousUsersPerSec.ToString(),
                      obj_iis.CurrentNonAnonymousUsers.ToString(), obj_iis.CGIRequestsPerSec.ToString(),
                      obj_iis.GetRequestsPerSec.ToString(), obj_iis.PostRequestsPerSec.ToString(),
                      obj_iis.NotFoundErrorsPerSec.ToString(), count - 1);

                        //#todo ; dublicate
                        // node_listView.Items.Add(new ListViewItem(new String[] { obj_iis.get_name_in_database(), obj_iis.get_ip_address() }));

                        if (obj_iis.get_alert().Equals("n/a") != true)
                        {
                            var dt = DateTime.Now;
                            //#TODO
                            add_to_list_alert_P("Error", obj_iis.get_ip_address(), obj_iis.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

                        }
                    }


                    foreach (var obj_Unavailable in UnavailableList)
                    {


                        var dt = DateTime.Now;
                        //#TODO
                        add_to_list_alert_P("Error", obj_Unavailable.get_ip_address(), "not available", dt.ToString("MM/dd/yyyy h:mm tt"));

                        node_listView.Items.Add(new ListViewItem(new String[] { obj_Unavailable.get_name_in_database(), obj_Unavailable.get_ip_address(), obj_Unavailable.get_user_name(), obj_Unavailable.get_pass_word(), "", "", "" }));


                    }

                    foreach (string ip_system in AvailableList)
                    {
                        string OS_info_SNMP = Detect_SW_SNMP(ip_system);

                        if (OS_info_SNMP.Contains("Windows") == true)
                        {
                            //Windows only
                            map_Windows_listView.Items.Add(new ListViewItem(new String[] { ip_system }));

                        }//end windows
                        else
                        {
                            map_Linux_listView.Items.Add(new ListViewItem(new String[] { ip_system }));
                        }



                    }


                    //Alert with basem 19/4/2021
                    // if (scan_pooling_P)
                }
                //pooling !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                else
                {
                    //
                    await Task.Run(() =>
                    {
                        //
                        while (true)
                        {
                            //OS
                            foreach (var obj_os in FilesList_OS)
                            {
                                // Console.WriteLine("CPU usage: {0}", obj_os.cpu_usage);

                                if (obj_os.Cpu_usage.Equals("n/a") && obj_os.Ratio_disk_size.Equals("n/a") && obj_os.Ratio_ram_size.Equals("n/a"))
                                {

                                }
                                else
                                {
                                    //#todo to subnet
                                    /// string targetIP = obj_os.get_ip_address().Substring("192.168.1".Length);

                                    //#todo new
                                    //add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Cpu_usage, "CPU");
                                    //add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Ratio_disk_size, "Disk size");
                                    //add_to_chart_P_OS_CPU_WMI(targetIP, obj_os.Ratio_ram_size, "RAM");


                                    string state_DB = "available";
                                    Console.WriteLine("OS timer loop");
                                    //obj_os.check_alert("Dashboard");

                                    //DB

                            //        foreach (var obj_DB in FilesList_DB)
                            //        {
                            //            obj_DB.read_data_base_MySQL_performance_accounts();
                            //            state_DB = obj_DB.Connection;
                            //            Console.WriteLine("Database");
                            //}

                                    //#todo test 21/4/2021


                                    obj_os.check_alert_All("Dashboard" , state_DB, action_mode);
                                 //   Console.WriteLine("action_mode " + action_mode.ToString());
                                    if (obj_os.notify_report_time.Equals("Empty") != true)
                                    {
                                        Displaynotify_custom(obj_os.get_ip_address(), obj_os.notify_report_time);
                                        Console.WriteLine("Displaynotify_custom");
                                    }
                         
                                }



                                //   node_listView.Items.Add(new ListViewItem(new String[] { obj_os.get_name_in_database(), obj_os.get_ip_address(), obj_os.get_user_name(), obj_os.get_pass_word(), "", "", "" }));

                                if (obj_os.get_alert().Equals("n/a") != true)
                                {
                                    var dt = DateTime.Now;
                                    //#TODO
                                    add_to_list_alert_P("Error", obj_os.get_ip_address(), obj_os.get_alert(), dt.ToString("MM/dd/yyyy h:mm tt"));

                                }



                            }//OS



                           
                                //Avalible 
                                //foreach (string ip_system in AvailableList)
                                //{
                                //    string OS_info_SNMP = Detect_SW_SNMP(ip_system);

                                //    if ((OS_info_SNMP.Contains("No response") || OS_info_SNMP.Contains("ERROR: You have Some TIMEOUT issue")) == true)
                                //    {
                                //       // map_Windows_listView.Items.Add(new ListViewItem(new String[] { ip_system }));
                                //        Monitoring_GP6_M_A_2021.(ip_system);

                                //    }


                                //}

                                if (WeAreDone)
                            {
                                Console.WriteLine("break");
                                break;
                            }
                        }
                        //
                    });

                    //
                }

            

                    //MessageBox.Show("From csv file: " + (count + " rows imported.")); // update count



        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "read_csv_automatically_with_objects_PAsync", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }

            fill_chart_custom(up, Critical);
        }

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

            Ping ping = new Ping();
            PingReply reply = ping.Send(agent.ToString(), 1000);
            if (reply != null)
            {
                Console.WriteLine("status : " + reply.Status + "\n time :" + reply.RoundtripTime + "\n Address: " + reply.Address + "\n");

            }
            else
            {
                Console.WriteLine("ERROR: You have Some TIMEOUT issue");
                sysDescr = "ERROR: You have Some TIMEOUT issue";
            }

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
                }
                else
                {
                    // Reply variables are returned in the same order as they were added
                    // to the VbList
                    //Console.WriteLine("sysDescr({0}) ({1}): {2}",
                    //    result.Pdu.VbList[0].Oid.ToString(),
                    //    SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type),
                    //    result.Pdu.VbList[0].Value.ToString());

                    sysDescr = result.Pdu.VbList[0].Oid.ToString() +
                        SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) +
                        result.Pdu.VbList[0].Value.ToString();

                    //Console.WriteLine("sysObjectID({0}) ({1}): {2}",
                    //    result.Pdu.VbList[1].Oid.ToString(),
                    //    SnmpConstants.GetTypeName(result.Pdu.VbList[1].Value.Type),
                    //    result.Pdu.VbList[1].Value.ToString());
                    //Console.WriteLine("sysUpTime({0}) ({1}): {2}",
                    //    result.Pdu.VbList[2].Oid.ToString(),
                    //    SnmpConstants.GetTypeName(result.Pdu.VbList[2].Value.Type),
                    //    result.Pdu.VbList[2].Value.ToString());
                    string sysUpTime = result.Pdu.VbList[2].Oid.ToString() +
                        SnmpConstants.GetTypeName(result.Pdu.VbList[2].Value.Type) +
                        result.Pdu.VbList[2].Value.ToString();
                    //label_info.Text = (sysDescr + "/n" + sysUpTime);
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
                sysDescr = "No response received from SNMP agent.";
            }
            return sysDescr;

        }//Method

        private void stop_button_Click(object sender, EventArgs e)
        {
            WeAreDone = true;

            scan_with_pooling_button.Visible = true;
            stop_button.Visible = false;

        }

        private void scan_with_pooling_button_Click(object sender, EventArgs e)
        {
            //stop_button.Visible = true;
            //scan_with_pooling_button.Visible = false;

            //read_csv_automatically_with_objects_PAsync(true);


            var selectedOption = MessageBox.Show("Optional feature:\nDo you want to restart the system if it has a problem?\n" +
                "The restarting prosses will happen while the monitoring is running.", "Scan Pooling Mode", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);



            // If the no button was pressed ...

            if (selectedOption == DialogResult.Yes)

            {
                stop_button.Visible = true;
                scan_with_pooling_button.Visible = false;

                read_csv_automatically_with_objects_PAsync(true , true);

                //  MessageBox.Show("Yes is pressed!", "Yes Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else if (selectedOption == DialogResult.No)
            {
                stop_button.Visible = true;
                scan_with_pooling_button.Visible = false;

                read_csv_automatically_with_objects_PAsync(true , false);

                //   MessageBox.Show("No is pressed!", "No Dialog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else

            {

                MessageBox.Show("As you wish, have fun while using the various services in this network monitoring tool", "Cancel Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //to class !!!!!!!
        public void add_to_chart_P_IIS_WMI(string name, string TotalGetRequests,
                      string TotalHeadRequests, string FilesSentPerSec, string FilesReceivedPerSec,
                      string AnonymousUsersPerSec, string CurrentNonAnonymousUsers
                      , string CGIRequestsPerSec, string GetRequestsPerSec, string PostRequestsPerSec
           , string NotFoundErrorsPerSec , int order)
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

            if (order == 0)
            {
                chart_iis.Titles.Add("IIS monitoring");
               // one_time = false;
            }



        }


        //alert_listView
        public void add_to_list_alert_P(string alert_name, string related_node, string Message,  string Date)
        {


            try
            {

                String[] row = {alert_name,  related_node,  Message,  Date};

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



        //to class !!
        public void get_CPU_Parallel(string ip_address, string username, string password)
        {


            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = username;
                options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead


                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();

                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor Where Name = '_Total'");


                cpu_usage = "n/a";
                ManagementObjectSearcher cpus = new ManagementObjectSearcher(scope, wmicpus);

                ManagementObjectCollection cpu_queryCollection = cpus.Get();

                List<ManagementObject> cpu_List = cpu_queryCollection.Cast<ManagementObject>().ToList();



                //test
                Parallel.ForEach(cpu_List, (cpu, state) =>

                {


                    //        uint cpu_usage = 100 - Convert.ToUInt32(mngObject["PercentIdleTime"]);

                    //MYA after test | 15/3/2021
                    //https://wutils.com/wmi/root/cimv2/win32_perfformatteddata_perfos_processor/

                    uint PercentProcessorTime = Convert.ToUInt32(cpu["PercentProcessorTime"]);



                    cpu_usage = PercentProcessorTime.ToString();
                    add_to_chart_P_OS_CPU_WMI(ip_address, cpu_usage , "CPU");

                    Displaynotify_custom(ip_address, "Beware of server " + ip_address +
                 "; CPU utilization :  " + cpu_usage);
                    //MessageBox.Show(cpu_usage, "get_CPU_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //http://www.howcsharp.com/114/break-parallel-foreach-earlier.html
                    state.Break();


                });


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "get_CPU_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
    }//class
}//namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using System.IO;
using System.Reflection;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading;

using SnmpSharpNet;
using System.Net;
namespace Project_GP6_Dashboard
{


    //search code by mohammad 7/2/2021

    //Test code and define event code to level by ahmed 8/2/2021

    //Design By ahmed 10/2/2021


    //Link code by mohammad 11/2/2021

    //Redesign By ahmed 12/2/2021


    //Add csv by mohammad 17/2/2021

    //Add Displaynotify but without link by mohammad 17/2/2021

    //Customizable notifications for errors and warnings 18/2/2021


    //add to SNMP 3/3/2021

    //add save logs to CSV 14/3/2021

    //make clear code to dashboard 16/3/2021

    //Ahmed with meet link to dashboard 16/3/2021

    //Mohammad try to parallel programming to problem 23/3/2021

    //Parallel programming finish 24/3/2021  by Mohammad , chart???

    public partial class Form_Event_log : Form
        {
            //best practice by Mohammad :) ; DRY (Don't repeat yourself)

            //string date = monthCalendar1.SelectionRange.Start.ToString();

            public static int Error = 0;
            public static int Warning = 0;
            public static int Information = 0;
            public static int Security_Audit_Success = 0;
            public static int Security_Audit_Failure = 0;

            private System.Windows.Forms.NotifyIcon notifyIcon1;
            static MailMessage message;
            static SmtpClient smtp;

            // List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });

            List<string> IP_list = new List<string>(new string[] { });

            static bool automatic_scan = false;



            public Form_Event_log()
            {
                InitializeComponent();
            }

            private void panel2_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel5_Paint(object sender, PaintEventArgs e)
            {

            }

            private void button5_Click(object sender, EventArgs e)
            {

            }

            private void button4_Click(object sender, EventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {

            }

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void Event_Log_Click(object sender, EventArgs e)
            {

                check_to_scan("All");
            }



            //with G1 
            public void check_to_scan(string filter_event)
            {
                //Catch empty IP addresses

                //https://github.com/zacharyreese/NetworkScanner/blob/master/NetworkScanner/Form1.cs

                //Catch empty IP addresses

                if (ip_textBox.Text == string.Empty)
                {
                    //  MessageBox.Show("Please enter IP address in the text box");

                    //https://stackoverflow.com/questions/2109441/how-to-show-error-warning-message-box-in-net-how-to-customize-messagebox
                    //  MessageBox.Show("Some text", "Some title",    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please enter IP address in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // scan_event_log(ip_textBox.Text, "All");
                    scan_event_log(ip_textBox.Text, filter_event);

                }

            }



            public static bool PingHost(string nameOrAddress)
            {
                bool pingable = false;
                Ping pinger = null;


                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(nameOrAddress);

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


            //   public void scan_event_log()
            public void scan_event_log(string ip_address, string Events_selected_for_viewing)

            {

            try
            {
                //      Console.WriteLine("Hello World! 7/2/2021");
                //https://www.codeproject.com/Questions/750848/How-to-get-Critical-Entrys-from-EventLog


                //https://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log

                if (PingHost(ip_address))
                {
                    var conOpt = new ConnectionOptions();
                    conOpt.Impersonation = ImpersonationLevel.Impersonate;
                    conOpt.EnablePrivileges = true;
                    conOpt.Username = "Administrator";
                    conOpt.Password = "Abcd@1234";
                    // conOpt.Authority = string.Format("ntlmdomain:{0}", "yourdomain.com");

                    var scope = new
                         //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "yourservername.yourdomain.com"),conOpt);

                         //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.15"), conOpt);
                         //     ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.10"), conOpt);

                         ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", ip_address), conOpt);

                    scope.Connect();
                    bool isConnected = scope.IsConnected;
                    if (isConnected)
                    {

                        /* entire day */
                        string dateTime = getDmtfFromDateTime(DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)));


                        //  best practice by Mohammad :) ; DRY (Don't repeat yourself)
                        if (automatic_scan)
                        {
                            //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1

                            dateTime = getDmtfFromDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                        }
                        else
                        {
                            dateTime = getDmtfFromDateTime(monthCalendar1.SelectionRange.Start.ToString()); // DateTime specific

                        }


                        SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                        ManagementObjectCollection logs = searcher.Get();
                        foreach (var log in logs)
                        {



                        //Add 7/2/2021
                        https://docs.microsoft.com/en-us/previous-versions/windows/desktop/eventlogprov/win32-ntlogevent
                            Console.WriteLine("CategoryString : {0}", log["CategoryString"]);
                            Console.WriteLine("EventIdentifier : {0}", log["EventIdentifier"]);

                            //Mohammad Idea to filters  11/2/2021
                            if (string.Equals(Events_selected_for_viewing, "All"))
                            {


                                //new 3/4/2021
                                //https://social.msdn.microsoft.com/Forums/windows/en-US/6bc0dd4e-f8ed-417d-b485-8606445a088a/c-add-newest-entry-on-top-first-row-of-a-listbox?forum=winforms
                                Event_listView.Items.Insert(0, (new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                    log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                    log["SourceName"].ToString(),log["RecordNumber"].ToString()
                    ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

                   })));
                                count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));



                            }
                            //filters
                            //Events_selected_for_viewing == log["EventType"].ToString()
                            //https://www.javatpoint.com/csharp-string-compare
                            else if (string.Compare(Events_selected_for_viewing, log["EventType"].ToString()) == 0)
                            {
                                Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                    log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                    log["SourceName"].ToString(),log["RecordNumber"].ToString()
                    ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

                   }));

                                //   count_event(log["EventType"].ToString());

                                ///18-2-2021
                                count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));



                            }
                            //else


                            save_csv(ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                       log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                       log["SourceName"].ToString(), log["RecordNumber"].ToString()
                       , getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));
                        }
                    }
                    //    IP_list.Add(ip_address);


                    //https://stackoverflow.com/questions/45577351/close-managementscope-connection
                    //To close the connection to become like Syslog | Ahmed & Mohammad in meet 18 - 2 - 2021
                    scope.Path = new ManagementPath(string.Empty);


                }//if ping
                else
                {
                    Event_listView.Items.Add(new ListViewItem(new String[] { ip_address, "Not available" }));

                }
                //  scope.Connect();




                //ReadLog();
                //Console.ReadLine();


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "scan_event_log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }//scan_event_log



        public void scan_event_log_Parallel(string ip_address, string Events_selected_for_viewing)

        {


            //      Console.WriteLine("Hello World! 7/2/2021");
            //https://www.codeproject.com/Questions/750848/How-to-get-Critical-Entrys-from-EventLog


            //https://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log

            if (PingHost(ip_address))
            {


        var conOpt = new ConnectionOptions();
                conOpt.Impersonation = ImpersonationLevel.Impersonate;
                conOpt.EnablePrivileges = true;
                conOpt.Username = "Administrator";
                conOpt.Password = "Abcd@1234";
                // conOpt.Authority = string.Format("ntlmdomain:{0}", "yourdomain.com");

                var scope = new
                     //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "yourservername.yourdomain.com"),conOpt);

                     //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.15"), conOpt);
                     //     ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.10"), conOpt);

                     ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", ip_address), conOpt);

                scope.Connect();
                bool isConnected = scope.IsConnected;
                if (isConnected)
                {

                    /* entire day */
                    string dateTime = getDmtfFromDateTime(DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)));


                    //  best practice by Mohammad :) ; DRY (Don't repeat yourself)
                    if (automatic_scan)
                    {
                        //https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1

                        dateTime = getDmtfFromDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    }
                    else
                    {
                        dateTime = getDmtfFromDateTime(monthCalendar1.SelectionRange.Start.ToString()); // DateTime specific

                    }


                    SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                    ManagementObjectCollection logs = searcher.Get();

                    //https://stackoverflow.com/questions/187913/fastest-convert-from-collection-to-listt


                    //ManagementObjectCollection managementObjects = m.GetInstances();

                    // List<ManagementObject> managementList = new List<ManagementObject>();

                    List<ManagementObject> logsList = logs.Cast<ManagementObject>().ToList();


                    /*
                     * 
                       Parallel.ForEach(integerList, i =>
            {
                long total = DoSomeIndependentTimeconsumingTask();
                Console.WriteLine("{0} - {1}", i, total);
            });
                    

                    //

              
                    */
                    //  foreach (var log in logs)


                    //   Event_listView.Items.Add(new ListViewItem(new String[] { "Test"}));

                    int i = 1;
                Parallel.ForEach(logsList, log =>
                    {

                        //


                        //     if (Event_listView.InvokeRequired)
                        //     {
                        //         Event_listView.Invoke((MethodInvoker)delegate ()
                        //         {
                        //             //ListViewItem item = new ListViewItem("12");
                        //             //IIS_WMI_listView.Items.Add(item);
                        //             //IIS_WMI_listView.EnsureVisible(IIS_WMI_listView.Items.Count - 1);

                        //             Event_listView.Items.Insert(0, (new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                        // log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                        // log["SourceName"].ToString(),log["RecordNumber"].ToString()
                        // ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

                        //})));
                        //         });
                        //     }

                        //
                        Console.WriteLine($"thread = {Thread.CurrentThread.ManagedThreadId}");



                        //Add 7/2/2021
                        https://docs.microsoft.com/en-us/previous-versions/windows/desktop/eventlogprov/win32-ntlogevent
                        //Console.WriteLine("CategoryString : {0}", log["CategoryString"]);
                        //Console.WriteLine("EventIdentifier : {0}", log["EventIdentifier"]);

                        //Mohammad Idea to filters  11/2/2021
                        if (string.Equals(Events_selected_for_viewing, "All"))
                        {


                            //new 3/4/2021
                            //https://social.msdn.microsoft.com/Forums/windows/en-US/6bc0dd4e-f8ed-417d-b485-8606445a088a/c-add-newest-entry-on-top-first-row-of-a-listbox?forum=winforms

                            //test if problem

                            //Event_listView.Items.Insert(0, (new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                            // log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                            // log["SourceName"].ToString(),log["RecordNumber"].ToString()
                            // ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

                            //})));


                            //MessageBox.Show(log["EventType"].ToString());


                            //Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString()
                            //                           }));



                            // add("prob", "reg", "data", "user");
                            //add(ip_address, log["Message"].ToString(), log["ComputerName"].ToString(), log["Type"].ToString());


                            //To solve the problem of adding to the list to bypass collision and Cross-thread operation


                            add_to_list_P(ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                             log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                             log["SourceName"].ToString(), log["RecordNumber"].ToString()
                             , getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));

                            //Work:
                            //if (Program.one_time != true)
                            //{

                            //    MessageBox.Show(Program.one_time.ToString());
                            //    Program.one_time = true;

                            //}

                            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!add to alert

                            //count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));


                            // Thread.Sleep(200);//test 22/3/2021

                        }
                        //filters
                        //Events_selected_for_viewing == log["EventType"].ToString()
                        //https://www.javatpoint.com/csharp-string-compare
                        else if (string.Compare(Events_selected_for_viewing, log["EventType"].ToString()) == 0)
                        {
                            //test if problem

                            //Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                            // log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                            // log["SourceName"].ToString(),log["RecordNumber"].ToString()
                            // ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

                            //}));

                            add_to_list_P(ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                      log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                      log["SourceName"].ToString(), log["RecordNumber"].ToString()
                      , getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));

                            //Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString()
                            //                           }));



                            //   count_event(log["EventType"].ToString());

                            ///18-2-2021
                            ///
                            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!add to alert

                            //  count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));


                            //  Thread.Sleep(200);//test 22/3/2021

                        }
                        //else


                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!add to save 
                        //     save_csv(ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                        //log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                        //log["SourceName"].ToString(), log["RecordNumber"].ToString()
                        //, getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));
                        //     //}


                    });


                }
                //    IP_list.Add(ip_address);


                //https://stackoverflow.com/questions/45577351/close-managementscope-connection
                //To close the connection to become like Syslog | Ahmed & Mohammad in meet 18 - 2 - 2021
                scope.Path = new ManagementPath(string.Empty);


            }//if ping
            else
            {
                //Event_listView.Items.Add(new ListViewItem(new String[] { ip_address, "Not available" }));

                add_to_list_P(ip_address, "Not available", "",
                     "", "", "",
                    "", "","");

                //Thread.Sleep(200);//test 22/3/2021

            }
            //  scope.Connect();


            //https://stackoverflow.com/questions/5855991/exit-from-a-function-in-c-sharp
            // return;


         //  MessageBox.Show("end last", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

            //ReadLog();
            //Console.ReadLine();
        }

        //https://stackoverflow.com/questions/36813127/how-to-add-items-in-listview-using-thread
        //  public void add(string prob, string reg, string data, string user)


        public void add_to_list_P(string ip_address, string Message, string ComputerName,
                 string Type, string EventType, string EventCode,
                 string SourceName, string RecordNumber
                 , string TimeWritten)
        {


            try
            {

                String[] row = {ip_address, Message,  ComputerName,
                  Type,  EventType,  EventCode,
                  SourceName,  RecordNumber
                 ,  TimeWritten };

                ListViewItem item = new ListViewItem(row);




                if (Event_listView.InvokeRequired)
                {
                    Event_listView.Invoke(new MethodInvoker(delegate
                    {
                        Event_listView.Items.Add(item);
                        item.Checked = true;

                    }));

                 
                }
                else
                {
                    Event_listView.Items.Add(item);
                    item.Checked = true;
                //  MessageBox.Show("else", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            if (Thread.CurrentThread.ManagedThreadId == 1)
            {
                MessageBox.Show("Finish", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            //if (i == 1)
            //{
            //    MessageBox.Show("end", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    MessageBox.Show(i.ToString());
            //}

            ////Work:
            //if (one_time != true)
            //{
            //    MessageBox.Show("end", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    // Console.WriteLine("end : add_to_list_P");

            //    one_time = true;
            //}


        }

        //public void scan_event_log_file(string ip_address, string Events_selected_for_viewing)

        //{
        //    if (PingHost(ip_address))
        //    {
        //        //      Console.WriteLine("Hello World! 7/2/2021");
        //        //https://www.codeproject.com/Questions/750848/How-to-get-Critical-Entrys-from-EventLog

        //        //???????

        //        //https://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log

        //        var conOpt = new ConnectionOptions();
        //        conOpt.Impersonation = ImpersonationLevel.Impersonate;
        //        conOpt.EnablePrivileges = true;
        //        conOpt.Username = "Administrator";
        //        conOpt.Password = "Abcd@1234";
        //        // conOpt.Authority = string.Format("ntlmdomain:{0}", "yourdomain.com");

        //        var scope = new
        //             //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "yourservername.yourdomain.com"),conOpt);

        //             //    ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.15"), conOpt);
        //             //     ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", "192.168.1.10"), conOpt);

        //             ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", ip_address), conOpt);

        //        scope.Connect();
        //        bool isConnected = scope.IsConnected;
        //        if (isConnected)
        //        {

        //            /* entire day */
        //            string dateTime = getDmtfFromDateTime(DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)));
        //            //string 
        //            //dateTime = getDmtfFromDateTime("09/06/2014 17:00:08"); // DateTime specific

        //            //  dateTime = getDmtfFromDateTime(date_input); // DateTime specific


        //            //  best practice by Mohammad :) ; DRY (Don't repeat yourself)

        //            dateTime = getDmtfFromDateTime(monthCalendar1.SelectionRange.Start.ToString()); // DateTime specific


        //            // to test only !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        //            //      dateTime = getDmtfFromDateTime("09/06/2014 17:00:08"); // DateTime specific


        //            SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
        //            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
        //            ManagementObjectCollection logs = searcher.Get();
        //            foreach (var log in logs)
        //            {


        //                /*
        //                Console.WriteLine("Message : {0}", log["Message"]);
        //                Console.WriteLine("ComputerName : {0}", log["ComputerName"]);
        //                Console.WriteLine("Type : {0}", log["Type"]);
        //                Console.WriteLine("User : {0}", log["User"]);

        //                //

        //                Console.WriteLine("EventType : {0}", log["EventType"]);

        //                //
        //                Console.WriteLine("EventCode : {0}", log["EventCode"]);
        //                Console.WriteLine("Category : {0}", log["Category"]);
        //                Console.WriteLine("SourceName : {0}", log["SourceName"]);
        //                Console.WriteLine("RecordNumber : {0}", log["RecordNumber"]);
        //                Console.WriteLine("TimeWritten : {0}", getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));


        //            //Add 7/2/2021
        //            https://docs.microsoft.com/en-us/previous-versions/windows/desktop/eventlogprov/win32-ntlogevent
        //                Console.WriteLine("CategoryString : {0}", log["CategoryString"]);
        //                Console.WriteLine("EventIdentifier : {0}", log["EventIdentifier"]);
        //                //  Console.WriteLine();
        //                */

        //                //   Event_listView.Items.Add(new ListViewItem(new String[] { log["Message"].ToString() }));


        //                //Mohammad Idea to filters  11/2/2021
        //                if (Events_selected_for_viewing == "All")
        //                {

        //                    Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
        //            log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
        //            log["SourceName"].ToString(),log["RecordNumber"].ToString()
        //            ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())}));

        //                    count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));

        //                }
        //                //filters
        //                //Events_selected_for_viewing == log["EventType"].ToString()
        //                //https://www.javatpoint.com/csharp-string-compare
        //                else if (string.Compare(Events_selected_for_viewing, log["EventType"].ToString()) == 0)
        //                {
        //                    Event_listView.Items.Add(new ListViewItem(new String[] {ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
        //            log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
        //            log["SourceName"].ToString(),log["RecordNumber"].ToString()
        //            ,  getDateTimeFromDmtfDate(log["TimeWritten"].ToString())

        //           }));

        //                    count_event(log["Message"].ToString(), log["EventType"].ToString(), getDateTimeFromDmtfDate(log["TimeWritten"].ToString()));

        //                }
        //                //else
        //                //{
        //                //    MessageBox.Show("else in filters  ?!");
        //                //}

        //            }
        //        }
        //        IP_list.Add(ip_address);

        //    }

        //    //ReadLog();
        //    //Console.ReadLine();
        //    else
        //    {
        //        Event_listView.Items.Add(new ListViewItem(new String[] { ip_address, "Not available" }));

        //    }
        //    }



        private static string getDmtfFromDateTime(DateTime dateTime)
            {
                return ManagementDateTimeConverter.ToDmtfDateTime(dateTime);
            }

            private static string getDmtfFromDateTime(string dateTime)
            {
                DateTime dateTimeValue = Convert.ToDateTime(dateTime);
                return getDmtfFromDateTime(dateTimeValue);
            }

            private static string getDateTimeFromDmtfDate(string dateTime)
            {
                return ManagementDateTimeConverter.ToDateTime(dateTime).ToString();
            }

            //4/3/2021
            public void sort()
            {


            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void panel6_Paint(object sender, PaintEventArgs e)
            {

            }

            private void button6_Click(object sender, EventArgs e)
            {

            }

            private void button7_Click(object sender, EventArgs e)
            {

            }

            private void button8_Click(object sender, EventArgs e)
            {

            }

            private void button9_Click(object sender, EventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {

            //https://stackoverflow.com/questions/8022825/cant-get-items-in-a-listview-cross-thread
            //Control.CheckForIllegalCrossThreadCalls = false; //bad idea

        }

        private void Event_listView_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
            {


            }



            private void clear_button_Click(object sender, EventArgs e)
            {
                Event_listView.Items.Clear();
                Error = 0;
                Warning = 0;
                Information = 0;
                Security_Audit_Success = 0;
                Security_Audit_Failure = 0;
            }

            private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
            {
                //MessageBox.Show(monthCalendar1.ToString());

                //monthCalendar1.SelectionRange.Start.ToString()
                //https://stackoverflow.com/questions/3429128/how-to-get-the-selected-date-of-a-monthcalendar-control-in-c-sharp/3429138
                //  MessageBox.Show(monthCalendar1.SelectionRange.Start.ToString());

            }

            private void errorToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                // string date = monthCalendar1.SelectionRange.Start.ToString();
                //scan_event_log(ip_textBox.Text,"1");


                check_to_scan("1");

            }

            private void warningToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                //   string date = monthCalendar1.SelectionRange.Start.ToString();
                //   scan_event_log(ip_textBox.Text, "2");

                check_to_scan("2");


            }

            private void informationToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                // string date = monthCalendar1.SelectionRange.Start.ToString();
                //  scan_event_log(ip_textBox.Text, "3");


                check_to_scan("3");

            }

            private void securityAuditSuccessToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                //   string date = monthCalendar1.SelectionRange.Start.ToString();
                // scan_event_log(ip_textBox.Text, "4");


                check_to_scan("4");

            }

            private void securityAuditFailureToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                //  string date = monthCalendar1.SelectionRange.Start.ToString(); //make global 
                //  scan_event_log(ip_textBox.Text, "5");

                check_to_scan("5");


            }

            private void button2_Click_1(object sender, EventArgs e)
            {
                //scan_event_log(ip_textBox.Text,"All");

                check_to_scan("All");

            }

            private void Cahrts_Click(object sender, EventArgs e)
        {
            Form_Event_log_chart window = new Form_Event_log_chart();
            window.Show();


            //MessageBox.Show("soon");
        }


        //   public  void count_event(string event_type)
        public void count_event(string Message_event, string event_type, string TimeWritten)
            {
                if (string.Compare(event_type, "1") == 0)
                {
                    Error = Error + 1;
                    Displaynotify_custom("Error" + " at: " + TimeWritten + ", Message: " + Message_event);
                }
                else if (string.Compare(event_type, "2") == 0)
                {
                    Warning = Warning + 1;
                    Displaynotify_custom("Warning" + " at: " + TimeWritten + ", Message: " + Message_event);
                }
                else if (string.Compare(event_type, "3") == 0)
                {
                    Information = Information + 1;
                }
                else if (string.Compare(event_type, "4") == 0)
                {
                    Security_Audit_Success = Security_Audit_Success + 1;
                }
                else if (string.Compare(event_type, "5") == 0)
                {
                    Security_Audit_Failure = Security_Audit_Failure + 1;
                    Displaynotify_custom("Security Audit Failure" + " at: " + TimeWritten + ", Message: " + Message_event);
                }
            }

            private void Load_file_auto_button_Click(object sender, EventArgs e)
            {
                read_csv_automatically();
            }


            //13/3/2021

            //public void save_csv()

            public void save_csv(string ip_address, string Message, string ComputerName,
                 string Type, string EventType, string EventCode,
                 string SourceName, string RecordNumber
                 , string TimeWritten)
            {

                ///



                //MYA

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Event_log.csv");

                //https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp

                using (StreamWriter sw = System.IO.File.AppendText(path))
                {
                    string first = "test 1";
                    string second = "test2";
                    // string csv = string.Format("{0},{1}\n", first, second);
                    // string csv = string.Format("{0},{1}", first, second);

                    string csv = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", ip_address, Message, ComputerName,
                         Type, EventType, EventCode,
                         SourceName, RecordNumber
                        , TimeWritten);



                    sw.WriteLine(csv);
                    //add
                    sw.Flush();//MYA: to \n
                    sw.Close();
                }

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


                        //It took too much time to discover
                        scan_event_log(parts[0], "All");



                        IP_list.Add(parts[0]); //parts[0] IP address

                        // scan_event_log("All", parts[0]);


                        //   IIS_W3SVC_WebService_WMI(parts[1], parts[2]);
                    }
                    MessageBox.Show("From csv file: " + (count + " rows imported.")); // update count

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Load_csv_manual_button

            private void read_csv_manual()
            {
                OpenFileDialog ofDialog = new OpenFileDialog();
                ofDialog.Filter = @"CSV Files|*.csv";
                ofDialog.Title = @"Select your list file...";
                ofDialog.FileName = "backlinks.csv";
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


                        //scan_http(parts[1], parts[2]);// with IIS_W3SVC_WebService_WMI if avalible
                        scan_event_log(parts[0], "All");
                        IP_list.Add(parts[0]); //parts[0] IP address


                    }
                    MessageBox.Show("From csv file: " + (count + " rows imported."));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void file_manual_button_Click(object sender, EventArgs e)
            {
                //   Displaynotify();

                //    Displaynotify_custom("basem and hadi");

                read_csv_manual();
            }
            //private void Displaynotify()
            //{
            //    components = new System.ComponentModel.Container();
            //    notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            //    try
            //    {
            //         string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ICON_GP6_V2.ico");

            //        //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@path_folder + "\\image\\ICON_GP6_V2.ico"));//icon

            //        notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(path));//icon


            //        notifyIcon1.Text = "Welcome to Ahmed & Mohammad project";
            //        notifyIcon1.Visible = true;
            //        notifyIcon1.BalloonTipTitle = "Welcome";
            //        notifyIcon1.BalloonTipText = "Click Here to see details";
            //        notifyIcon1.ShowBalloonTip(100);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}//Displaynotify


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
            /*
            public void Send_Email_Alert()
            {
                try
                {
                    message = new MailMessage();
                    if (IsValidEmail(email_textBox.Text))
                    {
                        message.To.Add(email_textBox.Text);
                    }

                    if (IsValidEmail(txtCC.Text))
                    {
                        message.CC.Add(txtCC.Text);
                    }
                    message.Subject = "Warning: Your network is in trouble!";

                    message.From = new MailAddress("ea.section2018@gmail.com");
                    string massage_gp6 = "Welcome, \n We would like to inform you that there is a network problem and it is issued by" +
                                        " the devices (" + testbox1_name_form3.Text + " with IP: " + ip_box_form3.Text + "),With the following problems: " + massage_error + " Please act quickly. \n" +
                                        "\n This message was sent automatically from the graduation project program by Ahmed and Mohammad";
                    message.Body = massage_gp6;//12 / nov
                    // set smtp details
                    smtp = new SmtpClient("smtp.gmail.com");//relay from 
                    smtp.Port = 587; //eng. maher : https://support.google.com/mail/answer/7126229?hl=en
                    smtp.EnableSsl = true;
                    //smtp.Credentials = new NetworkCredential("deepak.sharma009@gmail.com", "********");
                    smtp.Credentials = new System.Net.NetworkCredential("ea.section2018@gmail.com", "Easection2018");
                    smtp.SendAsync(message, message.Subject);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//send email 

            */
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




            private void Automatic_check_Click(object sender, EventArgs e)
            {
                //scan_http(ipadressbox.Text, websitebox.Text); //with IIS_W3SVC_WebService_WMI

                automatic_scan = true;

                while (true) // standred 
                ///int i = 0;
                // while (i < 2)

                {
                    // i++; //to test !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111
                    //https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-5.0

                    // scan_event_log("All", ip_textBox.Text);

                    foreach (var item in IP_list)
                    {
                        Console.WriteLine(" ");
                        Console.Write(item);
                        scan_event_log(item.ToString(), "All");
                        Console.Write("send to " + item.ToString());

                    }

                    Console.WriteLine("Sleep for 10 seconds.");
                    Thread.Sleep(10000);

                    //  Event_listView.Items.Clear();

                    //https://stackoverflow.com/questions/42112051/c-sharp-print-list-of-string-array
                    /*
                    List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });

                    mylist.Add("element 4");

                    foreach (var item in mylist)
                    {
                        Console.Write(" ");
                        Console.Write(item);
                    }
                    */
                    //     mylist.Add("element 4");





                }

                Console.WriteLine("Automatic_check_button_Click thread exits.");
            }



            //SNMP
            //public static void snmp_v1_walk_v2()
            //{


            //    // SNMP community name
            //    OctetString community = new OctetString("public");
            //    // Define agent parameters class
            //    AgentParameters param = new AgentParameters(community);
            //    // Set SNMP version to 1
            //    param.Version = SnmpVersion.Ver1;
            //    // Construct the agent address object
            //    // IpAddress class is easy to use here because
            //    //  it will try to resolve constructor parameter if it doesn't
            //    //  parse to an IP address


            //    // IpAddress agent = new IpAddress("127.0.0.1");

            //    IpAddress agent = new IpAddress("192.168.1.14");


            //    // Construct target
            //    UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            //    // Define Oid that is the root of the MIB
            //    //  tree you wish to retrieve
            //    Oid rootOid = new Oid("1.3.6.1.2.1.2.2.1.2"); // ifDescr
            //    // This Oid represents last Oid returned by
            //    //  the SNMP agent
            //    Oid lastOid = (Oid)rootOid.Clone();
            //    // Pdu class used for all requests
            //    Pdu pdu = new Pdu(PduType.GetNext);
            //    // Loop through results
            //    while (lastOid != null)
            //    {
            //        // When Pdu class is first constructed, RequestId is set to a random value
            //        // that needs to be incremented on subsequent requests made using the
            //        // same instance of the Pdu class.
            //        if (pdu.RequestId != 0)
            //        {
            //            pdu.RequestId += 1;
            //        }
            //        // Clear Oids from the Pdu class.
            //        pdu.VbList.Clear();
            //        // Initialize request PDU with the last retrieved Oid
            //        pdu.VbList.Add(lastOid);
            //        // Make SNMP request
            //        SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);
            //        // You should catch exceptions in the Request if using in real application.
            //        // If result is null then agent didn't reply or we couldn't parse the reply.
            //        if (result != null)
            //        {
            //            // ErrorStatus other then 0 is an error returned by
            //            // the Agent - see SnmpConstants for error definitions
            //            if (result.Pdu.ErrorStatus != 0)
            //            {
            //                // agent reported an error with the request
            //                Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
            //                    result.Pdu.ErrorStatus,
            //                    result.Pdu.ErrorIndex);
            //                lastOid = null;
            //                break;
            //            }
            //            else
            //            {
            //                // Walk through returned variable bindings
            //                foreach (Vb v in result.Pdu.VbList)
            //                {
            //                    // Check that retrieved Oid is "child" of the root OID
            //                    if (rootOid.IsRootOf(v.Oid))
            //                    {
            //                        Console.WriteLine("{0} ({1}): {2}",
            //                            v.Oid.ToString(),
            //                            SnmpConstants.GetTypeName(v.Value.Type),
            //                            v.Value.ToString());
            //                        lastOid = v.Oid;
            //                    }
            //                    else
            //                    {
            //                        // we have reached the end of the requested
            //                        // MIB tree. Set lastOid to null and exit loop
            //                        lastOid = null;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No response received from SNMP agent.");
            //        }
            //    }
            //    target.Close();
            //}




            //http://www.docs.snmpsharpnet.com/docs-0-7-6/html/M_SnmpSharpNet_SimpleSnmp_Walk.htm
            public static void snmp_walk_basic_v1()
            {
                try
                {

                    // String snmpAgent = "10.10.10.1";
                    String snmpAgent = "192.168.1.14";

                    String snmpCommunity = "public";
                    SimpleSnmp snmp = new SimpleSnmp(snmpAgent, snmpCommunity);
                    Dictionary<Oid, AsnType> result = snmp.Walk(SnmpVersion.Ver1, "1.3.6.1.2.1.1");
                    if (result == null)
                    {
                        Console.WriteLine("Request failed.");
                    }
                    else
                    {
                        foreach (KeyValuePair<Oid, AsnType> entry in result)
                        {
                            Console.WriteLine("{0} = {1}: {2}", entry.Key.ToString(), SnmpConstants.GetTypeName(entry.Value.Type),
                              entry.Value.ToString());
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public static void snmp_walk_basic_v2()
            {
                try
                {

                    // String snmpAgent = "10.10.10.1";
                    String snmpAgent = "192.168.1.14";

                    String snmpCommunity = "public";
                    SimpleSnmp snmp = new SimpleSnmp(snmpAgent, snmpCommunity);
                    Dictionary<Oid, AsnType> result = snmp.Walk(SnmpVersion.Ver1, "1.3.6.1.2.1");
                    if (result == null)
                    {
                        Console.WriteLine("Request failed.");
                    }
                    else
                    {
                        foreach (KeyValuePair<Oid, AsnType> entry in result)
                        {
                            Console.WriteLine("{0} = {1}: {2}", entry.Key.ToString(), SnmpConstants.GetTypeName(entry.Value.Type),
                              entry.Value.ToString());
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            private void back_home_button_Click(object sender, EventArgs e)
            {
            //snmp_walk_basic_v1();

            //Console.WriteLine("V2");
            //snmp_walk_basic_v2();


            // Syslog_SNMP();

            //save_csv();

            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
               this.Hide();
        }



        //https://stackoverflow.com/questions/55001079/monitor-ftp-directory-in-asp-net-c
        /*
        public static void ftp()
        {
            // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "example.com",
                UserName = "user",
                Password = "password",
            };

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                List<string> prevFiles = null;

                while (true)
                {
                    // Collect file list
                    List<string> files =
                        session.EnumerateRemoteFiles(
                            "/remote/path", "*.*", EnumerationOptions.AllDirectories)
                        .Select(fileInfo => fileInfo.FullName)
                        .ToList();
                    if (prevFiles == null)
                    {
                        // In the first round, just print number of files found
                        Console.WriteLine("Found {0} files", files.Count);
                    }
                    else
                    {
                        // Then look for differences against the previous list
                        IEnumerable<string> added = files.Except(prevFiles);
                        if (added.Any())
                        {
                            Console.WriteLine("Added files:");
                            foreach (string path in added)
                            {
                                Console.WriteLine(path);
                            }
                        }

                        IEnumerable<string> removed = prevFiles.Except(files);
                        if (removed.Any())
                        {
                            Console.WriteLine("Removed files:");
                            foreach (string path in removed)
                            {
                                Console.WriteLine(path);
                            }
                        }
                    }

                    prevFiles = files;

                    Console.WriteLine("Sleeping 10s...");
                    Thread.Sleep(10000);
                }
            }
        */

        //ALI

        //SNMP Version 2 GET-BULK Example
        //https://snmpsharpnet.com/index.php/walk-operation-with-snmp-version-1-and-2c/

        public static void Syslog_SNMP()
            {
                try
                {
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


                    //IpAddress agent = new IpAddress("127.0.0.1");

                    IpAddress agent = new IpAddress("192.168.1.90");

                    // Construct target
                    UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
                    // Define Oid that is the root of the MIB
                    //  tree you wish to retrieve
                    //  Oid rootOid = new Oid("1.3.6.1.2.1.2.2.1.2"); // ifDescr

                    //Syslog
                    //http://www.oid-info.com/get/1.3.6.1.2.1.173
                    // Oid rootOid = new Oid("1.3.6.1.2.1.173"); // ifDescr

                    //DNS
                    //1.3.6.1.3.52
                    //http://oid-info.com/get/1.3.6.1.3.52

                    //https://oidref.com/1.3.6.1.2.1.32
                    Oid rootOid = new Oid("1.3.6.1.2.1"); // ifDescr

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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }//Syslog_SNMP

        private void get_event_Parallel_button_Click(object sender, EventArgs e)
        {
            scan_event_log_Parallel(ip_textBox.Text, "All");

            //thread2 = new Thread(new ThreadStart(WriteTextUnsafe));
            //thread2.Start();

            Console.WriteLine("Finish");
          //  MessageBox.Show("Finish");

        }

        private void scan_oop_button_Click(object sender, EventArgs e)
        {
            Eventlog_Monitoring obj1 = new Eventlog_Monitoring(ip_textBox.Text, username_textBox.Text, password_textBox.Text, "All", false, monthCalendar1.SelectionRange.Start.ToString());

            List<string[]> MSFT_eventlog_temp = obj1.Eventlog_list;


            foreach (string[] i in MSFT_eventlog_temp)
            {

                Event_listView.Items.Add(new ListViewItem(i));

            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
    }


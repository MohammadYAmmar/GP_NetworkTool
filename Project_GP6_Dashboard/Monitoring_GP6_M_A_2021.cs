using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Net.Sockets;
using SnmpSharpNet;
using MySql.Data.MySqlClient;
using System.Net.Security;
using System.Diagnostics;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Net.Mail;
using MimeKit;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security;
using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;
using System.ServiceModel;
using System.IdentityModel.Protocols.WSTrust;
using OfficeDevPnP.Core.IdentityModel.TokenProviders.ADFS;



//create with another labtop , Mohammad 27 / 3/ 2021

//Test OS with ahmed and Basem 28/3/2021

//imrove every day , 4/4/2021 , 22/4/2021
namespace Project_GP6_Dashboard
{
    class Monitoring_GP6_M_A_2021 // : Form //// base class (parent)  //#todo form ???????????????
    {
        protected string ip_address;
        protected string user_name;
        protected string pass_word;

        protected string alert = "n/a";
        protected string availability = "n/a";
        protected string name_in_database = "n/a";


        private System.Windows.Forms.NotifyIcon notifyIcon1; //todo to uml ??????

        private bool Activate_timer = true;
        private Stopwatch stopwatch = new Stopwatch();

        private Stopwatch stopwatch_Availability = new Stopwatch();
        private Stopwatch stopwatch_OS = new Stopwatch();
        private Stopwatch stopwatch_CPU = new Stopwatch();
        private Stopwatch stopwatch_RAM = new Stopwatch();
        private Stopwatch stopwatch_Traffic = new Stopwatch();

        
        public string notify_report_time = "Empty";

        //make set
        private int time_to_Notifications = 5; //5
        private int time_to_Email = 10; //10
        private int time_to_Action = 15; //15

        //#todo add
        private bool one_time_email = true;
        private bool one_time_action = true;


      
        public Monitoring_GP6_M_A_2021()
        {
        }


        //common ??
        //  public static bool PingHost(string nameOrAddress)
        public bool PingHost()

        {
            bool pingable = false;
            Ping pinger = null;


            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip_address);

                pingable = reply.Status == IPStatus.Success;
                //  availability = "Available";
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
                //  availability = "Unavailable";

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


        //#todo satic
        public static bool PingHost(string ip_address)

        {
            bool pingable = false;
            Ping pinger = null;


            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ip_address);

                pingable = reply.Status == IPStatus.Success;
                //  availability = "Available";
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
                //  availability = "Unavailable";

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
        public string Detect_SW_SNMP(string ip_address)
        {
            string sysDescr = "n/a";

            try
            {

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
                    //   Console.WriteLine("status : " + reply.Status + "\n time :" + reply.RoundtripTime + "\n Address: " + reply.Address + "\n");

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
                        sysDescr = result.Pdu.VbList[0].Oid.ToString() +
                            SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) +
                            result.Pdu.VbList[0].Value.ToString();

                        string sysUpTime = result.Pdu.VbList[2].Oid.ToString() +
                            SnmpConstants.GetTypeName(result.Pdu.VbList[2].Value.Type) +
                            result.Pdu.VbList[2].Value.ToString();
                    }
                }
                else
                {
                    Console.WriteLine("No response received from SNMP agent.");
                    sysDescr = "No response received from SNMP agent.";
                }
            }
            catch (Exception ex)
            {
                alert = ex.Message + " From Detect_SW_SNMP";
                sysDescr = "No response received from SNMP agent.";
            }
            return sysDescr;

        }//Method
        private void Displaynotify_custom(string ip_address, string notify_text) //by MYA edit
        {

            //#todo solve
            //components = new System.ComponentModel.Container();
            //notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
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

                //#todo
                //  add_to_list_alert_P("Warning ?!", ip_address, notify_text, dt.ToString("MM/dd/yyyy h:mm tt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Displaynotify_custom", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Displaynotify





      
        public void Timer_to_polling_All(int CPU_usage, int RAM_usage, int Traffic, string uptime_WMI, string state_DB, int output_Queue_Length, List<string[]> Network_details, bool action_mode)
        {
            bool SNMP_connect = false;
            bool DB_connect = false;

            Console.WriteLine("Timer_to_polling_All");


            ////#odo
            //Send_Email_Alert_HTML("OS alert", "CPU and RAM have high utilization, with a value of CPU: " + CPU_usage + " % , "
            //           + "and a value of RAM: " + RAM_usage + " % , from " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
            //           + "The uptime of the server is " + uptime_WMI);

            //MessageBox.Show("test");
            ////#todo
            ///

            string OS_info_SNMP = Detect_SW_SNMP(ip_address);

            if (state_DB.Contains("Unavailable") == true)
            {
                Console.WriteLine("DB_connect error = T");
                DB_connect = true;
            }

            if ((OS_info_SNMP.Contains("No response") || OS_info_SNMP.Contains("ERROR: You have Some TIMEOUT issue")) == true)
            {
                Console.WriteLine("Detect_SW_SNMP error = T");
                SNMP_connect = true;
            }


            if (Activate_timer && (CPU_usage >= 80 || RAM_usage >= 80 || Traffic >= 1000 || SNMP_connect || DB_connect || output_Queue_Length > 2)) //#Traffic depend on website
            {
                Console.WriteLine(Activate_timer);
                // stopwatch = new Stopwatch();
                //                stopwatch.Start();



                if (CPU_usage >= 80 && RAM_usage >= 80)
                {
                    stopwatch_OS = new Stopwatch();
                    stopwatch_OS.Start();
                    Console.WriteLine("Timer_to_polling_All OS");
                }
                else if (RAM_usage >= 80)
                {
                    stopwatch_RAM = new Stopwatch();
                    stopwatch_RAM.Start();
                    Console.WriteLine("Timer_to_polling_All RAM");
                }
                else if (CPU_usage >= 80)
                {
                    stopwatch_CPU = new Stopwatch();
                    stopwatch_CPU.Start();
                    Console.WriteLine("Timer_to_polling_All CPU");
                }


                Activate_timer = false;
                Console.WriteLine(stopwatch.Elapsed.TotalSeconds);


            }
            else if (action_mode && one_time_action && (stopwatch_OS.IsRunning || stopwatch_CPU.IsRunning || stopwatch_RAM.IsRunning) &&
               (stopwatch_OS.Elapsed.TotalMinutes >= time_to_Action || stopwatch_CPU.Elapsed.TotalMinutes >= time_to_Action || stopwatch_RAM.Elapsed.TotalMinutes >= time_to_Action)

            //      (stopwatch_OS.Elapsed.TotalMinutes >= 3 || stopwatch_CPU.Elapsed.TotalMinutes >= 3 || stopwatch_RAM.Elapsed.TotalMinutes >= 3)
            && (CPU_usage >= 80 || RAM_usage >= 80 || Traffic >= 1000)) //#Traffic depend on website
            {
                Console.Write("%% Alert with action : ");
                Console.WriteLine(stopwatch.Elapsed.TotalSeconds);

                if (CPU_usage >= 80 && RAM_usage >= 80)
                {
                    //stopwatch_OS = new Stopwatch();
                    //stopwatch_OS.Start();
                    //Console.WriteLine("Timer_to_polling_All OS");

                    notify_report_time = "OS alert: from: " + ip_address + " ,since while " + stopwatch_OS.Elapsed.TotalMinutes + " minutes"
                        + "\n Due to the high utilization of CPU and RAM";

                    Console.WriteLine("reboot server : " + ip_address);
                    Action_to_server_windows(ip_address, 6, user_name, pass_word);
                    one_time_action = false;
                }
                else if (RAM_usage >= 80)
                {

                    notify_report_time = "RAM alert: from: " + ip_address + " ,since while " + stopwatch_RAM.Elapsed.TotalMinutes + " minutes"
                                       + "\n Due to the high utilization of RAM";
                    Action_to_server_windows(ip_address, 6, user_name, pass_word);
                    one_time_action = false;

                }
                else if (CPU_usage >= 80)
                {
                    notify_report_time = "CPU alert: from: " + ip_address + " ,since while " + stopwatch_CPU.Elapsed.TotalMinutes + " minutes"
                                 + "\n Due to the high utilization of CPU";
                    Action_to_server_windows(ip_address, 6, user_name, pass_word);
                    one_time_action = false;

                }



            }
            //email 10 m
            else if (one_time_email && (stopwatch_OS.IsRunning || stopwatch_CPU.IsRunning || stopwatch_RAM.IsRunning || SNMP_connect || DB_connect) &&
                    (stopwatch_OS.Elapsed.TotalMinutes >= time_to_Email || stopwatch_CPU.Elapsed.TotalMinutes >= time_to_Email || stopwatch_RAM.Elapsed.TotalMinutes >= time_to_Email)
            //     (stopwatch_OS.Elapsed.TotalMinutes >= 10 || stopwatch_CPU.Elapsed.TotalMinutes >= 2 || stopwatch_RAM.Elapsed.TotalMinutes >= 2)
            && (CPU_usage >= 80 || RAM_usage >= 80 || Traffic >= 1000 || output_Queue_Length > 2)) //#Traffic depend on website
            {
                //  MessageBox.Show("Alert" + ip_address + " is over 80% for 1 minutes ^^ ");
                Console.Write("%% Alert with email : ");
                Console.WriteLine(stopwatch.Elapsed.TotalSeconds);

                if (CPU_usage >= 80 && RAM_usage >= 80)
                {
                    string alert_type = "OS alert";
                    string OS_all_alert = "\n CPU and RAM have high utilization, with a value of CPU: " + CPU_usage + " % , "
                                            + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                                            + "\n \n The uptime of the server is " + uptime_WMI + " hour";
                    //Send_Email_Alert_HTML("OS alert", "\n CPU and RAM have high utilization, with a value of CPU: " + CPU_usage + " % , " 
                    //    +" \n and a value of RAM: " + RAM_usage  + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                    //    +"\n \n The uptime of the server is " + uptime_WMI + " hour");
                    string layer_state = "physical layer";



                    if (DB_connect && SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. " +
                            "Furthermore, unable to connect with the database. " +
                            "";
                        layer_state = "physical and transport and application layer";
                    }
                    else if (SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. ";
                        layer_state = "physical and transport layer";
                    }
                    else if (DB_connect)
                    {
                        alert_type = alert_type + " & DB alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the database. ";
                        layer_state = "physical and application layer";
                    }

                    if (output_Queue_Length > 2)
                    {
                        alert_type = alert_type + " Bottleneck in network alert";
                        OS_all_alert = OS_all_alert + ". On top of that ,Length of the output packet queue (in packets.) = " + output_Queue_Length +
                            "is longer than 2, delays are being experienced and the bottleneck should be found and eliminated. ";

                        layer_state = "network layer";
                    }

                    Console.WriteLine("layer_state " + layer_state);

                    Send_Email_Alert_HTML(alert_type, OS_all_alert, layer_state);

                    //   MessageBox.Show("Alert with email: Done to: " + ip_address, "Timer_to_polling_All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.Write("%% Alert with email : OS alert: CPU and RAM");

                    //notify_report_time = "OS alert: from: " + ip_address + " ,since while " + stopwatch.Elapsed.TotalMinutes + " minutes"
                    //    + "\n Due to the high utilization of CPU and RAM";

                    one_time_email = false;
                }
                else if (RAM_usage >= 80)
                {
                    string alert_type = "OS alert";
                    string OS_all_alert = "\n RAM have high utilization, with a value of CPU: " + CPU_usage + " % , "
                       + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                        + "\n \n The uptime of the server is " + uptime_WMI + " hour";

                    //Send_Email_Alert_HTML("OS alert", "\n CPU and RAM have high utilization, with a value of CPU: " + CPU_usage + " % , " 
                    //    +" \n and a value of RAM: " + RAM_usage  + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                    //    +"\n \n The uptime of the server is " + uptime_WMI + " hour");

                    string layer_state = "physical layer";


                    if (DB_connect && SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. " +
                            "Furthermore, unable to connect with the database. " +
                            "";
                        layer_state = "physical and transport and application layer";
                    }
                    else if (SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. ";
                        layer_state = "physical and transport layer";
                    }
                    else if (DB_connect)
                    {
                        alert_type = alert_type + " & DB alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the database. ";
                        layer_state = "physical and application layer";
                    }

                    Console.WriteLine("layer_state " + layer_state);

                    Send_Email_Alert_HTML(alert_type, OS_all_alert, layer_state);
                    //  MessageBox.Show("Alert with email: Done to: " + ip_address, "Timer_to_polling_All", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Send_Email_Alert_HTML("OS alert", "\n RAM have high utilization, with a value of CPU: " + CPU_usage + " % , "
                    //   + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago "
                    //    + "\n \n The uptime of the server is " + uptime_WMI + " hour");
                    Console.Write("%% Alert with email : OS alert: RAM");

                    //notify_report_time = "RAM alert: from: " + ip_address + " ,since while " + stopwatch.Elapsed.TotalMinutes + " minutes"
                    //                   + "\n Due to the high utilization of RAM";
                    one_time_email = false;

                }
                else if (CPU_usage >= 80)
                {

                    string alert_type = "OS alert";
                    string OS_all_alert = "\n CPU have high utilization, with a value of CPU: " + CPU_usage + " % , "
                         + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                        + "\n \n The uptime of the server is " + uptime_WMI + " hour";

                    //Send_Email_Alert_HTML("OS alert", "\n CPU and RAM have high utilization, with a value of CPU: " + CPU_usage + " % , " 
                    //    +" \n and a value of RAM: " + RAM_usage  + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                    //    +"\n \n The uptime of the server is " + uptime_WMI + " hour");

                    string layer_state = "physical layer";


                    if (DB_connect && SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. " +
                            "Furthermore, unable to connect with the database. " +
                            "";
                        layer_state = "physical and transport and application layer";
                    }
                    else if (SNMP_connect)
                    {
                        alert_type = alert_type + " & SNMP alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the server via SNMP. ";
                        layer_state = "physical and transport layer";
                    }
                    else if (DB_connect)
                    {
                        alert_type = alert_type + " & DB alert";
                        OS_all_alert = OS_all_alert + ". In addition, unable to connect with the database. ";
                        layer_state = "physical and application layer";
                    }

                    Console.WriteLine("layer_state " + layer_state);

                    Send_Email_Alert_HTML(alert_type, OS_all_alert, layer_state);
                    one_time_email = false;

                    //Send_Email_Alert_HTML("OS alert", "\n CPU have high utilization, with a value of CPU: " + CPU_usage + " % , "
                    //     + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago "
                    //    + "\n \n The uptime of the server is " + uptime_WMI + " hour");

                    Console.Write("%% Alert with email : OS alert: CPU");

                }


                if (output_Queue_Length > 2)
                {
                    string alert_type = "Bottleneck in network alert";
                    string network_alert = "\n Network have bottleneck" +
                       "  , Length of the output packet queue(in packets.) = " + output_Queue_Length +
                        "is longer than 2, delays are being experienced and the bottleneck should be found and eliminated. "
                        + "with a value of CPU: " + CPU_usage + " % , "
                         + " \n and a value of RAM: " + RAM_usage + " % \n From " + stopwatch_OS.Elapsed.TotalMinutes + " minutes ago. "
                        + "\n \n The uptime of the server is " + uptime_WMI + " hour";

                    foreach (string[] i in Network_details)
                    {

                        network_alert = network_alert + "\n The network details of the server are: " +
                            "Name of modem: " + i[1] + " , BytesReceivedPerSec: " + i[2] +
                           "BytesSentPerSec: " + i[3] + " , BytesTotalPerSec: " + i[4] + ", CurrentBandwidth: " + i[5];

                        //   string[] info_network = new string[] { ip_address,Name_network, Bytes_received_Psec 
                        //, Bytes_sent_Psec ,Bytes_total_Psec, Current_bandwidth + " MB"};
                        /*
                        Name of modem
    BytesReceivedPerSec
    BytesSentPerSec
    BytesTotalPerSec
    CurrentBandwidth

                        */
                        //network_listView.Items.Add(new ListViewItem(i));

                    }


                    string layer_state = "network layer";
                    Console.WriteLine("layer_state " + layer_state);

                    Send_Email_Alert_HTML(alert_type, network_alert, layer_state);

                    //  MessageBox.Show("Alert with email: Done to: " + ip_address, "Timer_to_polling_All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.Write("%% Alert with email : network alert");
                }




            }
            else if ((stopwatch_OS.IsRunning || stopwatch_CPU.IsRunning || stopwatch_RAM.IsRunning) &&
       (stopwatch_OS.Elapsed.TotalMinutes >= time_to_Notifications || stopwatch_CPU.Elapsed.TotalMinutes >= time_to_Notifications || stopwatch_RAM.Elapsed.TotalMinutes >= time_to_Notifications)
            //    (stopwatch_OS.Elapsed.TotalMinutes >= 1 || stopwatch_CPU.Elapsed.TotalMinutes >= 1 || stopwatch_RAM.Elapsed.TotalMinutes >= 1)
            && (CPU_usage >= 80 || RAM_usage >= 80 || Traffic >= 1000)) //#Traffic depend on website
            {
                //  MessageBox.Show("Alert" + ip_address + " is over 80% for 1 minutes ^^ ");
                Console.Write("%% Alert notify : ");
                //   Console.WriteLine(stopwatch.Elapsed.TotalSeconds);



                if (CPU_usage >= 80 && RAM_usage >= 80)
                {

                    notify_report_time = "OS alert: from: " + ip_address + " ,since while " + stopwatch_OS.Elapsed.TotalMinutes + " minutes"
                        + "\n Due to the high utilization of CPU and RAM";

                }
                else if (RAM_usage >= 80)
                {

                    notify_report_time = "RAM alert: from: " + ip_address + " ,since while " + stopwatch_RAM.Elapsed.TotalMinutes + " minutes"
                                       + "\n Due to the high utilization of RAM";
                }
                else if (CPU_usage >= 80)
                {
                    notify_report_time = "CPU alert: from: " + ip_address + " ,since while " + stopwatch_CPU.Elapsed.TotalMinutes + " minutes"
                                 + "\n Due to the high utilization of CPU";
                }


            }
            else if ((stopwatch_OS.IsRunning || stopwatch_CPU.IsRunning || stopwatch_RAM.IsRunning) &&
            (CPU_usage <= 80 || RAM_usage <= 80 || Traffic <= 1000)) //#Traffic depend on website)
            {
                //s Console.WriteLine("Enter Alert stop");

                if (CPU_usage <= 80 && RAM_usage <= 80)
                {

                    // todo remvoe
                    // stopwatch_OS.Stop();//here problem
                    //Console.WriteLine("Alert stop os");


                    //#todo
                    //  Activate_timer = true;

                }
                else if (RAM_usage <= 80)
                {

                    stopwatch_RAM.Stop();//here problem
                    Console.WriteLine("Alert stop RAM");

                }
                else if (CPU_usage <= 80)
                {
                    stopwatch_CPU.Stop();//here problem
                    Console.WriteLine("Alert stop CPU");

                }


                //stopwatch.Stop();//here problem

            }
            //    else if (Availability)
            //{
            //    //#todo
            //}

        }



        public void Action_to_server_windows(string host, int flags, string username, string password)
        {

            //Each flag, when issued in the query, sends a different command to taget machine
            /*
             *Flags:
             *  0 Log Off
             *  1 Shutdown
             *  2 Reboot
             *  4 Forced Log Off
             *  5 Forced Shutdown
             *  6 Forced Reboot
             *  8 Power Off
             *  12 Forced Power Off
             *  Flags:
- 0 (0x0) Log Off
- 4 (0x4) Forced Log Off (0 4)
- 1 (0x1) Shutdown
- 5 (0x5) Forced Shutdown (1 4)
- 2 (0x2) Reboot
- 6 (0x6) Forced Reboot (2 4)
- 8 (0x8) Power Off
- 12 (0xC) Forced Power Off (8 4)
             */

            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = username;
                options.Password = password;


                // ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM Win32_OperatingSystem");

                //MYA
                ManagementScope scope = new ManagementScope("\\\\" + host + "\\root\\cimv2", options);
                ObjectQuery query = new ObjectQuery("SELECT *FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject obj in searcher.Get())
                {
                    ManagementBaseObject inParams = obj.GetMethodParameters("Win32Shutdown");

                    inParams["Flags"] = flags;

                    ManagementBaseObject outParams = obj.InvokeMethod("Win32Shutdown", inParams, null);
                }
            }
            catch (ManagementException manex)
            {
                MessageBox.Show("Error:\n\n" + manex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException unaccex)
            {
                MessageBox.Show("Admin access required \n\n" + unaccex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //public void Send_Email_Alert()
        //{



        //    //Write the following code in the btnSend_Click event:

        //    //#TODO email

        //    try
        //    {
        //        //btnSend.Enabled = false;

        //        //btnCancel.Visible = true;

        //        // private  MailMessage message;
        //        //  private SmtpClient smtp;
        //        MailMessage message = new MailMessage();

        //        //    if (IsValidEmail(email_textBox.Text))
        //        if (IsValidEmail("world.m.y.a@gmail.com"))
        //        //if (IsValidEmail("aligalal97@yahoo.com"))


        //        {

        //            //  message.To.Add(email_textBox.Text);
        //            message.To.Add("world.m.y.a@gmail.com");
        //            //message.To.Add("aligalal97@yahoo.com");


        //        }



        //        if (IsValidEmail("‫Ahmed.alejil66@gmail.com‬"))
        //        {
        //            message.CC.Add("‫Ahmed.alejil66@gmail.com‬");
        //        }

        //        //message.Subject = txtSubject.Text;
        //        message.Subject = "Warning: Your network is in trouble!"; //mya :)

        //        //message.From = new MailAddress("deepak.sharma009@gmail.com");

        //        message.From = new MailAddress("ea.section2018@gmail.com");


        //        //message.Body = txtBody.Text;

        //        /*
        //         Welcome, we would like to inform you that there is a network problem and it is issued by 
        //        the device which is ()Please act quickly

        //        This message was sent automatically from the graduation project program for students Ahmed and Muhammad
        //         * */
        //        //rfit with ahmed 16/nov
        //        //string massage_gp6 = "Welcome, \n We would like to inform you that there is a network problem and it is issued by" +
        //        //                    " the devices (" + testbox1_name_form3.Text + " with IP: " + ip_box_form3.Text + "),With the following problems: " + massage_error + " Please act quickly. \n" +
        //        //                    "\n This message was sent automatically from the graduation project program by Ahmed and Mohammad";    //


        //        //message.Body = massage_gp6;//12 / nov

        //        message.Body = "Hi test with Ali and Abdurhman";//12 / nov

        //        // set smtp details

        //        SmtpClient smtp = new SmtpClient("smtp.gmail.com");//relay from 

        //        //smtp.Port = 465;

        //        smtp.Port = 587; //eng maher : https://support.google.com/mail/answer/7126229?hl=en




        //        // smtp.Port = 25;//No


        //        smtp.EnableSsl = true;

        //        //smtp.Credentials = new NetworkCredential("deepak.sharma009@gmail.com", "********");
        //        smtp.Credentials = new System.Net.NetworkCredential("ea.section2018@gmail.com", "Easection2018");


        //        smtp.SendAsync(message, message.Subject);

        //        // smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        //btnCancel.Visible = false;

        //        //btnSend.Enabled = true;
        //    }
        //}//send email 



        //public void send_Email_Alert(string massage_error)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();

        //        if (IsValidEmail("world.m.y.a@gmail.com"))
        //        //if (IsValidEmail("aligalal97@yahoo.com"))
        //        {
        //            message.To.Add("world.m.y.a@gmail.com");
        //        }
        //        if (IsValidEmail("‫Ahmed.alejil66@gmail.com‬"))
        //        {
        //            message.CC.Add("‫Ahmed.alejil66@gmail.com‬");
        //        }

        //        message.Subject = "Warning: Your network is in trouble!"; //#todo is problem if solve
        //        message.From = new MailAddress("ea.section2018@gmail.com");


        //        //message.Body = txtBody.Text;

        //        /*
        //         Welcome, we would like to inform you that there is a network problem and it is issued by 
        //        the device which is ()Please act quickly

        //        This message was sent automatically from the graduation project program for students Ahmed and Muhammad
        //         * */
        //        //rfit with ahmed 16/nov
        //        string massage_gp6 = "Welcome, \n We would like to inform you that there is a network problem and it is issued by" +
        //            //        " the devices (" + name_in_database + " with IP: " + ip_address + "),With the following problems: " + massage_error + " Please act quickly. \n" +
        //                   " the server (" + name_in_database + " with IP: " + ip_address + "),With the following problems: " + massage_error + ",with alert " + 
        //                   alert + " Please act quickly. \n" +
        //            "\n This message was sent automatically from the graduation project 2 program by Ahmed Elegl and Mohammad Ammar";    //


        //        message.Body = massage_gp6;//12 / nov


        //        // set smtp details

        //        SmtpClient smtp = new SmtpClient("smtp.gmail.com");//relay from 

        //        smtp.Port = 587; //Eng maher : https://support.google.com/mail/answer/7126229?hl=en


        //        smtp.EnableSsl = true;
        //        smtp.Credentials = new System.Net.NetworkCredential("ea.section2018@gmail.com", "Easection2018");


        //        //smtp.SendAsync(message, message.Subject);
        //        smtp.SendAsync(message, message.Subject);

        //        Console.WriteLine("send_Email_Alert");
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        alert = ex.Message + "From Send_Email_Alert";
        //    }
        //}//send email 

        //public static void Send_Email_Alert(string ip, string text, string date)
        public  void Send_Email_Alert_HTML(string problem, string massage_error , string layer_detect)

        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("GP6 monitoring tool", "Ea.Section2018@gmail.com"));
                mailMessage.To.Add(new MailboxAddress("Administrator", "world.m.y.a@gmail.com"));

            //run
            //mailMessage.To.Add(new MailboxAddress("Administrator", "Ahmed.alejil66@gmail.com"));

            mailMessage.Cc.Add(new MailboxAddress("NOC", "Ahmed.alejil66@gmail.com"));


            //
            mailMessage.Subject = ("Warning: Your network is in trouble!");
            //mailMessage.Body = new TextPart("plain")
            //{
            //   // Text = ip + text + date
            //   Text = "Welcome, \n We would like to inform you that there is a network problem and it is issued by" +
            //               //        " the devices (" + name_in_database + " with IP: " + ip_address + "),With the following problems: " + massage_error + " Please act quickly. \n" +
            //               " the server (" + name_in_database + " with IP: " + ip_address + "),With the following problems: " + massage_error + ",with alert " +
            //               alert + " Please act quickly. \n" +
            //        "\n This message was sent automatically from the graduation project 2 program by Ahmed Elegl and Mohammad Ammar"
            //};



            string original_Email = System.IO.File.ReadAllText(
                  Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index.htm"));

            string email_new   = original_Email.Replace("IP_Address", ip_address + " [ " + name_in_database + " ]");

            string email_new2 = email_new.Replace("Problem98", "Problem: " + problem);

            string email_new3 = email_new2.Replace("Specifications66", "Welcome, we want to alert you about a network problem, which is issued by" +
                                " the following devices (" + name_in_database + " with IP: " + ip_address + "), With the following problems: " + massage_error + "  Please act quickly.");

            /*
            "Welcome, we want to alert you to a network problem, which is issued by" +
                                " the following devices (" + name_in_database + " with IP: " + ip_address + "), With the following problems: " + massage_error + " \n Please act quickly. \n" +
                            
            */

            //   string email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/4l6j3nfil22klnp/Layer_physical_false.png?raw=1");

            string email_new4 = "";//defualt

            if (layer_detect.Contains("physical and transport and application") == true)
            {
                email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/9hbrzbpis7bpc3m/Layer_physical_transport_application_false.png?raw=1");
                //change
            }
            else if (layer_detect.Contains("physical and application") == true)
            {
                email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/7yll5eql9l8luf2/Layer_physical_application_false.png?raw=1");
                //change
            }
            else if (layer_detect.Contains("physical and transport") == true) {
                 email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/o0v9v8ih3nirpef/Layer_physical_transport_false.png?raw=1");
            }
            else if ((layer_detect.Contains("network")) == true)
            {
                email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/wsbkbvf315liys6/Layer_network_false.png?raw=1");
                //change 
            }
            else if (layer_detect.Contains("application") == true)
            {
                email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/aa32l4su7hy5o2o/Layer_application_false.png?raw=1");
            }
            else if (layer_detect.Contains("physical") == true)
            {
                email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/4l6j3nfil22klnp/Layer_physical_false.png?raw=1");
            }


            var dt = DateTime.Now;
            string name_of_email_file = dt.ToString("MM-dd-yyyy-h-mm-tt");


            System.IO.File.WriteAllText(
//#todo
            //      Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_last_sent.htm"), email_new4);
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_sent"+ name_of_email_file+".htm"), email_new4);

            //


            mailMessage.Body = new TextPart("html")
            {
                Text = //email_new
                System.IO.File.ReadAllText(
               // Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_last_sent.htm"))
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_sent" + name_of_email_file + ".htm"))
            };
                //After that add image and text with all specs in table

            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("Ea.Section2018@gmail.com", "Easection2018");
                smtpClient.Send(mailMessage);
                Console.WriteLine("Send Email");
                smtpClient.Disconnect(true);
            }
        }

            private bool IsValidEmail(string email)
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

        public string get_ip_address()
        {
            return ip_address;
        }

        public string get_alert()
        {
            return alert;
        }
        public string get_name_in_database()
        {
            return name_in_database;
        }
        public string get_user_name()
        {
            return user_name;
        }
        public string get_pass_word()
        {
            return pass_word;
        }




    }//class Monitoring_GP6_M_A_2021




    class Eventlog_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {

        public int error = 0;
        public int warning = 0;
        public int information = 0;
        public int Security_audit_success = 0;
        public int Security_audit_failure = 0;
        public List<string[]> Eventlog_list = new List<string[]>();

        public Eventlog_Monitoring(string ip_address, string user_name, string pass_word, string Events_selected_for_viewing, bool automatic_scan, string monthCalendar1)
        {
            base.ip_address = ip_address;
            base.user_name = user_name;
            base.pass_word = pass_word;
            scan_event_log_Parallel(Events_selected_for_viewing, automatic_scan, monthCalendar1);
        }

        //  public void scan_event_log_Parallel(string ip_address, string Events_selected_for_viewing)


        public void scan_event_log_Parallel(string Events_selected_for_viewing, bool automatic_scan, string monthCalendar1)
        {
            try
            {
                if (base.PingHost()) // base in C# , super in java
                {
                    var conOpt = new ConnectionOptions();
                    conOpt.Impersonation = ImpersonationLevel.Impersonate;
                    conOpt.EnablePrivileges = true;
                    conOpt.Username = user_name;
                    conOpt.Password = pass_word;
                    var scope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", ip_address), conOpt);
                    scope.Connect();
                    bool isConnected = scope.IsConnected;
                    if (isConnected)
                    {
                        string dateTime = getDmtfFromDateTime(DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)));  /* entire day */
                        //  best practice :) ; DRY (Don't repeat yourself)
                        if (automatic_scan)
                        {
                            dateTime = getDmtfFromDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                        }
                        else
                        {
                            dateTime = getDmtfFromDateTime(monthCalendar1); // DateTime specific
                        }
                        SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                        ManagementObjectCollection logs = searcher.Get();
                        List<ManagementObject> logsList = logs.Cast<ManagementObject>().ToList();
                        Parallel.ForEach(logsList, log =>
                        {
                            Console.WriteLine($"thread = {Thread.CurrentThread.ManagedThreadId}");
                        if (string.Equals(Events_selected_for_viewing, "All"))
                            {
                            string[] Event_log = new string[] { ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                             log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                             log["SourceName"].ToString(), log["RecordNumber"].ToString()
                             , getDateTimeFromDmtfDate(log["TimeWritten"].ToString()) };
                                Eventlog_list.Add(Event_log); // store to List
                        }
                        //filters
                        else if (string.Compare(Events_selected_for_viewing, log["EventType"].ToString()) == 0)
                            {
                            string[] Event_log = new string[] { ip_address, log["Message"].ToString(), log["ComputerName"].ToString(),
                             log["Type"].ToString(), log["EventType"].ToString(), log["EventCode"].ToString(),
                             log["SourceName"].ToString(), log["RecordNumber"].ToString()
                             , getDateTimeFromDmtfDate(log["TimeWritten"].ToString()) };

                                Eventlog_list.Add(Event_log); // store to List
                        }
                    });


                    }
                    //To close the connection to become like Syslog | Ahmed & Mohammad in meet 18 - 2 - 2021
                    scope.Path = new ManagementPath(string.Empty);
                }//if ping
                else
                {
                    string[] Event_log = new string[] { ip_address, "Not available", "",
                     "", "", "",
                    "", "", ""};
                    Eventlog_list.Add(Event_log); // store to List
                }
            }
            catch (Exception ex)
            {
              alert = ex.Message + " from " + "scan_event_log_Parallel";
            }
        }//Method scan_event_log_Parallel

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

        public void count_event(string Message_event, string event_type, string TimeWritten)
        {
            if (event_type.Equals("1"))
            {
                error = error + 1;
              //  Displaynotify_custom("Error" + " at: " + TimeWritten + ", Message: " + Message_event);
            }
            else if (event_type.Equals("2"))
            {
                warning = warning + 1;
              //  Displaynotify_custom("Warning" + " at: " + TimeWritten + ", Message: " + Message_event);
            }
            else if (event_type.Equals("3"))
            {
                information = information + 1;
            }
            else if (event_type.Equals("4"))
            {
                Security_audit_success = Security_audit_success + 1;
            }
            else if (event_type.Equals("5"))
            {
                Security_audit_failure = Security_audit_failure + 1;
               // Displaynotify_custom("Security Audit Failure" + " at: " + TimeWritten + ", Message: " + Message_event);
            }
        }

        ////complete #todo


    }//class Event_Log_Monitoring


    class IIS_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {
        //Data to WMI 
        public string NameOfWebsite = "";

        public int TotalGetRequests = 0;
        public int TotalHeadRequests = 0;
        public int FilesSentPerSec = 0;
        public int FilesReceivedPerSec = 0;
        public int AnonymousUsersPerSec = 0;
        public int CurrentNonAnonymousUsers = 0;
        public int CGIRequestsPerSec = 0;
        public int GetRequestsPerSec = 0;
        public int PostRequestsPerSec = 0;
        public int NotFoundErrorsPerSec = 0;
        //  public int TotalGetRequests_total = 0;

        //   public List<string[]> Trafic_IIS_list = new List<string[]>();

        private string website = "n/a";
        public IIS_Monitoring(string ip, string user, string pass, string name_in_database)
        {
            ip_address = ip;
            user_name = user;
            pass_word = pass;
            base.name_in_database = name_in_database;

            //TEST
            WebService_WMI_Parallel();

        }

        public IIS_Monitoring(string ip, string user, string pass, string name_in_database, string website)
        {
            ip_address = ip;
            user_name = user;
            pass_word = pass;
            base.name_in_database = name_in_database;

            this.website = website;
            //TEST
            WebService_WMI_Parallel();
            DNS_info();
            HTTP_info();
            //#todo more
        }

        public void WebService_WMI_Parallel()
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = user_name;
                options.Password = pass_word;
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();
                //Query system for web server information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                List<ManagementObject> IIS_List = queryCollection.Cast<ManagementObject>().ToList();
                Parallel.ForEach(IIS_List, m =>
                {
                    NameOfWebsite = m["Name"].ToString();
                    TotalGetRequests = int.Parse(m["TotalGetRequests"].ToString());
                    TotalHeadRequests = int.Parse(m["TotalHeadRequests"].ToString());
                    FilesSentPerSec = int.Parse(m["FilesSentPerSec"].ToString());
                    FilesReceivedPerSec = int.Parse(m["FilesReceivedPerSec"].ToString());
                    AnonymousUsersPerSec = int.Parse(m["AnonymousUsersPerSec"].ToString());
                    CurrentNonAnonymousUsers = int.Parse(m["CurrentNonAnonymousUsers"].ToString());
                    CGIRequestsPerSec = int.Parse(m["CGIRequestsPerSec"].ToString());
                    GetRequestsPerSec = int.Parse(m["GetRequestsPerSec"].ToString());
                    PostRequestsPerSec = int.Parse(m["PostRequestsPerSec"].ToString());
                    NotFoundErrorsPerSec = int.Parse(m["NotFoundErrorsPerSec"].ToString());
                });//eachfor P
                  }//try
            catch (Exception ex)
            {
                alert = ex.Message + " from " + "IIS_W3SVC_WebService_WMI_Parallel";
            }//catch
        }//WebService_WMI_Parallel

        public string DNS_info()
        {
            string website_new = website;
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
            try
            {
                var address = Dns.GetHostAddresses(website_new)[0]; //old
                return address.ToString();
            }
            catch (Exception ex)
            {
                alert = ex.Message + " From DNS_info";
                return ex.Message;
            }

        }
        public string HTTP_info()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(website);
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                timer.Stop();

                TimeSpan timeTaken = timer.Elapsed;

                return timeTaken.ToString();

            }
            catch (Exception ex)//add by Mohammad
            {
                alert = ex.Message + " From HTTP_info";
                return ex.Message;
            }
        }

    }//class IIS_Monitoring


    //TEST with ahmed and basem 28/3/2021
    class OS_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {
        public string Cpu_usage = "n/a";
        public string Thread_count = "n/a";


        public int Handle = 0;

        public string Ratio_disk_size = "n/a";
        public string Ratio_ram_size = "n/a";

        public string Current_voltage = "n/a";
        public IPHostEntry Host_name;

        private string uptime_WMI = "n/a";
        private int output_Queue_Length = 0;

        //Network
        //public string Name_network = "n/a";
        //public string Bytes_received_Psec = "n/a";
        //public string Bytes_sent_Psec = "n/a";
        //public string Bytes_total_Psec = "n/a";
        //public string Current_bandwidth = "n/a";
        public List<string[]> Network_details = new List<string[]>();


        public List<string[]> Processors_details = new List<string[]>();


        public OS_Monitoring(string ip_address, string user_name, string pass_word, string name_in_database, string filter)
        {
            base.ip_address = ip_address;
            base.user_name = user_name;
            base.pass_word = pass_word;
            base.name_in_database = name_in_database;




            scan_full_OS_Parallel(filter);

        }

        //public void check_alert(string custom)
        //{
        //    if (custom.Equals("Dashboard"))
        //    {
        //        get_CPU_Parallel();
        //    }
        //    Timer_to_polling(int.Parse(Cpu_usage));
        //}

        public void check_alert_All(string custom , string state_DB , bool action_mode)
        {
            if (custom.Equals("Dashboard"))
            {
                get_CPU_Parallel();
                get_RAM_WMI();
                get_Network_Parallel();

            }
            //  Timer_to_polling(int.Parse(Cpu_usage));

            //        public void Timer_to_polling_All(bool Availability, int CPU_usage, int RAM_usage, int Traffic)

            //todo tarafic
//Todo
            //  Timer_to_polling_All(int.Parse(Cpu_usage) , int.Parse(Ratio_ram_size) , 0 , uptime_WMI, state_DB , output_Queue_Length , Network_details);
            Timer_to_polling_All(int.Parse(Cpu_usage) , int.Parse(Ratio_ram_size) , 0 , uptime_WMI, state_DB , output_Queue_Length, Network_details , action_mode);
        }

        public void scan_full_OS_Parallel(string filter)
        {

            //  MessageBox.Show("scan_full_OS_Parallel");

            try
            {
                //P
                //  MessageBox.Show("scan_full_OS_Parallel");

                //#todo // done :)
                IPAddress addres;

                addres = IPAddress.Parse(ip_address);
                Host_name = Dns.GetHostEntry(addres);
                get_CPU_Parallel();
                get_Disk_space();
                get_RAM_WMI();
                if (filter.Equals("Custom"))
                {
                    Processors_details_task_manager();
                    get_CPU_Thread_Voltage();
                    get_CPU_Handle();
                    get_Network_Parallel();
                }


                //RAM_SNMP();
                //wmi_info

                /// test.listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", host.HostName, cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

            }


            //Catch invalid IP types
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
                alert = ex.Message + " from " + "scan_full_OS_Parallel";

            }
        }//method scan_full_OS_Parallel



        public void get_CPU_Parallel()
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = user_name;
                options.Password = pass_word; 
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();
                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor Where Name = '_Total'");
                ManagementObjectSearcher cpus = new ManagementObjectSearcher(scope, wmicpus);
                ManagementObjectCollection cpu_queryCollection = cpus.Get();
                List<ManagementObject> cpu_List = cpu_queryCollection.Cast<ManagementObject>().ToList();
                Parallel.ForEach(cpu_List, (cpu, state) =>
                {
                    uint PercentProcessorTime = Convert.ToUInt32(cpu["PercentProcessorTime"]);
                    Cpu_usage = PercentProcessorTime.ToString();
                    Console.WriteLine("get_CPU_Parallel");
                    state.Stop();
                });
            }//try
            catch (Exception ex)
            {
                alert = ex.Message + " from " + "get_CPU_Parallel";
            }//catch
        }//get_CPU_Parallel


        public void get_CPU_Thread_Voltage()

        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-thread

                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Processor");

                ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);

                ManagementObjectCollection queryCollection = cpus.Get();


                List<ManagementObject> Thread_List = queryCollection.Cast<ManagementObject>().ToList();


                Parallel.ForEach(Thread_List, cpu =>
                {



                    //MYA
                    //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor

                    //The number of threads per processor socket.
                    //MessageBox.Show(cpu["ThreadCount"].ToString());
                    Thread_count = "n/a";
                    Thread_count = cpu["ThreadCount"].ToString();
                    // break;

                    Current_voltage = cpu["CurrentVoltage"] + " V";

                    //  Console.WriteLine("total_" + cpu["DeviceId"] + " : " + cpu["LoadPercentage"] + "%");

                    ////  MessageBox.Show("total_" + cpu["DeviceId"] + " : " + cpu["LoadPercentage"] + "%");

                    //  //Console.WriteLine("Caption            : " + cpu["Caption"]);

                    //  Console.WriteLine("maxspeed           : " + cpu["MaxClockSpeed"] + " GH ");
                    //  Console.WriteLine("SystemName         : " + cpu["SystemName"]);
                    //  Console.WriteLine("CurrentVoltage     : " + cpu["CurrentVoltage"] + " V");
                    //  //label4.Text = cpu["LoadPercentage"].ToString() + "%";
                    //  //cpu_usage = int.Parse(cpu["LoadPercentage"].ToString());


                });
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(e.Message, "get_more_cpu_info_Win32_Processor_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert = ex.Message + " from " + "get_more_cpu_info_Win32_Processor_Parallel";
            }
        }

        public void get_CPU_Handle()

        {
            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = user_name;//solve problem to week ; IP 
                options.Password = pass_word;
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-thread


                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Thread");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmicpus);

                ManagementObjectCollection queryCollection = searcher.Get();


                List<ManagementObject> Thread_List = queryCollection.Cast<ManagementObject>().ToList();

                Parallel.ForEach(Thread_List, (cpu, state) =>
                {
                    //MYA idea 15/3/2021
                    Handle = Handle + int.Parse(cpu["Handle"].ToString());

                    //MessageBox.Show(Handle.ToString());


                    // state.Break();

                });
                //Handle = Handle_sum;
                //Handle_sum = 0;
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message, "get_more_cpu_info_win32_thread_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert = ex.Message + " from " + "get_more_cpu_info_win32_thread_Parallel";
            }
        }//Method get_more_cpu_info_win32_thread_Parallel

        public void get_Network_Parallel()
        {

            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead   username "Administrator"
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();


                List<ManagementObject> NetworkList = queryCollection.Cast<ManagementObject>().ToList();

                //  foreach (ManagementObject m in queryCollection)
                Parallel.ForEach(NetworkList, m =>
                {

                    // Display the remote computer information
                    //Console.WriteLine("net_BytesReceivedPerSec     : {0}", m["BytesReceivedPerSec"]);
                    //Console.WriteLine("net_BytesSentPerSec : {0}", m["BytesSentPerSec"]);
                    //Console.WriteLine("net_BytesTotalPerSec  : {0}", m["BytesTotalPerSec"]);
                    //Console.WriteLine("net_CurrentBandwidth : {0}", m["CurrentBandwidth"]);
                    //Console.WriteLine(" net1     : {0}", m["Name"]);


                    string Name_network = m["Name"].ToString();
                    string Bytes_received_Psec = m["BytesReceivedPerSec"].ToString();
                    string Bytes_sent_Psec = m["BytesSentPerSec"].ToString();
                    string Bytes_total_Psec = m["BytesTotalPerSec"].ToString();
                    string Current_bandwidth = m["CurrentBandwidth"].ToString();

                    string[] info_network = new string[] { ip_address,Name_network, Bytes_received_Psec 
                        , Bytes_sent_Psec ,Bytes_total_Psec, Current_bandwidth + " MB"};

                    Network_details.Add(info_network); // store to List

                    output_Queue_Length = int.Parse(m["OutputQueueLength"].ToString());
                    /*
                     Length of the output packet queue (in packets.) If this is longer than 2,
                    delays are being experienced and the bottleneck should be found and eliminated, 
                    if possible. Because the requests are queued by NDIS in this implementation, this value is always 0.
                     * */
                });

            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message, "network_OS_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert = ex.Message + " from " + "network_OS_Parallel";
            }
        }//Method get_more_cpu_info_win32_thread_Parallel



        //#todo imrove !!!!!!!!!!!!
        public void get_Disk_space()
        {
            try
            {



                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;

                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();

                //#todo check !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                SelectQuery query1 = new SelectQuery("Select * from Win32_LogicalDisk");

                //List<ManagementObject> GetDiskspace_p = queryCollection.Cast<ManagementObject>().ToList();
                ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
                ManagementObjectCollection queryCollection1 = searcher1.Get();
                //p
                List<ManagementObject> GetDiskspace_p2 = queryCollection1.Cast<ManagementObject>().ToList();


                 foreach (ManagementObject mo in queryCollection1)
             //   Parallel.ForEach(GetDiskspace_p2, (mo, state) =>
               {
                   // Display Logical Disks information
                   //string N = mo["Name"].ToString();
                   //Console.WriteLine("              Disk Name : {0}", mo["Name"]);
                   //double disksize = double.Parse(mo["Size"].ToString());
                   //Console.WriteLine("              Disk Size : {0} MB", mo["Size"]);
                   //Console.WriteLine("              FreeSpace : {0} MB", mo["FreeSpace"]);

                   double ratio_disk_size_temp = (double.Parse(mo["FreeSpace"].ToString()) / double.Parse(mo["Size"].ToString())) * 100;
                   //   ratio_disk_size =
                   // ratio_disk_size_temp = Math.Round(ratio_disk_size_temp, MidpointRounding.ToEven);

                   ratio_disk_size_temp = 100 - Math.Round(ratio_disk_size_temp, MidpointRounding.ToEven);


                   Ratio_disk_size = ratio_disk_size_temp.ToString();

                 //  Console.WriteLine("        Disk SystemName : {0}", mo["SystemName"]);

                   //Console.WriteLine("MYA ,FreeSpace /Disk Size  " + Ratio_disk_size.ToString() + " %");  //#todo
                                                                                                          //   state.Stop();//#todo ; hat 2 . 2 is 0
                   break;


                   //Console.WriteLine("        Disk SystemName : {0}", mo["SystemName"]);
                   //Console.WriteLine("Disk VolumeSerialNumber : {0}", mo["VolumeSerialNumber"]);
                   //Console.WriteLine();
                   ////liveChart();


                   //   });
                   // });
               }

            }

            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message, "GetDiskspace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert = ex.Message + " from " + "GetDiskspace";
            }
        }



        public void get_RAM_WMI()
        {
            try
            {


                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead
                options.Username = user_name;
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                // liveChart();
                ManagementObjectCollection queryCollection = searcher.Get();

                //parllel
                List<ManagementObject> OS_list = queryCollection.Cast<ManagementObject>().ToList();
                //  memoryusage_p = "n/a";
                /// foreach (ManagementObject m in queryCollection)
                Parallel.ForEach(OS_list, (m, state) =>
               {
                    
                    DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(m["LastBootUpTime"].ToString()); // uptime

                     uptime_WMI = (DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime()).ToString();
                   // Console.WriteLine("UPTIME IS : {0}", DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime());
                    //label15.Text = u.ToString();

                     
                    /*
                                        //Convert KB to MB
                                        double phmemory = int.Parse(m["TotalVisibleMemorySize"].ToString()) / 1024 * (0.0009765625);
                                        Console.WriteLine("TotalPhysicalMemorySize : " + phmemory + " MB");
                                        //Convert KB to MB
                                        double AvailabPhysical = int.Parse(m["FreePhysicalMemory"].ToString()) / 1024 * (0.0009765625);
                                        Console.WriteLine("Availabl Physical Memory: " + AvailabPhysical + " MB");

                                         */
                    //MYA
                    //Convert KB to MB
                    double phmemory = int.Parse(m["TotalVisibleMemorySize"].ToString());
                 //  Console.WriteLine("TotalPhysicalMemorySize : " + phmemory + " MB");
                    //Convert KB to MB
                    double AvailabPhysical = int.Parse(m["FreePhysicalMemory"].ToString());
                    //    Console.WriteLine("Availabl Physical Memory: " + AvailabPhysical + " MB");
                    // The amount of physical memory available for the operating system
                    // The amount of physical memory available for the operating system

                    double Total_memoryusage = Math.Round((phmemory - AvailabPhysical) / phmemory * 100);

                   Ratio_ram_size = Total_memoryusage.ToString();

                //   Console.WriteLine(Ratio_ram_size);
                   state.Stop();

                    // }
                });

            }
            catch (Exception ex)
            {
                alert = ex.Message + " From" + "RAM_WMI";
            }
        }


        //#todo fix accurecy
        public void RAM_SNMP()
        {
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            //IpAddress agent = new IpAddress("172.20.10.4");
            IpAddress agent = new IpAddress(ip_address);

            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add("1.3.6.1.2.1.25.2.2.0"); //RAM

            String core1;

            double total;


            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);


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
                    // Console.WriteLine("Ram usage is  ({0}) ({1}): {2}",
                    //  result.Pdu.VbList[0].Oid.ToString(),
                    //  SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type),
                    //result.Pdu.VbList[0].Value.ToString());



                    core1 = result.Pdu.VbList[0].Value.ToString();

                    total = Convert.ToDouble(core1);
                    // Console.WriteLine(("\n Total Ram usage is ") + (total / 100000.0) + ("%"));
                    Console.WriteLine(("\n Total Ram usage is ") + total + ("%"));

                    double ratio = (total / 100000.0);
                    Ratio_ram_size = ratio.ToString();
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }
        }



        public void Processors_details_task_manager()
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead Administrator
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
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


                    //add_to_list_P_basem(Address, queryObj["Name"].ToString(), queryObj["PercentProcessorTime"] + " %",
                    // queryObj["HandleCount"].ToString(), queryObj["ThreadCount"].ToString(), queryObj["WorkingSet"].ToString() + " MB"
                    // , queryObj["ElapsedTime"] + " s");

                    string[] info_task = new string[] { ip_address, queryObj["Name"].ToString(), queryObj["PercentProcessorTime"] + "%"
                        , queryObj["HandleCount"].ToString() ,queryObj["ThreadCount"].ToString(), queryObj["WorkingSet"].ToString() + " MB"
                    , queryObj["ElapsedTime"] + " s"};
                    Processors_details.Add(info_task); // store to List


                });
            }
            catch (ManagementException ex)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + ex.Message);
                //MessageBox.Show(ex.Message, "wmi_cpu error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //complete #todo




    }//class OS_Monitoring


    class Firewall_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {
        public string port = "The information is not available";
        public string port_name = "The information is not available";

        public string port_state = "The information is not available";


        public List<string[]> MSFT_firewall_list = new List<string[]>();

        public Firewall_Monitoring(string ip)
        {
            ip_address = ip;

        }
        public Firewall_Monitoring(string ip, string user, string pass)
        {
            ip_address = ip;
            user_name = user;
            pass_word = pass;
        }
        public void check_ports()
        {
            //https://en.wikipedia.org/wiki/List_of_TCP_and_UDP_port_numbers
            check_TCP_port("Connection to Web (HTTP)", "80");
            check_TCP_port("Connection to Mail (SMTP) for routing between mail servers", "25");
            check_TCP_port("Connection to Mail (POP3)", "110");
            check_TCP_port("Connection to DNS", "53");
            check_TCP_port("Connection to (FTP) data transfer", "20");
            check_TCP_port("Connection to (FTP) data control", "21");

        }
        public void check_TCP_port(string name_port, string port)
        {
            try
            {
                TcpClient tcp = new TcpClient();
                this.port = port;
                this.port_name = name_port;
                tcp.Connect(ip_address, Convert.ToInt16(port));
                port_state = "Online";

            }
            catch (Exception ex)
            {
                port_state = "Offline, " + ex.Message;
            }
        }

        public List<string[]> Check_MSFT_firewall()
        {
            try
            {
                // Specify Windows Storage Management API namespace.
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = user_name;
                options.Password = pass_word;
                var scope = new ManagementScope(@"\\" + ip_address + "\\root\\StandardCimv2", options);
                scope.Connect();

                var searcher = new ManagementObjectSearcher("SELECT * FROM MSFT_NetFirewallRule");
                searcher.Scope = scope;

                foreach (var filrwall_MSFT in searcher.Get())
                {
                    //Our group used a tool to find out most of the elements in the server by wbemtest in windows + R
                    string ElementName = filrwall_MSFT["ElementName"].ToString();
                    string DisplayName = filrwall_MSFT["DisplayName"].ToString();
                    string Status = filrwall_MSFT["Status"].ToString();

                    string[] info_wmi = new string[] { ip_address, ElementName, DisplayName, Status };
                    MSFT_firewall_list.Add(info_wmi); // store to List

                }
                return MSFT_firewall_list;
            }
            catch (Exception ex)
            {
                alert = ex.Message + " from " + "Check_MSFT_firewall";
                return MSFT_firewall_list;
            }
        }


    }//Firewall_Monitoring


    class Database_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {
        public List<string[]> performance_IO_DB_list = new List<string[]>();
        public List<string[]> Users_DB_list = new List<string[]>();
        public string Table = "";
        public string User_name_DB = "";
        public string Pass_word_DB = "";
        public string Connection = "Unavailable";
        public Database_Monitoring(string ip_address, string user_name, string pass_word, string user_name_DB, string pass_word_DB, string table, string name_in_database, string dashboard)
        {
            base.ip_address = ip_address;
            base.user_name = user_name;
            base.pass_word = pass_word;
            base.name_in_database = name_in_database;
            this.User_name_DB = user_name_DB;
            this.Pass_word_DB = pass_word_DB;
            this.Table = table;
        }
        public Database_Monitoring(string ip_address, string user_name, string pass_word, string table)
        {
            base.ip_address = ip_address;
            this.User_name_DB = user_name;
            this.Pass_word_DB = pass_word;
            this.Table = table;
            read_data_base_MySQL_performance_io_summary();
            read_data_base_MySQL_performance_accounts();
        }
        public void check_alert_DB(string custom)
        {
            if (custom.Equals("Dashboard"))
            {
                read_data_base_MySQL_performance_accounts();
               // get_RAM_WMI();
            }
            //  Timer_to_polling(int.Parse(Cpu_usage));

            //        public void Timer_to_polling_All(bool Availability, int CPU_usage, int RAM_usage, int Traffic)

            //todo tarafic
           // Timer_to_polling_All(int.Parse(Cpu_usage), int.Parse(Ratio_ram_size), 0, uptime_WMI);

         //   Timer_to_polling_All(int.Parse(Cpu_usage), int.Parse(Ratio_ram_size), 0, uptime_WMI);

        }
        public void read_data_base_MySQL_performance_io_summary()
        {
            //configure database connection
            string name_data_base = "performance_schema";
            string connectionString = "datasource=" + ip_address + ";port=3306;username=" + User_name_DB + ";password=" + Pass_word_DB + ";database=" + name_data_base + "; CharSet=utf8;";  
            // Query
            string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = '" + Table + "'";
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
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
                    string[] info_database = new string[] {ip_address,Table,"Available", COUNT_STAR, COUNT_FETCH, AVG_TIMER_WAIT, AVG_TIMER_WRITE, AVG_TIMER_READ, AVG_TIMER_FETCH, AVG_TIMER_INSERT };
                    performance_IO_DB_list.Add(info_database); // store to List
                    Connection = "Available";
                }//while
            }//try
            catch (Exception ex)
            {
                alert = ex.Message;
                Connection = "Unavailable , " + ex.Message;
                string[] info_database = new string[] { ip_address, Table, Connection };
                performance_IO_DB_list.Add(info_database); // store to List
            }//catch
        }//read read_data_base_MySQL_performance_io_waits_summary

        public void read_data_base_MySQL_performance_accounts()
        {
            //configure database connection
            string name_data_base = "performance_schema";
            string connectionString = "datasource=" + ip_address + ";port=3306;username=" + User_name_DB + ";password=" + Pass_word_DB + ";database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8   
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
                    string[] users_info = new string[] { ip_address, USER, HOST, CURRENT_CONNECTIONS, TOTAL_CONNECTIONS };
                    Users_DB_list.Add(users_info);// store to List
                }//while
            }//try
            catch (Exception ex)
            {
                string[] users_info = new string[] { ip_address, name_data_base, ex.Message };
                alert = ex.Message + " From " + "read_data_base_MySQL_performance_io_waits_summary";
                Users_DB_list.Add(users_info);// store to List
                Connection = "Unavailable , " + ex.Message;

            }//catch
        }//read read_data_base_MySQL_performance_io_waits_summary



    }

    class Application_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {


        //
        public string SMTP_status = "n/a";
        public string FTP_status = "n/a";
        public string SMTP_Connection = "n/a";
        public string FTP_Connection = "n/a";


        public Application_Monitoring(string ip_address, string user_name, string pass_word, string name_in_database)
        {
            base.ip_address = ip_address;
            base.user_name = user_name;
            base.pass_word = pass_word;
            base.name_in_database = name_in_database;


            check_SMTP();
            check_FTF();
        }


        public void check_SMTP()
        {

            try
            {
                using (var client = new TcpClient())
                {
                    var server = "smtp.gmail.com";
                    //      var server = "smtp.ahmed_ib.com";//JUST FOR TEST

                    var port = 465;
                    client.Connect(server, port);
                    // As GMail requires SSL we should use SslStream
                    // If your SMTP server doesn't support SSL you can
                    // work directly with the underlying stream
                    using (var stream = client.GetStream())
                    using (var sslStream = new SslStream(stream))
                    {
                        sslStream.AuthenticateAsClient(server);
                        using (var writer = new StreamWriter(sslStream))
                        using (var reader = new StreamReader(sslStream))
                        {
                            writer.WriteLine("EHLO " + server);
                            writer.Flush();
                            //  Console.WriteLine(reader.ReadLine());

                            SMTP_status = "EHLO " + server;
                            SMTP_Connection = "Available";
                            //     App_listView.Items.Add(new ListViewItem(new String[] { ip_address, "SMTP", "Available", reader.ReadLine() }));
                            //MessageBox.Show(reader.ReadLine());
                            // GMail responds with: 220 mx.google.com ESMTP
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "check_smtp Form App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    App_listView.Items.Add(new ListViewItem(new String[] { ip_address, "SMTP", "Unavailable", ex.Message }));
         //       SMTP_Connection = "Unvailable";
                alert = ex.Message + " From check_SMTP";
            }
        }

        public void check_FTF()
        {
            try
            {
                var dt = DateTime.Now;
                string directory = dt.ToString("MM-dd-yyyy-h-mm-tt");
                WebRequest request = WebRequest.Create("ftp://" + ip_address + "/" + directory);

                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(user_name, pass_word);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                    FTP_Connection = "Available FTP";//for debug
                    FTP_status = resp.StatusCode.ToString();
                }//using
            }//try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//for debug
                alert = ex.Message + " From check_FTF";
                FTP_Connection = "Unvailable";
            }//cactch
        }//check_FTF

    }//

    //#TODO edit name of that
    class Unavailable_Devices : Monitoring_GP6_M_A_2021
    {


        public Unavailable_Devices(string ip_address, string name_in_database, string user_name, string pass_word)
        {
            base.ip_address = ip_address;
            base.alert = "Unavailable";
            base.name_in_database = name_in_database;

            base.user_name = user_name;
            base.pass_word = pass_word;

        }


    }


    class Sharepoint_Monitoring
    {

        //  public string siteCollUrl = "https://taibahuniv.sharepoint.com/_layouts/15/sharepoint.aspx";

        public string siteCollUrl = "https://taibahuniv.sharepoint.com/sites/GP6_Site/";

        public string userName = "mohammad_y_ammar@taibahu.edu.sa";
        public string password = "----";


        public Sharepoint_Monitoring()
        {
            //ConnectToSharePointOnline();
            //ConnectToSharePointOnline();

        }
        //https://global-sharepoint.com/sharepoint-online/how-to-authenticate-to-sharepoint-online-using-c-coding/

        //Program.ConnectToSharePointOnline("https:////taibahuniv.sharepoint.com//sites//GP6_Site//", "mohammad_y_ammar@taibahu.edu.sa", "");

        //https://github.com/pnp/PnP-Sites-Core/blob/master/Core/SAML%20authentication.md
        public void test2()
        {
         //   string samlSite = "https://saml.set1.bertonline.info/sites/bert";

            string samlSite = "https://taibahuniv.sharepoint.com/sites/GP6_Site";

            OfficeDevPnP.Core.AuthenticationManager am = new OfficeDevPnP.Core.AuthenticationManager();
            //   ClientContext ctx = am.GetADFSUserNameMixedAuthenticatedContext(samlSite, "administrator", "pwd", "domain", "sts.set1.bertonline.info", "urn:sharepoint:saml");

            //GP6: Security Token Service (STS).
            ClientContext ctx = am.GetADFSUserNameMixedAuthenticatedContext(samlSite, "mohammad_y_ammar@taibahu.edu.sa", "---", "taibahuniv.sharepoint.com", "sts.taibahuniv", "urn:sharepoint:taibahuniv");


            FieldCollection fields = ctx.Web.Fields;
            IEnumerable<Field> results = ctx.LoadQuery<Field>(fields.Where(item => item.Hidden != false));
            ctx.ExecuteQuery();

            foreach (Field field in results)
            {
                Console.WriteLine("{0} - {1}", field.Id, field.InternalName);
            }
        }

        public string test_token()
        {
            UsernameMixed adfsTokenProvider = new UsernameMixed();
            Uri userNameMixed = new Uri( "https://taibahuniv.sharepoint.com/sites/GP6_Site");

            string relyingPartyIdentifier = null;
            //     var token = adfsTokenProvider.RequestToken(userName, password, userNameMixed, relyingPartyIdentifier);
            var token = RequestToken(userName, password, userNameMixed, relyingPartyIdentifier);
            return token.ToString();
        }
        private GenericXmlSecurityToken RequestToken(string userName, string passWord, Uri userNameMixed, string relyingPartyIdentifier)
        {
            var factory = new WSTrustChannelFactory(new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential), new EndpointAddress(userNameMixed));

            factory.TrustVersion = TrustVersion.WSTrust13;
            // Hookup the user and password 
            factory.Credentials.UserName.UserName = userName;
            factory.Credentials.UserName.Password = passWord;

            var requestSecurityToken = new RequestSecurityToken
            {
                RequestType = RequestTypes.Issue,
                AppliesTo = new EndpointReference(relyingPartyIdentifier),
                KeyType = KeyTypes.Bearer
            };

            IWSTrustChannelContract channel = factory.CreateChannel();
            GenericXmlSecurityToken genericToken = channel.Issue(requestSecurityToken) as GenericXmlSecurityToken;

            return genericToken;
        }


        public void ConnectToSharePointOnline()
        {

            //Namespace: It belongs to Microsoft.SharePoint.Client
            ClientContext ctx = new ClientContext(siteCollUrl);

            // Namespace: It belongs to System.Security
            SecureString secureString = new SecureString();
            password.ToList().ForEach(secureString.AppendChar);

            // Namespace: It belongs to Microsoft.SharePoint.Client
            ctx.Credentials = new SharePointOnlineCredentials(userName, secureString);

            // Namespace: It belongs to Microsoft.SharePoint.Client
            Site mySite = ctx.Site;

            ctx.Load(mySite);
            ctx.ExecuteQuery();

            Console.WriteLine(mySite.Url.ToString());
            MessageBox.Show(mySite.Url.ToString(), "ConnectToSharePointOnline", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //https://stackoverflow.com/questions/10651304/authenticate-user-by-adfs-active-directory-federation-service
        public void check_new()
        {
            //WSTrustChannelFactory adfsfactory = new WSTrustChannelFactory(new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
            //                StsEndpoint);

            //adfsfactory.TrustVersion = TrustVersion.WSTrust13;

            //// Username and Password here...
            //factory.Credentials.UserName.UserName = "domain\username";
            //factory.Credentials.UserName.Password = "password";

            //IWSTrustChannelContract channel = adfsfactory.CreateChannel();

            //// request the token
            //SecurityToken token = channel.Issue(rst);



        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //https://www.codesharepoint.com/sharepoint-tutorial/connect-to-sharepoint-online-on-premise-and-extranet-using-csom
        public void AuthenticateUser(Uri TargetSiteUrl, string Environmentvalue, string username, string password)
        {
            //MYA
            //Uri uri_new Uri(SiteURL)
            try
            {
                // Based on the environmentvalue provided it execute the function.
                if (string.Compare(Environmentvalue, "onpremises", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = LogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
                else if (string.Compare(Environmentvalue, "o365", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = O365LogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
                else if (string.Compare(Environmentvalue, "extranet", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = ExtranetLogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
            }
            catch (Exception ex)
            {
                // log error
               MessageBox.Show(ex.Message, "AuthenticateUser", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private static ClientContext LogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    SecureString securestring = new SecureString();
                    password.ToCharArray().ToList().ForEach(s => securestring.AppendChar(s));
                    clientContext.Credentials = new System.Net.NetworkCredential(userName, securestring);
                    clientContext.ExecuteQuery();
                }
                else
                {
                    clientContext.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    clientContext.ExecuteQuery();
                }

                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }

            return ctx;
        }

        private static ClientContext O365LogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx = null;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    SecureString securestring = new SecureString();
                    password.ToCharArray().ToList().ForEach(s => securestring.AppendChar(s));
                    clientContext.Credentials = new SharePointOnlineCredentials(userName, securestring);
                    clientContext.ExecuteQuery();
                }
                else
                {
                    clientContext.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    clientContext.ExecuteQuery();
                }
                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }
            return ctx;
        }

        private static ClientContext ExtranetLogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName))
                {
                    NetworkCredential networkCredential = new NetworkCredential(userName, password);
                    CredentialCache cc = new CredentialCache();
                    cc.Add(url, "NTLM", networkCredential);
                    clientContext.Credentials = cc;
                    clientContext.ExecuteQuery();
                }
                else
                {
                    CredentialCache cc = new CredentialCache();
                    cc.Add(url, "NTLM", System.Net.CredentialCache.DefaultNetworkCredentials);
                    clientContext.Credentials = cc;
                    clientContext.ExecuteQuery();
                }
                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }
            return ctx;
        }
    }//share point

    class Cloud_Monitoring : Monitoring_GP6_M_A_2021  //// derived class (child)
    {

        //public string COUNT_STAR = "n/a";
        //public string COUNT_FETCH = "n/a";
        //public string AVG_TIMER_WAIT = "n/a";
        //public string AVG_TIMER_WRITE = "n/a";
        //public string AVG_TIMER_READ = "n/a";
        //public string AVG_TIMER_FETCH = "n/a";
        //public string AVG_TIMER_INSERT = "n/a";

        public List<string[]> performance_IO_Cloud_list = new List<string[]>();


        //
        //public string USER = "n/a";
        //public string HOST = "n/a";
        //public string CURRENT_CONNECTIONS = "n/a";
        //public string TOTAL_CONNECTIONS = "n/a";
        public List<string[]> Users_Azure_list = new List<string[]>();


        //
        public string Table = "";

        public string User_name_cloud = "";
        public string Pass_word_cloud = "";
        public string Connection = "";


        public Cloud_Monitoring(string name_of_server, string user_name, string pass_word, string table)
        {
            base.ip_address = name_of_server;
            this.User_name_cloud = user_name;
            this.Pass_word_cloud = pass_word;
            this.Table = table;

            read_Azure_IO_summary();


            read_Azure_performance_accounts();

        }

        public void read_Azure_IO_summary()
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder
                {

                    Server = ip_address,
                    Port = 3306,
                    Database = "performance_schema",
                    UserID = User_name_cloud,
                    Password = Pass_word_cloud,
                    SslMode = MySqlSslMode.Preferred,

                    //Server = "studenttestsql.mysql.database.azure.com",
                    //Port = 3306,
                    //Database = "studenttestsql",
                    //Database = "performance_schema",

                    //UserID = "studenttest@studenttestsql",
                    //Password = "ST@172839",
                    //SslMode = MySqlSslMode.Preferred,
                };

                using (var conn = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("Opening connection");
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        string query = "SELECT* FROM `table_io_waits_summary_by_table` WHERE `OBJECT_NAME` = '" + Table + "'";
                        command.CommandText = query;
                        Connection = "Available";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string COUNT_STAR = reader["COUNT_STAR"].ToString();
                                string COUNT_FETCH = reader["COUNT_FETCH"].ToString();
                                string AVG_TIMER_WAIT = reader["AVG_TIMER_WAIT"].ToString();
                                string AVG_TIMER_WRITE = reader["AVG_TIMER_WRITE"].ToString();
                                string AVG_TIMER_READ = reader["AVG_TIMER_READ"].ToString();
                                string AVG_TIMER_FETCH = reader["AVG_TIMER_FETCH"].ToString();
                                string AVG_TIMER_INSERT = reader["AVG_TIMER_INSERT"].ToString();
                                string[] info_azure = new string[] {ip_address,Table , COUNT_STAR, COUNT_FETCH, AVG_TIMER_WAIT, AVG_TIMER_WRITE, AVG_TIMER_READ, AVG_TIMER_FETCH, AVG_TIMER_INSERT };
                                performance_IO_Cloud_list.Add(info_azure); // store to List
                            }
                        }
                    }
                    Console.WriteLine("Closing connection");
                }
            }
            catch (Exception ex)
            {
                Connection = "Unavailable " + ex.Message;
                alert = ex.Message + " From read_Azure_IO_waits_summary_by_table";
            }

        }

        public void read_Azure_performance_accounts()
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = ip_address,
                    Port = 3306,
                    Database = "performance_schema",
                    UserID = User_name_cloud,
                    Password = Pass_word_cloud,
                    SslMode = MySqlSslMode.Preferred,
                };
                using (var conn = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("Opening connection");
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        Connection = "Aavailable ";
                        string query = "SELECT* FROM `accounts`";
                        command.CommandText = query;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string USER = reader["USER"].ToString();
                                string HOST = reader["HOST"].ToString();
                                string CURRENT_CONNECTIONS = reader["CURRENT_CONNECTIONS"].ToString();
                                string TOTAL_CONNECTIONS = reader["TOTAL_CONNECTIONS"].ToString();
                                string[] users_info = new string[] { ip_address, USER, HOST, CURRENT_CONNECTIONS, TOTAL_CONNECTIONS };
                                Users_Azure_list.Add(users_info);// store to List
                            }
                        }
                    }
                    Console.WriteLine("Closing connection, read_Azure_performance_accounts");//foe debug
                }
            }//try
            catch (Exception ex)
            {
                Connection = "Unavailable " + ex.Message;
                alert = ex.Message + " From read_Azure_performance_accounts";
            }
        }//read_Azure_performance_accounts
    }//namespace Project_GP6_Dashboard
}

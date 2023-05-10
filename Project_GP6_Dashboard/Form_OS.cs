using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace Project_GP6_Dashboard

//public partial class Form_OS : Form

//19-3-2021: Add count CPU


using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

using SnmpSharpNet;
//14/3/2021 edit from
//Author: Zachary Reese
//eID: 900893107
//https://github.com/zacharyreese/NetworkScanner




using System.Reflection;

namespace Project_GP6_Dashboard
{

    public partial class Form_OS : Form //, Monitoring_GP6_M_A_2021
    //   public partial class Form_OS : Monitoring_GP6_M_A_2021
    {

        //  delegate void MyDelegate(string[] array);

        delegate void MyDelegate(string[] array);

        public Form_OS()
        {
            InitializeComponent();
            //Initialize form
            //lblStatus.ForeColor = System.Drawing.Color.Red;
           // lblStatus.Text = "Idle";
           // Control.CheckForIllegalCrossThreadCalls = false;

           // progressBar1. = true;

        }

        Thread myThread = null;

        string wmi_info = "n/a";
        string cpu_usage = "n/a";
        string Thread_Count = "n/a";


        int Handle = 0;


        PingReply reply_scan;

        //old:




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


        //process 








        public void test_Parallel()
        {
            Console.WriteLine("C# For Loop");
            int number = 10;
            for (int count = 0; count < number; count++)
            {
                //Thread.CurrentThread.ManagedThreadId returns an integer that 
                //represents a unique identifier for the current managed thread.
                Console.WriteLine($"value of count = {count}, thread = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine();
            Console.WriteLine("Parallel For Loop");
            Parallel.For(0, number, count =>
            {
                Console.WriteLine($"value of count = {count}, thread = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                        //Sleep the loop for 10 miliseconds
                        System.Threading.Thread.Sleep(10);
            });
            //Console.ReadLine();
        }



        //new MYA | 15/3/2021 | not in old project
        public void scan_GP6(string ip_address, string username, string password)
        {
            try
            {

                //Split IP string into a 4 part array
                // string[] startIPString = start.Split('.');
                //  int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                //   string[] endIPString = end.Split('.');
                //    int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                Ping myPing;
                //  PingReply reply;

                IPAddress addr;
                IPHostEntry host;

                //Progress bar
                progressBar1.Maximum = 1;
                progressBar1.Value = 0;
                //     listVAddr.Items.Clear();  //button to clear !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                ////Loops through the IP range, maxing out at 255
                //for (int i = startIP[2]; i <= endIP[2]; i++)
                //{ //3rd octet loop
                //    for (int y = startIP[3]; y <= 255; y++)
                //    { //4th octet loop
                //        string ipAddress = startIP[0] + "." + startIP[1] + "." + i + "." + y; //Convert IP array back into a string
                //        string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                //        //If current IP matches final IP in range, break
                //        if (ipAddress == endIPAddress)
                //        {
                //            break;
                //        }

                myPing = new Ping();
                try
                {
                    reply_scan = myPing.Send(ip_address, 500); //Ping IP address with 500ms timeout
                }
                catch (Exception ex)
                {
                    //  break;

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                //lblStatus.Text = "Scanning: " + ip_address;

                //Log pinged IP address in listview
                //Grabs DNS information to obtain system info
                if (reply_scan.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse(ip_address);
                        host = Dns.GetHostEntry(addr);


                        //    query_GP6(ip_address);
                        //   query_cpu("192.168.1.14");//error !

                        get_CPU_GP6(ip_address);
                        get_more_cpu_info_Win32_Processor(ip_address);
                        get_more_cpu_info_win32_thread(ip_address);
                        network_OS(ip_address, username, password);



                        // listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                        //MYA
                        //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                        //Thread qThread = new Thread(() => query(ipAddress));


                        //list view here


                        //wmi_info
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", host.HostName, cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                        count++;
                    }
                    catch
                    {

                        //  listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                        //MYA
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", "Could not retrieve", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings
                        count++;
                    }
                }

                // }
                else
                {
                    //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                    listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Down", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                }
                progressBar1.Value += 1; //Increase progress bar
                                         //    }

                //    startIP[3] = 1; //If 4th octet reaches 255, reset back to 1
                //  }

                //Re-enable buttons
                //  cmdScan.Enabled = true;
             //   //
                // txtIP.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Green;
                //lblStatus.Text = "Done!";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                //  cmdScan.Enabled = true;
               // //
                //txtIP.Enabled = true;
                //txtIP2.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Scanning stopped";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //    cmdScan.Enabled = true;
                ////
                //  txtIP.Enabled = true;
                //   txtIP2.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Invalid IP range";

            }
        }

        //https://stackoverflow.com/questions/9777661/returning-cpu-usage-in-wmi-using-c-sharp

        public void get_CPU_GP6(string Address)
        {


            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Password = "Abcd@1234"; // you may want to avoid plain text password and use SecurePassword property instead
                options.Username = "Administrator";
                //ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
                //scope.Connect();


                //ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");



                ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
                scope.Connect();

                //ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");

                //MYA after test

                // string query = "\"_Total\"";

                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor Where Name = '_Total'");
                //MessageBox.Show("hi 1");

                //Error from / !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111
                /*
                  SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                    ManagementObjectCollection logs = searcher.Get();
                    foreach (var log in logs)
                 * 
                 * */

                cpu_usage = "n/a";
                ManagementObjectSearcher cpus = new ManagementObjectSearcher(scope, wmicpus);
                foreach (ManagementObject cpu in cpus.Get())
                {
                    //    MessageBox.Show("hi 2");


                    //        uint cpu_usage = 100 - Convert.ToUInt32(mngObject["PercentIdleTime"]);

                    //MYA after test | 15/3/2021
                    //https://wutils.com/wmi/root/cimv2/win32_perfformatteddata_perfos_processor/

                    uint PercentProcessorTime = Convert.ToUInt32(cpu["PercentProcessorTime"]);



                    cpu_usage = PercentProcessorTime.ToString();

                    //MYA
                    break;
                    //test
                    //   MessageBox.Show(PercentProcessorTime.ToString());


                }
                //if (mngObjColl.Count > 0)
                //{
                //foreach (ManagementObject mngObject in mngObjColl)
                //{
                //    try
                //    {
                //        uint cpu_usage = 100 - Convert.ToUInt32(mngObject["PercentIdleTime"]);

                //        MessageBox.Show(cpu_usage.ToString());
                //        break;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);

                //        break;
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        public void get_CPU_Parallel(string Address, string username, string password)
        {


            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Username = username;
                options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead


                ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
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

                     add_to_chart_P_OS_CPU_WMI(Address, cpu_usage,"CPU");

                     MessageBox.Show(cpu_usage, "get_CPU_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //http://www.howcsharp.com/114/break-parallel-foreach-earlier.html
                    state.Break();


                 });


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "get_CPU_Parallel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //basem
        //public void getOSinfo(String Address)

        public void get_more_cpu_info_Win32_Processor(string Address)

        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            options.Password = "Abcd@1234"; // you may want to avoid plain text password and use SecurePassword property instead
            options.Username = "Administrator";
            ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
            scope.Connect();


            //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-thread

            ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Processor");

            ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);
            foreach (ManagementObject cpu in cpus.Get())
            {

                //MYA
                //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor

                //The number of threads per processor socket.
                //MessageBox.Show(cpu["ThreadCount"].ToString());
                Thread_Count = "n/a";
                Thread_Count = cpu["ThreadCount"].ToString();
                break;



                //  Console.WriteLine("total_" + cpu["DeviceId"] + " : " + cpu["LoadPercentage"] + "%");

                ////  MessageBox.Show("total_" + cpu["DeviceId"] + " : " + cpu["LoadPercentage"] + "%");

                //  //Console.WriteLine("Caption            : " + cpu["Caption"]);

                //  Console.WriteLine("maxspeed           : " + cpu["MaxClockSpeed"] + " GH ");
                //  Console.WriteLine("SystemName         : " + cpu["SystemName"]);
                //  Console.WriteLine("CurrentVoltage     : " + cpu["CurrentVoltage"] + " V");
                //  //label4.Text = cpu["LoadPercentage"].ToString() + "%";
                //  //cpu_usage = int.Parse(cpu["LoadPercentage"].ToString());


            }
        }

        public void get_more_cpu_info_Win32_Processor_Parallel(string Address)

        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            options.Password = "Abcd@1234"; // you may want to avoid plain text password and use SecurePassword property instead
            options.Username = "Administrator";
            ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
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
                Thread_Count = "n/a";
                Thread_Count = cpu["ThreadCount"].ToString();
                // break;



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
        public void get_more_cpu_info_win32_thread(string Address)

        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            options.Password = "Abcd@1234"; // you may want to avoid plain text password and use SecurePassword property instead
            options.Username = "Administrator";
            ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
            scope.Connect();


            //https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-thread


            ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Thread");

            //       MessageBox.Show("Win32_Thread");

            ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);
            foreach (ManagementObject cpu in cpus.Get())
            {
                //MYA idea 15/3/2021
                Handle = Handle + int.Parse(cpu["Handle"].ToString());

                //break;

            }
        }


        public void get_more_cpu_info_win32_thread_Parallel(string Address)

        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            options.Password = "Abcd@1234"; // you may want to avoid plain text password and use SecurePassword property instead
            options.Username = "Administrator";
            ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
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


                state.Break();

            });
        }

        //old
        //WQL query, Windows Management Instrumentation (WMI System Information)
        public void query(string host)
        {

            //string acc;
            //string os;
            //string board;
            //string biosVersion;
            string temp = null;

            //Find system information using Win32 classes
            //https://msdn.microsoft.com/en-us/ie/aa394084%28v=vs.94%29?f=255&MSPPError=-2147217396
            string[] searchClass = { "Win32_ComputerSystem", "Win32_OperatingSystem", "Win32_ComputerSystem", "Win32_ComputerSystem", "Win32_DesktopMonitor" }; //Class type
            string[] param = { "UserName", "Caption", "SystemType", "Domain", "Caption" }; //Parameter within class

          //  lblStatus.ForeColor = System.Drawing.Color.Green;

            //Iterate through Win32 classes and query system info
            for (int i = 0; i <= searchClass.Length - 1; i++)
            {
                //lblStatus.Text = "Getting information.";
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM " + searchClass[i]);
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        lblStatus.Text = "Getting information. .";

                        //Add system info to dialog box
                        temp += obj.GetPropertyValue(param[i]).ToString() + "\n";
                        if (i == searchClass.Length - 1)
                        {
                            lblStatus.Text = "Done!";
                            MessageBox.Show(temp, "Hostinfo: " + host, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        lblStatus.Text = "Getting information. . .";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not retrieve information \n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
            }
        }

        //WQL query, Windows Management Instrumentation (WMI System Information)
        public void query_GP6(string host)
        {

            //string acc;
            //string os;
            //string board;
            //string biosVersion;
            string temp = null;

            //Find system information using Win32 classes
            //https://msdn.microsoft.com/en-us/ie/aa394084%28v=vs.94%29?f=255&MSPPError=-2147217396
            string[] searchClass = { "Win32_ComputerSystem", "Win32_OperatingSystem", "Win32_ComputerSystem", "Win32_ComputerSystem", "Win32_DesktopMonitor" }; //Class type
            string[] param = { "UserName", "Caption", "SystemType", "Domain", "Caption" }; //Parameter within class

            lblStatus.ForeColor = System.Drawing.Color.Green;

            //Iterate through Win32 classes and query system info
            for (int i = 0; i <= searchClass.Length - 1; i++)
            {
                lblStatus.Text = "Getting information.";
                try
                {

                    //MYA | 15/3/2021
                    ConnectionOptions options = new ConnectionOptions();
                    options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                    options.EnablePrivileges = true;
                    options.Username = "Administrator";
                    options.Password = "Abcd@1234";

                    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM " + searchClass[i]);

                    //new MYA
                    ManagementScope scope = new ManagementScope("\\\\" + host + "\\root\\CIMV2", options);
                    scope.Connect();

                    ObjectQuery wmi_query = new WqlObjectQuery("SELECT *FROM " + searchClass[i]);

                    ManagementObjectSearcher wmi = new ManagementObjectSearcher(wmi_query);

                    //
                    // ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM " + searchClass[i]);
                    foreach (ManagementObject obj in wmi.Get())
                    {
                        lblStatus.Text = "Getting information. .";

                        //Add system info to dialog box
                        temp += obj.GetPropertyValue(param[i]).ToString() + "\n";
                        if (i == searchClass.Length - 1)
                        {
                            lblStatus.Text = "Done!";
                            //    MessageBox.Show(temp, "Hostinfo: " + host, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            wmi_info = temp;
                            break;
                        }
                        lblStatus.Text = "Getting information. . .";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not retrieve information \n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
            }
        }

        //Send system commands (shutdown) to computers if you have admin access
        public void controlSys(string host, int flags)
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
             */

            /*
                   ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead   username "Administrator"
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
             * */

            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = "Administrator";
                options.Password = "Abcd@1234";

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

        //Scan button | old 

        //private void cmdScan_Click(object sender, EventArgs e)
        //{
        //    //Catch empty IP addresses
        //    if (txtIP.Text == string.Empty)
        //    {
        //        //MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        lblStatus.ForeColor = System.Drawing.Color.Red;
        //        lblStatus.Text = "No IP address entered.";
        //    }
        //    else
        //    {
        //        //Create new thread for pinging
        //        //myThread = new Thread(() => scan(txtIP.Text));
        //        myThread = new Thread(() => scan2(txtIP.Text, txtIP2.Text));
        //        myThread.Start();

        //        if (myThread.IsAlive == true)
        //        {
        //            cmdStop.Enabled = true;
        //            cmdScan.Enabled = false;
        //            txtIP.Enabled = false;
        //            txtIP2.Enabled = false;
        //        }
        //    }      
        //}

        //Scan button | new 



        //Stop button, kills thread and re-enables buttons
        private void cmdStop_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            //  cmdScan.Enabled = true;
            //
            //txtIP.Enabled = true;
            //txtIP2.Enabled = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Scanning stopped";
        }

        //Context menu for information buttons
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void listVAddr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listVAddr.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    conMenuStripIP.Show(Cursor.Position);
                }
            }
        }

        //Open network folder to see shared folders
        private void openNetworkFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"\\" + listVAddr.SelectedItems[0].Text.ToString()); //Open explorer with host IP
        }

        //Query machine for system information
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = listVAddr.SelectedItems[0].Text.ToString();
            Thread qThread = new Thread(() => query(host));
            qThread.Start();
        }

        //Send shutdown command using controlSys method
        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = listVAddr.SelectedItems[0].Text.ToString();
            controlSys(host, 5);
        }

        //Send reboot command
        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = listVAddr.SelectedItems[0].Text.ToString();
            controlSys(host, 6);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GetDiskspace("192.168.1.90", "Administrator", "Abcd@1234");


            //check_RAM();
            //   MessageBox.Show("check_RAM complete");


            //Console.WriteLine("The drivers in the system are\n ");
            //drives("192.168.1.13");
            //Console.WriteLine("\n The total space in the system\n  ");
            //total_space("192.168.1.13");
            //Console.WriteLine("\nThe used space in the system\n  ");
            //used_space("192.168.1.13");

          // snmp_waik("192.168.1.15");
        }
        //From Ali
        public void snmp_waik(string ip_address)
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
                IpAddress agent = new IpAddress(ip_address);
                // Construct target
                UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
                // Define Oid that is the root of the MIB
                //  tree you wish to retrieve
             //   Oid rootOid = new Oid(".1.3.6.1.4.1.2021.11.9.0"); // ifDescr

                Oid rootOid = new Oid(".1.3.6.1.2.1.1.3.0"); // ifDescr




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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    }

        public void RAM_SNMP(string ip_address)
        {
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress(ip_address);
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(".1.3.6.1.4.1.2021.4.11.0"); //Ram 

            //uptime 
            // .1.3.6.1.2.1.1.3.0
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
                    Console.WriteLine("Ram usage is  ({0}) ({1}): {2}",
                     result.Pdu.VbList[0].Oid.ToString(),
                     SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type),
                   result.Pdu.VbList[0].Value.ToString());



                    //core1 = result.Pdu.VbList[0].Value.ToString();

                    //total = Convert.ToDouble(core1);
                    //Console.WriteLine(("\n Total Ram usage is ") + (total / 100000.0) + ("%"));
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }


        }
        static void drives(string ip_address)
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
            // IpAddress agent = new IpAddress("192.168.1.101");
            IpAddress agent = new IpAddress(ip_address);

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Define Oid that is the root of the MIB
            //  tree you wish to retrieve
            Oid rootOid = new Oid("1.3.6.1.2.1.25.2.3.1.3"); // ifDescr
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


        static void total_space(string ip_address)
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
            // IpAddress agent = new IpAddress("192.168.1.101");
            IpAddress agent = new IpAddress(ip_address);

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Define Oid that is the root of the MIB
            //  tree you wish to retrieve
            Oid rootOid = new Oid("1.3.6.1.2.1.25.2.3.1.5"); // ifDescr
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
        static void used_space(string ip_address)
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
            //  IpAddress agent = new IpAddress("192.168.1.101");
              IpAddress agent = new IpAddress(ip_address);

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Define Oid that is the root of the MIB
            //  tree you wish to retrieve
            Oid rootOid = new Oid("1.3.6.1.2.1.25.2.3.1.6"); // ifDescr
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


        //End from Ali
        private void listVAddr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gP1GP6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mohammad & Basem" + "Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void conMenuStripIP_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtIP2_TextChanged(object sender, EventArgs e)
        {

        }




        //form group gp1 with edit
        public void query_cpu(string Address)
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;


                // options.EnablePrivileges = true;
                options.Username = "Administrator";
                options.Password = "Abcd@1234";


                //options.Username = username;
                //options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead Administrator


                ManagementScope scope = new ManagementScope("\\\\" + Address + "\\root\\cimv2", options);
                scope.Connect();

                // ManagementObjectSearcher searcher =
                //    new ManagementObjectSearcher("root\\CIMV2",
                //   "SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");

                ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Processor");

                ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);
                foreach (ManagementObject cpu in cpus.Get())
                {
                    //Console.WriteLine("total_" + cpu["DeviceId"] + " : " + cpu["LoadPercentage"] + "%");
                    ////Console.WriteLine("Caption            : " + cpu["Caption"]);

                    //Console.WriteLine("maxspeed           : " + cpu["MaxClockSpeed"] + " GH ");
                    //Console.WriteLine("SystemName         : " + cpu["SystemName"]);
                    //Console.WriteLine("CurrentVoltage     : " + cpu["CurrentVoltage"] + " V");
                    //label4.Text = cpu["LoadPercentage"].ToString() + "%";
                    //cpu_usage = int.Parse(cpu["LoadPercentage"].ToString());


                    //label6.Text = cpu["MaxClockSpeed"] + " GH ";
                    //label8.Text = cpu["SystemName"].ToString();
                    //label10.Text = cpu["CurrentVoltage"] + " V";
                    //// label12.Text = cpu["TotalVirtualMemorySize"].ToString() + " KB";
                    //label13.Text = cpu["TotalVisibleMemorySize"].ToString() + " KB";

                    cpu_usage = "n/a";
                    cpu_usage = cpu["LoadPercentage"].ToString();
                    MessageBox.Show(cpu["LoadPercentage"].ToString());

                }



            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }

        }




        //From basem 20/3/2021 with edit

        public void network_OS(string ip_address, string user_name, string password)
        {

            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead   username "Administrator"
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();


                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Console.WriteLine("net_BytesReceivedPerSec     : {0}", m["BytesReceivedPerSec"]);
                    Console.WriteLine("net_BytesSentPerSec : {0}", m["BytesSentPerSec"]);
                    Console.WriteLine("net_BytesTotalPerSec  : {0}", m["BytesTotalPerSec"]);
                    Console.WriteLine("net_CurrentBandwidth : {0}", m["CurrentBandwidth"]);
                    Console.WriteLine(" net1     : {0}", m["Name"]);


                    //     MessageBox.Show("network");


                    network_listView.Items.Add(new ListViewItem(new String[] { ip_address,m["Name"].ToString(),  m["BytesReceivedPerSec"].ToString(),
                        m["BytesSentPerSec"].ToString() , m["BytesTotalPerSec"].ToString(),
                   m["CurrentBandwidth"].ToString() })); ; //Log successful pings

                    //MessageBox.Show("BytesReceivedPerSec " + m["BytesReceivedPerSec"] +
                    //    "net_BytesSentPerSec " + m["BytesSentPerSec"]

                    //    ,
                    //    "Neteork", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Console.WriteLine("net2      : {0}", m["Timestamp_Sys100NS"]);
                    //Console.WriteLine("Status : {0}", m["Status"]);


                    //label4.Text = m["Name"].ToString();
                    //label5.Text = (m["CurrentBandwidth"].ToString()) + "bps";
                    //liveChart();

                    //solidGauge1.Value = double.Parse(m["BytesReceivedPerSec"].ToString()) * 0.001;
                    //solidGauge2.Value = double.Parse(m["BytesSentPerSec"].ToString()) * 0.001;
                    //solidGauge3.Value = double.Parse(m["BytesTotalPerSec"].ToString()) * 0.001;

                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //25/3/2021

        //method to list P !!!!!!!!!!!!!!!!!
        public void network_OS_Parallel(string ip_address, string user_name, string password)
        {

            try
            {

                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;
                options.Password = password; // you may want to avoid plain text password and use SecurePassword property instead   username "Administrator"
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
                    Console.WriteLine("net_BytesReceivedPerSec     : {0}", m["BytesReceivedPerSec"]);
                    Console.WriteLine("net_BytesSentPerSec : {0}", m["BytesSentPerSec"]);
                    Console.WriteLine("net_BytesTotalPerSec  : {0}", m["BytesTotalPerSec"]);
                    Console.WriteLine("net_CurrentBandwidth : {0}", m["CurrentBandwidth"]);
                    Console.WriteLine(" net1     : {0}", m["Name"]);


                    network_listView.Items.Add(new ListViewItem(new String[] { ip_address,m["Name"].ToString(),  m["BytesReceivedPerSec"].ToString(),
                        m["BytesSentPerSec"].ToString() , m["BytesTotalPerSec"].ToString(),
                   m["CurrentBandwidth"].ToString() })); ; //Log successful pings

                    //MessageBox.Show("BytesReceivedPerSec " + m["BytesReceivedPerSec"] +
                    //    "net_BytesSentPerSec " + m["BytesSentPerSec"]

                    //    ,
                    //    "Neteork", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //Console.WriteLine("net2      : {0}", m["Timestamp_Sys100NS"]);
                    //Console.WriteLine("Status : {0}", m["Status"]);


                    //label4.Text = m["Name"].ToString();
                    //label5.Text = (m["CurrentBandwidth"].ToString()) + "bps";
                    //liveChart();

                    //solidGauge1.Value = double.Parse(m["BytesReceivedPerSec"].ToString()) * 0.001;
                    //solidGauge2.Value = double.Parse(m["BytesSentPerSec"].ToString()) * 0.001;
                    //solidGauge3.Value = double.Parse(m["BytesTotalPerSec"].ToString()) * 0.001;


                });

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void button_scan_Click(object sender, EventArgs e)
        {
            //Catch empty IP addresses
            if (IP_textBox.Text == string.Empty)
            {
                ////MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No IP address entered.";
            }
            else
            {
                //Create new thread for ????????????????????????????????



                // myThread = new Thread(() => scan_GP6(IP_textBox.Text));

                scan_full_OS(IP_textBox.Text);

                // myThread.Start();

                //if (myThread.IsAlive == true)
                //{
                //    cmdStop.Enabled = true;
                //    cmdScan.Enabled = false;
                //    txtIP.Enabled = false;
                //    txtIP2.Enabled = false;
                //}
            }
        }

        //new MYA | 15/3/2021 | not in old project
        public void scan_full_OS(string ip_address)
        {
            try
            {

                //Split IP string into a 4 part array
                // string[] startIPString = start.Split('.');
                //  int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                //   string[] endIPString = end.Split('.');
                //    int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                Ping myPing;
                //  PingReply reply;

                IPAddress addr;
                IPHostEntry host;

                //Progress bar
                progressBar1.Maximum = 1;
                progressBar1.Value = 0;
                //     listVAddr.Items.Clear();  //button to clear !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                myPing = new Ping();
                try
                {
                    reply_scan = myPing.Send(ip_address, 500); //Ping IP address with 500ms timeout
                }
                catch (Exception ex)
                {
                    //  break;

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                lblStatus.Text = "Scanning: " + ip_address;

                //Log pinged IP address in listview
                //Grabs DNS information to obtain system info
                if (reply_scan.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse(ip_address);
                        host = Dns.GetHostEntry(addr);


                        //    query_GP6(ip_address);
                        //   query_cpu("192.168.1.14");//error !

                        get_CPU_GP6(ip_address);
                        get_more_cpu_info_Win32_Processor(ip_address);
                        get_more_cpu_info_win32_thread(ip_address);
                        network_OS(ip_address, "Administrator", "Abcd@1234"); // to P


                        // listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                        //MYA
                        //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                        //Thread qThread = new Thread(() => query(ipAddress));


                        //list view here


                        //wmi_info
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", host.HostName, cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                        count++;
                    }
                    catch
                    {

                        //  listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                        //MYA
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", "Could not retrieve", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings
                        count++;
                    }
                }

                // }
                else
                {
                    //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                    listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Down", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                }
                progressBar1.Value += 1; //Increase progress bar
                                         //    }

                //    startIP[3] = 1; //If 4th octet reaches 255, reset back to 1
                //  }

                //Re-enable buttons
                //cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Done!";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                // cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Scanning stopped";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //  cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid IP range";

            }
        }



        public void scan_full_OS_Parallel(string ip_address)
        {
            try
            {

                //Split IP string into a 4 part array
                // string[] startIPString = start.Split('.');
                //  int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                //   string[] endIPString = end.Split('.');
                //    int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                Ping myPing;
                //  PingReply reply;

                IPAddress addr;
                IPHostEntry host;

                //Progress bar
                progressBar1.Maximum = 1;
                progressBar1.Value = 0;
                //     listVAddr.Items.Clear();  //button to clear !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                myPing = new Ping();
                try
                {
                    reply_scan = myPing.Send(ip_address, 500); //Ping IP address with 500ms timeout
                }
                catch (Exception ex)
                {
                    //  break;

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                lblStatus.Text = "Scanning: " + ip_address;

                //Log pinged IP address in listview
                //Grabs DNS information to obtain system info
                if (reply_scan.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse(ip_address);
                        host = Dns.GetHostEntry(addr);



                        //get_CPU_GP6(ip_address);
                        //get_more_cpu_info_Win32_Processor(ip_address);
                        //get_more_cpu_info_win32_thread(ip_address);
                        //network_OS(ip_address, "Administrator", "Abcd@1234"); // to P


                        //P
                        get_CPU_Parallel(ip_address, "Administrator", "Abcd@1234");
                        get_more_cpu_info_Win32_Processor_Parallel(ip_address);
                        get_more_cpu_info_win32_thread_Parallel(ip_address);
                        network_OS_Parallel(ip_address, "Administrator", "Abcd@1234");


                        // listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                        //MYA
                        //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                        //Thread qThread = new Thread(() => query(ipAddress));


                        //list view here


                        //wmi_info
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", host.HostName, cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                        count++;
                    }
                    catch
                    {

                        //  listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                        //MYA
                        listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Up", "Could not retrieve", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings
                        count++;
                    }
                }

                // }
                else
                {
                    //   listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                    listVAddr.Items.Add(new ListViewItem(new String[] { ip_address, "Down", "n/a", cpu_usage, Thread_Count, Handle.ToString() })); //Log successful pings

                }
                progressBar1.Value += 1; //Increase progress bar
                                         //    }

                //    startIP[3] = 1; //If 4th octet reaches 255, reset back to 1
                //  }

                //Re-enable buttons
                //cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Done!";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                // cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Scanning stopped";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //  cmdScan.Enabled = true;
                //
                IP_textBox.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid IP range";

            }
        }
        private void scan_p_button_Click(object sender, EventArgs e)
        {
            //method to all
            //Catch empty IP addresses
            if (IP_textBox.Text == string.Empty)
            {
                ////MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No IP address entered.";
            }
            else
            {
                //Create new thread for ????????????????????????????????



                // myThread = new Thread(() => scan_GP6(IP_textBox.Text));

                //  scan_full_OS(IP_textBox.Text);

                scan_full_OS_Parallel(IP_textBox.Text);

                //network_OS_Parallel(IP_textBox.Text, "Administrator", "Abcd@1234");
                //get_CPU_Parallel(IP_textBox.Text);
                //get_more_cpu_info_win32_thread_Parallel(IP_textBox.Text);

                MessageBox.Show("Finish", "scan_p_button_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // myThread.Start();

                //if (myThread.IsAlive == true)
                //{
                //    cmdStop.Enabled = true;
                //    cmdScan.Enabled = false;
                //    txtIP.Enabled = false;
                //    txtIP2.Enabled = false;
                //}

            }







            /*
        // get_more_cpu_info_Win32_Processor_Parallel("192.168.1.13"); // errror in mangment , for what???


                    get_more_cpu_info_win32_thread(ip_address);// P
                    get_more_cpu_info_Win32_Processor(ip_address);// P
                    get_CPU_GP6(ip_address); // P
                    network_OS(ip_address, "Administrator", "Abcd@1234"); // P
        */
        }


        //25/3/2021


        //_Parallel




        //basem 25/3/2021 , mohammad edit 26/3/2021


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

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                    Console.WriteLine("PercentProcessorTime: {0}", queryObj["PercentProcessorTime"] + "%");
                    Console.WriteLine("HandleCount: {0}", queryObj["HandleCount"]);
                    Console.WriteLine("ThreadCount: {0}", queryObj["ThreadCount"]);
                    Console.WriteLine("WorkingSet: {0}", queryObj["WorkingSet"]);
                    Console.WriteLine("ElapsedTime: {0}", queryObj["ElapsedTime"] + " s");



                    //listVAddr.Items.Add(new ListViewItem(new String[] {queryObj["Name"].ToString() , queryObj["PercentProcessorTime"] + " %" ,
                    // queryObj["HandleCount"].ToString() , queryObj["ThreadCount"].ToString() , queryObj["WorkingSet"].ToString() + " MB"
                    // ,queryObj["ElapsedTime"] + " s"  }));


                    add_to_list_P_basem(Address, queryObj["Name"].ToString(), queryObj["PercentProcessorTime"] + " %",
                     queryObj["HandleCount"].ToString(), queryObj["ThreadCount"].ToString(), queryObj["WorkingSet"].ToString() + " MB"
                     , queryObj["ElapsedTime"] + " s");

                });
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                MessageBox.Show(e.Message, "wmi_cpu error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




                if (listVAddr.InvokeRequired)
                {
                    listVAddr.Invoke(new MethodInvoker(delegate
                    {
                        listVAddr.Items.Add(item);
                        item.Checked = true;

                    }));


                }
                else
                {
                    listVAddr.Items.Add(item);
                    item.Checked = true;
                    //  MessageBox.Show("else", "add_to_list_P", MessageBoxButtons.OK, MessageBoxIcon.Question);

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

        //alert_listView



        private void read_csv_automatically_P()//edit with group to auto :) 15/nov/2020 and 24/3/2021
        {
            int count = 0;
            try
            {

                //https://stackoverflow.com/questions/13762338/read-files-from-a-folder-present-in-project

                // string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Names.txt");

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"IP_OS.csv");

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

                    //  MessageBox.Show(parts[1] + " " + parts[2] + " " + parts[3], "read_csv_automatically_P", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    scan_full_OS_Parallel(parts[1]); //edit !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    //network_OS_Parallel(IP_textBox.Text, "Administrator", "Abcd@1234");
                    //get_CPU_Parallel(IP_textBox.Text);
                    //get_more_cpu_info_win32_thread_Parallel(IP_textBox.Text);

                    MessageBox.Show("Finish", "scan_p_button_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);




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

        private void load_file_button_Click(object sender, EventArgs e)
        {
            read_csv_automatically_P();
        }

        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            this.Hide();
        }

        public void add_to_chart_P_OS_CPU_WMI(string name, string usage, string series)
        {


            try
            {



                if (chart2.InvokeRequired)
                {
                    chart2.Invoke(new MethodInvoker(delegate
                    {
                        //chart1.Items.Add(item);
                        //item.Checked = true;


                        chart2.Series[series].Points.AddXY(name, usage);



                    }));


                }
                else
                {

                    chart2.Series[series].Points.AddXY(name, usage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "add_to_chart_P", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //MessageBox.Show(i.ToString() + "before");

            //Why !!!!!!!!!!!!!!!!!!!!!!!
            //if (Thread.CurrentThread.ManagedThreadId == 1)
            //{
            //    MessageBox.Show("Finish", "add_to_chart_P_OS_CPU_WMI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    chart2.Titles.Add("OS monitoring");

            //}

        
    }

        private void scan_button_Click(object sender, EventArgs e)
        {

        }

        private void scan_p_obj_button_Click(object sender, EventArgs e)
        {
           

            //Catch empty IP addresses
            if (IP_textBox.Text == string.Empty)
            {
                ////MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "No IP address entered.";
            }
            else
            {
                OS_Monitoring obj1 = new OS_Monitoring(IP_textBox.Text, username_textBox.Text, password_textBox.Text,"n/a", "Custom");


                listVAddr.Items.Add(new ListViewItem(new String[] { obj1.get_ip_address(), obj1.PingHost().ToString(), obj1.Host_name.HostName, obj1.Cpu_usage, obj1.Thread_count, obj1.Handle.ToString() })); //Log successful pings

//#todo host !!!!!!!!!!!!!!!
              // listVAddr.Items.Add(new ListViewItem(new String[] { obj1.get_ip_address(), obj1.PingHost().ToString(), obj1.Cpu_usage, obj1.Thread_count, obj1.Handle.ToString() })); //Log successful pings

                List<string[]> Network_details_temp = obj1.Network_details;


                foreach (string[] i in Network_details_temp)
                {

                    network_listView.Items.Add(new ListViewItem(i));

                }
                add_to_chart_P_OS_CPU_WMI(obj1.get_ip_address(), obj1.Cpu_usage,"CPU");
                add_to_chart_P_OS_CPU_WMI(obj1.get_ip_address(), obj1.Ratio_disk_size, "Disk size");
                add_to_chart_P_OS_CPU_WMI(obj1.get_ip_address(), obj1.Ratio_ram_size, "RAM");

                // myThread.Start();

                //if (myThread.IsAlive == true)
                //{
                //    cmdStop.Enabled = true;
                //    cmdScan.Enabled = false;
                //    txtIP.Enabled = false;
                //    txtIP2.Enabled = false;
                //}
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        //public void setLvi(string name, string age, string dob)
        //{
        //    ListViewItem lvi = new ListViewItem(name);
        //    lvi.SubItems.Add(age);
        //    lvi.SubItems.Add(dob);
        //    listVAddr.Items.Add(lvi);
        //}


        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/8e12382a-490f-4bd1-bfbe-bbaa8caf10b4/updating-listview-from-another-form
        public void UpdatingListView(string[] array)
        {
            if (this.network_listView.InvokeRequired)
                this.network_listView.Invoke(new MyDelegate(UpdatingListView), new object[] { array });
            else
            {
                ListViewItem lvi = new ListViewItem(array[0]);
             //   lvi.SubItems.Add(array[1]);
                this.network_listView.Items.Add(lvi);
            }
        }




        public void GetDiskspace(string ip_address, string user_name, string pass_word)
        {
            try
            {



                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

                options.Username = user_name;

                options.Password = pass_word; // you may want to avoid plain text password and use SecurePassword property instead
                ManagementScope scope = new ManagementScope("\\\\" + ip_address + "\\root\\cimv2", options);
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                SelectQuery query1 = new SelectQuery("Select * from Win32_LogicalDisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                //p
                //List<ManagementObject> GetDiskspace_p = queryCollection.Cast<ManagementObject>().ToList();
                ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
                ManagementObjectCollection queryCollection1 = searcher1.Get();
                //p
                // List<ManagementObject> GetDiskspace_p2 = queryCollection1.Cast<ManagementObject>().ToList();

                foreach (ManagementObject m in queryCollection)
                // Parallel.ForEach(GetDiskspace_p, m =>
                {
                    // Display the remote computer information

                    Console.WriteLine("Computer Name : {0}", m["csname"]);
                    Console.WriteLine("Windows Directory : {0}", m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}", m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer : {0}", m["Manufacturer"]);
                    Console.WriteLine();
                    //hard.Items.Add(new ListViewItem(new String[] {m["csname"].ToString() , m["WindowsDirectory"].ToString(),
                    //  m["Caption"].ToString() ,  m["Version"].ToString() , m["Manufacturer"].ToString() }));
                    ////parllel
                    ///


                    MessageBox.Show(m["csname"].ToString() + m["WindowsDirectory"].ToString()+ 
                    m["Caption"].ToString()+  m["Version"].ToString() + m["Manufacturer"].ToString() );



                    foreach (ManagementObject mo in queryCollection1)
                    // Parallel.ForEach(GetDiskspace_p2, mo =>
                    {
                        // Display Logical Disks information
                        string N = mo["Name"].ToString();
                        Console.WriteLine("              Disk Name : {0}", mo["Name"]);
                        double disksize = double.Parse(mo["Size"].ToString());
                        Console.WriteLine("              Disk Size : {0} MB", mo["Size"]);
                        Console.WriteLine("              FreeSpace : {0} MB", mo["FreeSpace"]);


                        double ratio_size = (double.Parse(mo["FreeSpace"].ToString()) / double.Parse(mo["Size"].ToString())) *100;
                        ratio_size = Math.Round(ratio_size, MidpointRounding.ToEven);
                        Console.WriteLine("MYA ,FreeSpace /Disk Size  " + ratio_size.ToString() + " %");  //#todo

                        Console.WriteLine("        Disk SystemName : {0}", mo["SystemName"]);
                        Console.WriteLine("Disk VolumeSerialNumber : {0}", mo["VolumeSerialNumber"]);
                        Console.WriteLine();
                        //liveChart();



                        //livechart_HardiskP(disksize.ToString(), mo["FreeSpace"].ToString());
                        //solidGauge1.Value = double.Parse(mo["Size"].ToString()) / 1000000;
                        //solidGauge2.Value = double.Parse(mo["FreeSpace"].ToString()) / 1000000;
                        //solidGauge3.Value = double.Parse(mo["Size"].ToString()) / 1000000;
                        //solidGauge2.Value = double.Parse(mo["FreeSpace"].ToString()) / 1000000;
                        ////solidGauge3.Value = double.Parse(mo["Size"].ToString()) / 1000000;
                        //solidGauge4.Value = double.Parse(mo["FreeSpace"].ToString()) / 1000000;

                        // hard.Items.Add(new ListViewItem(new String[] {" Disk Name : ", N.ToString() ," Disk Size:", disksize.ToString() +
                        //" MB","FreeSpace:"+mo["FreeSpace"].ToString()+" MB","Disk DeviceID:"+mo["DeviceID"]+"Disk VolumeName:", mo["VolumeName"].ToString()+"Disk VolumeSerialNumber:"+mo["VolumeSerialNumber"]}));
                        // //parllel

                        //add_listView1_HardiskP2("Disk Name: " + N.ToString(), " Disk Size: ", disksize.ToString() +
                        //  " MB", "FreeSpace:" + mo["FreeSpace"].ToString() + " MB", "Disk DeviceID:" + mo["DeviceID"] + "Disk VolumeName:",
                        //  mo["VolumeName"].ToString() + "Disk VolumeSerialNumber:" + mo["VolumeSerialNumber"]);

                        //    char s = 'c';
                        //    if (string.Equals(N, "C:"))
                        //    {
                        //        solidGauge1.Value = (Int64.Parse(mo["Size"].ToString()) / 1000000) * 9.38 / 100000;
                        //        solidGauge3.Value = (Int64.Parse(mo["FreeSpace"].ToString()) / 1000000) * 9.31 / 10000;
                        //        //MessageBox.Show("   ggggg");
                        //        if (Convert.ToInt64(disksize) / 1000000 * (9.38 / 100000) > 80)
                        //        {
                        //            Displaynotify(Address);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        solidGauge2.Value = double.Parse(mo["Size"].ToString()) / 1000000;
                        //        solidGauge4.Value = (Int64.Parse(mo["FreeSpace"].ToString()) / 1000000);
                        //        //solidGauge2.Value = double.Parse(mo["Size"].ToString()) / 1000000;
                        //        // solidGauge4.Value = double.Parse(mo["FreeSpace"].ToString()) / 1000000;
                        //    }

                        //}

                        string line;
                        line = Console.ReadLine();
                        //   });
                        //  });
                    }


                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //#todo remove


        private static readonly Dictionary<ushort, string> busTypeMap =
            new Dictionary<ushort, string>()
            {
            {0, "unknown"},
            {1, "SCSI"},
            {2, "ATAPI"},
            {3, "ATA"},
            {4, "IEEE 1394"},
            {5, "SSA"},
            {6, "Fibre Channel"},
            {7, "USB"},
            {8, "RAID"},
            {9, "iSCSI"},
            {10, "SAS"},
            {11, "SATA"},
            {12, "SD"},
            {13, "MMC"},
            {14, "reserved"},
            {15, "File-Backed Virtual"},
            {16, "Storage Spaces"},
            {17, "reserved"},
            };

        private static readonly Dictionary<ushort, string> mediaTypeMap =
            new Dictionary<ushort, string>()
            {
            {0, "Unspecified"},
            {3, "HDD"},
            {4, "SSD"},
            };



        public void check_RAM()
        {
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress("192.168.1.90");
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add("1.3.6.1.2.1.25.2.2.0"); //Ram 

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
                    Console.WriteLine(("\n Total Ram usage is ") + (total / 100000.0) + ("%"));
                }
            }
            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }

        }

    }




}
    


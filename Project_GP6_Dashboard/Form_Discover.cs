﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GP6_Dashboard
{
    public partial class Form_Discover : Form
    {
        public Form_Discover()
        {
            InitializeComponent();
            //Initialize form
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Idle";
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        Thread myThread = null;

        private void cmdScan_Click(object sender, EventArgs e)
        {
            //Catch empty IP addresses
            if (txtIP.Text == string.Empty)
            {
                ////MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No IP address entered.";
            }
            else
            {
                //Create new thread for pinging
                //myThread = new Thread(() => scan(txtIP.Text));
                ////myThread = new Thread(() => scan2(txtIP.Text, txtIP2.Text));

                //myThread = new Thread(() => scan_GP6());

                myThread = new Thread(() => scan_discover_GP6(txtIP.Text, txtIP2.Text));

                

                myThread.Start();

                if (myThread.IsAlive == true)
                {
                    cmdStop.Enabled = true;
                    cmdScan.Enabled = false;
                    txtIP.Enabled = false;
                    txtIP2.Enabled = false;
                }
            }
        }

        private void scan_p_button_Click(object sender, EventArgs e)
        {
            //Catch empty IP addresses
            if (txtIP.Text == string.Empty)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No IP address entered.";
            }
            else
            {
                //Create new thread for pinging
                //myThread = new Thread(() => scan(txtIP.Text));
                ////myThread = new Thread(() => scan2(txtIP.Text, txtIP2.Text));

                //      myThread = new Thread(() => Parallel_scan_GP6(txtIP.Text, txtIP2.Text));//P
                Parallel_scan_discover_GP6(txtIP.Text, txtIP2.Text);

                //      myThread.Start();

                //if (myThread.IsAlive == true)
                //{
                //    cmdStop.Enabled = true;
                //    cmdScan.Enabled = false;
                //    txtIP.Enabled = false;
                //    txtIP2.Enabled = false;
                //}
            }
        }
        public void Parallel_scan_discover_GP6(string start, string end)
        {
            try
            {
                //Split IP string into a 4 part array
                string[] startIPString = start.Split('.');
                int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                string[] endIPString = end.Split('.');
                int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                IPAddress addr;
                IPHostEntry host;
                //Progress bar
                progressBar1.Maximum = 254;
                progressBar1.Value = 0;
                Discover_list.Items.Clear();
                //Parallel
                int i = start[2];
                int j = endIP[2] - 1;
                int y = startIP[3];
                //CancellationTokenSource cts = new CancellationTokenSource();

                Parallel.For(startIP[3], endIP[3] + 1, count_p =>
                {
                    //For debug
                    Console.WriteLine($"value of count = {count_p}, thread = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    string ipAddress = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + count_p; //Convert IP array back into a string
                    string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range
                    lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                    lblStatus.Text = "Scanning: " + ipAddress;
                    //Log pinged IP address in listview grabs DNS information to obtain system info
                    if (PingHost(ipAddress))
                    {
                        try
                        {
                            addr = IPAddress.Parse(ipAddress);
                            host = Dns.GetHostEntry(addr);
                            Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName })); //Log successful pings
                            count++;
                        }
                        catch
                        {
                            Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", "n/a" })); //Log successful pings
                            count++;
                        }
                    }
                    else
                    {
                        Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Down", "n/a" })); //Log unsuccessful pings
                    }
                    System.Threading.Thread.Sleep(10);//Sleep the loop for 10 miliseconds
                });


                //int number_inital = startIP[2];
                //int number_end = endIP[2];//end !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1

                //int y_gp6 = startIP[2];

                //Console.WriteLine("Parallel For Loop");
                //Parallel.For(number_inital, number_end, count_loop =>
                //{
                //    Console.WriteLine($"value of count = {count_loop}, thread = {System.Threading.Thread.CurrentThread.ManagedThreadId}");


                //    //Sleep the loop for 10 miliseconds
                //    // System.Threading.Thread.Sleep(10);

                //    //new

                //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //    /*
                //                     //Loops through the IP range, maxing out at 255
                //for (int i = startIP[2]; i <= endIP[2]; i++)
                //{ //3rd octet loop
                //    for (int y = startIP[3]; y <= 255; y++)
                //    { //4th octet loop
                //        string ipAddress = startIP[0] + "." + startIP[1] + "." + i + "." + y; //Convert IP array back into a string
                //        string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                //     */

                //    //     MessageBox.Show(count_loop.ToString());

                //    string ipAddress = startIP[0] + "." + startIP[1] + "." + i + "." + y; //Convert IP array back into a string
                //    string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                //    //If current IP matches final IP in range, break
                //    if (ipAddress == endIPAddress)
                //{
                // //   break;
                //}

                //myPing = new Ping();
                //try
                //{
                //        reply_P = myPing.Send(ipAddress, 500); //Ping IP address with 500ms timeout
                //}
                //catch (Exception ex)
                //{
                //   // break;
                //}

                //lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                //lblStatus.Text = "Scanning: " + ipAddress;

                //    //Log pinged IP address in listview
                //    //Grabs DNS information to obtain system info
                //    if (reply_P.Status == IPStatus.Success)
                //    {
                //        try
                //        {
                //            addr = IPAddress.Parse(ipAddress);
                //            host = Dns.GetHostEntry(addr);

                //            if (ipAddress.Equals("192.168.1.1") != true)//!edit!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //            {
                //                //WMI , without password

                //                //delay problem
                //                //Thread qThread = new Thread(() => query_GP6(ipAddress));
                //                //qThread.Start();
                //                wmi_info = "n/a";
                //                //   query_GP6(ipAddress);

                //            }


                //            // Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                //            //MYA
                //            //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                //            //Thread qThread = new Thread(() => query(ipAddress));


                //            //list view here


                //            //wmi_info
                //            Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName })); //Log successful pings

                //            count++;
                //        }
                //        catch
                //        {

                //            //  Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                //            //MYA
                //            Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", "n/a" })); //Log successful pings
                //            count++;
                //        }
                //    }
                //    else
                //    {
                //        //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                //        Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Down", "n/a" })); //Log successful pings

                //    } });
                //
                /*
                Parallel.For(i, j, parallel1 => {

                   // for (int y = startIP[3]; y <= 255; y++)
                   Parallel.For(y, ye, parallel2 => {

                        //4th octet loop
                           string ipAddress = startIP[0] + "." + startIP[1] + "." + i + "." + y; //Convert IP array back into a string
                       string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                       //If current IP matches final IP in range, break
                       if (ipAddress == endIPAddress)
                       {
                           //     break;
                           //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-cancel-a-parallel-for-or-foreach-loop
                           cts.Cancel();
                       }

                       myPing = new Ping();
                       try
                       {
                           reply_P = myPing.Send(ipAddress, 500); //Ping IP address with 500ms timeout
                       }
                       catch (Exception ex)
                       {
                           //break;
                           cts.Cancel();

                       }

                       lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                       lblStatus.Text = "Scanning: " + ipAddress;

                       //Log pinged IP address in listview
                       //Grabs DNS information to obtain system info
                       if (reply_P.Status == IPStatus.Success)
                       {
                           try
                           {
                               addr = IPAddress.Parse(ipAddress);
                               host = Dns.GetHostEntry(addr);

                               if (ipAddress.Equals("192.168.1.1") != true)//!edit!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                               {
                                   //WMI , without password

                                   //delay problem
                                   //Thread qThread = new Thread(() => query_GP6(ipAddress));
                                   //qThread.Start();
                                   wmi_info = "n/a";
                                   query_GP6(ipAddress);

                               }


                               // Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                               //MYA
                               //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                               //Thread qThread = new Thread(() => query(ipAddress));


                               //list view here


                               //wmi_info
                               Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName, wmi_info })); //Log successful pings

                               count++;
                           }
                           catch
                           {

                               //  Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                               //MYA
                               Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", "Could not retrieve", "n/a" })); //Log successful pings
                               count++;
                           }
                       }
                       else
                       {
                           //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                           Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Down", "n/a", "n/a" })); //Log successful pings

                       }
                       progressBar1.Value += 1; //Increase progress bar
                  // }//for
                    });


                startIP[3] = 1; //If 4th octet reaches 255, reset back to 1

               });

            //    { //3rd octet loop
                      //for (int y = startIP[3]; y <= 255; y++)

                  // }//for


                */
                //Re-enable buttons
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Done!";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                txtIP2.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Scanning stopped";
            }

            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                txtIP2.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid IP range";
            }
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            cmdScan.Enabled = true;
            cmdStop.Enabled = false;
            txtIP.Enabled = true;
            txtIP2.Enabled = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Scanning stopped";
        }

        //new MYA | 14/3/2021
        public void scan_discover_GP6(string start, string end)
        {
            try
            {

                //Split IP string into a 4 part array
                string[] startIPString = start.Split('.');
                int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                string[] endIPString = end.Split('.');
                int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                Ping myPing;
                PingReply reply;
                IPAddress addr;
                IPHostEntry host;

                //Progress bar
                progressBar1.Maximum = 254;
                progressBar1.Value = 0;
                Discover_list.Items.Clear();

                //Loops through the IP range, maxing out at 255
                for (int i = startIP[2]; i <= endIP[2]; i++)
                { //3rd octet loop
                    for (int y = startIP[3]; y <= 255; y++)
                    { //4th octet loop
                        string ipAddress = startIP[0] + "." + startIP[1] + "." + i + "." + y; //Convert IP array back into a string
                        string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                        //If current IP matches final IP in range, break
                        if (ipAddress == endIPAddress)
                        {
                            break;
                        }

                        myPing = new Ping();
                        //try
                        //{
                        //    reply = myPing.Send(ipAddress, 500); //Ping IP address with 500ms timeout
                        //}
                        //catch (Exception ex)
                        //{
                        //    break;
                        //}

                        lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                        lblStatus.Text = "Scanning: " + ipAddress;

                        //Log pinged IP address in listview
                        //Grabs DNS information to obtain system info
                        //  if (reply.Status == IPStatus.Success)

                        //MYA
                        if (PingHost(ipAddress))

                        {
                            try
                            {
                                addr = IPAddress.Parse(ipAddress);
                                host = Dns.GetHostEntry(addr);

                                //if (ipAddress.Equals("192.168.1.1") != true)//!edit!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                //{
                                //    //WMI , without password

                                //    //delay problem
                                //    //Thread qThread = new Thread(() => query_GP6(ipAddress));
                                //    //qThread.Start();
                                //    wmi_info = "n/a";
                                // //   query_GP6(ipAddress);

                                //}


                                // Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, host.HostName, "Up" })); //Log successful pings

                                //MYA
                                //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName})); //Log successful pings

                                //Thread qThread = new Thread(() => query(ipAddress));


                                //list view here


                                //wmi_info
                                Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", host.HostName })); //Log successful pings

                                count++;
                            }
                            catch
                            {

                                //  Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Could not retrieve", "Up" })); //Logs pings that are successful, but are most likely not windows machines

                                //MYA
                                Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Up", "n/a" })); //Log successful pings
                                count++;
                            }
                        }
                        else
                        {
                            //   Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings


                            Discover_list.Items.Add(new ListViewItem(new String[] { ipAddress, "Down", "n/a" })); //Log successful pings

                        }
                        progressBar1.Value += 1; //Increase progress bar
                    }

                    startIP[3] = 1; //If 4th octet reaches 255, reset back to 1
                }

                //Re-enable buttons
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Done!";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                txtIP2.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Scanning stopped";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                cmdScan.Enabled = true;
                cmdStop.Enabled = false;
                txtIP.Enabled = true;
                txtIP2.Enabled = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid IP range";
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

        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Form_Discover_Load(object sender, EventArgs e)
        {

        }

        //
        //WQL query, Windows Management Instrumentation (WMI System Information)
        public void query(string host)
        {

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

        //Open network folder to see shared folders
        private void openNetworkFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"\\" + Discover_list.SelectedItems[0].Text.ToString()); //Open explorer with host IP
        }

        //Query machine for system information
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = Discover_list.SelectedItems[0].Text.ToString();
            Thread qThread = new Thread(() => query(host));
            qThread.Start();
        }

        //Send shutdown command using controlSys method
        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = Discover_list.SelectedItems[0].Text.ToString();
            controlSys(host, 5);
        }

        //Send reboot command
        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = Discover_list.SelectedItems[0].Text.ToString();
            controlSys(host, 6);
        }

        private void Discover_list_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Discover_list.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    conMenuStripIP.Show(Cursor.Position);
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

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM Win32_OperatingSystem");

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

    }
}

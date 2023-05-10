using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GP6_Dashboard
{
    public partial class Database_Management_Form : Form
    {
        public Database_Management_Form()
        {
            InitializeComponent();
        }

        private void Database_Management_Load(object sender, EventArgs e)
        {
            read_csv_automatic();
        }
        private void read_csv_automatic()//edit with group to auto :) 15/nov/2020
        {
            //OpenFileDialog ofDialog = new OpenFileDialog();

            //ofDialog.Filter = @"CSV Files|*.csv";
            //ofDialog.Title = @"Select your backlink file...";
            //ofDialog.FileName = "backlinks.csv";
            int count = 1;
            //// is cancel pressed?
            //if (ofDialog.ShowDialog() == DialogResult.Cancel)
            //    return;
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dataset_IP.csv");
                var lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    count = count + 1;
                    var parts = line.Split(',');
                    ListViewItem lvi = new ListViewItem(parts[0]);//MYA: parts[0] Name
                                                                  //lvi.SubItems.Add(parts[1]);
                    DB_listView.Items.Add(new ListViewItem(new String[] { parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]}));

                }
                // update count
                // MessageBox.Show(File.ReadAllLines(ofDialog.FileName).Count() + " rows imported.");
           //     MessageBox.Show("From database file: " + (count + " rows imported.")); //MYA edit

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//read_csv_automatic
        private void label1_Click(object sender, EventArgs e)
        {

        }
 
        private void Insert_button_Click(object sender, EventArgs e)
        {
            save_csv(name_textBox.Text, ipadressbox.Text, username_textBox.Text, password_textBox.Text,
        username_DB_textBox.Text, password_DB_textBox.Text, table_textBox.Text);

            DB_listView.Items.Add(new ListViewItem(new String[] { name_textBox.Text, ipadressbox.Text, username_textBox.Text, password_textBox.Text,
        username_DB_textBox.Text, password_DB_textBox.Text, table_textBox.Text }));


        }

        public void save_csv(string Name_of_server, string IP_address, string Username, string Password,
      string Username_in_DB, string Password_in_DB, string Table)
        {

            ///



            //MYA

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Dataset_IP.csv");

            //https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp

            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
 
                string csv = string.Format("{0},{1},{2},{3},{4},{5},{6}", Name_of_server,  IP_address,  Username,  Password,
       Username_in_DB,  Password_in_DB,  Table);



                sw.WriteLine(csv);
                //add
                sw.Flush();//MYA: to \n
                sw.Close();
            }

        }
        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void ipadressbox_TextChanged(object sender, EventArgs e)
        {

        }

        //Open network folder to see shared folders
        private void openNetworkFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"\\" + DB_listView.SelectedItems[0].Text.ToString()); //Open explorer with host IP
        }

        //Query machine for system information
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string server = DB_listView.SelectedItems[0].SubItems[1].Text.ToString();
            string username = DB_listView.SelectedItems[0].SubItems[2].Text.ToString();
            string password = DB_listView.SelectedItems[0].SubItems[3].Text.ToString();

            Thread qThread = new Thread(() => query_info_windows(server, username, password));
            qThread.Start();
        }

        //Send shutdown command using controlSys method
        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string host = DB_listView.SelectedItems[0].Text.ToString();
            //controlSys(host, 5);
            string server = DB_listView.SelectedItems[0].SubItems[1].Text.ToString();
            string username = DB_listView.SelectedItems[0].SubItems[2].Text.ToString();
            string password = DB_listView.SelectedItems[0].SubItems[3].Text.ToString();

            Action_to_server_windows(server, 5, username, password);
        }

        //Send reboot command
        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string server = DB_listView.SelectedItems[0].SubItems[1].Text.ToString();
            string username = DB_listView.SelectedItems[0].SubItems[2].Text.ToString();
            string password = DB_listView.SelectedItems[0].SubItems[3].Text.ToString();

            Action_to_server_windows(server,6, username, password);

            //Monitoring_GP6_M_A_2021 test = new Monitoring_GP6_M_A_2021();
           // test.Action_to_server_windows(server, 6, username, password);

           // controlSys(host, 6);
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

        public void Action_to_server_windows(string host, int flags,string username,string password)
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

        //WQL query, Windows Management Instrumentation (WMI System Information)
        public void query_info_windows(string host, string username, string password)
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


            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;

            options.Username = username;
            options.Password = password;

            //  lblStatus.ForeColor = System.Drawing.Color.Green;

            //Iterate through Win32 classes and query system info
            for (int i = 0; i <= searchClass.Length - 1; i++)
            {
                //lblStatus.Text = "Getting information.";
                try
                {
          

                    ManagementScope scope = new ManagementScope("\\\\" + host + "\\root\\cimv2", options);
                    ObjectQuery query = new ObjectQuery("SELECT *FROM " + searchClass[i]);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                    // ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + host + "\\root\\CIMV2", "SELECT *FROM " + searchClass[i]);
                    foreach (ManagementObject obj in searcher.Get())
                    {

                        //Add system info to dialog box
                        temp += obj.GetPropertyValue(param[i]).ToString() + "\n";
                        if (i == searchClass.Length - 1)
                        {
                            MessageBox.Show(temp, "Hostinfo: " + host, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not retrieve information \n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            DB_listView.Items.Clear();

            read_csv_automatic();
        }
    }

}

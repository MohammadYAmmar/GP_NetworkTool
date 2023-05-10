using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;



using System.Net.NetworkInformation;//ping , IS
    using System.Net.Sockets;
  //  using MySql.Data.MySqlClient;

    using System.Threading;

    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient; //dll to that . to .csproj | https://stackoverflow.com/questions/54472165/what-is-wrong-with-this-code-why-cant-i-use-sqlconnection
                                 //using Microsoft.Data.SqlClient; //https://www.nuget.org/packages/Microsoft.Data.SqlClient/

    using System.Drawing;
    using System.Text;
    //using System.Windows.Forms; // MessageBox
    using System.Net;
    using System.IO;
    using System.Collections;
    using System.Web;
//using System.Windows.Forms;//MessageBox
// using System.ServiceProcess; //IIS

using Microsoft.SharePoint.Client;

using System.Security;
using System.Xml;
using Microsoft.Exchange.WebServices;
using System.Reflection;

namespace Project_GP6_Dashboard
{

        static class Program
        {


 


        public static bool one_time;

        // end SNMP variables  , massage file 

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
            static void Main()
            {
            //    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Begin_Log_in_Form());


            // Application.Run(new Dashboard_Form());

            // Monitoring_GP6_M_A_2021 TEST = new Monitoring_GP6_M_A_2021();
            //   TEST.Send_Email_Alert_HTML("hi");


            //

            //string original_Email = System.IO.File.ReadAllText(
            //   Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index.htm"));

            //string email_new =  original_Email.Replace("IP_Address", "192.168.1.1");


            //  original_Email.Replace("Specifications66", "Specifications: here test ");

            //  original_Email.Replace("Layer_default", "Layer_physical_false");


            //    System.IO.File.WriteAllText(
            //        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_test.htm"), email_new);

            //string path_new = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_tesr.htm"));

            //System.IO.File.WriteAllText(path_new, original_Email));

            //


            //

            //var selectedOption = MessageBox.Show("Please Select a button?", "Dialog Value Demo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);



            //// If the no button was pressed ...

            //if (selectedOption == DialogResult.Yes)

            //{

            ////    MessageBox.Show("Yes is pressed!", "Yes Dialog", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}

            //else if (selectedOption == DialogResult.No)

            //{

            //    MessageBox.Show("No is pressed!", "No Dialog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}

            //else

            //{

            //    MessageBox.Show("Cancel is pressed", "Cancel Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //





            //Application.Run(new Dashboard_Custom_Form());



            //  MsOnlineClaimsHelper obj1 = new MsOnlineClaimsHelper("test", "mohammad_y_ammar@taibahu.edu.sa", "");

            // ClientContext t =  obj1.MSOnlineHelperClassAuth_NEW("sss");


            //  MsOnlineClaimsHelper.MSOnlineHelperClassAuth("https://taibahuniv.sharepoint.com/sites/GP6_Site/");


        }//main


        //SharePoint

        //with ahmed 22/3/2021

        public static void BindItemsToDropDownList()
        {
            using (ClientContext clientContext = new ClientContext("https://taibahuniv.sharepoint.com/sites/GP6_Site"))
            {
                clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                //            Program.ConnectToSharePointOnline("https://taibahuniv.sharepoint.com/sites/GP6_Site", "", "???");

                clientContext.Credentials = new SharePointOnlineCredentials("mohammad_y_ammar@taibahu.edu.sa", GetSPOSecureStringPassword());

                Web web = clientContext.Web;
                ListTemplateCollection templateColl = web.ListTemplates;
                clientContext.Load(templateColl);

                clientContext.ExecuteQuery();

                //Further Code
            }
        }

        private static SecureString GetSPOSecureStringPassword()
        {
            try
            {
                var secureString = new SecureString();
                foreach (char c in "2350614679")
                {
                    secureString.AppendChar(c);
                }

                return secureString;
            }
            catch
            {
                throw;
            }
        }



        //https://global-sharepoint.com/sharepoint-online/how-to-authenticate-to-sharepoint-online-using-c-coding/

        //Program.ConnectToSharePointOnline("https:////taibahuniv.sharepoint.com//sites//GP6_Site//", "mohammad_y_ammar@taibahu.edu.sa", "");

        public static void ConnectToSharePointOnline(string siteCollUrl, string userName, string password)
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
            MessageBox.Show(mySite.Url.ToString(), "ConnectToSharePointOnline",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        //public static void GetWSSCollectionsInfo(string url, string user, SecureString password)
        //{
        //    //TheWebService.Webs webs = new TheWebService.Webs
        //    {
        //        PreAuthenticate = true,
        //        Credentials = new System.Net.NetworkCredential(user, password),
        //        Url = url + "/_vti_bin/Webs.asmx"
        //    };
        //    try
        //    {
        //        XmlNode collection = webs.GetWebCollection();
        //        XmlNodeList nodes = collection.SelectNodes("*");
        //        if (collection == null || collection.ChildNodes[0] == null)
        //        {
        //            return;
        //        }
        //        foreach (XmlNode node in nodes)
        //        {
        //            Console.WriteLine("Title: " + node.Attributes["Title"].Value);
        //            Console.WriteLine("Url: " + node.Attributes["Url"].Value);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine("Exception of type" + exception.GetType() + "caught.");
        //        Console.WriteLine(exception.Message);
        //        Console.WriteLine(exception.StackTrace);
        //    }
        //}

        //

        public static List GetList()
        {

            //var siteURL = "https://dennis.sharepoint.com/sites/Dennis";
            //var listName = "CustomList";
            //var login = "dennis@dennis.onmicrosoft.com";
            //var password = "******";


            //            Program.ConnectToSharePointOnline("https://taibahuniv.sharepoint.com/sites/GP6_Site", "mohammad_y_ammar@taibahu.edu.sa", "??");


            var siteURL = "https://taibahuniv.sharepoint.com/sites/GP6_Site";
            var listName = "GP6_Site";
            var login = "mohammad_y_ammar@taibahu.edu.sa";
            var password = "";


            


            ClientContext context = new ClientContext(siteURL);

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            SharePointOnlineCredentials credentials = new SharePointOnlineCredentials(login, securePassword);

            context.Credentials = credentials;

            List list = context.Web.Lists.GetByTitle(listName);
            context.Load(list);

            try
            {
                context.ExecuteQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(list.ToString(), "GetList", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return list;
        }



        public static String PingHost_string(string nameOrAddress)
            {
                bool result = PingHost(nameOrAddress);
                if (result == true)
                {
                    return "Available";
                }
                else
                {
                    return "Not available";
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
            }//PingHost

            //public static string check_data_base(string address, string name_data_base, string name_table)
            //{
            //    string connectionString = "datasource=" + address + ";port=3306;username=username;password=password;database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

            //    // Your query,
            //    //string query = "SELECT * FROM information_students";
            //    string query = "SELECT * FROM " + name_table;

            //    // Prepare the connection
            //    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //    commandDatabase.CommandTimeout = 60;
            //    // MySqlDataReader reader;//MYA 


            //    // Let's do it !
            //    try
            //    {
            //        // Open the database
            //        databaseConnection.Open();
            //        Console.WriteLine("Database Status: Connected in SQL ");



            //        // All succesfully executed, now do something


            //        //Finally close the connection
            //        databaseConnection.Close();
            //        return "Connected in SQL";

            //    }//try
            //    catch (Exception ex)
            //    {
            //        // Show any error message.
            //        //MessageBox.Show(ex.Message);

            //        Console.WriteLine(ex.Message);

            //    }//catch
            //    return "Not connected in SQL";

            //}//check data base 

            //public static string read_data_base(string address, string name_data_base, string table)
            //{
            //    string connectionString = "datasource=" + address + ";port=3306;username=username;password=password;database=" + name_data_base + "; CharSet=utf8;";//CharSet=utf8 mb4    

            //    // Your query,
            //    //string query = "SELECT * FROM information_students";
            //    string query = "SELECT * FROM " + table;

            //    // Prepare the connection
            //    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //    commandDatabase.CommandTimeout = 60;
            //    MySqlDataReader reader;//MYA

            //    string temp = null;

            //    try
            //    {
            //        // Open the database
            //        databaseConnection.Open();
            //        Console.WriteLine("Database Status: Connected in SQL ");

            //        //new 2 https://stackoverflow.com/questions/6003480/reading-values-from-sql-database-in-c-sharp
            //        // by group edition
            //        // Execute the query
            //        reader = commandDatabase.ExecuteReader();
            //        //Console.WriteLine("The database: \n");

            //        //test 4/nov/2020
            //        // 
            //        while (reader.Read())
            //        {
            //            temp += "ID:  " + reader["ID"].ToString() + "\n"
            //                + "Name: " + reader["first_name"].ToString()
            //                + " " + reader["Last_name"].ToString() + "\n"
            //                + "University mail: " + reader["Email"].ToString() + "\n"
            //                + "Year of Birth:   " + reader["Year_of_birth"].ToString() + "\n"
            //                + "College:   " + reader["College"].ToString() + "\n"
            //                + "\n";

            //        }//while
            //        MessageBox.Show(temp, "DataBase : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //        //    lblStatus.Text = "Getting information. . .";
            //    }
            //    catch (Exception ex)
            //    {
            //        // Show any error message.
            //        MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        // Console.WriteLine(ex.Message);
            //    }
            //    return temp;

            //}//read DB
            //public static string check_SNMP(String nameOrAddress)//edit !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //{
            //    IP_ADDRESS = nameOrAddress; //change from constant

            //    //just ti check - MYA
            //    // MessageBox.Show(IP_ADDRESS, "212", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    //GP6


            //    //byte[] response = new byte[1024];

            //    //end GP6 

            //    // IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(Program.IP_ADDRESS), Program.PORT_NUMBER);
            //    //UdpClient udpClient = new UdpClient(Program.PORT_NUMBER);


            //    //udpClient.Connect(ipEndPoint);


            //    //

            //    //try
            //    //{
            //    //    UdpClient udpClient = new UdpClient(Port);
            //    //    Socket uSocket = udpClient.Client;
            //    //    uSocket.ReceiveTimeout = 5000;
            //    //    uSocket.Connect(Adress, Port);
            //    //    udpClient.Connect(Adress, Port);
            //    //    IPEndPoint RemoteIpEndPoint = new IPEndPoint(Adress, Port);
            //    //    Byte[] sendBytes = Encoding.ASCII.GetBytes("?");
            //    //    udpClient.Send(sendBytes, sendBytes.Length);
            //    //    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            //    //}
            //    //catch (SocketException e)
            //    //{
            //    //    if (e.ErrorCode == 10054)
            //    //    {
            //    //        return false;
            //    //    }
            //    //    else
            //    //    {
            //    //        return false;
            //    //    }
            //    //}
            //    //return true;
            //    //
            //    //s
            //    try
            //    {
            //        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(Program.IP_ADDRESS), Program.PORT_NUMBER);
            //        UdpClient udpClient = new UdpClient(Program.PORT_NUMBER);
            //        //Socket uSocket = udpClient.Client;
            //        //uSocket.ReceiveTimeout = 5000;
            //        //uSocket.Connect(Program.IP_ADDRESS, Program.PORT_NUMBER);
            //        //udpClient.Connect(ipEndPoint);
            //        //MessageBox.Show("here 257.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        udpClient.Connect(ipEndPoint);
            //        return "Connected";

            //    }
            //    catch (SocketException e)
            //    {

            //        if (e.ErrorCode == 10054)
            //        {
            //            return "not Connected";
            //        }
            //        else
            //        {
            //            return "not Connected";
            //        }
            //    }
                //s

                //GP6 





                //https://stackoverflow.com/questions/29884988/check-remote-udp-socket


                //http://www.java2s.com/Code/CSharp/Network/SimpleSNMP.htm

                //https://www.codeproject.com/Questions/1173462/Detect-SNMP-device-over-network-with-Csharp



            }//check SNMP

            //public static void read_SNMP(String nameOrAddress)
            //{
            //    // string temp = null;//NEW
            //    //IP_ADDRESS = nameOrAddress;
            //    IP_ADDRESS = nameOrAddress; //change from constant

            //    MessageBox.Show(IP_ADDRESS, "311 snmp1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    string temp = null;

            //    //GP6
            //    int commlength, miblength, datatype, datalength, datastart;
            //    int uptime = 0;
            //    string output;

            //    //byte[] response = new byte[1024];

            //    //end GP6 

            //    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(Program.IP_ADDRESS), Program.PORT_NUMBER);
            //    UdpClient udpClient = new UdpClient(Program.PORT_NUMBER);

            //    udpClient.Connect(ipEndPoint);

            //    // Convert message to byte array
            //    byte[] request_packet = new Message().getMessageAsByteArray();
            //    udpClient.Send(request_packet, request_packet.Length);

            //    byte[] response_packet = udpClient.Receive(ref ipEndPoint);

            //    //Console.WriteLine("Received data: " +
            //    //    Encoding.ASCII.GetString(response_packet)
            //    //    + " from address " + ipEndPoint.Address.ToString());


            //    // 19/nov
            //    String Rdata = "Received data: " +
            //        Encoding.ASCII.GetString(response_packet)
            //        + " from address " + ipEndPoint.Address.ToString();

            //    //temp += "Received data: " +
            //    //    Encoding.ASCII.GetString(response_packet)
            //    //    + " from address " + ipEndPoint.Address.ToString();

            //    // Form1.WMIlistView.Items.Add(new ListViewItem(new String[] { Rdata }));


            //    //
            //    //test 4/nov/2020


            //    // Console.WriteLine("SNMP Status: Connected ");


            //    //GP6 
            //    //http://www.java2s.com/Code/CSharp/Network/SimpleSNMP.htm

            //    if (response_packet[0] == 0xff)
            //    {
            //        Console.WriteLine("No response from {0}", response_packet[0]);

            //        //  return;
            //    }

            //    // If response, get the community name and MIB lengths
            //    commlength = Convert.ToInt16(response_packet[6]);
            //    miblength = Convert.ToInt16(response_packet[23 + commlength]);

            //    // Extract the MIB data from the SNMP response
            //    datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
            //    datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
            //    datastart = 26 + commlength + miblength;
            //    output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
            //    //Console.WriteLine("  sysName - Datatype: {0}, Value: {1}", datatype, output);


            //    temp += ("  sysName - Datatype: {0}, Value: {1}", datatype, output);

            //    // Send a sysLocation SNMP request
            //    /*
            //    response_packet = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.6.0");

            //    if (response_packet[0] == 0xff)
            //    {
            //        Console.WriteLine("No response from {0}", response_packet[0]);
            //        return;
            //    }
            //    */

            //    // If response, get the community name and MIB lengths
            //    commlength = Convert.ToInt16(response_packet[6]);
            //    miblength = Convert.ToInt16(response_packet[23 + commlength]);

            //    // Extract the MIB data from the SNMP response
            //    datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
            //    datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
            //    datastart = 26 + commlength + miblength;
            //    output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
            //    //Console.WriteLine("  sysLocation - Datatype: {0}, Value: {1}", datatype, output);


            //    temp += ("  sysLocation - Datatype: {0}, Value: {1}", datatype, output);

            //    // Send a sysContact SNMP request
            //    //response = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.4.0");

            //    /*
            //    response_packet = conn.get("get", array_GP6[0], array_GP6[1], "1.3.6.1.2.1.1.4.0");

            //    if (response[0] == 0xff)
            //    {
            //        //  Console.WriteLine("No response from {0}", argv[0]);
            //        Console.WriteLine("No response from {0}", array_GP6[0]);

            //        return;
            //    }
            //    */

            //    // Get the community and MIB lengths
            //    commlength = Convert.ToInt16(response_packet[6]);
            //    miblength = Convert.ToInt16(response_packet[23 + commlength]);

            //    // Extract the MIB data from the SNMP response
            //    datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
            //    datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
            //    datastart = 26 + commlength + miblength;
            //    output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
            //    //Console.WriteLine("  sysContact - Datatype: {0}, Value: {1}",
            //    //        datatype, output);


            //    temp += ("  sysContact - Datatype: {0}, Value: {1}", datatype, output);

            //    /*
            //    // Send a SysUptime SNMP request
            //    response = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.3.0");
            //    if (response[0] == 0xff)
            //    {
            //        Console.WriteLine("No response from {0}", argv[0]);
            //        return;
            //    }
            //    */
            //    // Get the community and MIB lengths of the response
            //    commlength = Convert.ToInt16(response_packet[6]);
            //    miblength = Convert.ToInt16(response_packet[23 + commlength]);

            //    // Extract the MIB data from the SNMp response
            //    datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
            //    datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
            //    datastart = 26 + commlength + miblength;

            //    // The sysUptime value may by a multi-byte integer
            //    // Each byte read must be shifted to the higher byte order
            //    while (datalength > 0)
            //    {
            //        uptime = (uptime << 8) + response_packet[datastart++];
            //        datalength--;
            //    }
            //    //Console.WriteLine("  sysUptime - Datatype: {0}, Value: {1}",
            //    //       datatype, uptime);

            //    temp += ("  sysUptime - Datatype: {0}, Value: {1}", datatype, uptime);
            //    //end GP6 



            //    udpClient.Close();

            //    MessageBox.Show(temp, "SNMP : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    //return temp;
            //    // Console.ReadLine(); //GP6

            //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1


            //    temp += "1"; //NEW




            //    MessageBox.Show(temp, "SNMP : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);//NEW

            //}//read_SNMP



            //SNMP_GP6 
    //        public static void read_SNMP2(String nameOrAddress)
    //        {
    //            //IP_ADDRESS = nameOrAddress; //change from constant
    //            MessageBox.Show(IP_ADDRESS, "488 anmp2", MessageBoxButtons.OK, MessageBoxIcon.Error);

    //            string temp = null;


    //            //GP6
    //            int commlength, miblength, datatype, datalength, datastart;
    //            int uptime = 0;
    //            string output;

    //            //byte[] response = new byte[1024];

    //            //end GP6 

    //            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(Program.IP_ADDRESS), Program.PORT_NUMBER);
    //            UdpClient udpClient = new UdpClient(Program.PORT_NUMBER);

    //            udpClient.Connect(ipEndPoint);

    //            // Convert message to byte array
    //            byte[] request_packet = new dashboard.Message().getMessageAsByteArray();
    //            udpClient.Send(request_packet, request_packet.Length);

    //            byte[] response_packet = udpClient.Receive(ref ipEndPoint);
    //            //Console.WriteLine("Received data: " +
    //            //    Encoding.ASCII.GetString(response_packet)
    //            //    + " from address " + ipEndPoint.Address.ToString());

    //            temp += ("Received data: " +
    //                Encoding.ASCII.GetString(response_packet)
    //                + " from address " + ipEndPoint.Address.ToString());






    //            // Console.WriteLine("SNMP Status: Connected ");


    //            //GP6 
    //            //http://www.java2s.com/Code/CSharp/Network/SimpleSNMP.htm

    //            if (response_packet[0] == 0xff)
    //            {
    //                Console.WriteLine("No response from {0}", response_packet[0]);

    //                return;
    //            }

    //            // If response, get the community name and MIB lengths
    //            commlength = Convert.ToInt16(response_packet[6]);
    //            miblength = Convert.ToInt16(response_packet[23 + commlength]);

    //            // Extract the MIB data from the SNMP response
    //            datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
    //            datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
    //            datastart = 26 + commlength + miblength;
    //            output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
    //            Console.WriteLine("  sysName - Datatype: {0}, Value: {1}", datatype, output);

    //            // Send a sysLocation SNMP request
    //            /*
    //            response_packet = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.6.0");

    //            if (response_packet[0] == 0xff)
    //            {
    //                Console.WriteLine("No response from {0}", response_packet[0]);
    //                return;
    //            }
    //            */

    //            // If response, get the community name and MIB lengths
    //            commlength = Convert.ToInt16(response_packet[6]);
    //            miblength = Convert.ToInt16(response_packet[23 + commlength]);

    //            // Extract the MIB data from the SNMP response
    //            datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
    //            datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
    //            datastart = 26 + commlength + miblength;
    //            output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
    //            Console.WriteLine("  sysLocation - Datatype: {0}, Value: {1}", datatype, output);

    //            // Send a sysContact SNMP request
    //            //response = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.4.0");

    //            /*
    //            response_packet = conn.get("get", array_GP6[0], array_GP6[1], "1.3.6.1.2.1.1.4.0");

    //            if (response[0] == 0xff)
    //            {
    //                //  Console.WriteLine("No response from {0}", argv[0]);
    //                Console.WriteLine("No response from {0}", array_GP6[0]);

    //                return;
    //            }
    //            */

    //            // Get the community and MIB lengths
    //            commlength = Convert.ToInt16(response_packet[6]);
    //            miblength = Convert.ToInt16(response_packet[23 + commlength]);

    //            // Extract the MIB data from the SNMP response
    //            datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
    //            datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
    //            datastart = 26 + commlength + miblength;
    //            output = Encoding.ASCII.GetString(response_packet, datastart, datalength);
    //            Console.WriteLine("  sysContact - Datatype: {0}, Value: {1}",
    //                    datatype, output);

    //            /*
    //            // Send a SysUptime SNMP request
    //            response = conn.get("get", argv[0], argv[1], "1.3.6.1.2.1.1.3.0");
    //            if (response[0] == 0xff)
    //            {
    //                Console.WriteLine("No response from {0}", argv[0]);
    //                return;
    //            }
    //            */
    //            // Get the community and MIB lengths of the response
    //            commlength = Convert.ToInt16(response_packet[6]);
    //            miblength = Convert.ToInt16(response_packet[23 + commlength]);

    //            // Extract the MIB data from the SNMp response
    //            datatype = Convert.ToInt16(response_packet[24 + commlength + miblength]);
    //            datalength = Convert.ToInt16(response_packet[25 + commlength + miblength]);
    //            datastart = 26 + commlength + miblength;

    //            // The sysUptime value may by a multi-byte integer
    //            // Each byte read must be shifted to the higher byte order
    //            while (datalength > 0)
    //            {
    //                uptime = (uptime << 8) + response_packet[datastart++];
    //                datalength--;
    //            }
    //            Console.WriteLine("  sysUptime - Datatype: {0}, Value: {1}",
    //                   datatype, uptime);
    //            //end GP6 



    //            udpClient.Close();
    //            MessageBox.Show(temp, "SNMP : " + "content", MessageBoxButtons.OK, MessageBoxIcon.Information);//NEW


    //            // Console.ReadLine(); //GP6

    //        }//SNMP_GP6 _  read snmp2


    //        //https://www.c-sharpcorner.com/UploadFile/nipuntomar/check-internet-connection/

    //        /*
    //        public static string IsConnectedToInternet()    {
    //        string host = "https://www.google.com";  
    ////bool result = false;
    //        Ping p = new Ping();
    //        try
    //        {
    //            PingReply reply = p.Send(host, 1000);
    //            if (reply.Status == IPStatus.Success)
    //                return "Available";
    //        }
    //        catch (Exception ex)
    //            {
    //                MessageBox.Show(ex.Message, "ConnectedToInternet", MessageBoxButtons.OK, MessageBoxIcon.Error);

    //            }
    //            return "not Available";
    //    }
    //        */

    //        public static bool IsConnectedToInternet()
    //        {
    //            string host = "http://www.google.com";  //MYA

    //            // string host = "localhost";  //

    //            bool result = false;
    //            Ping p = new Ping();
    //            try
    //            {
    //                PingReply reply = p.Send(host, 100);
    //                if (reply.Status == IPStatus.Success)
    //                    return true;
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show(ex.Message, "ConnectedToInternet", MessageBoxButtons.OK, MessageBoxIcon.Error);

    //            }
    //            return result;
    //        }

            //public static String IsConnectedToInternet_string()
            //{
            //    bool result = IsConnectedToInternet();
            //    if (result == true)
            //    {
            //        return "Available";
            //    }
            //    else
            //    {
            //        return "Not available";
            //    }
            //}

            //http://www.programcall.com/20/dotnet/check-if-iis-is-running-using-cs.aspx
            //https://stackoverflow.com/questions/9816751/check-iis-is-installed-and-running
            //using System.ServiceProcess;

            //public static bool IsConnectedToIIS_localhost()
            //{
            //    bool isRunning = false;

            //    ////  ServiceController controller = new ServiceController("W3SVC");

            //    //ServiceController controller = new ServiceController("World Wide Web Publishing Service");

            //    //if (controller.Status == ServiceControllerStatus.Running)
            //    //{
            //    //    isRunning = true;
            //    //}

            //    return isRunning;
            //}

            //public static String IsConnectedToIIS_string()
            //{
            //    bool result = IsConnectedToIIS_localhost();
            //    if (result == true)
            //    {
            //        return "Available";
            //    }
            //    else
            //    {
            //        return "Not available";
            //    }
            //}

            //Share point (library in picture)

            ////        https://stackoverflow.com/questions/2023469/check-to-see-if-a-sharepoint-site-exists-or-not

            ////https://collab365.community/checking-the-lists-exists-or-not-in-the-share-point-site-share/

            ////https://sharepoint.stackexchange.com/questions/221728/how-to-check-the-list-is-present-in-the-sharepoint-online-site/221743

            /*
            public static void checkSharePoint()
            {
                // Input Parameters  
                string siteUrl = "https://nakkeerann.sharepoint.com";
                string userName = "abc@nakkeerann.onmicrosoft.com";
                string password = "***";

                // PnP component to set context  
                AuthenticationManager authManager = new AuthenticationManager();

                try
                {
                    // Get and set the client context  
                    // Connects to SharePoint online site using inputs provided  
                    using (var clientContext = authManager.GetSharePointOnlineAuthenticatedContextTenant(siteUrl, userName, password))
                    {
                        // List name input  
                        string listName = "TestList";
                        // Checks the list exists  
                        bool listExists = clientContext.Site.RootWeb.ListExists(listName);
                        if (listExists)
                        {
                            Console.WriteLine("List is available on the site");
                        }
                        else
                        {
                            Console.WriteLine("List is not available on the site");
                        }
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                    Console.ReadKey();
                }
            }
                    */

        } //class
    

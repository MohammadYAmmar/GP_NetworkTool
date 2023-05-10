using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GP6_Dashboard
{
    public partial class Form_Application : Form
    {
        public Form_Application()
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

        private void Form_Application_Load(object sender, EventArgs e)
        {
           // check_FTF_file("192.168.1.92");
            //check_ftp("192.168.1.13");
            //    CreateFolder_FTP();
        }


       

        //https://stackoverflow.com/questions/1633391/testing-smtp-server-is-running-via-c-sharp
        //with Ahmed 19/3/2021
        public void check_smtp(string ipaddress)
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



                            App_listView.Items.Add(new ListViewItem(new String[] { ipaddress, "SMTP" , "Available", reader.ReadLine() }));
                            //MessageBox.Show(reader.ReadLine());
                            // GMail responds with: 220 mx.google.com ESMTP
                        }


                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "check_smtp Form App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App_listView.Items.Add(new ListViewItem(new String[] { ipaddress, "SMTP", "Unavailable", ex.Message }));

            }
        }

    
        //https://www.codeproject.com/questions/314681/make-directory-on-ftp-using-csharp
        public void check_FTF_file(string ipaddress, string username, string password)
        {
            try
            {
                var dt = DateTime.Now;

                string directory = dt.ToString("MM-dd-yyyy-h-mm-tt");
                //WebRequest request = WebRequest.Create("ftp://" + ipadress +  "/directory");
                WebRequest request = WebRequest.Create("ftp://" + ipaddress + "/" + directory);


                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                // request.Credentials = new NetworkCredential("Administrator", "Abcd@1234");
                request.Credentials = new NetworkCredential(username, password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                    App_listView.Items.Add(new ListViewItem(new String[] { ipaddress, "FTP", "Available", resp.StatusCode.ToString() }));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                App_listView.Items.Add(new ListViewItem(new String[] { ipaddress, "FTP", "Unvailable", ex.Message }));


            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {

            Application_Monitoring obj_oop = new Application_Monitoring(ipadressbox.Text, username_textBox.Text, password_textBox.Text, "");

               App_listView.Items.Add(new ListViewItem(new String[] { obj_oop.get_ip_address(), "SMTP", obj_oop.SMTP_Connection , obj_oop.SMTP_status, obj_oop.get_alert()}));

                 App_listView.Items.Add(new ListViewItem(new String[] { obj_oop.get_ip_address(), "FTP", obj_oop.FTP_Connection, obj_oop.FTP_status, obj_oop.get_alert() }));



            //     App_listView.Items.Add(new ListViewItem(new String[] { ip_address, "SMTP", "Available", reader.ReadLine() }));

            //check_smtp(ipadressbox.Text);

            //check_FTF_file(ipadressbox.Text, username_textBox.Text , password_textBox.Text);
        }
    }

            //IIS 
            // https://forums.iis.net/p/1191870/2031127.aspx?Re+Get+FTP+State+using+VBScript+WMI
        }
        
    

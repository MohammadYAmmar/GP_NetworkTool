using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Design by Ahmed 26/3/2021
namespace Project_GP6_Dashboard
{
    public partial class Form_Forgot_your_password : Form
    {
        public Form_Forgot_your_password()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Creating and setting the properties of Lable1
            Label Mylablel = new Label();
            Mylablel.Location = new Point(96, 54);
            Mylablel.Text = "Enter Password";
            Mylablel.AutoSize = true;
            Mylablel.BackColor = Color.LightGray;

            // Add this label to form
            this.Controls.Add(Mylablel);

            // Creating and setting the properties of TextBox1
            TextBox Mytextbox = new TextBox();
            Mytextbox.Location = new Point(187, 51);
            Mytextbox.BackColor = Color.LightGray;
            Mytextbox.ForeColor = Color.DarkOliveGreen;
            Mytextbox.AutoSize = true;
            Mytextbox.Name = "text_box1";
            Mytextbox.UseSystemPasswordChar = true;

            // Add this textbox to form
            this.Controls.Add(Mytextbox);

        }

        private void Forgot_your_password_Load(object sender, EventArgs e)
        {

        }

        private void button_fast_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();

            // windows_home.FormBorderStyle.Sizable;

            //https://www.sololearn.com/Discuss/1807338/how-to-create-flexible-in-c-windows-form-application
            //  windows_home.FormBorderStyle = FormBorderStyle.FixedToolWindow;

          //  windows_home.Size = new Size(250, 200) ;
            windows_home.Show();

            this.Hide();
        }

        private void Log_in_button_Click(object sender, EventArgs e)
        {
            Begin_Log_in_Form windows_home = new Begin_Log_in_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void send_button_Click(object sender, EventArgs e)
        {


            if (name_textBox.Text == string.Empty || email_textBox.Text == string.Empty || phone_number_textBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter your name and email and phone number", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Send_Email_Forgot_your_password_HTML(name_textBox.Text, email_textBox.Text, phone_number_textBox.Text);

            }

        }

        public void Send_Email_Forgot_your_password_HTML(string name, string email, string phone_number)

        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("GP6 monitoring tool", "Ea.Section2018@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("HelpDesk", "Ahmed.alejil66@gmail.com"));

            //run
            //mailMessage.To.Add(new MailboxAddress("Administrator", "Ahmed.alejil66@gmail.com"));

            mailMessage.Cc.Add(new MailboxAddress("Administrator", "world.m.y.a@gmail.com"));


            //
            mailMessage.Subject = ("Technical Support: Register user information for monitoring tool");
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
                  Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_email.htm"));

            string email_new = original_Email.Replace("user_name", name);


            string email_new3 = email_new.Replace("Info00", "Welcome, you have a new request to register a new user to the network monitoring tool from: name: " + name + "  , email: " 
                + email +", and phone number: "+ phone_number +
                ".   Please register and inform him as soon as possible.");

            /*
            "Welcome, we want to alert you to a network problem, which is issued by" +
                                " the following devices (" + name_in_database + " with IP: " + ip_address + "), With the following problems: " + massage_error + " \n Please act quickly. \n" +
                            
            */

            //   string email_new4 = email_new3.Replace("images/Layer_default.png", "https://www.dropbox.com/s/4l6j3nfil22klnp/Layer_physical_false.png?raw=1");

           

            var dt = DateTime.Now;
            string name_of_email_file = dt.ToString("MM-dd-yyyy-h-mm-tt");


            System.IO.File.WriteAllText(
            //#todo
            //      Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_last_sent.htm"), email_new4);
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_email_sent" + name_of_email_file + ".htm"), email_new3);

            //


            mailMessage.Body = new TextPart("html")
            {
                Text = //email_new
                System.IO.File.ReadAllText(
                // Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_last_sent.htm"))
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"index_email_sent" + name_of_email_file + ".htm"))
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.SharePoint.Client;

using System.Security;
//using Microsoft.SharePoint.Client;
//using System.Net;
//using Microsoft.SharePoint.Client;

namespace Project_GP6_Dashboard
{
    public partial class Form_Sharepoint : Form
    {
        public Form_Sharepoint()
        {
            InitializeComponent();
        }

        private void Form_Sharepoint_Load(object sender, EventArgs e)
        {

            // Program.BindItemsToDropDownList();




           // Sharepoint_Monitoring obj = new Sharepoint_Monitoring();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        //private void list_button_Click(object sender, EventArgs e)
        //{
        //    Program.GetList(); // more in program
        //}

        private void start_button_Click(object sender, EventArgs e)
        {
            //        public static ClientContext MSOnlineHelperClassAuth_GP6(string username_sharepoint, string password_sharepoint, string SiteUrl)

            //  string state_share_point = MsOnlineClaimsHelper.MSOnlineHelperClassAuth_GP6(username_textBox.Text, password_textBox.Text, website_box.Text);

            //   sharepoint_listView.Items.Add(new ListViewItem(new String[] { website_box.Text, state_share_point }));



            //MsOnlineClaimsHelper.MSOnlineHelperClassAuth_GP6("https://taibahuniv.sharepoint.com/sites/GP6_Site/");


            //https://www.codesharepoint.com/sharepoint-tutorial/connect-to-sharepoint-online-on-premise-and-extranet-using-csom
            Sharepoint_Monitoring sharepoint_Monitoring = new Sharepoint_Monitoring();
            // Provide Site URL
            string SiteURL = website_box.Text;

            // Provide the environment in which the site resides. One of the below options.
            // (i) onpremises (ii) o365 (iii) extranet
            string Environmentvalue = "o365";
            string username = username_textBox.Text;
            string password = password_textBox.Text;
            sharepoint_Monitoring.AuthenticateUser(new Uri(SiteURL), Environmentvalue, username, password);

            MessageBox.Show("Connection");

        }

        private void back_home_button_Click(object sender, EventArgs e)
        {

            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            this.Hide();
        }
    }//class
}

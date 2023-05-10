using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
//using NetFlow;

//3/3/2021 with meet ahmed

// 6/3/2021 by mohammad test in WMI


//12-3-2021 Mohammad used a tool to find out most of the elements in the server by wbemtest in windows + R

//2-4-2021 move all to class by Mohammad
namespace Project_GP6_Dashboard
{
    public partial class Form_Firewall : Form
    {
        public Form_Firewall()
        {
            InitializeComponent();
        }

        private void Form_Firewall_Load(object sender, EventArgs e)
        {

        }

        //
     

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //https://stackoverflow.com/questions/6943205/detect-if-windows-firewall-is-blocking-my-program
       
       

       

        private void Ports_listView_SelectedIndexChanged(object sender, EventArgs e)
        //   private void Ports_listView_SelectedIndexChanged(object sender, MouseEventArgs e)

        {

        }

        //_MouseClick


        private void Ports_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Ports_listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }




      

        private void testWithGP1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //     PingHost(Ports_listView.SelectedItems[0].Text.ToString());
            MessageBox.Show(Ports_listView.SelectedItems[0].Text.ToString());


        }


      
        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void MSFT_Firewall_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void testWithGP1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

   

        private void button_MSFT_NetFirewallRule_Click_1(object sender, EventArgs e)
        {
            Firewall_Monitoring obj = new Firewall_Monitoring(ip_textBox.Text, username_textBox.Text, password_textBox.Text);

            obj.Check_MSFT_firewall();



       List<string[]> MSFT_firewall_list_temp = obj.MSFT_firewall_list;


            foreach (string [] i in MSFT_firewall_list_temp)
            {

                  MSFT_Firewall_listView.Items.Add(new ListViewItem(i));

            }



        }

     
   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ip_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_port_button_Click_1(object sender, EventArgs e)
        {
            string[] name_of_ports = {"Connection to Web (HTTP)", "Connection to Mail (SMTP) for routing between mail servers"
                    , "Connection to Mail (POP3)","Connection to DNS","Connection to (FTP) data transfer" ,"Connection to (FTP) data control"};

            string[] list_of_ports = {"80", "25", "110","53","20" ,"21"};

            Firewall_Monitoring obj_port = new Firewall_Monitoring(ip_textBox.Text);
            obj_port.check_ports();

            for(int i = 0; i < 6; i++)
            {
                obj_port.check_TCP_port(name_of_ports[i], list_of_ports[i]);
                Ports_listView.Items.Add(new ListViewItem(new String[] { obj_port.get_ip_address(), obj_port.port_name, obj_port.port, obj_port.port_state }));
            }
        
        }

        private void Ports_listView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void scan_button_Click(object sender, EventArgs e)
        {
            Firewall_Monitoring obj = new Firewall_Monitoring(ip_textBox.Text, username_textBox.Text, password_textBox.Text);



            
            obj.Check_MSFT_firewall();

            List<string[]> MSFT_firewall_list_temp = obj.MSFT_firewall_list;


            foreach (string[] i in MSFT_firewall_list_temp)
            {
                MSFT_Firewall_listView.Items.Add(new ListViewItem(i));
            }


            string[] name_of_ports = {"Connection to Web (HTTP)", "Connection to Mail (SMTP) for routing between mail servers"
                    , "Connection to Mail (POP3)","Connection to DNS","Connection to (FTP) data transfer" ,"Connection to (FTP) data control"};

            string[] list_of_ports = { "80", "25", "110", "53", "20", "21" };

            Firewall_Monitoring obj_port = new Firewall_Monitoring(ip_textBox.Text);
            obj_port.check_ports();

            for (int i = 0; i < 6; i++)
            {
                obj_port.check_TCP_port(name_of_ports[i], list_of_ports[i]);
                Ports_listView.Items.Add(new ListViewItem(new String[] { obj_port.get_ip_address(), obj_port.port_name, obj_port.port, obj_port.port_state }));
            }


        }

    }




}


    


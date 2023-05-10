using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Design by Ahmed 26/3/2021
namespace Project_GP6_Dashboard
{
    public partial class Begin_Log_in_Form : Form
    {
        public Begin_Log_in_Form()
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

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                // MessageBox.Show("enter");

                /*
                //add the handler to the textbox
this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
                */

                if (username_textBox.Text == string.Empty || password_textBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter your username and password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((username_textBox.Text == "Admin" || username_textBox.Text == "admin") && password_textBox.Text == "Admin")
                {
                    Dashboard_Form windows_home = new Dashboard_Form();
                    windows_home.Show();
                    this.Hide();
                }
                else if ((username_textBox.Text == "Ahmed" || username_textBox.Text == "ahmed") && password_textBox.Text == "Ahmed98")
                {
                    Dashboard_Form windows_home = new Dashboard_Form();
                    windows_home.Show();
                    this.Hide();
                }
                else if ((username_textBox.Text == "Mohammad" || username_textBox.Text == "mohammad") && password_textBox.Text == "Mohammad98")
                {
                    Dashboard_Form windows_home = new Dashboard_Form();
                    windows_home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid password. Please try again", "Signin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Begin_Log_in_Form_Load(object sender, EventArgs e)
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
            if(username_textBox.Text == string.Empty  || password_textBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter your username and password", "Login", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if ((username_textBox.Text == "Admin" || username_textBox.Text == "admin") && password_textBox.Text == "Admin")
            {
                Dashboard_Form windows_home = new Dashboard_Form();
                windows_home.Show();
                this.Hide();
            }
            else if ((username_textBox.Text == "Ahmed" || username_textBox.Text == "ahmed") && password_textBox.Text == "Ahmed98")
            {
                Dashboard_Form windows_home = new Dashboard_Form();
                windows_home.Show();
                this.Hide();
            }
            else if ((username_textBox.Text == "Mohammad" || username_textBox.Text == "mohammad") && password_textBox.Text == "Mohammad98")
            {
                Dashboard_Form windows_home = new Dashboard_Form();
                windows_home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid password. Please try again", "Signin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Forgot_your_password windows_home = new Form_Forgot_your_password();

            windows_home.Show();

            this.Hide();
        }
    }
}


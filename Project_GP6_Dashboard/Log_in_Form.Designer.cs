
//namespace Project_GP6_Dashboard
//{
//    partial class Log_in_Form

namespace Project_GP6_Dashboard
{
    partial class Log_in_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login = new System.Windows.Forms.Panel();
            this.sign_in_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_fast = new System.Windows.Forms.Button();
            this.Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(84)))), ((int)(((byte)(103)))));
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.Controls.Add(this.button_fast);
            this.Login.Controls.Add(this.sign_in_button);
            this.Login.Controls.Add(this.label3);
            this.Login.Controls.Add(this.label2);
            this.Login.Controls.Add(this.label1);
            this.Login.Controls.Add(this.textBox2);
            this.Login.Controls.Add(this.textBox1);
            this.Login.Dock = System.Windows.Forms.DockStyle.Left;
            this.Login.Location = new System.Drawing.Point(0, 0);
            this.Login.Margin = new System.Windows.Forms.Padding(5);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(582, 941);
            this.Login.TabIndex = 1;
            // 
            // sign_in_button
            // 
            this.sign_in_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.sign_in_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sign_in_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in_button.ForeColor = System.Drawing.Color.Black;
            this.sign_in_button.Location = new System.Drawing.Point(127, 596);
            this.sign_in_button.Margin = new System.Windows.Forms.Padding(5);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(318, 91);
            this.sign_in_button.TabIndex = 6;
            this.sign_in_button.Text = "Sign In";
            this.sign_in_button.UseVisualStyleBackColor = false;
            this.sign_in_button.Click += new System.EventHandler(this.sign_in_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(34, 430);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(34, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(203, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 76);
            this.label1.TabIndex = 2;
            this.label1.Text = "GP6";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 430);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 36);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 330);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 36);
            this.textBox1.TabIndex = 0;
            // 
            // button_fast
            // 
            this.button_fast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.button_fast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_fast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fast.ForeColor = System.Drawing.Color.Black;
            this.button_fast.Location = new System.Drawing.Point(127, 755);
            this.button_fast.Margin = new System.Windows.Forms.Padding(5);
            this.button_fast.Name = "button_fast";
            this.button_fast.Size = new System.Drawing.Size(318, 109);
            this.button_fast.TabIndex = 7;
            this.button_fast.Text = "Fast log in , remove later";
            this.button_fast.UseVisualStyleBackColor = false;
            this.button_fast.Click += new System.EventHandler(this.button_fast_Click);
            // 
            // Log_in_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 941);
            this.Controls.Add(this.Login);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Log_in_Form";
            this.Text = "GP6login";
            this.Load += new System.EventHandler(this.Log_in_Form_Load);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Login;
        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_fast;
    }
}


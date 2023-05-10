
namespace Project_GP6_Dashboard
{
    partial class Form_Firewall
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader IP;
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MSFT_Firewall_listView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testWithGP1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_MSFT_NetFirewallRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.check_port_button = new System.Windows.Forms.Button();
            this.back_home_button = new System.Windows.Forms.Button();
            this.scan_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Name_Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ports_listView = new System.Windows.Forms.ListView();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "IP address";
            columnHeader1.Width = 131;
            // 
            // IP
            // 
            IP.Text = "IP address";
            IP.Width = 131;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ElementName";
            this.columnHeader2.Width = 197;
            // 
            // MSFT_Firewall_listView
            // 
            this.MSFT_Firewall_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.MSFT_Firewall_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.MSFT_Firewall_listView.ContextMenuStrip = this.contextMenuStrip1;
            this.MSFT_Firewall_listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.MSFT_Firewall_listView.HideSelection = false;
            this.MSFT_Firewall_listView.Location = new System.Drawing.Point(18, 396);
            this.MSFT_Firewall_listView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MSFT_Firewall_listView.Name = "MSFT_Firewall_listView";
            this.MSFT_Firewall_listView.Size = new System.Drawing.Size(1036, 226);
            this.MSFT_Firewall_listView.TabIndex = 28;
            this.MSFT_Firewall_listView.UseCompatibleStateImageBehavior = false;
            this.MSFT_Firewall_listView.View = System.Windows.Forms.View.Details;
            this.MSFT_Firewall_listView.SelectedIndexChanged += new System.EventHandler(this.MSFT_Firewall_listView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DisplayName";
            this.columnHeader3.Width = 186;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testWithGP1ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 28);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // testWithGP1ToolStripMenuItem
            // 
            this.testWithGP1ToolStripMenuItem.Name = "testWithGP1ToolStripMenuItem";
            this.testWithGP1ToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.testWithGP1ToolStripMenuItem.Text = "Test with GP1";
            this.testWithGP1ToolStripMenuItem.Click += new System.EventHandler(this.testWithGP1ToolStripMenuItem_Click_1);
            // 
            // button_MSFT_NetFirewallRule
            // 
            this.button_MSFT_NetFirewallRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.button_MSFT_NetFirewallRule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_MSFT_NetFirewallRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_MSFT_NetFirewallRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button_MSFT_NetFirewallRule.Location = new System.Drawing.Point(848, 51);
            this.button_MSFT_NetFirewallRule.Margin = new System.Windows.Forms.Padding(1);
            this.button_MSFT_NetFirewallRule.Name = "button_MSFT_NetFirewallRule";
            this.button_MSFT_NetFirewallRule.Size = new System.Drawing.Size(184, 34);
            this.button_MSFT_NetFirewallRule.TabIndex = 25;
            this.button_MSFT_NetFirewallRule.Text = "MSFT_NetFirewallRule";
            this.button_MSFT_NetFirewallRule.UseVisualStyleBackColor = false;
            this.button_MSFT_NetFirewallRule.Click += new System.EventHandler(this.button_MSFT_NetFirewallRule_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Server IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ip_textBox
            // 
            this.ip_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.ip_textBox.Location = new System.Drawing.Point(130, 54);
            this.ip_textBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(213, 22);
            this.ip_textBox.TabIndex = 21;
            this.ip_textBox.Text = "192.168.1";
            this.ip_textBox.TextChanged += new System.EventHandler(this.ip_textBox_TextChanged);
            // 
            // check_port_button
            // 
            this.check_port_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.check_port_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.check_port_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_port_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.check_port_button.Location = new System.Drawing.Point(848, 7);
            this.check_port_button.Margin = new System.Windows.Forms.Padding(1);
            this.check_port_button.Name = "check_port_button";
            this.check_port_button.Size = new System.Drawing.Size(184, 34);
            this.check_port_button.TabIndex = 19;
            this.check_port_button.Text = "Check ports";
            this.check_port_button.UseVisualStyleBackColor = false;
            this.check_port_button.Click += new System.EventHandler(this.check_port_button_Click_1);
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(18, 8);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(238, 36);
            this.back_home_button.TabIndex = 36;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // scan_button
            // 
            this.scan_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.scan_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scan_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.scan_button.Location = new System.Drawing.Point(605, 7);
            this.scan_button.Margin = new System.Windows.Forms.Padding(1);
            this.scan_button.Name = "scan_button";
            this.scan_button.Size = new System.Drawing.Size(184, 34);
            this.scan_button.TabIndex = 37;
            this.scan_button.Text = "Scan";
            this.scan_button.UseVisualStyleBackColor = false;
            this.scan_button.Click += new System.EventHandler(this.scan_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(462, 51);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(118, 22);
            this.password_textBox.TabIndex = 42;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(462, 19);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(118, 22);
            this.username_textBox.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(349, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 34);
            this.label8.TabIndex = 40;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label7.Location = new System.Drawing.Point(349, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 34);
            this.label7.TabIndex = 39;
            this.label7.Text = "Username:";
            // 
            // Name_Port
            // 
            this.Name_Port.Text = "Name of port";
            this.Name_Port.Width = 171;
            // 
            // Port
            // 
            this.Port.Text = "Port";
            this.Port.Width = 81;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 586;
            // 
            // Ports_listView
            // 
            this.Ports_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Ports_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            IP,
            this.Name_Port,
            this.Port,
            this.Status});
            this.Ports_listView.ContextMenuStrip = this.contextMenuStrip1;
            this.Ports_listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.Ports_listView.HideSelection = false;
            this.Ports_listView.Location = new System.Drawing.Point(18, 89);
            this.Ports_listView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Ports_listView.Name = "Ports_listView";
            this.Ports_listView.Size = new System.Drawing.Size(1036, 265);
            this.Ports_listView.TabIndex = 22;
            this.Ports_listView.UseCompatibleStateImageBehavior = false;
            this.Ports_listView.View = System.Windows.Forms.View.Details;
            this.Ports_listView.SelectedIndexChanged += new System.EventHandler(this.Ports_listView_SelectedIndexChanged_1);
            // 
            // Form_Firewall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1070, 637);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.scan_button);
            this.Controls.Add(this.back_home_button);
            this.Controls.Add(this.MSFT_Firewall_listView);
            this.Controls.Add(this.button_MSFT_NetFirewallRule);
            this.Controls.Add(this.Ports_listView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ip_textBox);
            this.Controls.Add(this.check_port_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1088, 684);
            this.MinimumSize = new System.Drawing.Size(1088, 684);
            this.Name = "Form_Firewall";
            this.Text = " Firewall monitoring";
            this.Load += new System.EventHandler(this.Form_Firewall_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView MSFT_Firewall_listView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testWithGP1ToolStripMenuItem;
        private System.Windows.Forms.Button button_MSFT_NetFirewallRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_textBox;
        private System.Windows.Forms.Button check_port_button;
        private System.Windows.Forms.Button back_home_button;
        private System.Windows.Forms.Button scan_button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader Name_Port;
        private System.Windows.Forms.ColumnHeader Port;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ListView Ports_listView;
    }
}
namespace Project_GP6_Dashboard
{
    partial class Form_OS
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listVAddr = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Handles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Downtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.conMenuStripIP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openNetworkFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gP1GP6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IP_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scan_button = new System.Windows.Forms.Button();
            this.scan_p_button = new System.Windows.Forms.Button();
            this.load_file_button = new System.Windows.Forms.Button();
            this.back_home_button = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.scan_p_obj_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.network_listView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conMenuStripIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listVAddr
            // 
            this.listVAddr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.listVAddr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Status,
            this.Hostname,
            this.CPU,
            this.Thread,
            this.Handles,
            this.Downtime});
            this.listVAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listVAddr.HideSelection = false;
            this.listVAddr.Location = new System.Drawing.Point(8, 229);
            this.listVAddr.Margin = new System.Windows.Forms.Padding(4);
            this.listVAddr.Name = "listVAddr";
            this.listVAddr.Size = new System.Drawing.Size(1236, 128);
            this.listVAddr.TabIndex = 1;
            this.listVAddr.UseCompatibleStateImageBehavior = false;
            this.listVAddr.View = System.Windows.Forms.View.Details;
            this.listVAddr.SelectedIndexChanged += new System.EventHandler(this.listVAddr_SelectedIndexChanged);
            this.listVAddr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listVAddr_MouseClick);
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 109;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 180;
            // 
            // Hostname
            // 
            this.Hostname.Text = "Hostname";
            this.Hostname.Width = 241;
            // 
            // CPU
            // 
            this.CPU.Text = "CPU usage";
            this.CPU.Width = 292;
            // 
            // Thread
            // 
            this.Thread.Text = "ThreadCount";
            this.Thread.Width = 333;
            // 
            // Handles
            // 
            this.Handles.Text = "Handles";
            this.Handles.Width = 285;
            // 
            // Downtime
            // 
            this.Downtime.Text = "Downtime";
            this.Downtime.Width = 311;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 174);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(754, 46);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // conMenuStripIP
            // 
            this.conMenuStripIP.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.conMenuStripIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNetworkFolderToolStripMenuItem,
            this.showInfoToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.gP1GP6ToolStripMenuItem});
            this.conMenuStripIP.Name = "conMenuStripIP";
            this.conMenuStripIP.Size = new System.Drawing.Size(221, 124);
            this.conMenuStripIP.Opening += new System.ComponentModel.CancelEventHandler(this.conMenuStripIP_Opening);
            // 
            // openNetworkFolderToolStripMenuItem
            // 
            this.openNetworkFolderToolStripMenuItem.Name = "openNetworkFolderToolStripMenuItem";
            this.openNetworkFolderToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.openNetworkFolderToolStripMenuItem.Text = "Open Network Folder";
            this.openNetworkFolderToolStripMenuItem.Click += new System.EventHandler(this.openNetworkFolderToolStripMenuItem_Click);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.rebootToolStripMenuItem.Text = "Reboot";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
            // 
            // gP1GP6ToolStripMenuItem
            // 
            this.gP1GP6ToolStripMenuItem.Name = "gP1GP6ToolStripMenuItem";
            this.gP1GP6ToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.gP1GP6ToolStripMenuItem.Text = "GP1 | GP6";
            this.gP1GP6ToolStripMenuItem.Click += new System.EventHandler(this.gP1GP6ToolStripMenuItem_Click);
            // 
            // IP_textBox
            // 
            this.IP_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_textBox.Location = new System.Drawing.Point(369, 12);
            this.IP_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.IP_textBox.Name = "IP_textBox";
            this.IP_textBox.Size = new System.Drawing.Size(213, 37);
            this.IP_textBox.TabIndex = 9;
            this.IP_textBox.Text = "192.168.1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Enter Server IP Address:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // scan_button
            // 
            this.scan_button.Location = new System.Drawing.Point(0, 0);
            this.scan_button.Margin = new System.Windows.Forms.Padding(2);
            this.scan_button.Name = "scan_button";
            this.scan_button.Size = new System.Drawing.Size(46, 13);
            this.scan_button.TabIndex = 14;
            this.scan_button.Click += new System.EventHandler(this.scan_button_Click);
            // 
            // scan_p_button
            // 
            this.scan_p_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.scan_p_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scan_p_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_p_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.scan_p_button.Location = new System.Drawing.Point(997, 65);
            this.scan_p_button.Margin = new System.Windows.Forms.Padding(4);
            this.scan_p_button.Name = "scan_p_button";
            this.scan_p_button.Size = new System.Drawing.Size(248, 47);
            this.scan_p_button.TabIndex = 16;
            this.scan_p_button.Text = "Scan P";
            this.scan_p_button.UseVisualStyleBackColor = false;
            this.scan_p_button.Click += new System.EventHandler(this.scan_p_button_Click);
            // 
            // load_file_button
            // 
            this.load_file_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.load_file_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.load_file_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_file_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.load_file_button.Location = new System.Drawing.Point(997, 114);
            this.load_file_button.Margin = new System.Windows.Forms.Padding(4);
            this.load_file_button.Name = "load_file_button";
            this.load_file_button.Size = new System.Drawing.Size(246, 47);
            this.load_file_button.TabIndex = 17;
            this.load_file_button.Text = "Load scan P";
            this.load_file_button.UseVisualStyleBackColor = false;
            this.load_file_button.Click += new System.EventHandler(this.load_file_button_Click);
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(997, 169);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(248, 47);
            this.back_home_button.TabIndex = 40;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(8, 506);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            series2.ShadowOffset = 1;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Disk size";
            this.chart2.Series.Add(series1);
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(1236, 147);
            this.chart2.TabIndex = 41;
            this.chart2.Text = "chart_OS";
            // 
            // scan_p_obj_button
            // 
            this.scan_p_obj_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.scan_p_obj_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scan_p_obj_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_p_obj_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.scan_p_obj_button.Location = new System.Drawing.Point(996, 10);
            this.scan_p_obj_button.Margin = new System.Windows.Forms.Padding(4);
            this.scan_p_obj_button.Name = "scan_p_obj_button";
            this.scan_p_obj_button.Size = new System.Drawing.Size(248, 47);
            this.scan_p_obj_button.TabIndex = 42;
            this.scan_p_obj_button.Text = "Scan  OOP";
            this.scan_p_obj_button.UseVisualStyleBackColor = false;
            this.scan_p_obj_button.Click += new System.EventHandler(this.scan_p_obj_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(369, 94);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(213, 22);
            this.password_textBox.TabIndex = 46;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(369, 62);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(213, 22);
            this.username_textBox.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(209, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 32);
            this.label8.TabIndex = 44;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label7.Location = new System.Drawing.Point(209, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 32);
            this.label7.TabIndex = 43;
            this.label7.Text = "Username:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(57, 5);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 29);
            this.lblStatus.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(369, 133);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 37);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(242, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // network_listView
            // 
            this.network_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.network_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.network_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F);
            this.network_listView.HideSelection = false;
            this.network_listView.Location = new System.Drawing.Point(9, 365);
            this.network_listView.Margin = new System.Windows.Forms.Padding(4);
            this.network_listView.Name = "network_listView";
            this.network_listView.Size = new System.Drawing.Size(1235, 135);
            this.network_listView.TabIndex = 47;
            this.network_listView.UseCompatibleStateImageBehavior = false;
            this.network_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name of modem";
            this.columnHeader11.Width = 159;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "BytesReceivedPerSec";
            this.columnHeader12.Width = 269;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "BytesSentPerSec";
            this.columnHeader13.Width = 213;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "BytesTotalPerSec";
            this.columnHeader14.Width = 218;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "CurrentBandwidth";
            this.columnHeader15.Width = 180;
            // 
            // Form_OS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1271, 665);
            this.Controls.Add(this.network_listView);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.scan_p_obj_button);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.back_home_button);
            this.Controls.Add(this.load_file_button);
            this.Controls.Add(this.scan_p_button);
            this.Controls.Add(this.scan_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IP_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listVAddr);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1049, 712);
            this.Name = "Form_OS";
            this.Text = "OS monitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.conMenuStripIP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ListView listVAddr;
        public System.Windows.Forms.ColumnHeader IP;
        public System.Windows.Forms.ColumnHeader Hostname;
        public System.Windows.Forms.ColumnHeader Status;
        public System.Windows.Forms.ContextMenuStrip conMenuStripIP;
        public System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openNetworkFolderToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem gP1GP6ToolStripMenuItem;
        public System.Windows.Forms.TextBox IP_textBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button scan_button;
        public System.Windows.Forms.ColumnHeader CPU;
        public System.Windows.Forms.ColumnHeader Downtime;
        public System.Windows.Forms.ColumnHeader Handles;
        public System.Windows.Forms.ColumnHeader Thread;
        public System.Windows.Forms.Button scan_p_button;
        public System.Windows.Forms.Button load_file_button;
        public System.Windows.Forms.Button back_home_button;
        public System.Windows.Forms.Button scan_p_obj_button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView network_listView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader11;
        public System.Windows.Forms.ColumnHeader columnHeader12;
        public System.Windows.Forms.ColumnHeader columnHeader13;
        public System.Windows.Forms.ColumnHeader columnHeader14;
        public System.Windows.Forms.ColumnHeader columnHeader15;
    }
}


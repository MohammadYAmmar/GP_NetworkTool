
namespace Project_GP6_Dashboard
{
    partial class Form_IIS_DNS
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_load_file_P = new System.Windows.Forms.Button();
            this.button_scan_P = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.back_home_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DNS_listView = new System.Windows.Forms.ListView();
            this.Website = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Timer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.dns_button = new System.Windows.Forms.Button();
            this.Automatic_check_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IIS_WMI_listView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.HTTP_listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.websitebox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipadressbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1917, 951);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.panel2.Controls.Add(this.button_load_file_P);
            this.panel2.Controls.Add(this.button_scan_P);
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Controls.Add(this.back_home_button);
            this.panel2.Controls.Add(this.password_textBox);
            this.panel2.Controls.Add(this.username_textBox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.DNS_listView);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dns_button);
            this.panel2.Controls.Add(this.Automatic_check_button);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.IIS_WMI_listView);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.HTTP_listview);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.websitebox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ipadressbox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1900, 934);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button_load_file_P
            // 
            this.button_load_file_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_load_file_P.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_load_file_P.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load_file_P.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_load_file_P.Location = new System.Drawing.Point(794, 47);
            this.button_load_file_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_load_file_P.Name = "button_load_file_P";
            this.button_load_file_P.Size = new System.Drawing.Size(347, 37);
            this.button_load_file_P.TabIndex = 35;
            this.button_load_file_P.Text = "Load database in parallel";
            this.button_load_file_P.UseVisualStyleBackColor = false;
            this.button_load_file_P.Click += new System.EventHandler(this.button_load_file_P_Click);
            // 
            // button_scan_P
            // 
            this.button_scan_P.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.button_scan_P.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_scan_P.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_scan_P.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_scan_P.Location = new System.Drawing.Point(963, 3);
            this.button_scan_P.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_scan_P.Name = "button_scan_P";
            this.button_scan_P.Size = new System.Drawing.Size(178, 37);
            this.button_scan_P.TabIndex = 34;
            this.button_scan_P.Text = "Start Scanning P";
            this.button_scan_P.UseVisualStyleBackColor = false;
            this.button_scan_P.Click += new System.EventHandler(this.button_scan_P_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(9, 559);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "TotalGetRequests";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "TotalHeadRequests";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "FilesSentPerSec";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "FilesReceivedPerSec";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "AnonymousUsersPerSec";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "CurrentNonAnonymousUsers";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "CGIRequestsPerSec";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "GetRequestsPerSec";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "PostRequestsPerSec";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "NotFoundErrorsPerSec";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(1885, 350);
            this.chart1.TabIndex = 33;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(1436, 2);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(272, 38);
            this.back_home_button.TabIndex = 32;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(649, 50);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(118, 22);
            this.password_textBox.TabIndex = 29;
            this.password_textBox.UseSystemPasswordChar = true;
            this.password_textBox.TextChanged += new System.EventHandler(this.password_textBox_TextChanged);
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(649, 18);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(118, 22);
            this.username_textBox.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(536, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 34);
            this.label8.TabIndex = 27;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(536, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 34);
            this.label7.TabIndex = 26;
            this.label7.Text = "Username:";
            // 
            // DNS_listView
            // 
            this.DNS_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.DNS_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Website,
            this.IP,
            this.Timer});
            this.DNS_listView.HideSelection = false;
            this.DNS_listView.Location = new System.Drawing.Point(1179, 135);
            this.DNS_listView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DNS_listView.Name = "DNS_listView";
            this.DNS_listView.Size = new System.Drawing.Size(715, 142);
            this.DNS_listView.TabIndex = 25;
            this.DNS_listView.UseCompatibleStateImageBehavior = false;
            this.DNS_listView.View = System.Windows.Forms.View.Details;
            this.DNS_listView.SelectedIndexChanged += new System.EventHandler(this.DNS_listView_SelectedIndexChanged);
            // 
            // Website
            // 
            this.Website.Text = "Website";
            this.Website.Width = 142;
            // 
            // IP
            // 
            this.IP.Text = "IP of the website";
            this.IP.Width = 122;
            // 
            // Timer
            // 
            this.Timer.Text = "Response & loading time of a webpage";
            this.Timer.Width = 404;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(1173, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 34);
            this.label6.TabIndex = 24;
            this.label6.Text = "DNS:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dns_button
            // 
            this.dns_button.BackColor = System.Drawing.Color.Wheat;
            this.dns_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dns_button.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dns_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dns_button.Location = new System.Drawing.Point(1146, 47);
            this.dns_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dns_button.Name = "dns_button";
            this.dns_button.Size = new System.Drawing.Size(284, 37);
            this.dns_button.TabIndex = 23;
            this.dns_button.Text = "DNS info";
            this.dns_button.UseVisualStyleBackColor = false;
            this.dns_button.Click += new System.EventHandler(this.dns_button_Click);
            // 
            // Automatic_check_button
            // 
            this.Automatic_check_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Automatic_check_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Automatic_check_button.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Automatic_check_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Automatic_check_button.Location = new System.Drawing.Point(1146, 3);
            this.Automatic_check_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Automatic_check_button.Name = "Automatic_check_button";
            this.Automatic_check_button.Size = new System.Drawing.Size(284, 37);
            this.Automatic_check_button.TabIndex = 21;
            this.Automatic_check_button.Text = "Automatic update";
            this.Automatic_check_button.UseVisualStyleBackColor = false;
            this.Automatic_check_button.Click += new System.EventHandler(this.Automatic_check_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(2, 516);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 34);
            this.label5.TabIndex = 17;
            this.label5.Text = "Charts:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(2, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 34);
            this.label4.TabIndex = 14;
            this.label4.Text = "Data:";
            // 
            // IIS_WMI_listView
            // 
            this.IIS_WMI_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.IIS_WMI_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader18,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.IIS_WMI_listView.HideSelection = false;
            this.IIS_WMI_listView.Location = new System.Drawing.Point(9, 314);
            this.IIS_WMI_listView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.IIS_WMI_listView.Name = "IIS_WMI_listView";
            this.IIS_WMI_listView.Size = new System.Drawing.Size(1886, 193);
            this.IIS_WMI_listView.TabIndex = 13;
            this.IIS_WMI_listView.UseCompatibleStateImageBehavior = false;
            this.IIS_WMI_listView.View = System.Windows.Forms.View.Details;
            this.IIS_WMI_listView.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IP";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Name";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "TotalGetRequests";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "TotalHeadRequests";
            this.columnHeader9.Width = 220;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "FilesSentPerSec";
            this.columnHeader10.Width = 180;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "FilesReceivedPerSec";
            this.columnHeader11.Width = 220;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "AnonymousUsersPerSec";
            this.columnHeader12.Width = 260;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "CurrentNonAnonymousUsers";
            this.columnHeader13.Width = 300;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "CGIRequestsPerSec";
            this.columnHeader14.Width = 220;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "GetRequestsPerSec";
            this.columnHeader15.Width = 210;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "PostRequestsPerSec";
            this.columnHeader16.Width = 220;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "NotFoundErrorsPerSec";
            this.columnHeader17.Width = 300;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(2, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "Data from WMI:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // HTTP_listview
            // 
            this.HTTP_listview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.HTTP_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.HTTP_listview.HideSelection = false;
            this.HTTP_listview.Location = new System.Drawing.Point(9, 135);
            this.HTTP_listview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HTTP_listview.Name = "HTTP_listview";
            this.HTTP_listview.Size = new System.Drawing.Size(1143, 142);
            this.HTTP_listview.TabIndex = 5;
            this.HTTP_listview.UseCompatibleStateImageBehavior = false;
            this.HTTP_listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Website";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Server availability";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Website availability";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "More information";
            this.columnHeader5.Width = 190;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "HTTP information";
            this.columnHeader6.Width = 300;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(794, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start Scanning";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // websitebox
            // 
            this.websitebox.Location = new System.Drawing.Point(290, 49);
            this.websitebox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.websitebox.Name = "websitebox";
            this.websitebox.Size = new System.Drawing.Size(230, 22);
            this.websitebox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the IIS of the Website:";
            // 
            // ipadressbox
            // 
            this.ipadressbox.Location = new System.Drawing.Point(290, 18);
            this.ipadressbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ipadressbox.Name = "ipadressbox";
            this.ipadressbox.Size = new System.Drawing.Size(230, 22);
            this.ipadressbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Server IP Address:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form_IIS_DNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1917, 951);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(1935, 998);
            this.Name = "Form_IIS_DNS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "IIS GP6";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Panel panel2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ListView HTTP_listview;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.TextBox websitebox;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox ipadressbox;
            private System.Windows.Forms.ColumnHeader columnHeader1;
            private System.Windows.Forms.ColumnHeader columnHeader2;
            private System.Windows.Forms.ColumnHeader columnHeader3;
            private System.Windows.Forms.ColumnHeader columnHeader4;
            private System.Windows.Forms.ColumnHeader columnHeader5;
            private System.Windows.Forms.ColumnHeader columnHeader6;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.ListView IIS_WMI_listView;
            private System.Windows.Forms.ColumnHeader columnHeader7;
            private System.Windows.Forms.ColumnHeader columnHeader8;
            private System.Windows.Forms.ColumnHeader columnHeader9;
            private System.Windows.Forms.ColumnHeader columnHeader10;
            private System.Windows.Forms.ColumnHeader columnHeader11;
            private System.Windows.Forms.ColumnHeader columnHeader12;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.ColumnHeader columnHeader13;
            private System.Windows.Forms.ColumnHeader columnHeader14;
            private System.Windows.Forms.ColumnHeader columnHeader15;
            private System.Windows.Forms.ColumnHeader columnHeader16;
            private System.Windows.Forms.ColumnHeader columnHeader17;
            private System.Windows.Forms.ColumnHeader columnHeader18;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Button Automatic_check_button;
            private System.Windows.Forms.Button dns_button;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.ListView DNS_listView;
            private System.Windows.Forms.ColumnHeader IP;
            private System.Windows.Forms.ColumnHeader Timer;
            private System.Windows.Forms.ColumnHeader Website;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.TextBox password_textBox;
            private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Button back_home_button;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_scan_P;
        private System.Windows.Forms.Button button_load_file_P;
    }
    }


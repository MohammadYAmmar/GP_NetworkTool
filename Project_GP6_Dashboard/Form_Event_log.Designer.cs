
namespace Project_GP6_Dashboard
{

        partial class Form_Event_log
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
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Event_listView = new System.Windows.Forms.ListView();
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RecordNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeWritten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.scan_oop_button = new System.Windows.Forms.Button();
            this.get_event_Parallel_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.back_home_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.file_manual_button = new System.Windows.Forms.Button();
            this.Load_file_auto_button = new System.Windows.Forms.Button();
            this.Cahrts = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityAuditSuccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityAuditFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Get_Event_Log = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Text = "IP address";
            this.IP.Width = 120;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(78)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1783, 667);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.Event_listView);
            this.panel2.Controls.Add(this.monthCalendar1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(14, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.MinimumSize = new System.Drawing.Size(1400, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1756, 599);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Event Data";
            // 
            // Event_listView
            // 
            this.Event_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Event_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Message,
            this.ComputerName,
            this.Type,
            this.EventType,
            this.EventCode,
            this.SourceName,
            this.RecordNumber,
            this.TimeWritten});
            this.Event_listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.Event_listView.HideSelection = false;
            this.Event_listView.Location = new System.Drawing.Point(326, 61);
            this.Event_listView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Event_listView.MinimumSize = new System.Drawing.Size(1047, 436);
            this.Event_listView.Name = "Event_listView";
            this.Event_listView.Size = new System.Drawing.Size(1245, 514);
            this.Event_listView.TabIndex = 10;
            this.Event_listView.UseCompatibleStateImageBehavior = false;
            this.Event_listView.View = System.Windows.Forms.View.Details;
            this.Event_listView.SelectedIndexChanged += new System.EventHandler(this.Event_listView_SelectedIndexChanged);
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 90;
            // 
            // ComputerName
            // 
            this.ComputerName.Text = "ComputerName";
            this.ComputerName.Width = 110;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // EventType
            // 
            this.EventType.Text = "EventType";
            this.EventType.Width = 105;
            // 
            // EventCode
            // 
            this.EventCode.Text = "EventCode";
            this.EventCode.Width = 110;
            // 
            // SourceName
            // 
            this.SourceName.Text = "SourceName";
            this.SourceName.Width = 110;
            // 
            // RecordNumber
            // 
            this.RecordNumber.Text = "RecordNumber";
            this.RecordNumber.Width = 110;
            // 
            // TimeWritten
            // 
            this.TimeWritten.Text = "TimeWritten";
            this.TimeWritten.Width = 110;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(6, 93);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(14)))), ((int)(((byte)(10)))));
            this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.password_textBox);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.username_textBox);
            this.panel4.Controls.Add(this.scan_oop_button);
            this.panel4.Controls.Add(this.get_event_Parallel_button);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.ip_textBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1590, 33);
            this.panel4.TabIndex = 9;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(697, -2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password:";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(819, 0);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(213, 22);
            this.password_textBox.TabIndex = 18;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(358, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Username:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(480, 2);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(213, 22);
            this.username_textBox.TabIndex = 16;
            // 
            // scan_oop_button
            // 
            this.scan_oop_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.scan_oop_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scan_oop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_oop_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.scan_oop_button.Location = new System.Drawing.Point(1057, 0);
            this.scan_oop_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.scan_oop_button.Name = "scan_oop_button";
            this.scan_oop_button.Size = new System.Drawing.Size(251, 33);
            this.scan_oop_button.TabIndex = 14;
            this.scan_oop_button.Text = "Get Event Log (OOP) ";
            this.scan_oop_button.UseVisualStyleBackColor = false;
            this.scan_oop_button.Click += new System.EventHandler(this.scan_oop_button_Click);
            // 
            // get_event_Parallel_button
            // 
            this.get_event_Parallel_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(218)))), ((int)(((byte)(220)))));
            this.get_event_Parallel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.get_event_Parallel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.get_event_Parallel_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.get_event_Parallel_button.Location = new System.Drawing.Point(1335, -1);
            this.get_event_Parallel_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.get_event_Parallel_button.Name = "get_event_Parallel_button";
            this.get_event_Parallel_button.Size = new System.Drawing.Size(251, 33);
            this.get_event_Parallel_button.TabIndex = 13;
            this.get_event_Parallel_button.Text = "Get Event Log (Parallel) ";
            this.get_event_Parallel_button.UseVisualStyleBackColor = false;
            this.get_event_Parallel_button.Click += new System.EventHandler(this.get_event_Parallel_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ip_textBox
            // 
            this.ip_textBox.Location = new System.Drawing.Point(129, 4);
            this.ip_textBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(213, 22);
            this.ip_textBox.TabIndex = 1;
            this.ip_textBox.Text = "192.168.1.";
            this.ip_textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.panel3.Controls.Add(this.back_home_button);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.file_manual_button);
            this.panel3.Controls.Add(this.Load_file_auto_button);
            this.panel3.Controls.Add(this.Cahrts);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Controls.Add(this.clear_button);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.Get_Event_Log);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1590, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 599);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_home_button.ForeColor = System.Drawing.SystemColors.Control;
            this.back_home_button.Location = new System.Drawing.Point(-1, 505);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(164, 70);
            this.back_home_button.TabIndex = 12;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(-1, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 74);
            this.button1.TabIndex = 11;
            this.button1.Text = "Automatic check";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Automatic_check_Click);
            // 
            // file_manual_button
            // 
            this.file_manual_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.file_manual_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.file_manual_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_manual_button.ForeColor = System.Drawing.SystemColors.Control;
            this.file_manual_button.Location = new System.Drawing.Point(-1, 335);
            this.file_manual_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.file_manual_button.Name = "file_manual_button";
            this.file_manual_button.Size = new System.Drawing.Size(164, 88);
            this.file_manual_button.TabIndex = 10;
            this.file_manual_button.Text = "Load file manual ";
            this.file_manual_button.UseVisualStyleBackColor = false;
            this.file_manual_button.Click += new System.EventHandler(this.file_manual_button_Click);
            // 
            // Load_file_auto_button
            // 
            this.Load_file_auto_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.Load_file_auto_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Load_file_auto_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_file_auto_button.ForeColor = System.Drawing.SystemColors.Control;
            this.Load_file_auto_button.Location = new System.Drawing.Point(-1, 269);
            this.Load_file_auto_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Load_file_auto_button.Name = "Load_file_auto_button";
            this.Load_file_auto_button.Size = new System.Drawing.Size(164, 63);
            this.Load_file_auto_button.TabIndex = 9;
            this.Load_file_auto_button.Text = "Load file automatically";
            this.Load_file_auto_button.UseVisualStyleBackColor = false;
            this.Load_file_auto_button.Click += new System.EventHandler(this.Load_file_auto_button_Click);
            // 
            // Cahrts
            // 
            this.Cahrts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.Cahrts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cahrts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cahrts.ForeColor = System.Drawing.SystemColors.Control;
            this.Cahrts.Location = new System.Drawing.Point(0, 210);
            this.Cahrts.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Cahrts.Name = "Cahrts";
            this.Cahrts.Size = new System.Drawing.Size(164, 56);
            this.Cahrts.TabIndex = 8;
            this.Cahrts.Text = "Chart";
            this.Cahrts.UseVisualStyleBackColor = false;
            this.Cahrts.Click += new System.EventHandler(this.Cahrts_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(166, 33);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorToolStripMenuItem,
            this.warningToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.securityAuditSuccessToolStripMenuItem,
            this.securityAuditFailureToolStripMenuItem});
            this.itemsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.errorToolStripMenuItem.Text = "Error";
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.errorToolStripMenuItem_Click_1);
            // 
            // warningToolStripMenuItem
            // 
            this.warningToolStripMenuItem.Name = "warningToolStripMenuItem";
            this.warningToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.warningToolStripMenuItem.Text = "Warning";
            this.warningToolStripMenuItem.Click += new System.EventHandler(this.warningToolStripMenuItem_Click_1);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click_1);
            // 
            // securityAuditSuccessToolStripMenuItem
            // 
            this.securityAuditSuccessToolStripMenuItem.Name = "securityAuditSuccessToolStripMenuItem";
            this.securityAuditSuccessToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.securityAuditSuccessToolStripMenuItem.Text = "Security Audit Success";
            this.securityAuditSuccessToolStripMenuItem.Click += new System.EventHandler(this.securityAuditSuccessToolStripMenuItem_Click_1);
            // 
            // securityAuditFailureToolStripMenuItem
            // 
            this.securityAuditFailureToolStripMenuItem.Name = "securityAuditFailureToolStripMenuItem";
            this.securityAuditFailureToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.securityAuditFailureToolStripMenuItem.Text = "Security Audit Failure";
            this.securityAuditFailureToolStripMenuItem.Click += new System.EventHandler(this.securityAuditFailureToolStripMenuItem_Click_1);
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_button.ForeColor = System.Drawing.SystemColors.Control;
            this.clear_button.Location = new System.Drawing.Point(0, 151);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(164, 56);
            this.clear_button.TabIndex = 6;
            this.clear_button.Text = "Clear list";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(0, 92);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Get_Event_Log
            // 
            this.Get_Event_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.Get_Event_Log.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Get_Event_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Get_Event_Log.ForeColor = System.Drawing.SystemColors.Control;
            this.Get_Event_Log.Location = new System.Drawing.Point(0, 33);
            this.Get_Event_Log.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Get_Event_Log.Name = "Get_Event_Log";
            this.Get_Event_Log.Size = new System.Drawing.Size(164, 56);
            this.Get_Event_Log.TabIndex = 4;
            this.Get_Event_Log.Text = "Get Event Log";
            this.Get_Event_Log.UseVisualStyleBackColor = false;
            this.Get_Event_Log.Click += new System.EventHandler(this.Event_Log_Click);
            // 
            // Form_Event_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1785, 626);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1803, 673);
            this.MinimumSize = new System.Drawing.Size(1187, 588);
            this.Name = "Form_Event_log";
            this.Text = "EventLog monitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Panel panel2;
            private System.Windows.Forms.ListView Event_listView;
            private System.Windows.Forms.ColumnHeader Message;
            private System.Windows.Forms.ColumnHeader ComputerName;
            private System.Windows.Forms.ColumnHeader Type;
            private System.Windows.Forms.ColumnHeader EventType;
            private System.Windows.Forms.ColumnHeader EventCode;
            private System.Windows.Forms.ColumnHeader SourceName;
            private System.Windows.Forms.ColumnHeader RecordNumber;
            private System.Windows.Forms.ColumnHeader TimeWritten;
            private System.Windows.Forms.Panel panel4;
            private System.Windows.Forms.MonthCalendar monthCalendar1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox ip_textBox;
            private System.Windows.Forms.Panel panel3;
            private System.Windows.Forms.Button clear_button;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button Get_Event_Log;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem warningToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem securityAuditSuccessToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem securityAuditFailureToolStripMenuItem;
            private System.Windows.Forms.Button Cahrts;
            private System.Windows.Forms.Button Load_file_auto_button;
            private System.Windows.Forms.Button file_manual_button;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button back_home_button;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.Button get_event_Parallel_button;
        private System.Windows.Forms.Button scan_oop_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_textBox;
    }
    }


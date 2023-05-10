
namespace Project_GP6_Dashboard
{
    partial class Form_Database
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
            this.Database_listView = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.N_database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COUNT_STAR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COUNT_FETCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_WAIT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_WRITE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_READ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_FETCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_INSERT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipadressbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.back_home_button = new System.Windows.Forms.Button();
            this.table_textBox = new System.Windows.Forms.TextBox();
            this.users_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.current_connections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_scan_OOP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Database_listView
            // 
            this.Database_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Database_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.N_database,
            this.Status,
            this.COUNT_STAR,
            this.COUNT_FETCH,
            this.AVG_TIMER_WAIT,
            this.AVG_TIMER_WRITE,
            this.AVG_TIMER_READ,
            this.AVG_TIMER_FETCH,
            this.AVG_TIMER_INSERT});
            this.Database_listView.HideSelection = false;
            this.Database_listView.Location = new System.Drawing.Point(8, 108);
            this.Database_listView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Database_listView.Name = "Database_listView";
            this.Database_listView.Size = new System.Drawing.Size(1468, 166);
            this.Database_listView.TabIndex = 14;
            this.Database_listView.UseCompatibleStateImageBehavior = false;
            this.Database_listView.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 120;
            // 
            // N_database
            // 
            this.N_database.Text = "Name of table in database";
            this.N_database.Width = 175;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 77;
            // 
            // COUNT_STAR
            // 
            this.COUNT_STAR.Text = "Count star";
            this.COUNT_STAR.Width = 88;
            // 
            // COUNT_FETCH
            // 
            this.COUNT_FETCH.Text = "Count fetch";
            this.COUNT_FETCH.Width = 98;
            // 
            // AVG_TIMER_WAIT
            // 
            this.AVG_TIMER_WAIT.Text = "Average timer wait";
            this.AVG_TIMER_WAIT.Width = 143;
            // 
            // AVG_TIMER_WRITE
            // 
            this.AVG_TIMER_WRITE.Text = "Average timer write";
            this.AVG_TIMER_WRITE.Width = 145;
            // 
            // AVG_TIMER_READ
            // 
            this.AVG_TIMER_READ.Text = "Average timer read";
            this.AVG_TIMER_READ.Width = 157;
            // 
            // AVG_TIMER_FETCH
            // 
            this.AVG_TIMER_FETCH.Text = "Average timer fetch";
            this.AVG_TIMER_FETCH.Width = 140;
            // 
            // AVG_TIMER_INSERT
            // 
            this.AVG_TIMER_INSERT.Text = "Average timer insert";
            this.AVG_TIMER_INSERT.Width = 146;
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(567, 53);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(118, 22);
            this.password_textBox.TabIndex = 38;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(567, 21);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(118, 22);
            this.username_textBox.TabIndex = 37;
            this.username_textBox.TextChanged += new System.EventHandler(this.username_textBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(454, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 34);
            this.label8.TabIndex = 36;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label7.Location = new System.Drawing.Point(454, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 34);
            this.label7.TabIndex = 35;
            this.label7.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(2, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 34);
            this.label2.TabIndex = 32;
            this.label2.Text = "Name of table in database:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ipadressbox
            // 
            this.ipadressbox.Location = new System.Drawing.Point(265, 23);
            this.ipadressbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ipadressbox.Name = "ipadressbox";
            this.ipadressbox.Size = new System.Drawing.Size(132, 22);
            this.ipadressbox.TabIndex = 31;
            this.ipadressbox.Text = "192.168.1.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(2, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 34);
            this.label1.TabIndex = 30;
            this.label1.Text = "Server IP Address:";
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(1230, 53);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(238, 32);
            this.back_home_button.TabIndex = 39;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // table_textBox
            // 
            this.table_textBox.Location = new System.Drawing.Point(265, 54);
            this.table_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_textBox.Name = "table_textBox";
            this.table_textBox.Size = new System.Drawing.Size(132, 22);
            this.table_textBox.TabIndex = 40;
            // 
            // users_listView
            // 
            this.users_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.users_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.User,
            this.Host,
            this.current_connections,
            this.columnHeader3});
            this.users_listView.HideSelection = false;
            this.users_listView.Location = new System.Drawing.Point(11, 298);
            this.users_listView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.users_listView.Name = "users_listView";
            this.users_listView.Size = new System.Drawing.Size(1468, 166);
            this.users_listView.TabIndex = 41;
            this.users_listView.UseCompatibleStateImageBehavior = false;
            this.users_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 120;
            // 
            // User
            // 
            this.User.Text = "User";
            // 
            // Host
            // 
            this.Host.Text = "Host";
            // 
            // current_connections
            // 
            this.current_connections.Text = "Current connections";
            this.current_connections.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total connections";
            this.columnHeader3.Width = 185;
            // 
            // button_scan_OOP
            // 
            this.button_scan_OOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.button_scan_OOP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_scan_OOP.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_scan_OOP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button_scan_OOP.Location = new System.Drawing.Point(1230, 9);
            this.button_scan_OOP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_scan_OOP.Name = "button_scan_OOP";
            this.button_scan_OOP.Size = new System.Drawing.Size(238, 37);
            this.button_scan_OOP.TabIndex = 42;
            this.button_scan_OOP.Text = "Start Scanning";
            this.button_scan_OOP.UseVisualStyleBackColor = false;
            this.button_scan_OOP.Click += new System.EventHandler(this.button_scan_OOP_Click);
            // 
            // Form_Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1490, 498);
            this.Controls.Add(this.button_scan_OOP);
            this.Controls.Add(this.users_listView);
            this.Controls.Add(this.table_textBox);
            this.Controls.Add(this.back_home_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipadressbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Database_listView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1049, 368);
            this.Name = "Form_Database";
            this.Text = "Database monitoring";
            this.Load += new System.EventHandler(this.Database_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Database_listView;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader N_database;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipadressbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back_home_button;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.TextBox table_textBox;
        private System.Windows.Forms.ColumnHeader COUNT_STAR;
        private System.Windows.Forms.ColumnHeader COUNT_FETCH;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_WAIT;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_WRITE;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_READ;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_FETCH;
        private System.Windows.Forms.ListView users_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader Host;
        private System.Windows.Forms.ColumnHeader current_connections;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_INSERT;
        private System.Windows.Forms.Button button_scan_OOP;
    }
}
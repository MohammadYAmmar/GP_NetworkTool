
namespace Project_GP6_Dashboard
{
    partial class Form_Cloud
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
            this.back_home_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.database_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipadressbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cloud_listView = new System.Windows.Forms.ListView();
            this.users_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.current_connections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Database_listView = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.N_database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COUNT_STAR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COUNT_FETCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_WAIT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_WRITE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_READ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_FETCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVG_TIMER_INSERT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.table_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(1253, 86);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(381, 58);
            this.back_home_button.TabIndex = 37;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(1018, 93);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(186, 31);
            this.password_textBox.TabIndex = 49;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(1018, 42);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(186, 31);
            this.username_textBox.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(837, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 51);
            this.label8.TabIndex = 47;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label7.Location = new System.Drawing.Point(837, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 51);
            this.label7.TabIndex = 46;
            this.label7.Text = "Username:";
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.start_button.Location = new System.Drawing.Point(1253, 18);
            this.start_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(381, 59);
            this.start_button.TabIndex = 45;
            this.start_button.Text = "Start Scanning";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // database_box
            // 
            this.database_box.Location = new System.Drawing.Point(453, 90);
            this.database_box.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.database_box.Name = "database_box";
            this.database_box.Size = new System.Drawing.Size(366, 31);
            this.database_box.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 51);
            this.label2.TabIndex = 43;
            this.label2.Text = "Enter the name of database:";
            // 
            // ipadressbox
            // 
            this.ipadressbox.Location = new System.Drawing.Point(453, 42);
            this.ipadressbox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ipadressbox.Name = "ipadressbox";
            this.ipadressbox.Size = new System.Drawing.Size(366, 31);
            this.ipadressbox.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 51);
            this.label1.TabIndex = 41;
            this.label1.Text = "Enter URL of Server:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Statuts";
            this.columnHeader8.Width = 1004;
            // 
            // Server
            // 
            this.Server.Text = "Server";
            this.Server.Width = 307;
            // 
            // Cloud_listView
            // 
            this.Cloud_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Cloud_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Server,
            this.columnHeader8});
            this.Cloud_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.Cloud_listView.HideSelection = false;
            this.Cloud_listView.Location = new System.Drawing.Point(12, 220);
            this.Cloud_listView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Cloud_listView.Name = "Cloud_listView";
            this.Cloud_listView.Size = new System.Drawing.Size(1975, 299);
            this.Cloud_listView.TabIndex = 40;
            this.Cloud_listView.UseCompatibleStateImageBehavior = false;
            this.Cloud_listView.View = System.Windows.Forms.View.Details;
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
            this.users_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.users_listView.HideSelection = false;
            this.users_listView.Location = new System.Drawing.Point(9, 823);
            this.users_listView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.users_listView.Name = "users_listView";
            this.users_listView.Size = new System.Drawing.Size(1978, 263);
            this.users_listView.TabIndex = 51;
            this.users_listView.UseCompatibleStateImageBehavior = false;
            this.users_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Server";
            this.columnHeader1.Width = 120;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 286;
            // 
            // Host
            // 
            this.Host.Text = "Host";
            this.Host.Width = 208;
            // 
            // current_connections
            // 
            this.current_connections.Text = "Current connections";
            this.current_connections.Width = 493;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total connections";
            this.columnHeader3.Width = 446;
            // 
            // Database_listView
            // 
            this.Database_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Database_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.N_database,
            this.COUNT_STAR,
            this.COUNT_FETCH,
            this.AVG_TIMER_WAIT,
            this.AVG_TIMER_WRITE,
            this.AVG_TIMER_READ,
            this.AVG_TIMER_FETCH,
            this.AVG_TIMER_INSERT});
            this.Database_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.Database_listView.HideSelection = false;
            this.Database_listView.Location = new System.Drawing.Point(9, 529);
            this.Database_listView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Database_listView.Name = "Database_listView";
            this.Database_listView.Size = new System.Drawing.Size(1978, 263);
            this.Database_listView.TabIndex = 50;
            this.Database_listView.UseCompatibleStateImageBehavior = false;
            this.Database_listView.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "Server";
            this.IP.Width = 120;
            // 
            // N_database
            // 
            this.N_database.Text = "Name of table in database";
            this.N_database.Width = 464;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 51);
            this.label3.TabIndex = 52;
            this.label3.Text = "Enter the name of table:";
            // 
            // table_textBox
            // 
            this.table_textBox.Location = new System.Drawing.Point(453, 146);
            this.table_textBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.table_textBox.Name = "table_textBox";
            this.table_textBox.Size = new System.Drawing.Size(366, 31);
            this.table_textBox.TabIndex = 53;
            // 
            // Form_Cloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(2016, 1111);
            this.Controls.Add(this.table_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.users_listView);
            this.Controls.Add(this.Database_listView);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.database_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipadressbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cloud_listView);
            this.Controls.Add(this.back_home_button);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1661, 543);
            this.Name = "Form_Cloud";
            this.Text = "Cloud monitoring";
            this.Load += new System.EventHandler(this.Form_Cloud_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back_home_button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.TextBox database_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipadressbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader Server;
        private System.Windows.Forms.ListView Cloud_listView;
        private System.Windows.Forms.ListView users_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader Host;
        private System.Windows.Forms.ColumnHeader current_connections;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView Database_listView;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader N_database;
        private System.Windows.Forms.ColumnHeader COUNT_STAR;
        private System.Windows.Forms.ColumnHeader COUNT_FETCH;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_WAIT;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_WRITE;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_READ;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_FETCH;
        private System.Windows.Forms.ColumnHeader AVG_TIMER_INSERT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox table_textBox;
    }
}
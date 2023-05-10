
namespace Project_GP6_Dashboard
{
    partial class Database_Management_Form

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
            this.back_home_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Insert_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ipadressbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DB_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conMenuStripIP_Action = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.table_textBox = new System.Windows.Forms.TextBox();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.password_DB_textBox = new System.Windows.Forms.TextBox();
            this.username_DB_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.refresh_button = new System.Windows.Forms.Button();
            this.conMenuStripIP_Action.SuspendLayout();
            this.SuspendLayout();
            // 
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(1100, 111);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(238, 36);
            this.back_home_button.TabIndex = 37;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(832, 59);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(230, 22);
            this.password_textBox.TabIndex = 49;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(342, 59);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(230, 22);
            this.username_textBox.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label8.Location = new System.Drawing.Point(588, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 34);
            this.label8.TabIndex = 47;
            this.label8.Text = "Password of server:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label7.Location = new System.Drawing.Point(11, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 34);
            this.label7.TabIndex = 46;
            this.label7.Text = "Username of server:";
            // 
            // Insert_button
            // 
            this.Insert_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Insert_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.Insert_button.Location = new System.Drawing.Point(1100, 21);
            this.Insert_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(238, 37);
            this.Insert_button.TabIndex = 45;
            this.Insert_button.Text = "Insert to database";
            this.Insert_button.UseVisualStyleBackColor = false;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 34);
            this.label2.TabIndex = 43;
            this.label2.Text = "Enter the name of table in database:";
            // 
            // ipadressbox
            // 
            this.ipadressbox.Location = new System.Drawing.Point(342, 22);
            this.ipadressbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ipadressbox.Name = "ipadressbox";
            this.ipadressbox.Size = new System.Drawing.Size(230, 22);
            this.ipadressbox.TabIndex = 42;
            this.ipadressbox.TextChanged += new System.EventHandler(this.ipadressbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 34);
            this.label1.TabIndex = 41;
            this.label1.Text = "Enter the IP address of Server:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "IP address";
            this.columnHeader8.Width = 159;
            // 
            // Server
            // 
            this.Server.Text = "Name";
            this.Server.Width = 104;
            // 
            // DB_listView
            // 
            this.DB_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.DB_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Server,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.DB_listView.ContextMenuStrip = this.conMenuStripIP_Action;
            this.DB_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.DB_listView.HideSelection = false;
            this.DB_listView.Location = new System.Drawing.Point(17, 193);
            this.DB_listView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DB_listView.Name = "DB_listView";
            this.DB_listView.Size = new System.Drawing.Size(1321, 454);
            this.DB_listView.TabIndex = 40;
            this.DB_listView.UseCompatibleStateImageBehavior = false;
            this.DB_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Password";
            this.columnHeader2.Width = 154;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Username of database";
            this.columnHeader4.Width = 292;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Password of database";
            this.columnHeader5.Width = 293;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Table";
            this.columnHeader6.Width = 158;
            // 
            // conMenuStripIP_Action
            // 
            this.conMenuStripIP_Action.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.conMenuStripIP_Action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.openNetworkFolderToolStripMenuItem});
            this.conMenuStripIP_Action.Name = "conMenuStripIP";
            this.conMenuStripIP_Action.Size = new System.Drawing.Size(221, 100);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.rebootToolStripMenuItem.Text = "Reboot";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // openNetworkFolderToolStripMenuItem
            // 
            this.openNetworkFolderToolStripMenuItem.Name = "openNetworkFolderToolStripMenuItem";
            this.openNetworkFolderToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.openNetworkFolderToolStripMenuItem.Text = "Open Network Folder";
            this.openNetworkFolderToolStripMenuItem.Click += new System.EventHandler(this.openNetworkFolderToolStripMenuItem_Click);
            // 
            // table_textBox
            // 
            this.table_textBox.Location = new System.Drawing.Point(342, 90);
            this.table_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.table_textBox.Name = "table_textBox";
            this.table_textBox.Size = new System.Drawing.Size(230, 22);
            this.table_textBox.TabIndex = 53;
            this.table_textBox.Text = "n/a";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(832, 25);
            this.name_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(230, 22);
            this.name_textBox.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(588, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 34);
            this.label4.TabIndex = 54;
            this.label4.Text = "Enter the name of Server:";
            // 
            // password_DB_textBox
            // 
            this.password_DB_textBox.Location = new System.Drawing.Point(832, 121);
            this.password_DB_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.password_DB_textBox.Name = "password_DB_textBox";
            this.password_DB_textBox.Size = new System.Drawing.Size(230, 22);
            this.password_DB_textBox.TabIndex = 59;
            this.password_DB_textBox.Text = "n/a";
            this.password_DB_textBox.UseSystemPasswordChar = true;
            // 
            // username_DB_textBox
            // 
            this.username_DB_textBox.Location = new System.Drawing.Point(342, 124);
            this.username_DB_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.username_DB_textBox.Name = "username_DB_textBox";
            this.username_DB_textBox.Size = new System.Drawing.Size(230, 22);
            this.username_DB_textBox.TabIndex = 58;
            this.username_DB_textBox.Text = "n/a";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label5.Location = new System.Drawing.Point(584, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 34);
            this.label5.TabIndex = 57;
            this.label5.Text = "Password of database:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label6.Location = new System.Drawing.Point(11, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 34);
            this.label6.TabIndex = 56;
            this.label6.Text = "Username of database:";
            // 
            // refresh_button
            // 
            this.refresh_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.refresh_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.refresh_button.Location = new System.Drawing.Point(1100, 64);
            this.refresh_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(238, 37);
            this.refresh_button.TabIndex = 60;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = false;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // Database_Management_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1349, 659);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.password_DB_textBox);
            this.Controls.Add(this.username_DB_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.table_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Insert_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipadressbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DB_listView);
            this.Controls.Add(this.back_home_button);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1045, 357);
            this.Name = "Database_Management_Form";
            this.Text = "Database Management Form";
            this.Load += new System.EventHandler(this.Database_Management_Load);
            this.conMenuStripIP_Action.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Button back_home_button;
            private System.Windows.Forms.TextBox password_textBox;
            private System.Windows.Forms.TextBox username_textBox;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.Button Insert_button;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox ipadressbox;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ColumnHeader columnHeader8;
            private System.Windows.Forms.ColumnHeader Server;
            private System.Windows.Forms.ListView DB_listView;
            private System.Windows.Forms.TextBox table_textBox;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password_DB_textBox;
        private System.Windows.Forms.TextBox username_DB_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ContextMenuStrip conMenuStripIP_Action;
        public System.Windows.Forms.ToolStripMenuItem openNetworkFolderToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.Button refresh_button;
    }
    }
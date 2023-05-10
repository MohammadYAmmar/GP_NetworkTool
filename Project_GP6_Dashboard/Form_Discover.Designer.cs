
namespace Project_GP6_Dashboard
{
    partial class Form_Discover
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.conMenuStripIP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openNetworkFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gP1GP6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scan_p_button = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdScan = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Discover_list = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.back_home_button = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.conMenuStripIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(33, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Range: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.label3.Location = new System.Drawing.Point(33, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(163, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 46);
            this.panel2.TabIndex = 15;
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
            // txtIP2
            // 
            this.txtIP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP2.Location = new System.Drawing.Point(397, 63);
            this.txtIP2.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(227, 37);
            this.txtIP2.TabIndex = 16;
            this.txtIP2.Text = "192.168.1.15";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(163, 63);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(227, 37);
            this.txtIP.TabIndex = 12;
            this.txtIP.Text = "192.168.1.1";
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
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.rebootToolStripMenuItem.Text = "Reboot";
            // 
            // gP1GP6ToolStripMenuItem
            // 
            this.gP1GP6ToolStripMenuItem.Name = "gP1GP6ToolStripMenuItem";
            this.gP1GP6ToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.gP1GP6ToolStripMenuItem.Text = "GP1 | GP6";
            // 
            // scan_p_button
            // 
            this.scan_p_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.scan_p_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scan_p_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_p_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.scan_p_button.Location = new System.Drawing.Point(692, 86);
            this.scan_p_button.Margin = new System.Windows.Forms.Padding(4);
            this.scan_p_button.Name = "scan_p_button";
            this.scan_p_button.Size = new System.Drawing.Size(150, 62);
            this.scan_p_button.TabIndex = 17;
            this.scan_p_button.Text = "Discover (parallel)";
            this.scan_p_button.UseVisualStyleBackColor = false;
            this.scan_p_button.Click += new System.EventHandler(this.scan_p_button_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.cmdStop.Enabled = false;
            this.cmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmdStop.Location = new System.Drawing.Point(692, 185);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(4);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(150, 39);
            this.cmdStop.TabIndex = 10;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdScan
            // 
            this.cmdScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(163)))), ((int)(((byte)(177)))));
            this.cmdScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.cmdScan.Location = new System.Drawing.Point(692, 13);
            this.cmdScan.Margin = new System.Windows.Forms.Padding(4);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(150, 62);
            this.cmdScan.TabIndex = 9;
            this.cmdScan.Text = "Discover";
            this.cmdScan.UseVisualStyleBackColor = false;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(54, 164);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(569, 46);
            this.progressBar1.TabIndex = 14;
            // 
            // Discover_list
            // 
            this.Discover_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.Discover_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Status,
            this.Hostname});
            this.Discover_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Discover_list.HideSelection = false;
            this.Discover_list.Location = new System.Drawing.Point(53, 232);
            this.Discover_list.Margin = new System.Windows.Forms.Padding(4);
            this.Discover_list.Name = "Discover_list";
            this.Discover_list.Size = new System.Drawing.Size(789, 589);
            this.Discover_list.TabIndex = 11;
            this.Discover_list.UseCompatibleStateImageBehavior = false;
            this.Discover_list.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 266;
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
            // back_home_button
            // 
            this.back_home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(62)))), ((int)(((byte)(96)))));
            this.back_home_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back_home_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_home_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.back_home_button.Location = new System.Drawing.Point(1, 2);
            this.back_home_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.back_home_button.Name = "back_home_button";
            this.back_home_button.Size = new System.Drawing.Size(220, 53);
            this.back_home_button.TabIndex = 33;
            this.back_home_button.Text = "Back to Dashboard";
            this.back_home_button.UseVisualStyleBackColor = false;
            this.back_home_button.Click += new System.EventHandler(this.back_home_button_Click);
            // 
            // Form_Discover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(893, 827);
            this.Controls.Add(this.back_home_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtIP2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.scan_p_button);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Discover_list);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(911, 874);
            this.MinimumSize = new System.Drawing.Size(911, 664);
            this.Name = "Form_Discover";
            this.Text = "Discover monitoring";
            this.Load += new System.EventHandler(this.Form_Discover_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.conMenuStripIP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ContextMenuStrip conMenuStripIP;
        private System.Windows.Forms.ToolStripMenuItem openNetworkFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gP1GP6ToolStripMenuItem;
        private System.Windows.Forms.Button scan_p_button;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView Discover_list;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Hostname;
        private System.Windows.Forms.Button back_home_button;
    }
}
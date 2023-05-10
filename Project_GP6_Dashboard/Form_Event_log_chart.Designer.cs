
//namespace Project_GP6_Dashboard
//{
//    partial class Form_Event_log_chart

namespace Project_GP6_Dashboard
{
    partial class Form_Event_log_chart
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
            this.pieChart_eventlog = new LiveCharts.WinForms.PieChart();
            this.SuspendLayout();
            // 
            // pieChart_eventlog
            // 
            this.pieChart_eventlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart_eventlog.Location = new System.Drawing.Point(0, 0);
            this.pieChart_eventlog.Name = "pieChart_eventlog";
            this.pieChart_eventlog.Size = new System.Drawing.Size(684, 449);
            this.pieChart_eventlog.TabIndex = 0;
            this.pieChart_eventlog.Text = "pieChart1";
            // 
            // Form_Event_log_chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(684, 449);
            this.Controls.Add(this.pieChart_eventlog);
            this.Name = "Form_Event_log_chart";
            this.Text = "Piechart of Eventlog";
            this.Load += new System.EventHandler(this.Form_Event_log_chart_Load_1);
            this.ResumeLayout(false);

        }

        private LiveCharts.WinForms.PieChart pieChart_eventlog;

        #endregion

        //  private LiveCharts.WinForms.PieChart pieChart1;
    }
}
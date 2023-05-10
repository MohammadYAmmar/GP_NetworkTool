using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Include the required namespace of LiveCharts
using LiveCharts;
using LiveCharts.Wpf;

namespace Project_GP6_Dashboard
{
    public partial class Form_Event_log_chart : Form
    {
        public Form_Event_log_chart()
        {
            InitializeComponent();
        }
		//private void Form_Event_log_chart_Load(object sender, EventArgs e)
  //      {

  //      }

        private void Form_Event_log_chart_Load_1(object sender, EventArgs e)
        {
            //   Define the label that will appear over the piece of the chart
            //  in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define a collection of items to display in the chart 
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Error",
                    Values = new ChartValues<double> {Form_Event_log.Error},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Warning",
                    Values = new ChartValues<double> {Form_Event_log.Warning},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Information",
                    Values = new ChartValues<double> {Form_Event_log.Information},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Security Audit Success",
                    Values = new ChartValues<double> {Form_Event_log.Security_Audit_Success},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Security Audit Failure",
                    Values = new ChartValues<double> {Form_Event_log.Security_Audit_Failure},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            // You can add a new item dinamically with the add method of the collection
            // Useful when you define the data dinamically and not statically


            // Define the collection of Values to display in the Pie Chart
            pieChart_eventlog.Series = piechartData;

            // Set the legend location to appear in the Right side of the chart
            pieChart_eventlog.LegendLocation = LegendLocation.Right;
        }

        //private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        //{

        //}
    }
}

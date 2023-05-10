using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Microsoft.Windows.EventTracing.HyperV;

namespace Project_GP6_Dashboard
{
    public partial class Form_Citrix : Form
    {
        public Form_Citrix()
        {
            InitializeComponent();
        }

        private void back_home_button_Click(object sender, EventArgs e)
        {
            Dashboard_Form windows_home = new Dashboard_Form();
            windows_home.Show();

            //Test
            this.Hide();
        }

        private void Form_Citrix_Load(object sender, EventArgs e)
        {

        }


        public void citrix_hyperv(){

            //     AppDomainInitializer hypercall 
            //https://docs.microsoft.com/en-us/dotnet/api/microsoft.windows.eventtracing.hyperv.ihypercall?view=trace-processor-dotnet-1.0


        }

        private void IIS_WMI_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

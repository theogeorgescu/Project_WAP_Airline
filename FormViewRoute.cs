using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlink_WAP_Project
{
    public partial class FormViewRoute : Form
    {
        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuRoute formMenuRouteReference;

        public FormViewRoute()
        {
            InitializeComponent();
        }

        public FormViewRoute(AirlinkCoordinator aCoord, FormMenuRoute callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuRouteReference = callerRefValue;
            for (int i = 1; i <= aCoord.getMaxRoute(); i++)
            {
                if (aCoord.routeExistCheck(i))
                {
                    string result = aCoord.routeList(i); ;
                    dataGridView1.Rows.Add(result);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuRouteReference.Show();
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

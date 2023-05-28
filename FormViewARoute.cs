using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Airlink_WAP_Project
{
    public partial class FormViewARoute : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuRoute formMenuRouteReference;
        public FormViewARoute()
        {
            InitializeComponent();
        }

        public FormViewARoute(AirlinkCoordinator aCoord, FormMenuRoute callerRefValue)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int id;
            //check if input not integer
            if (!int.TryParse(textBox2.Text, out id))
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add("Please enter a valid choice.");
            }
            //check if route exist
            else if (aCoord.routeExistCheck(id))
            {
                dataGridView2.Rows.Clear();
                string result = aCoord.viewARoute(id);
                dataGridView2.Rows.Add(result);
            }
            else
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add("The route does not exist.");
            }
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuRouteReference.Show();
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
        textBox2.Text = "";
        dataGridView2.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

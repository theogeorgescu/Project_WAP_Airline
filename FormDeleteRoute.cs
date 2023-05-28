using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlink_WAP_Project
{
    public partial class FormDeleteRoute : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuRoute formMenuRouteReference;

        public FormDeleteRoute()
        {
            InitializeComponent();
        }

        public FormDeleteRoute(AirlinkCoordinator aCoord, FormMenuRoute callerRefValue)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Text = "";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int id;
            //check if input not integer
            if (!int.TryParse(textBox2.Text, out id))
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Please enter a valid choice.";
            }
            //delete route
            else if (aCoord.deleteRoute(id))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Route with id " + id + " deleted.";
                dataGridView1.Rows.Clear();
                for (int i = 1; i <= aCoord.getMaxRoute(); i++)
                {
                    if (aCoord.routeExistCheck(i))
                    {
                        string result = aCoord.routeList(i); ;
                        dataGridView1.Rows.Add(result);
                    }
                }
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Route with id " + id + " was not found.";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuRouteReference.Show();
            this.Close();
        }
    }
}

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
    public partial class FormAddRoute : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuRoute formMenuRouteReference;

        public FormAddRoute()
        {
            InitializeComponent();
        }

        public FormAddRoute(AirlinkCoordinator aCoord, FormMenuRoute callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuRouteReference = callerRefValue;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int maxSeats;
            string origin = textBox2.Text;
            string destination = textBox3.Text;
            //check if input not integer and strings not empty
            if (int.TryParse(textBox1.Text, out maxSeats) && (maxSeats > 0) && origin != "" && destination != "")
            {
                aCoord.addRoute(origin, destination, maxSeats);
                label5.ForeColor = Color.Green;
                label5.Text = "Route was added successfully.";
            }
            else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Route was not added. All fields are required.";
            }
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label5.Text = "";
        }

        private void buttonBackToRoute_Click(object sender, EventArgs e)
        {
            formMenuRouteReference.Show();
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

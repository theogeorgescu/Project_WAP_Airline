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
    public partial class FormAddBooking : Form
    {
        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuBooking formMenuBookReference;

        public FormAddBooking()
        {
            InitializeComponent();
        }

        //constructor
        public FormAddBooking(AirlinkCoordinator aCoord, FormMenuBooking callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuBookReference = callerRefValue;
            for (int i = 1; i <= aCoord.getMaxCompanies(); i++)
            {
                if (aCoord.companyExistCheck(i))
                {
                    string result = aCoord.companyList(i); ;
                    dataGridView2.Rows.Add(result);
                }
            }
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int routeId, companyId;

            //check if input not integer
            if (!int.TryParse(textBox2.Text, out routeId))
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Please enter a valid choice.";
            }
            //check if input not integer
            if (!int.TryParse(textBox4.Text, out companyId))
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Please enter a valid choice.";
            }
            //check if company ID, route ID exist and empty seats > 0
            if (aCoord.companyExistCheck(companyId) && aCoord.routeExistCheck(routeId)
                && (aCoord.getEmptySeats(routeId) > 0) && aCoord.addBooking(routeId, companyId)
                && aCoord.addPassenger(routeId, companyId))
            {
                label4.ForeColor = Color.Green;
                label4.Text = "Booking was added successfully.";
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Booking was not added.";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuBookReference.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
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
    public partial class FormDeleteBooking : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuBooking formMenuBookReference;
        public FormDeleteBooking()
        {
            InitializeComponent();
        }

        public FormDeleteBooking(AirlinkCoordinator aCoord, FormMenuBooking callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuBookReference = callerRefValue;
            for (int i = 1; i <= aCoord.getMaxBookings(); i++)
            {
                if (aCoord.bookingExistCheck(i))
                {
                    string result = aCoord.bookingList(i); ;
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
            //delete booking
            else if (aCoord.deleteBooking(id))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Booking with id " + id + " was deleted.";
                dataGridView1.Rows.Clear();
                for (int i = 1; i <= aCoord.getMaxBookings(); i++)
                {
                    if (aCoord.bookingExistCheck(i))
                    {
                        string result = aCoord.bookingList(i); ;
                        dataGridView1.Rows.Add(result);
                    }
                }
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Booking with id " + id + " was not found.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuBookReference.Show();
            this.Close();
        }
    }
}

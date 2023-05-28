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
    public partial class FormMenuBooking : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormAirlink formAirlinkReference;
        public FormMenuBooking()
        {
            InitializeComponent();
        }

        public FormMenuBooking(AirlinkCoordinator aCoord, FormAirlink callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formAirlinkReference = callerRefValue;
        }

        private void buttonAddBooking_Click(object sender, EventArgs e)
        {
            FormAddBooking form = new FormAddBooking(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonViewBookings_Click(object sender, EventArgs e)
        {
            FormViewBooking form = new FormViewBooking(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonDeleteBooking_Click(object sender, EventArgs e)
        {
            FormDeleteBooking form = new FormDeleteBooking(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formAirlinkReference.Show();
            this.Close();
        }
    }
}

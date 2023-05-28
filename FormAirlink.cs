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
    public partial class FormAirlink : Form
    {

        AirlinkCoordinator aCoord;
        public FormAirlink()
        {
            InitializeComponent();
        }
        public FormAirlink(AirlinkCoordinator aCoord)
        {
            this.aCoord = aCoord;
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
            //terminates application
            Application.Exit();
        }

        private void buttonBookings_Click(object sender, EventArgs e)
        {
            FormMenuBooking form = new FormMenuBooking(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonRoutes_Click(object sender, EventArgs e)
        {
            FormMenuRoute form = new FormMenuRoute(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonCompanies_Click(object sender, EventArgs e)
        {
            FormMenuCompany form = new FormMenuCompany(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



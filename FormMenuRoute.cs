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
    public partial class FormMenuRoute : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormAirlink formAirlinkReference;

        public FormMenuRoute()
        {
            InitializeComponent();
        }

        public FormMenuRoute(AirlinkCoordinator aCoord, FormAirlink callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formAirlinkReference = callerRefValue;
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            formAirlinkReference.Show();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            FormDeleteRoute form = new FormDeleteRoute(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            FormViewRoute form = new FormViewRoute(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddRoute form = new FormAddRoute(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonAR_Click(object sender, EventArgs e)
        {
            FormViewARoute form = new FormViewARoute(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }
    }
}

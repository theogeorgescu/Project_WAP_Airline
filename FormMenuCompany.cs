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
    public partial class FormMenuCompany : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormAirlink formAirlinkReference;

        public FormMenuCompany()
        {
            InitializeComponent();
        }
        public FormMenuCompany(AirlinkCoordinator aCoord, FormAirlink callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formAirlinkReference = callerRefValue;
        }

        private void buttonAddCompany_Click(object sender, EventArgs e)
        {
            FormAddCompany form = new FormAddCompany(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonViewCompanies_Click(object sender, EventArgs e)
        {
            FormViewCompany form = new FormViewCompany(aCoord, this);
            form.Show();
            //hide current form
            this.Hide();
        }

        private void buttonDeleteCompanies_Click(object sender, EventArgs e)
        {
            FormDeleteCompany form = new FormDeleteCompany(aCoord, this);
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

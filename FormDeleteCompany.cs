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
    public partial class FormDeleteCompany : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuCompany formMenuCompanyReference;
        public FormDeleteCompany()
        {
            InitializeComponent();
        }

        public FormDeleteCompany(AirlinkCoordinator aCoord, FormMenuCompany callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuCompanyReference = callerRefValue;
            for (int i = 1; i <= aCoord.getMaxCompanies(); i++)
            {
                if (aCoord.companyExistCheck(i))
                {
                    string result = aCoord.companyList(i); ;
                    dataGridView1.Rows.Add(result);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            formMenuCompanyReference.Show();
            this.Close();
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
            //delete company
            else if (aCoord.deleteCompany(id))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Company with id " + id + " was deleted successfully.";
                dataGridView1.Rows.Clear();
                for (int i = 1; i <= aCoord.getMaxCompanies(); i++)
                {
                    if (aCoord.companyExistCheck(i))
                    {
                        string result = aCoord.companyList(i); ;
                        dataGridView1.Rows.Add(result);
                    }
                }
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Company with id " + id + " was not found.";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuCompanyReference.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

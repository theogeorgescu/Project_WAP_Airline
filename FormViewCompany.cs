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
    public partial class FormViewCompany : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuCompany formMenuCustReference;

        public FormViewCompany()
        {
            InitializeComponent();
        }

        public FormViewCompany(AirlinkCoordinator aCoord, FormMenuCompany callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuCustReference = callerRefValue;
            for (int i = 1; i <= aCoord.getMaxCompanies(); i++)
            {
                if (aCoord.companyExistCheck(i))
                {
                    string result = aCoord.companyList(i); ;
                    dataGridView1.Rows.Add(result);
                }
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuCustReference.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

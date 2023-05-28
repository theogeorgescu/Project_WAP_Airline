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
using System.Xml.Linq;

namespace Airlink_WAP_Project
{
    public partial class FormAddCompany : Form
    {

        AirlinkCoordinator aCoord;

        //this variable will be used to remember from where was called this form
        FormMenuCompany formMenuCompReference;
        public FormAddCompany()
        {
            InitializeComponent();
        }

        public FormAddCompany(AirlinkCoordinator aCoord, FormMenuCompany callerRefValue)
        {
            InitializeComponent();
            this.aCoord = aCoord;
            formMenuCompReference = callerRefValue;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string location = textBox3.Text;
            string phone = textBox1.Text;
            //check if strings not empty
            if (name != "" && location != "" && phone != "")
            {
                aCoord.addCompany(name, location, phone);
                label5.ForeColor = Color.Green;
                label5.Text = "Company " + name + " " + " was added successfully.";
            }
            else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Company " + name + " " + " was not added. All fields are required.";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label5.Text = "";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            formMenuCompReference.Show();
            this.Close();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbName_Validated(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(textBox2, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class LicenseDetails : Form
    {
        public License License { get; set; }

        LicenseService serviceLicense = new LicenseService();

        SoftwareService serviceSoft = new SoftwareService();
        public LicenseDetails()
        {
            InitializeComponent();
        }

        private void LicenseDetails_Load(object sender, EventArgs e)
        {
            if (License != null)
            {
                this.txtName.Text = License.LicenseName;
                this.rTxtTerms.Text = License.Terms;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool formIsValid = true;

            bool formIsValid1 = ValidateName();
            bool formIsValid2 = ValidateTerms();

            if(formIsValid1 && formIsValid2)
            {

            }
            else
            {
                formIsValid = false;
            }

            if(License != null && formIsValid)
            {
                License.LicenseName = this.txtName.Text;
                License.Terms = this.rTxtTerms.Text;

                serviceLicense.Update(License);
                this.Close();
            }
            else if(formIsValid)
            {
                License temp = new License();
                temp.LicenseName = this.txtName.Text;
                temp.Terms = this.rTxtTerms.Text;

                serviceLicense.Add(temp);
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(License != null)
            {
                bool isUsed = false;
                List<Software> temp = serviceSoft.GetList();

                foreach(var item in temp)
                {
                    if(item.LicenseID == License.ID)
                    {
                        isUsed = true;
                    }
                }

                if (!isUsed)
                {
                    serviceLicense.Delete(License);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This licens is being used cannot delete it");
                }
            }
            else
            {
                MessageBox.Show("select license from main form");
            }
        }

        private bool ValidateName()
        {
            bool isValid = true;

            if(this.txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Enter name of the license");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }

            return isValid;
        }

        private bool ValidateTerms()
        {
            bool isValid = true;

            if (this.rTxtTerms.Text == "")
            {
                errorProvider1.SetError(rTxtTerms, "Enter terms of the license");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(rTxtTerms, "");
            }

            return isValid;
        }
    }
}

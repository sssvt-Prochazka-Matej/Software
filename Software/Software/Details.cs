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
    public partial class Details : Form
    {

        public Software software { get; set; }

        SoftwareService serviceSoft = new SoftwareService();

        LicenseService serviceLicense = new LicenseService();


        public Details()
        {
            InitializeComponent();
            
        }

        private void Details_Load(object sender, EventArgs e)
        {
            List<License> licenses = serviceLicense.GetList();

            List<string> dataSource = new List<string>();

            foreach(var item in licenses)
            {
                dataSource.Add(item.LicenseName);
            }

            this.cmbLicense.DataSource = dataSource;
            if (software != null)
            {
                this.txtName.Text = software.Name;
                this.txtProvider.Text = software.Provider;
                this.txtVersion.Text = Convert.ToString(software.Version);
                this.txtRelease.Text = Convert.ToString(software.ReleaseDate);
                this.cmbLicense.Text = serviceLicense.GetLicenseName(software.LicenseID);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool formValid = true;

            bool formValid1 = ValidateName();
            bool formValid2 = ValidateProvider();
            bool formValid3 = ValidateVersion();
            bool formValid4 = ValidateDate();
            bool formValid5 = ValidateLicense();

            if(formValid1 && formValid2 && formValid3 && formValid4 && formValid5)
            {
                formValid = true;
            }
            else
            {
                formValid = false;
            }

            if (software != null && formValid)
            {
                software.Name = this.txtName.Text;
                software.Provider = this.txtProvider.Text;
                software.Version = Convert.ToInt32(this.txtVersion.Text);
                software.ReleaseDate = Convert.ToDateTime(this.txtRelease.Text);
                software.LicenseID = serviceLicense.GetLicenseId(this.cmbLicense.Text);
            
                serviceSoft.Update(software);
                this.Close();

            }
            else if(formValid)
            {
                Software temp = new Software();
                temp.Name = this.txtName.Text;
                temp.Provider = this.txtProvider.Text;
                temp.Version = Convert.ToInt32(this.txtVersion.Text);
                temp.ReleaseDate = Convert.ToDateTime(this.txtRelease.Text);
                temp.LicenseID = serviceLicense.GetLicenseId(this.cmbLicense.Text);

                serviceSoft.Add(temp);
                this.Close();

            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(software != null)
            {
                serviceSoft.Delete(software);
                this.Close();
            }
            else
            {
                MessageBox.Show("select a software in table in the main form");
            }
        }


        private bool ValidateName()
        {
            bool isValid = true;

            if(this.txtName.Text.Length < 1 || this.txtName.Text.Length > 50)
            {
                this.errorProvider1.SetError(txtName, "Zadej jmeno v rozsahu 1 - 50 zanků");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(txtName, "");
            }

            return isValid;
        }

        private bool ValidateProvider()
        {
            bool isValid = true;

            if (this.txtProvider.Text.Length < 1 || this.txtProvider.Text.Length > 50)
            {
                this.errorProvider1.SetError(txtProvider, "Zadej providera v rozsahu 1 - 50 zanků");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(txtProvider, "");
            }

            return isValid;
        }

        private bool ValidateVersion()
        {
            bool isValid = true;
            if (this.txtVersion.Text == "")
            {
                errorProvider1.SetError(txtVersion, "Please enter your Age");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtVersion, "");
                try
                {
                    int temp = Convert.ToInt32(this.txtVersion.Text); 
                    
                    if(temp < 1 && temp > 30)
                    {
                        errorProvider1.SetError(txtVersion, "Please enter number between 1 and 30");
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtVersion, "Please enter your version as a number");
                    isValid = false;
                }
                
            }

            return isValid;
        }


        private bool ValidateDate()
        {
            bool isValid = true;

            if (this.txtRelease.Text == "")
            {
                errorProvider1.SetError(txtRelease, "Please enter release date");
                isValid = false;
            }
            else 
            {
                errorProvider1.SetError(txtRelease, "");
                try
                {
                    DateTime temp = Convert.ToDateTime(this.txtRelease.Text);

                    if(temp > DateTime.Now)
                    {
                        errorProvider1.SetError(txtRelease, "Please enter release date in past");
                        isValid = false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtRelease, "Please enter valid date (dd.mm.yy)");
                    isValid = false;
                }
            }

            return isValid;
        }

        private bool ValidateLicense()
        {
            bool isValid = false;

            List<License> licenses = serviceLicense.GetList();

            foreach(var item in licenses)
            {
                if(item.LicenseName == this.cmbLicense.Text)
                {
                    errorProvider1.SetError(cmbLicense, "");
                    isValid = true;
                }
            }
            if (!isValid)
            {
                errorProvider1.SetError(cmbLicense, "select value from combobox");
            }
            
            return isValid;
        }
    }
}

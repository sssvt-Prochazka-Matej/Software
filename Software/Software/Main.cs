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
    public partial class Main : Form
    {

        Details detailForm = new Details();

        LicenseDetails licenseDetailForm = new LicenseDetails();

        SoftwareService serviceSoft = new SoftwareService();

        LicenseService licenseService = new LicenseService();
        

        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = serviceSoft.GetList();
            this.dataGridView2.DataSource = licenseService.GetList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Software> temp = serviceSoft.GetList();

            Software tempSoft = temp[e.RowIndex];

            
            this.detailForm = new Details();
            this.detailForm.software = tempSoft;

            this.detailForm.ShowDialog(this);

            this.dataGridView1.DataSource = serviceSoft.GetList();


        }

        private void button1_Click(object sender, EventArgs e) //add software
        {
            
            this.detailForm = new Details();
            this.detailForm.ShowDialog(this);

            this.dataGridView1.DataSource = serviceSoft.GetList();

        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<License> templist = licenseService.GetList();

            License temp = templist[e.RowIndex];

            this.licenseDetailForm = new LicenseDetails();
            this.licenseDetailForm.License = temp;

            this.licenseDetailForm.ShowDialog(this);

            this.dataGridView2.DataSource = licenseService.GetList();
        }

        private void button2_Click(object sender, EventArgs e) // add license
        {
            this.licenseDetailForm = new LicenseDetails();
            this.licenseDetailForm.ShowDialog(this);

            this.dataGridView2.DataSource = licenseService.GetList();
        }
    }
}

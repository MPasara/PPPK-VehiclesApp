using PPPK.DAO;
using PPPK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK
{
    public partial class DriversForm : Form
    {
        private static Driver selectedDriver;
        public DriversForm()
        {
            InitializeComponent();
            LoadDrivers();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValid())
                {
                    Driver driver = new Driver(tbFirstName.Text, tbSurname.Text, tbPhoneNumber.Text, tbDrivingLicenceNumber.Text);
                    if (SqlRepository.CreateDriver(driver) > 0) 
                    {
                        LoadDrivers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
        }

        private void LoadDrivers()
        {
            try
            {
                lbDrivers.DataSource = SqlRepository.SelectDrivers();
                btnClearForm.PerformClick();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }

        private bool FormValid()
        {
            bool ok = true;

            if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbSurname.Text) || string.IsNullOrEmpty(tbPhoneNumber.Text) || string.IsNullOrEmpty(tbDrivingLicenceNumber.Text))
            {
                ok = false;
                MessageBox.Show("All fields must be filled out");
                tbFirstName.Focus();
            }

            return ok;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                selectedDriver.Firstname = tbFirstName.Text.Trim();
                selectedDriver.Surname = tbSurname.Text.Trim();
                selectedDriver.PhoneNumber = tbPhoneNumber.Text.Trim();
                selectedDriver.DrivingLicenceNumber = tbDrivingLicenceNumber.Text.Trim();
                if (SqlRepository.UpdateDriver(selectedDriver) > 0)
                {
                    LoadDrivers();
                }   
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDriver != null && MessageBox.Show("Rili?", "Cancle perscription to life", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlRepository.DeleteDriver(selectedDriver);
                LoadDrivers();
            }
            else
            {
                MessageBox.Show("Please select driver.");
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            tbFirstName.Text = string.Empty;
            tbSurname.Text = string.Empty;
            tbPhoneNumber.Text = string.Empty;
            tbDrivingLicenceNumber.Text = string.Empty;
            lbDrivers.SelectedItem = null;
        }

        private void lbDrivers_SelectedIndexChanged(object sender, EventArgs e) => FillData();

        private void FillData()
        {
            selectedDriver = (Driver)lbDrivers.SelectedItem;
            tbFirstName.Text = selectedDriver?.Firstname;
            tbSurname.Text = selectedDriver?.Surname;
            tbPhoneNumber.Text = selectedDriver?.PhoneNumber;
            tbDrivingLicenceNumber.Text = selectedDriver?.DrivingLicenceNumber;
        }
    }
}

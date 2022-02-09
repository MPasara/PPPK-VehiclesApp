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
    public partial class VehiclesForm : Form
    {
        private static Vehicle selectedVehicle;

        public VehiclesForm()
        {
            InitializeComponent();
            LoadVehicles();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void LoadVehicles()
        {
            lbVehicles.DataSource = SqlRepository.SelectVehicles();
            btnClearForm.PerformClick();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            tbVehicleType.Text = string.Empty;
            tbVehicleMake.Text = string.Empty;
            tbYear.Text = string.Empty;
            tbKilometers.Text = string.Empty;
            tbIsAvailable.Text = string.Empty;
            tbService.Text = string.Empty;
            lbVehicles.SelectedItem = null;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValid())
                {
                    Vehicle v = new Vehicle(tbVehicleType.Text, tbVehicleMake.Text, int.Parse(tbYear.Text), int.Parse(tbKilometers.Text), bool.Parse(tbIsAvailable.Text), tbService.Text);
                    if (SqlRepository.CreateVehicle(v) > 0)
                    {
                        LoadVehicles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private bool FormValid()
        {
            bool ok = true;

            if (string.IsNullOrEmpty(tbVehicleType.Text) || string.IsNullOrEmpty(tbVehicleMake.Text) 
                || string.IsNullOrEmpty(tbYear.Text) || string.IsNullOrEmpty(tbKilometers.Text) || string.IsNullOrEmpty(tbIsAvailable.Text) || string.IsNullOrEmpty(tbService.Text))
            {
                ok = false;
                MessageBox.Show("All fields must be filled out");
                tbVehicleType.Focus();
            }

            return ok;
        }

        private void lbVehicles_SelectedIndexChanged(object sender, EventArgs e) => FillData();

        private void FillData()
        {
            selectedVehicle = (Vehicle)lbVehicles.SelectedItem;
            tbVehicleType.Text = selectedVehicle?.VehicleType;
            tbVehicleMake.Text = selectedVehicle?.Make;
            tbYear.Text = selectedVehicle?.YearOfMake.ToString();
            tbKilometers.Text = selectedVehicle?.Kilometers.ToString();
            tbIsAvailable.Text = selectedVehicle?.IsAvailable.ToString();
            tbService.Text = selectedVehicle?.VehicleServiceDetails.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                selectedVehicle.VehicleType = tbVehicleType.Text.Trim();
                selectedVehicle.Make = tbVehicleMake.Text.Trim();
                selectedVehicle.YearOfMake = int.Parse(tbYear.Text.Trim());
                selectedVehicle.Kilometers = int.Parse(tbKilometers.Text.Trim());
                selectedVehicle.IsAvailable = bool.Parse(tbIsAvailable.Text.Trim());
                selectedVehicle.VehicleServiceDetails = tbService.Text.Trim();
                if (SqlRepository.UpdateVehicle(selectedVehicle) > 0)
                {
                    LoadVehicles();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVehicle != null && MessageBox.Show("Rili?", "Delete vehicle from database", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlRepository.DeleteVehicle(selectedVehicle);
                LoadVehicles();
            }
            else
            {
                MessageBox.Show("Please select vehicle.");
            }
        }
    }
}

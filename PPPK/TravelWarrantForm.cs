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
    public partial class TravelWarrantForm : Form
    {
        private static TravelWarrant selectedWarrant;
        public TravelWarrantForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadTravelWarrants();
        }

        private void LoadTravelWarrants()
        {
            try
            {
                lbTravelWarrants.DataSource = SqlRepository.SelectTravelWarrants();
                btnClearForm.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbTravelWarrants_SelectedIndexChanged(object sender, EventArgs e) => FillData();

        private void FillData()
        {
            selectedWarrant = (TravelWarrant)lbTravelWarrants.SelectedItem;
            tbCommander.Text = selectedWarrant?.Commander;
            tbWarrantNumber.Text = selectedWarrant?.WarrantNumber.ToString();
            tbStart.Text = selectedWarrant?.StartPoint;
            tbDestination.Text = selectedWarrant?.Destination;
            tbDays.Text = selectedWarrant?.QuantityOfDays.ToString();
            tbDateOfOpening.Text = selectedWarrant?.DateOfOpening.ToString();
            tbDateOfClosing.Text = selectedWarrant?.DateOfClosing.ToString();
            tbDriverId.Text = selectedWarrant?.DriverID.ToString();
            tbVehicleId.Text = selectedWarrant?.VehicleID.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValid())
                {
                    TravelWarrant travelWarrant = new TravelWarrant(tbCommander.Text,int.Parse(tbWarrantNumber.Text),tbStart.Text,tbDestination.Text,int.Parse(tbDays.Text),
                        DateTime.Parse(tbDateOfOpening.Text),DateTime.Parse(tbDateOfClosing.Text), int.Parse(tbDriverId.Text), int.Parse(tbVehicleId.Text));
                    if (SqlRepository.CreateTravelWarrant(travelWarrant) > 0)
                    {
                        LoadTravelWarrants();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool FormValid()
        {
            bool ok = true;

            if (string.IsNullOrEmpty(tbCommander.Text) || string.IsNullOrEmpty(tbWarrantNumber.Text) || string.IsNullOrEmpty(tbStart.Text) 
                || string.IsNullOrEmpty(tbDestination.Text) || string.IsNullOrEmpty(tbDays.Text) || string.IsNullOrEmpty(tbDateOfOpening.Text) 
                || string.IsNullOrEmpty(tbDateOfClosing.Text) || string.IsNullOrEmpty(tbDriverId.Text) || string.IsNullOrEmpty(tbVehicleId.Text))
            {
                ok = false;
                MessageBox.Show("All fields must be filled out");
                tbCommander.Focus();
            }

            return ok;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                selectedWarrant.Commander = tbCommander.Text.Trim();
                selectedWarrant.WarrantNumber = int.Parse(tbWarrantNumber.Text.Trim());
                selectedWarrant.StartPoint = tbStart.Text.Trim();
                selectedWarrant.Destination = tbDestination.Text.Trim();
                selectedWarrant.QuantityOfDays = int.Parse(tbDays.Text.Trim());
                selectedWarrant.DateOfOpening = DateTime.Parse(tbDateOfOpening.Text.Trim());
                selectedWarrant.DateOfClosing = DateTime.Parse(tbDateOfClosing.Text.Trim());
                selectedWarrant.DriverID = int.Parse(tbDriverId.Text.Trim());
                selectedWarrant.VehicleID = int.Parse(tbVehicleId.Text.Trim());
                if (SqlRepository.UpdateTravelWarrant(selectedWarrant) > 0)
                {
                    LoadTravelWarrants();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedWarrant != null && MessageBox.Show("Rili?", "Dilit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlRepository.DeleteTravelWarrant(selectedWarrant);
                LoadTravelWarrants();
            }
            else
            {
                MessageBox.Show("Please select driver.");
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            tbCommander.Text = string.Empty;
            tbWarrantNumber.Text = string.Empty;
            tbStart.Text = string.Empty;
            tbDestination.Text = string.Empty;
            tbDays.Text = string.Empty;
            tbDateOfOpening.Text = string.Empty;
            tbDateOfClosing.Text = string.Empty;
            tbDriverId.Text = string.Empty;
            tbVehicleId.Text = string.Empty;
            lbTravelWarrants.SelectedItem = null;
        }
    }
}

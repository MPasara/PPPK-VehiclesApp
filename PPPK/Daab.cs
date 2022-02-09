using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using PPPK.DAO;
using PPPK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPPK
{
    public partial class Daab : Form
    {
        private const string XML_PATH = @"../../App_Data/Rute.xml";
        //private static readonly IList<TravelRoute> routes;
        private static TravelRoute selectedRoute;

        public Daab()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            try
            {
                lbTravelRoutes.DataSource = SqlRepository.SelectTravelRoutes();
                btnClearForm.PerformClick();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void lbTravelRoutes_SelectedIndexChanged(object sender, EventArgs e) => FillData();

        private void FillData()
        {
             selectedRoute = (TravelRoute)lbTravelRoutes.SelectedItem;
             //tbRoute.Text = selectedRoute?.Route();
             tbHoursOfTravel.Text = selectedRoute?.TravelHours.ToString();
             tbCoordinateA.Text = selectedRoute?.CoordinateA.ToString();
             tbCoordinateB.Text = selectedRoute?.CoordinateB.ToString();
             tbKilometers.Text = selectedRoute?.KilometersTavelled.ToString();
             tbAverageSpeed.Text = selectedRoute?.AverageSpeed.ToString();
             tbSpentFuel.Text = selectedRoute?.FuelSpent.ToString();
             tbTravelWarrantID.Text = selectedRoute?.TravelWarrantID.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValid())
                {
                    TravelRoute route = new TravelRoute(int.Parse(tbHoursOfTravel.Text), double.Parse(tbCoordinateA.Text), double.Parse(tbCoordinateB.Text), 
                        int.Parse(tbKilometers.Text), double.Parse(tbAverageSpeed.Text), double.Parse(tbSpentFuel.Text), int.Parse(tbTravelWarrantID.Text));
                    if (SqlRepository.CreateTravelRoute(route) > 0)
                    {
                        LoadRoutes();
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

            if (string.IsNullOrEmpty(tbRoute.Text) || string.IsNullOrEmpty(tbHoursOfTravel.Text) || string.IsNullOrEmpty(tbCoordinateA.Text) 
                || string.IsNullOrEmpty(tbCoordinateB.Text) || string.IsNullOrEmpty(tbKilometers.Text) || string.IsNullOrEmpty(tbAverageSpeed.Text) 
                || string.IsNullOrEmpty(tbSpentFuel.Text) || string.IsNullOrEmpty(tbTravelWarrantID.Text))
            {
                ok = false;
                MessageBox.Show("All fields must be filled out");
                tbRoute.Focus();
            }

            return ok;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                selectedRoute.TravelHours = int.Parse(tbHoursOfTravel.Text.Trim());
                selectedRoute.CoordinateA = double.Parse(tbCoordinateA.Text.Trim());
                selectedRoute.CoordinateB = double.Parse(tbCoordinateB.Text.Trim());
                selectedRoute.KilometersTavelled = int.Parse(tbKilometers.Text.Trim());
                selectedRoute.AverageSpeed = double.Parse(tbAverageSpeed.Text.Trim());
                selectedRoute.FuelSpent = double.Parse(tbSpentFuel.Text.Trim());
                selectedRoute.TravelWarrantID = int.Parse(tbTravelWarrantID.Text.Trim());
                if (SqlRepository.UpdateTravelRoute(selectedRoute) > 0)
                {
                    LoadRoutes();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoute != null && MessageBox.Show("Rili?", "Delete route from database", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                SqlRepository.DeleteTravelRoute(selectedRoute);
                LoadRoutes();
            }
            else
            {
                MessageBox.Show("Please select route.");
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            tbRoute.Text = string.Empty;
            tbHoursOfTravel.Text = string.Empty;
            tbCoordinateA.Text = string.Empty;
            tbCoordinateB.Text = string.Empty;
            tbKilometers.Text = string.Empty;
            tbAverageSpeed.Text = string.Empty;
            tbSpentFuel.Text = string.Empty;
            tbTravelWarrantID.Text = string.Empty;
            lbTravelRoutes.SelectedItem = null;
            tbXmlData.Text = string.Empty;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                ShowXmlDataInTextBox();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowXmlDataInTextBox()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(XML_PATH);

            DataTable dt = ds.Tables[0];

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("ID:").Append(dr[0]).Append("\r\n");
                sb.Append("Hours:").Append(dr[1]).Append("\r\n");
                sb.Append("CA:").Append(dr[2]).Append("\r\n");
                sb.Append("CB:").Append(dr[3]).Append("\r\n");
                sb.Append("Km:").Append(dr[4]).Append("\r\n");
                sb.Append("Avg speed:").Append(dr[5]).Append("\r\n");
                sb.Append("Fuel:").Append(dr[6]).Append("\r\n");
                sb.Append("TWID:").Append(dr[7]).Append("\r\n");
            }

            
            tbXmlData.Text = sb.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = SqlRepository.ExportDataToXml(selectedRoute.IDRoute);
                ds.WriteXml(XML_PATH, XmlWriteMode.WriteSchema);
                MessageBox.Show("Export successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select route to export.");
            }
        }
    }
}

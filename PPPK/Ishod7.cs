using PPPK.DAO;
using PPPK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK
{
    public partial class Ishod7 : Form
    {
        private static Vehicle selectedVehicle;
        private const string HTML_PATH = @"../../HTML/HtmlReport.html";

        public Ishod7()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            lbVehicles.DataSource = SqlRepository.SelectVehicles();
            btnClearForm.PerformClick();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            try
            {
                tbServiceDetails.Text = string.Empty;
                lbVehicles.SelectedItem = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValid())
                {
                    selectedVehicle = (Vehicle)lbVehicles.SelectedItem;

                    selectedVehicle.VehicleServiceDetails = tbServiceDetails.Text;
                    SqlRepository.UpdateVehicle(selectedVehicle);
                    LoadVehicles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadVehicleService()
        {
            
        }

        private bool FormValid()
        {
            bool ok = true;

            if (string.IsNullOrEmpty(tbServiceDetails.Text) && selectedVehicle==null)
            {
                ok = false;
                MessageBox.Show("All fields must be filled out, and vehicle must be selected");
                tbServiceDetails.Focus();
            }

            return ok;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                selectedVehicle.VehicleServiceDetails = tbServiceDetails.Text;
                if (SqlRepository.UpdateVehicle(selectedVehicle) > 0)
                {
                    LoadVehicles();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             MessageBox.Show("No no you naughty naughty! ;)");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string H1_TAG = "<h1>";
            string H1_CLOSING_TAG = "</h1>";
            string H2_TAG = "<h2>";
            string H2_CLOSING_TAG = "</h2>";
            string H3_TAG = "<h3>";
            string H3_CLOSING_TAG = "</h3>";
            string BOLD = "<b>";
            string BOLD_CLOSE = "</b>";

            var report = new StringBuilder();
            report.Append($"{H1_TAG}{Environment.NewLine}");

            report.Append($"{H2_TAG}{BOLD}Vozilo{BOLD_CLOSE}{H2_CLOSING_TAG}{Environment.NewLine}");
            report.Append($"{H3_TAG}{nameof(Vehicle.IDVehicle)}: {selectedVehicle.IDVehicle}{H3_CLOSING_TAG}{Environment.NewLine}");
            report.Append($"{H3_TAG}{nameof(Vehicle.VehicleType)}: {selectedVehicle.VehicleType}{H3_CLOSING_TAG}{Environment.NewLine}");
            report.Append($"{H3_TAG}{nameof(Vehicle.Make)}: {selectedVehicle.Make}{H3_CLOSING_TAG}{Environment.NewLine}");
            report.Append($"{H3_TAG}{nameof(Vehicle.YearOfMake)}: {selectedVehicle.YearOfMake}{H3_CLOSING_TAG}{Environment.NewLine}");
            report.Append($"{H3_TAG}{nameof(Vehicle.Kilometers)}: {selectedVehicle.Kilometers}{H3_CLOSING_TAG}{Environment.NewLine}");

            /*using (var db = new PPPKEntities())
            {
                db.Vehicles
                    .ToList()
                    .ForEach(v =>
                    {
                        report.Append($"{H2_TAG}{BOLD}Servis{BOLD_CLOSE}{H2_CLOSING_TAG}{Environment.NewLine}");
                        report.Append($"{H3_TAG}{nameof(Vehicle.VehicleServiceDetails)}{H3_CLOSING_TAG}{Environment.NewLine}");
                    });
            }
            report.Append($"{H1_CLOSING_TAG}{Environment.NewLine}");
            File.WriteAllText(HTML_PATH, report.ToString());*/
        }

        private void lbVehicles_SelectedIndexChanged(object sender, EventArgs e) => FillData();

        private void FillData()
        {
            try
            {
                selectedVehicle = (Vehicle)lbVehicles.SelectedItem;
                
                tbServiceDetails.Text = selectedVehicle?.VehicleServiceDetails.ToString();

                if (selectedVehicle != null)
                {
                    selectedVehicle.VehicleServiceDetails = tbServiceDetails.Text;
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}

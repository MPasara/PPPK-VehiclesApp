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
    public partial class StartForm : Form
    {
        
        public StartForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            VehiclesForm vehiclesForm = new VehiclesForm();
            vehiclesForm.Show();
        }

        private void btnTravelWarrants_Click(object sender, EventArgs e)
        {
            TravelWarrantForm travelWarrantForm = new TravelWarrantForm();
            travelWarrantForm.Show();
        }

        //Db operations button
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            DriversForm driversForm = new DriversForm();
            driversForm.Show();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Rili?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void btnDaab_Click(object sender, EventArgs e)
        {
            Daab daab = new Daab();
            daab.Show();
        }

        private void btnIshod7_Click(object sender, EventArgs e)
        {
            Ishod7 ishod7 = new Ishod7();
            ishod7.Show();
        }
    }
}

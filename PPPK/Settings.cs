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
using System.Xml;

namespace PPPK
{
    public partial class Settings : Form
    {
        private const string Db_To_Xml_Path = @"../../App_Data/XmlDb.xml";
        public Settings()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                SqlRepository.AddExampleRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                BackupDbToXML();
                MessageBox.Show("Backup succesfull.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackupDbToXML()
        {
            //BackupDriversToXml();
            //BackupVehiclesToXml();
            using (XmlWriter writer = XmlWriter.Create(Db_To_Xml_Path, new XmlWriterSettings { Indent = true}))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("DbData");

                DataTable dtTravelWarrants = SqlRepository.GetAllDataFromDatabase();
                IList<TravelRoute> travelRoutes;
                dtTravelWarrants.Rows.Cast<DataRow>()
                    .ToList()
                    .ForEach(dr =>
                    {
                        travelRoutes = SqlRepository.SelectTravelRoutes();
                        //travel warrant
                        writer.WriteStartElement("travelWarrant");
                        writer.WriteAttributeString("id", dr[nameof(TravelWarrant.IDTravelWarrant)].ToString());
                        writer.WriteElementString("commander", dr[nameof(TravelWarrant.Commander)].ToString());
                        writer.WriteElementString("warrantNumber", dr[nameof(TravelWarrant.WarrantNumber)].ToString());

                        //driver
                        writer.WriteStartElement("driver");
                        writer.WriteElementString("id", dr[nameof(Driver.IDDriver)].ToString());
                        writer.WriteElementString("firstname", dr[nameof(Driver.Firstname)].ToString());
                        writer.WriteElementString("surname", dr[nameof(Driver.Surname)].ToString());
                        writer.WriteElementString("phoneNumber", dr[nameof(Driver.PhoneNumber)].ToString());
                        writer.WriteElementString("drivingLicenceNumber", dr[nameof(Driver.DrivingLicenceNumber)].ToString());
                        writer.WriteEndElement();

                        //vehicle
                        writer.WriteStartElement("vehicle");
                        writer.WriteElementString("id", dr[nameof(Vehicle.IDVehicle)].ToString());
                        writer.WriteElementString("vehicleType", dr[nameof(Vehicle.VehicleType)].ToString());
                        writer.WriteElementString(nameof(Vehicle.Make), dr[nameof(Vehicle.Make)].ToString());
                        writer.WriteElementString("yearOfMake", dr[nameof(Vehicle.YearOfMake)].ToString());
                        writer.WriteElementString("kilometers", dr[nameof(Vehicle.Kilometers)].ToString());
                        writer.WriteElementString("isAvailable", dr[nameof(Vehicle.IsAvailable)].ToString());
                        writer.WriteEndElement();


                        //route
                        writer.WriteStartElement("travelRoute");
                        foreach (var route in travelRoutes)
                        {
                            writer.WriteStartElement("Route");
                            writer.WriteElementString("id", route.IDRoute.ToString());
                            writer.WriteElementString("travelHours", route.TravelHours.ToString());
                            writer.WriteElementString("coordinateA", route.CoordinateA.ToString());
                            writer.WriteElementString("coordinateB", route.CoordinateB.ToString());
                            writer.WriteElementString("kilometersTavelled", route.KilometersTavelled.ToString());
                            writer.WriteElementString("averageSpeed", route.AverageSpeed.ToString());
                            writer.WriteElementString("fuelSpent", route.FuelSpent.ToString());
                        }
                        writer.WriteEndElement();

                        writer.WriteElementString("StartPoint", dr[nameof(TravelWarrant.StartPoint)].ToString());
                        writer.WriteElementString("Destination", dr[nameof(TravelWarrant.Destination)].ToString());
                        writer.WriteElementString("QuantityOfDays", dr[nameof(TravelWarrant.QuantityOfDays)].ToString());
                        writer.WriteElementString("DateOfOpening", dr[nameof(TravelWarrant.DateOfOpening)].ToString());
                        writer.WriteElementString("DateOfClosing", dr[nameof(TravelWarrant.DateOfClosing)].ToString());
                    });
                writer.WriteEndElement();
            }
        }
        
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                RestoreDrivers();
                RestoreVehicles();
                RestoreTravelWarrants();
                RestoreRoutes();
                MessageBox.Show("Restore succesfull.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreDrivers()
        {
            XmlDocument doc = LoadDocument();
            XmlElement root = doc.DocumentElement;
            XmlNodeList driverNodes = root.SelectNodes($"{nameof(TravelWarrant)}/{nameof(Driver)}");

            driverNodes.Cast<XmlNode>().ToList().ForEach(node =>
            {
                Driver driver = new Driver
                {
                    IDDriver = int.Parse(node.SelectSingleNode(nameof(Driver.IDDriver)).InnerText),
                    Firstname = node.SelectSingleNode(nameof(Driver.Firstname)).InnerText,
                    Surname = node.SelectSingleNode(nameof(Driver.Surname)).InnerText,
                    PhoneNumber = node.SelectSingleNode(nameof(Driver.PhoneNumber)).InnerText,
                    DrivingLicenceNumber = node.SelectSingleNode(nameof(Driver.DrivingLicenceNumber)).InnerText
                };
                SqlRepository.CreateDriver(driver);
            });
        }

        private XmlDocument LoadDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Db_To_Xml_Path);
            return doc;
        }

        private void RestoreVehicles()
        {
            XmlDocument doc = LoadDocument();
            XmlElement root = doc.DocumentElement;
            XmlNodeList vehicleNodes = root.SelectNodes($"{nameof(TravelWarrant)}/{nameof(Vehicle)}");

            vehicleNodes.Cast<XmlNode>().ToList().ForEach(node =>
            {
                Vehicle vehicle = new Vehicle
                {
                    IDVehicle = int.Parse(node.SelectSingleNode(nameof(Vehicle.IDVehicle)).InnerText),
                    VehicleType = node.SelectSingleNode(nameof(Vehicle.VehicleType)).InnerText,
                    Make = node.SelectSingleNode(nameof(Vehicle.Make)).InnerText,
                    YearOfMake = int.Parse(node.SelectSingleNode(nameof(Vehicle.YearOfMake)).InnerText),
                    Kilometers = int.Parse(node.SelectSingleNode(nameof(Vehicle.Kilometers)).InnerText),
                    IsAvailable = bool.Parse(node.SelectSingleNode(nameof(Vehicle.IsAvailable)).InnerText)
                };
                SqlRepository.CreateVehicle(vehicle);
            });
        }

        private void RestoreTravelWarrants()
        {
            XmlDocument doc = LoadDocument();
            XmlElement root = doc.DocumentElement;
            XmlNodeList twNodes = root.SelectNodes($"{nameof(TravelWarrant)}/{nameof(TravelWarrant)}");

            twNodes.Cast<XmlNode>().ToList().ForEach(node =>
            {
                TravelWarrant warrant = new TravelWarrant
                {
                    IDTravelWarrant = int.Parse(node.SelectSingleNode(nameof(TravelWarrant.IDTravelWarrant)).InnerText),
                    Commander = node.SelectSingleNode(nameof(TravelWarrant.Commander)).InnerText,
                    WarrantNumber = int.Parse(node.SelectSingleNode(nameof(TravelWarrant.WarrantNumber)).InnerText),
                    StartPoint = node.SelectSingleNode(nameof(TravelWarrant.StartPoint)).InnerText,
                    Destination = node.SelectSingleNode(nameof(TravelWarrant.Destination)).InnerText,
                    QuantityOfDays = int.Parse(node.SelectSingleNode(nameof(TravelWarrant.QuantityOfDays)).InnerText),
                    DateOfOpening = DateTime.Parse(node.SelectSingleNode(nameof(TravelWarrant.DateOfOpening)).InnerText),
                    DateOfClosing = DateTime.Parse(node.SelectSingleNode(nameof(TravelWarrant.DateOfClosing)).InnerText),
                    DriverID = int.Parse(node.SelectSingleNode(nameof(TravelWarrant.DriverID)).InnerText),
                    VehicleID = int.Parse(node.SelectSingleNode(nameof(TravelWarrant.VehicleID)).InnerText)
                };
                SqlRepository.CreateTravelWarrant(warrant);
            });
        }

        private void RestoreRoutes()
        {
            XmlDocument doc = LoadDocument();
            XmlElement root = doc.DocumentElement;
            XmlNodeList routeNodes = root.SelectNodes($"{nameof(TravelWarrant)}/{nameof(TravelRoute)}");

            routeNodes.Cast<XmlNode>().ToList().ForEach(node =>
            {
                TravelRoute route = new TravelRoute
                {
                    IDRoute = int.Parse(node.SelectSingleNode(nameof(TravelRoute.IDRoute)).InnerText),
                    TravelHours = int.Parse(node.SelectSingleNode(nameof(TravelRoute.TravelHours)).InnerText),
                    CoordinateA = double.Parse(node.SelectSingleNode(nameof(TravelRoute.CoordinateA)).InnerText),
                    CoordinateB = double.Parse(node.SelectSingleNode(nameof(TravelRoute.CoordinateB)).InnerText),
                    KilometersTavelled = int.Parse(node.SelectSingleNode(nameof(TravelRoute.KilometersTavelled)).InnerText),
                    AverageSpeed = double.Parse(node.SelectSingleNode(nameof(TravelRoute.AverageSpeed)).InnerText),
                    FuelSpent = double.Parse(node.SelectSingleNode(nameof(TravelRoute.FuelSpent)).InnerText),
                    TravelWarrantID = int.Parse(node.SelectSingleNode(nameof(TravelRoute.IDRoute)).InnerText)
                };
                SqlRepository.CreateTravelRoute(route);
            });
        }

        private void btnCleanDb_Click(object sender, EventArgs e)
        {
            try
            {
                SqlRepository.CleanDb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}

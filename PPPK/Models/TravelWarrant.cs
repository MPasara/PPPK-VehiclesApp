using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.Models
{
    public class TravelWarrant
    {
        public int IDTravelWarrant { get; set; }
        public string Commander { get; set; }
        public int WarrantNumber { get; set; }
        public string StartPoint { get; set; }
        public string Destination { get; set; }
        public int QuantityOfDays { get; set; }
        public DateTime DateOfOpening { get; set; }
        public DateTime? DateOfClosing { get; set; }
        public int DriverID { get; set; }
        public int VehicleID { get; set; }

        public override string ToString() => $"ID: {IDTravelWarrant}, Start point:{StartPoint}, Destination: {Destination}, No: {WarrantNumber}";

        public TravelWarrant(){}

        public TravelWarrant(int iDTravelWarrant, string commander, int warrantNumber, string startPoint, string destination, int quantityOfDays, DateTime dateOfOpening, DateTime? dateOfClosing, int driverID, int vehicleID)
            :this(commander, warrantNumber, startPoint, destination, quantityOfDays, dateOfOpening, dateOfClosing, driverID, vehicleID)
        {
            IDTravelWarrant = iDTravelWarrant;
        }

        public TravelWarrant(string commander, int warrantNumber, string startPoint, string destination, int quantityOfDays, DateTime dateOfOpening, DateTime? dateOfClosing, int driverID, int vehicleID)
        {
            Commander = commander;
            WarrantNumber = warrantNumber;
            StartPoint = startPoint;
            Destination = destination;
            QuantityOfDays = quantityOfDays;
            DateOfOpening = dateOfOpening;
            DateOfClosing = dateOfClosing;
            DriverID = driverID;
            VehicleID = vehicleID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.Models
{
    public class VehicleService
    {
        public int IDVehicleService { get; set; }
        public string ServiceDetails { get; set; }
        public DateTime ServiceDate { get; set; }
        public int VehicleID { get; set; }

        public VehicleService()
        {
        }

        public VehicleService(int iDVehicleService, string serviceDetails, DateTime serviceDate, int vehicleID)
            :this(serviceDetails, serviceDate, vehicleID)
        {
            IDVehicleService = iDVehicleService;
        }

        public VehicleService(string serviceDetails, DateTime serviceDate, int vehicleID)
        {
            ServiceDetails = serviceDetails;
            ServiceDate = serviceDate;
            VehicleID = vehicleID;
        }
    }
}

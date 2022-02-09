using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.Models
{
    public class Vehicle
    {
        public int IDVehicle { get; set; }
        public string VehicleType { get; set; }
        public string Make { get; set; }
        public int YearOfMake { get; set; }
        public int Kilometers { get; set; }
        public bool IsAvailable { get; set; }
        public string VehicleServiceDetails { get; set; }
        public override string ToString() => $"ID: {IDVehicle}, Type: {VehicleType}, Make: {Make}, Service:{VehicleServiceDetails}";

        public string VehicleService() => $"";

        public Vehicle()
        {
        }

        public Vehicle(int iDVehicle, string vehicleType, string make, int yearOfMake, int kilometers, bool isAvailable, string vehicleServiceDetails)
            :this(vehicleType,make,yearOfMake,kilometers,isAvailable,vehicleServiceDetails)
        {
            IDVehicle = iDVehicle;
        }

        public Vehicle(string vehicleType, string make, int yearOfMake, int kilometers, bool isAvailable, string vehicleServiceDetails)
        {
            VehicleType = vehicleType;
            Make = make;
            YearOfMake = yearOfMake;
            Kilometers = kilometers;
            IsAvailable = isAvailable;
            VehicleServiceDetails = vehicleServiceDetails;
        }



        /*public Vehicle(int iDVehicle, string vehicleType, string make, int yearOfMake, int kilometers, bool isAvailable)
            :this(vehicleType, make, yearOfMake, kilometers, isAvailable)
        {
            IDVehicle = iDVehicle;
        }

        public Vehicle(string vehicleType, string make, int yearOfMake, int kilometers, bool isAvailable)
        {
            VehicleType = vehicleType;
            Make = make;
            YearOfMake = yearOfMake;
            Kilometers = kilometers;
            IsAvailable = isAvailable;
        }*/


        /*public Vehicle(string vehicleType, string make, int yearOfMake, int kilometers, bool isAvailable, 
            string vehicleServiceDetails) : this(vehicleType, make, yearOfMake, kilometers, isAvailable)
        {
            VehicleServiceDetails = vehicleServiceDetails;
        }*/
    }
}

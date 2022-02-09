using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.Models
{
    public class TravelRoute
    {
        public int IDRoute { get; set; }
        public int TravelHours { get; set; }
        public double CoordinateA { get; set; }
        public double CoordinateB { get; set; }
        public int KilometersTavelled { get; set; }
        public double AverageSpeed { get; set; }
        public double FuelSpent { get; set; }
        public int TravelWarrantID { get; set; }

        public override string ToString() => $"ID:{IDRoute}, CA:{CoordinateA}, CB:{CoordinateB}";

        public TravelRoute()
        {
        }


        public TravelRoute(int iDRoute, int travelHours, double coordinateA, double coordinateB, int kilometersTravelled, double averageSpeed, 
            double fuelSpent, int travelWarrantID)
            : this(travelHours, coordinateA, coordinateB, kilometersTravelled, averageSpeed, fuelSpent, travelWarrantID)
        {
            IDRoute = iDRoute;
        }

        public TravelRoute(int travelHours, double coordinateA, double coordinateB, int kilometersTravelled, double averageSpeed, 
            double fuelSpent, int travelWarrantID)
        {
            TravelHours = travelHours;
            CoordinateA = coordinateA;
            CoordinateB = coordinateB;
            KilometersTavelled = kilometersTravelled;
            AverageSpeed = averageSpeed;
            FuelSpent = fuelSpent;
            TravelWarrantID = travelWarrantID;
        }

        internal string Route() => $"ID:{IDRoute}, CA:{CoordinateA}, CB:{CoordinateB}";
    }
}

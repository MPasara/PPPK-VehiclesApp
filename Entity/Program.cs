using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            char repeat;

            do
            {
                Console.Clear();

                
                Console.WriteLine("Welcome");
                Console.WriteLine("Choose what data you want to see.");
                Console.WriteLine("1 - Drivers");
                Console.WriteLine("2 - Vehicles");
                Console.WriteLine("3 - Travel warrants");
                Console.WriteLine("4 - Travel route");
                Console.WriteLine("5 - Exit app");
                Console.WriteLine("----------------------------------------------");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Drivers:");
                        using (var db = new PPPKEntities())
                        {
                            db.Driver.ToList().ForEach(d =>
                            {
                                Console.WriteLine("ID: " + d.IDDriver);
                                Console.WriteLine("Firstname: " + d.Firstname);
                                Console.WriteLine("Surname: " + d.Surname);
                                Console.WriteLine("Phone number: " + d.PhoneNumber);
                                Console.WriteLine("Driving licence number: " + d.DrivingLicenceNumber);
                                Console.WriteLine("---------------------------------------------------");
                            });
                        }
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Vehicles:");
                        using (var db = new PPPKEntities())
                        {
                            db.Vehicle.ToList().ForEach(v =>
                            {
                                Console.WriteLine("ID: " + v.IDVehicle);
                                Console.WriteLine("Vehicle type: " + v.VehicleType);
                                Console.WriteLine("Make: " + v.Make);
                                Console.WriteLine("Year of make: " + v.YearOfMake);
                                Console.WriteLine("Kilometers: " + v.Kilometers);
                                Console.WriteLine("Available: " + v.IsAvailable);
                                Console.WriteLine("Vehicle service details: " + v.VehicleServiceDetails);
                                Console.WriteLine("---------------------------------------------------");
                            });
                        }
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Travel warrants:");
                        using (var db = new PPPKEntities())
                        {
                            db.TravelWarrant.ToList().ForEach(tw =>
                            {
                                Console.WriteLine("ID: " + tw.IDTravelWarrant);
                                Console.WriteLine("Commander: " + tw.Commander);
                                Console.WriteLine("Warrant number: " + tw.WarrantNumber);
                                Console.WriteLine("Start point: " + tw.StartPoint);
                                Console.WriteLine("Destination: " + tw.Destination);
                                Console.WriteLine("Quantity of days: " + tw.QuantityOfDays);
                                Console.WriteLine("Date of opening: " + tw.DateOfOpening);
                                Console.WriteLine("Date of closing: " + tw.DateOfClosing);
                                Console.WriteLine("Driver id: " + tw.DriverID);
                                Console.WriteLine("Vehicle id: " + tw.VehicleID);
                                Console.WriteLine("---------------------------------------------------");
                            });
                        }
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Travel routes:");
                        using (var db = new PPPKEntities())
                        {
                            db.TravelRoute.ToList().ForEach(tr =>
                            {
                                Console.WriteLine("ID: " + tr.IDRoute);
                                Console.WriteLine("Travel hours: " + tr.TravelHours);
                                Console.WriteLine("Coordinate A: " + tr.CoordinateA);
                                Console.WriteLine("Coordinate B: " + tr.CoordinateB);
                                Console.WriteLine("Kilometers travelled: " + tr.KilometersTavelled);
                                Console.WriteLine("Average speed: " + tr.AverageSpeed);
                                Console.WriteLine("Fuel spent: " + tr.FuelSpent);
                                Console.WriteLine("Travel warrant id: " + tr.TravelWarrantID);
                                Console.WriteLine("---------------------------------------------------");
                            });
                        }
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("Press enter to confirm..");
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("Repeat (y/n)?");
                repeat = Console.ReadKey().KeyChar;

            } while (repeat == 'y');
        }
    }
}

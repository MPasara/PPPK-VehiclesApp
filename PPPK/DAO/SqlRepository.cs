using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using PPPK.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PPPK.DAO
{
    class SqlRepository
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase db = new SqlDatabase(cs);

        public static void CleanDb()
        {
            
        }

        internal static int AddExampleRecords()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand command = con.CreateCommand())
                    {
                        command.CommandText = "addExampleRecords";
                        command.CommandType = CommandType.StoredProcedure;
                        int result = command.ExecuteNonQuery();
                        scope.Complete();
                        return result;
                    }
                }
            }
        }

        public static int CreateDriver(Driver driver)
        {   
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "createDriver";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Firstname", driver.Firstname);
                    command.Parameters.AddWithValue("Surname", driver.Surname);
                    command.Parameters.AddWithValue("PhoneNumber", driver.PhoneNumber);
                    command.Parameters.AddWithValue("DrivingLicenceNumber", driver.DrivingLicenceNumber);
                    SqlParameter idVozac = new SqlParameter("@IDDriver", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idVozac);
                    command.ExecuteNonQuery();
                    return (int)(idVozac.Value);
                }
            }
        }

        internal static int UpdateVehicleService(VehicleService selectedService)
        {
            throw new NotImplementedException();
        }

        public static int CreateVehicleService(VehicleService service)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "createVehicleService";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ServiceDetails", service.ServiceDetails);
                    command.Parameters.AddWithValue("ServiceDate", service.ServiceDate);
                    command.Parameters.AddWithValue("VehicleID", service.VehicleID);
                    SqlParameter idVehicleService = new SqlParameter("@IDVehicleService", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idVehicleService);
                    command.ExecuteNonQuery();
                    return (int)(idVehicleService.Value);
                }
            }
        }

        /*internal static IList<TravelRoute> GetTravelRoutes()
        {
            
        }*/

        internal static DataTable GetAllDataFromDatabase()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                   //command.CommandText = MethodBase.GetCurrentMethod().Name;
                    command.CommandText = "getAllDataFromDatabase";
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable(nameof(TravelWarrant));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public static int CreateTravelRoute(TravelRoute travelRoute)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(CreateTravelRoute);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("TravelHours", travelRoute.TravelHours);
                    command.Parameters.AddWithValue("CoordinateA", travelRoute.CoordinateA);
                    command.Parameters.AddWithValue("CoordinateB", travelRoute.CoordinateB);
                    command.Parameters.AddWithValue("KilometersTavelled", travelRoute.KilometersTavelled);
                    command.Parameters.AddWithValue("AverageSpeed", travelRoute.AverageSpeed);
                    command.Parameters.AddWithValue("FuelSpent", travelRoute.FuelSpent);
                    command.Parameters.AddWithValue("TravelWarrantID", travelRoute.TravelWarrantID);
                    SqlParameter idTravelRoute = new SqlParameter("@IDRoute", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idTravelRoute);
                    command.ExecuteNonQuery();
                    return (int)(idTravelRoute.Value);
                }
            }
        }

        public static int CreateTravelWarrant(TravelWarrant travelWarrant)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(CreateTravelWarrant);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Commander", travelWarrant.Commander);
                    command.Parameters.AddWithValue("WarrantNumber", travelWarrant.WarrantNumber);
                    command.Parameters.AddWithValue("StartPoint", travelWarrant.StartPoint);
                    command.Parameters.AddWithValue("Destination", travelWarrant.Destination);
                    command.Parameters.AddWithValue("QuantityOfDays", travelWarrant.QuantityOfDays);
                    command.Parameters.AddWithValue("DateOfOpening", travelWarrant.DateOfOpening);
                    command.Parameters.AddWithValue("DateOfClosing", travelWarrant.DateOfClosing);
                    command.Parameters.AddWithValue("DriverID", travelWarrant.DriverID);
                    command.Parameters.AddWithValue("VehicleID", travelWarrant.VehicleID);
                    SqlParameter idWarrant = new SqlParameter("@IDTravelWarrant", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idWarrant);
                    command.ExecuteNonQuery();
                    return (int)(idWarrant.Value);
                }
            }
        }

        internal static DataTable WriteVehiclesToXml()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = MethodBase.GetCurrentMethod().Name;
                    //command.CommandText = "getAllDataFromDatabase";
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable(nameof(Driver));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        internal static DataTable WriteDriversToXml()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = MethodBase.GetCurrentMethod().Name;
                    //command.CommandText = "getAllDataFromDatabase";
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable(nameof(Driver));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        internal static DataSet ExportDataToXml(int idRuta)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDRoute", idRuta);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet("Route");

                    dataAdapter.Fill(ds);

                    return ds;
                }
            }
        }

        public static int CreateVehicle(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "createVehicle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("VehicleType", vehicle.VehicleType);
                    command.Parameters.AddWithValue("Make", vehicle.Make);
                    command.Parameters.AddWithValue("YearOfMake", vehicle.YearOfMake);
                    command.Parameters.AddWithValue("Kilometers", vehicle.Kilometers);
                    command.Parameters.AddWithValue("IsAvailable", vehicle.IsAvailable);
                    command.Parameters.AddWithValue("VehicleServiceDetails", vehicle.VehicleServiceDetails);
                    SqlParameter idVehicle = new SqlParameter("@IDVehicle", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idVehicle);
                    command.ExecuteNonQuery();
                    return (int)(idVehicle.Value);
                }
            }
        }


        public static int DeleteDriver(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(DeleteDriver);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IDDriver", driver.IDDriver);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteTravelWarrant(TravelWarrant travelWarrant)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(DeleteTravelWarrant);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IDTravelWarrant", travelWarrant.IDTravelWarrant);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteTravelRoute(TravelRoute travelRoute)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "deleteRoute";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IDRoute", travelRoute.IDRoute);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteVehicle(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(DeleteVehicle);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IDVehicle", vehicle.IDVehicle);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteVehicleService(VehicleService vehicleService)
        {
            return 1;
        }

        public static int SelectDriver(int id)
        {
            return 1;
        }

        public static IList<Driver> SelectDrivers()
        {
            IList<Driver> drivers = new List<Driver>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(SelectDrivers);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new Driver(
                                    (int)reader[nameof(Driver.IDDriver)],
                                    reader[nameof(Driver.Firstname)].ToString(),
                                    reader[nameof(Driver.Surname)].ToString(),
                                    reader[nameof(Driver.PhoneNumber)].ToString(),
                                    reader[nameof(Driver.DrivingLicenceNumber)].ToString()
                                ));
                        }
                    }
                }
            }

            return drivers;
        }

        public void SelectTravelRoute(int id)
        {
            
        }

        public static IList<TravelRoute> SelectTravelRoutes()
        {
            IList<TravelRoute> routes = new List<TravelRoute>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(SelectTravelRoutes);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            routes.Add(new TravelRoute(
                                    (int)reader[nameof(TravelRoute.IDRoute)],
                                    (int)reader[nameof(TravelRoute.TravelHours)],
                                    (double)reader[nameof(TravelRoute.CoordinateA)],
                                    (double)reader[nameof(TravelRoute.CoordinateB)],
                                    (int)reader[nameof(TravelRoute.KilometersTavelled)],
                                    (double)reader[nameof(TravelRoute.AverageSpeed)],
                                    (double)reader[nameof(TravelRoute.FuelSpent)],
                                    (int)reader[nameof(TravelRoute.TravelWarrantID)]
                                ));
                        }
                    }
                }
            }

            return routes;
        }

        public void SelectTravelWarrant(int id)
        {
            
        }

        public static IList<TravelWarrant> SelectTravelWarrants()
        {
            IList<TravelWarrant> warrants = new List<TravelWarrant>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(SelectTravelWarrants);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            warrants.Add(new TravelWarrant(
                                    (int)reader[nameof(TravelWarrant.IDTravelWarrant)],
                                    reader[nameof(TravelWarrant.Commander)].ToString(),
                                    (int)reader[nameof(TravelWarrant.WarrantNumber)],
                                    reader[nameof(TravelWarrant.StartPoint)].ToString(),
                                    reader[nameof(TravelWarrant.Destination)].ToString(),
                                    (int)reader[nameof(TravelWarrant.QuantityOfDays)],
                                    (DateTime)reader[nameof(TravelWarrant.DateOfOpening)],
                                    (DateTime)reader[nameof(TravelWarrant.DateOfClosing)],
                                    (int)reader[nameof(TravelWarrant.DriverID)],
                                    (int)reader[nameof(TravelWarrant.VehicleID)]
                                ));
                        }
                    }
                }
            }

            return warrants;
        }

        public void SelectVehicle(int id)
        {
            
        }

        public static IList<Vehicle> SelectVehicles()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = nameof(SelectVehicles);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new Vehicle(
                                    (int)reader[nameof(Vehicle.IDVehicle)],
                                    reader[nameof(Vehicle.VehicleType)].ToString(),
                                    reader[nameof(Vehicle.Make)].ToString(),
                                    (int)reader[nameof(Vehicle.YearOfMake)],
                                    (int)reader[nameof(Vehicle.Kilometers)],
                                    (bool)reader[nameof(Vehicle.IsAvailable)],
                                    reader[nameof(Vehicle.VehicleServiceDetails)].ToString()
                                ));
                        }
                    }
                }
            }
            return vehicles;
        }

        public void SelectVehicleService(int id)
        {
            
        }

        public List<VehicleService> SelectVehicleServices()
        {
            return null;
        }

        public static int UpdateDriver(Driver driver)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = nameof(UpdateDriver);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("IDDriver", driver.IDDriver);
                    command.Parameters.AddWithValue("Firstname", driver.Firstname);
                    command.Parameters.AddWithValue("Surname", driver.Surname);
                    command.Parameters.AddWithValue("PhoneNumber", driver.PhoneNumber);
                    command.Parameters.AddWithValue("DrivingLicenceNumber", driver.DrivingLicenceNumber);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateTravelRoute(TravelRoute travelRoute)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = nameof(UpdateTravelRoute);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("IDRoute", travelRoute.IDRoute);
                    command.Parameters.AddWithValue("TravelHours", travelRoute.TravelHours);
                    command.Parameters.AddWithValue("CoordinateA", travelRoute.CoordinateA);
                    command.Parameters.AddWithValue("CoordinateB", travelRoute.CoordinateB);
                    command.Parameters.AddWithValue("KilometersTavelled", travelRoute.KilometersTavelled);
                    command.Parameters.AddWithValue("AverageSpeed", travelRoute.AverageSpeed);
                    command.Parameters.AddWithValue("FuelSpent", travelRoute.FuelSpent);
                    command.Parameters.AddWithValue("TravelWarrantID", travelRoute.TravelWarrantID);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateTravelWarrant(TravelWarrant travelWarrant)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = nameof(UpdateTravelWarrant);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("IDTravelWarrant", travelWarrant.IDTravelWarrant);
                    command.Parameters.AddWithValue("Commander", travelWarrant.Commander);
                    command.Parameters.AddWithValue("WarrantNumber", travelWarrant.WarrantNumber);
                    command.Parameters.AddWithValue("StartPoint", travelWarrant.StartPoint);
                    command.Parameters.AddWithValue("Destination", travelWarrant.Destination);
                    command.Parameters.AddWithValue("QuantityOfDays", travelWarrant.QuantityOfDays);
                    command.Parameters.AddWithValue("DateOfOpening", travelWarrant.DateOfOpening);
                    command.Parameters.AddWithValue("DateOfClosing", travelWarrant.DateOfClosing);
                    command.Parameters.AddWithValue("DriverID", travelWarrant.DriverID);
                    command.Parameters.AddWithValue("VehicleID", travelWarrant.VehicleID);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = nameof(UpdateVehicle);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("IDVehicle", vehicle.IDVehicle);
                    command.Parameters.AddWithValue("VehicleType", vehicle.VehicleType);
                    command.Parameters.AddWithValue("Make", vehicle.Make);
                    command.Parameters.AddWithValue("YearOfMake", vehicle.YearOfMake);
                    command.Parameters.AddWithValue("Kilometers", vehicle.Kilometers);
                    command.Parameters.AddWithValue("IsAvailable", vehicle.IsAvailable);
                    command.Parameters.AddWithValue("VehicleServiceDetails", vehicle.VehicleServiceDetails);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVehicleService(int id, VehicleService vehicleService)
        {
            
        }
    }
}

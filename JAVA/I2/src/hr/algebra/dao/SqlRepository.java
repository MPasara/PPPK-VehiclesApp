/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao;

import hr.algebra.models.Driver;
import hr.algebra.models.Vehicle;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.List;
import javax.sql.DataSource;

/**
 *
 * @author pasar
 */
public class SqlRepository {

    private static final String INSERT_DRIVERS = "{call createDriver(?,?,?,?,?)}";
    private static final String INSERT_VEHICLES = "{call createVehicle(?,?,?,?,?,?,?)}";
    private static final String SELECT_DRIVERS = "{call selectDrivers()}";
    private static final String SELECT_VEHICLES = "{call selectVehicles()}";

    public static int insertDrivers(List<Driver> drivers) throws SQLException {
        DataSource dataSource = DataSourceSingleton.getInstance();

        try (Connection con = dataSource.getConnection();
                CallableStatement stmt = con.prepareCall(INSERT_DRIVERS)) {

            for (Driver driver : drivers) {
                stmt.registerOutParameter(1, Types.INTEGER);
                stmt.setString(2, driver.getFirstname());
                stmt.setString(3, driver.getSurname());
                stmt.setString(4, driver.getPhoneNumber());
                stmt.setString(5, driver.getDrivingLicenceNumber());
                
                stmt.executeUpdate();

            }
            return stmt.getInt(1);
        }
    }

    public static int insertVehicles(List<Vehicle> vehicles) throws SQLException {
        DataSource dataSource = DataSourceSingleton.getInstance();

        try (Connection con = dataSource.getConnection();
                CallableStatement stmt = con.prepareCall(INSERT_VEHICLES)) {
            
            for (Vehicle vehicle : vehicles) {
                stmt.registerOutParameter(1, Types.INTEGER);
                stmt.setString(2, vehicle.getVehicleType());
                stmt.setString(3, vehicle.getVehicleMake());
                stmt.setInt(4, vehicle.getYearOfMake());
                stmt.setInt(5, vehicle.getKilometersTravelled());
                stmt.setBoolean(6, vehicle.getIsAvailable());
                stmt.setString(7, vehicle.getVehicleServiceDetails());
                
                stmt.executeUpdate();
                
            }
            return stmt.getInt(1);
        }
    }

    public static List<Vehicle> selectVehicles() throws SQLException {
        List<Vehicle> vehicles = new ArrayList<>();
        
        DataSource dataSource = DataSourceSingleton.getInstance();
        
        try (Connection con = dataSource.getConnection();
                CallableStatement stmt = con.prepareCall(SELECT_VEHICLES)) {
            
            try(ResultSet rs = stmt.executeQuery()){
                while (rs.next()) {                    
                    vehicles.add(new Vehicle(
                            rs.getInt(1),
                            rs.getString(2),
                            rs.getString(3),
                            rs.getInt(4),
                            rs.getInt(5),
                            rs.getBoolean(6),
                            rs.getString(7)
                    ));
                    
                }
            }catch(SQLException ex){
                ex.printStackTrace();
            }
            
        }
        
        return vehicles;
    }

    public static List<Driver> selectDrivers() throws SQLException {
        List<Driver> drivers = new ArrayList<>();
        DataSource dataSource = DataSourceSingleton.getInstance();
        
        try (Connection con = dataSource.getConnection();
                CallableStatement stmt = con.prepareCall(SELECT_DRIVERS)) {
            
            try(ResultSet rs = stmt.executeQuery()){
                while (rs.next()) {                    
                    drivers.add(new Driver(
                            rs.getInt(1),
                            rs.getString(2),
                            rs.getString(3),
                            rs.getString(4),
                            rs.getString(5)
                    ));
                    
                }
            }catch(SQLException ex){
                ex.printStackTrace();
            }
            
        }
        
        return drivers;
    }
}

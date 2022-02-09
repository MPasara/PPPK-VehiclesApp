/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.validation;

import hr.algebra.dao.SqlRepository;
import hr.algebra.models.Driver;
import hr.algebra.models.Vehicle;
import java.sql.SQLException;
import java.util.List;

/**
 *
 * @author pasar
 */
public class ValidationUtils {

    public static boolean validateVehicles(List<Vehicle> dbVehicles) throws SQLException {
        
        dbVehicles = SqlRepository.selectVehicles();
        return !dbVehicles.isEmpty();
    }

    public static boolean validateDrivers(List<Driver> dbDrivers) throws SQLException {
        
        dbDrivers = SqlRepository.selectDrivers();
        return !dbDrivers.isEmpty();
    }
    
}

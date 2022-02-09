/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.main;

import hr.algebra.dao.SqlRepository;
import hr.algebra.models.Driver;
import hr.algebra.models.Vehicle;
import hr.algebra.validation.ValidationUtils;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ThreadLocalRandom;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author pasar
 */
public class I2 {

    /**
     * @param args the command line arguments
     * @throws java.lang.Exception
     */
    public static void main(String[] args) throws Exception {
        createDrivers(5);
        createVehicles(5);
        List<Driver> drivers = loadDriversFromCsv();
        List<Vehicle> vehicles = loadVehiclesFromCsv();
        try {
            SqlRepository.insertDrivers(drivers);
            SqlRepository.insertVehicles(vehicles);
        } catch (SQLException ex) {
            Logger.getLogger(I2.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.out.println("------------------------VALIDATION!!--------------------------");
        /*ValidationUtils.validateDrivers(drivers);
        ValidationUtils.validateVehicles(vehicles);*/
        System.out.println("Drivers:");
        System.out.println(ValidationUtils.validateDrivers(drivers) ? "All good" : "Na mate you fucked it");
        System.out.println("Vehicles:");
        System.out.println(ValidationUtils.validateVehicles(vehicles) ? "All good" : "Na mate you fucked it");
    }

    private static void createDrivers(int size) throws IOException {
        try (FileWriter writer = new FileWriter("Drivers.csv")) {
            for (int i = 0; i < size; i++) {
                writer.append(generateString(6));
                writer.append(",");
                writer.append(generateString(6));
                writer.append(",");
                writer.append(String.valueOf(generateRandomNumber(1111111, 9999999)));
                writer.append(",");
                writer.append(String.valueOf(generateRandomNumber(1111, 9999)));
                writer.append("\n");
            }
            writer.flush();
        }
    }

    private static void createVehicles(int size) throws IOException {
        try (FileWriter writer = new FileWriter("Vehicles.csv")) {
            for (int i = 0; i < size; i++) {
                writer.append(generateString(6));
                writer.append(",");
                writer.append(generateString(6));
                writer.append(",");
                writer.append(String.valueOf(generateRandomNumber(1900, 2021)));
                writer.append(",");
                writer.append(String.valueOf(generateRandomNumber(1, 500000)));
                writer.append(",");
                writer.append("true");
                writer.append(",");
                writer.append(generateString(20));
                writer.append("\n");
            }
            writer.flush();
        }
    }

    private static List<Driver> loadDriversFromCsv() {
        List<Driver> drivers = new ArrayList<>();
        
        try (BufferedReader reader = new BufferedReader(new FileReader("Drivers.csv"))){
            String line;
            while((line = reader.readLine())!= null){
                String[] values = line.split(",");
                drivers.add(new Driver(values[0],values[1],values[2],values[3]));
                System.out.println(drivers.toString());
            }
        } catch (IOException ex) {
            System.out.println("load Drivers no do");
        }
        return drivers;
    }

    private static List<Vehicle> loadVehiclesFromCsv() {
        List<Vehicle> vehicles = new ArrayList<>();
        
        try (BufferedReader reader = new BufferedReader(new FileReader("Vehicles.csv"))){
            String line;
            while((line = reader.readLine())!= null){
                String[] values = line.split(",");
                vehicles.add(new Vehicle(values[0], values[1],
                        Integer.parseInt(values[2]), Integer.parseInt(values[3]),
                        Boolean.parseBoolean(values[4]), values[5]));
                //String print = vehicles.forEach(v -> v.toString());
                System.out.println(vehicles.toString());
            }
        } catch (IOException ex) {
            System.out.println("load Vehicles no do");
        }
        
        return vehicles;
    }

    private static CharSequence generateString(int size) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < size; i++) {
            sb.append((char)ThreadLocalRandom.current().nextInt(97, 122));
        }        
        return sb.toString();
    }

    private static Object generateRandomNumber(int min, int max) {
        return (int) ((Math.random() * (max - min)) + min);
    }
    
}

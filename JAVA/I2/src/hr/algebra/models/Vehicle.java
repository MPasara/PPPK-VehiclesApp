/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.models;

/**
 *
 * @author pasar
 */
public class Vehicle {
    
    private int idVehicle;
    private String vehicleType;
    private String vehicleMake;
    private int yearOfMake;
    private int kilometersTravelled;
    private boolean isAvailable;
    private String vehicleServiceDetails;

    public Vehicle(int idVehicle, String vehicleType, String vehicleMake, int yearOfMake, int kilometersTravelled, boolean isAvailable,String vehicleServiceDetails) {
        this(vehicleType,vehicleMake,yearOfMake,kilometersTravelled,isAvailable, vehicleServiceDetails);
        this.idVehicle = idVehicle;
    }

    public Vehicle(String vehicleType, String vehicleMake, int yearOfMake, int kilometersTravelled, boolean isAvailable, String vehicleServiceDetails) {
        this.vehicleType = vehicleType;
        this.vehicleMake = vehicleMake;
        this.yearOfMake = yearOfMake;
        this.kilometersTravelled = kilometersTravelled;
        this.isAvailable = isAvailable;
        this.vehicleServiceDetails = vehicleServiceDetails;
    }

    

    public int getIdVehicle() {
        return idVehicle;
    }

    public void setIdVehicle(int idVehicle) {
        this.idVehicle = idVehicle;
    }

    public String getVehicleType() {
        return vehicleType;
    }

    public void setVehicleType(String vehicleType) {
        this.vehicleType = vehicleType;
    }

    public String getVehicleMake() {
        return vehicleMake;
    }

    public void setVehicleMake(String vehicleMake) {
        this.vehicleMake = vehicleMake;
    }

    public int getYearOfMake() {
        return yearOfMake;
    }

    public void setYearOfMake(int yearOfMake) {
        this.yearOfMake = yearOfMake;
    }

    public int getKilometersTravelled() {
        return kilometersTravelled;
    }

    public void setKilometersTravelled(int kilometersTravelled) {
        this.kilometersTravelled = kilometersTravelled;
    }

    public boolean getIsAvailable() {
        return isAvailable;
    }

    public void setIsAvailable(boolean isAvailable) {
        this.isAvailable = isAvailable;
    }

    public String getVehicleServiceDetails() {
        return vehicleServiceDetails;
    }

    public void setVehicleServiceDetails(String vehicleServiceDetails) {
        this.vehicleServiceDetails = vehicleServiceDetails;
    }
    
    
    @Override
    public String toString() {
        return "Vehicle{" + "idVehicle=" + idVehicle + ", vehicleType=" + vehicleType + ", vehicleMake=" + vehicleMake + '}';
    }
    
    
}

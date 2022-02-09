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
public class Driver {
    
    private int idDriver;
    private String firstname;
    private String surname;
    private String phoneNumber;
    private String drivingLicenceNumber;

    public Driver(int idDriver, String firstname, String surname, String phoneNumber, String drivingLicenceNumber) {
        this(firstname,surname,phoneNumber,drivingLicenceNumber);
        this.idDriver = idDriver;
    }

    public Driver(String firstname, String surname, String phoneNumber, String drivingLicenceNumber) {
        this.firstname = firstname;
        this.surname = surname;
        this.phoneNumber = phoneNumber;
        this.drivingLicenceNumber = drivingLicenceNumber;
    }

    public int getIdDriver() {
        return idDriver;
    }

    public void setIdDriver(int idDriver) {
        this.idDriver = idDriver;
    }

    public String getFirstname() {
        return firstname;
    }

    public void setFirstname(String firstname) {
        this.firstname = firstname;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getDrivingLicenceNumber() {
        return drivingLicenceNumber;
    }

    public void setDrivingLicenceNumber(String drivingLicenceNumber) {
        this.drivingLicenceNumber = drivingLicenceNumber;
    }

    @Override
    public String toString() {
        return "Driver{" + "idDriver=" + idDriver + ", firstname=" + firstname + ", surname=" + surname + '}';
    }
    
    
}

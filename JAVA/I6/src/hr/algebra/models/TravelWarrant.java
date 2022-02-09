/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.models;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Temporal;

/**
 *
 * @author pasar
 */
@Entity
public class TravelWarrant implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int IDTravelWarrant;
    
    @Column(name = "Commander")
    private String Commander;
    
    @Column(name = "WarrantNumber")
    private int WarrantNumner;
    
    @Column(name = "StartPoint")
    private String StartPoint;
    
    @Column(name = "Destination")
    private String Destination;
    
    @Column(name = "QuantityOfDays")
    private int QuantityOfDays;
    
    @Column(name = "DateOfopening")
    @Temporal(javax.persistence.TemporalType.TIMESTAMP)
    private Date DateOfopening;
    
    @Column(name = "DateOfClosing")
    @Temporal(javax.persistence.TemporalType.TIMESTAMP)
    private Date DateOfClosing;
    
    @Column(name = "DriverID")
    private int DriverID;
    
    @Column(name = "VehicleID")
    private int VehicleId;

    public TravelWarrant() {
    }

    public TravelWarrant(int IDTravelWarrant, String Commander, int WarrantNumner, String StartPoint, String Destination, int QuantityOfDays, Date DateOfopening, Date DateOfClosing, int DriverID, int VehicleId) {
        this.IDTravelWarrant = IDTravelWarrant;
        this.Commander = Commander;
        this.WarrantNumner = WarrantNumner;
        this.StartPoint = StartPoint;
        this.Destination = Destination;
        this.QuantityOfDays = QuantityOfDays;
        this.DateOfopening = DateOfopening;
        this.DateOfClosing = DateOfClosing;
        this.DriverID = DriverID;
        this.VehicleId = VehicleId;
    }

    public int getIDTravelWarrant() {
        return IDTravelWarrant;
    }

    public void setIDTravelWarrant(int IDTravelWarrant) {
        this.IDTravelWarrant = IDTravelWarrant;
    }

    public String getCommander() {
        return Commander;
    }

    public void setCommander(String Commander) {
        this.Commander = Commander;
    }

    public int getWarrantNumner() {
        return WarrantNumner;
    }

    public void setWarrantNumner(int WarrantNumner) {
        this.WarrantNumner = WarrantNumner;
    }

    public String getStartPoint() {
        return StartPoint;
    }

    public void setStartPoint(String StartPoint) {
        this.StartPoint = StartPoint;
    }

    public String getDestination() {
        return Destination;
    }

    public void setDestination(String Destination) {
        this.Destination = Destination;
    }

    public int getQuantityOfDays() {
        return QuantityOfDays;
    }

    public void setQuantityOfDays(int QuantityOfDays) {
        this.QuantityOfDays = QuantityOfDays;
    }

    public Date getDateOfopening() {
        return DateOfopening;
    }

    public void setDateOfopening(Date DateOfopening) {
        this.DateOfopening = DateOfopening;
    }

    public Date getDateOfClosing() {
        return DateOfClosing;
    }

    public void setDateOfClosing(Date DateOfClosing) {
        this.DateOfClosing = DateOfClosing;
    }

    public int getDriverID() {
        return DriverID;
    }

    public void setDriverID(int DriverID) {
        this.DriverID = DriverID;
    }

    public int getVehicleId() {
        return VehicleId;
    }

    public void setVehicleId(int VehicleId) {
        this.VehicleId = VehicleId;
    }
    
    
    public int getId() {
        return IDTravelWarrant;
    }

    public void setId(int id) {
        this.IDTravelWarrant = id;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (int) IDTravelWarrant;
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TravelWarrant)) {
            return false;
        }
        TravelWarrant other = (TravelWarrant) object;
        return this.IDTravelWarrant == other.IDTravelWarrant;
    }

    @Override
    public String toString() {
        return "TravelWarrant[ id=" + IDTravelWarrant + " ]";
    }
    
}

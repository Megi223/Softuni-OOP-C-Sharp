using System;
using System.Collections.Generic;
using System.Text;

namespace P01P02Vehicles
{
   public abstract class Vehicle
    {
        
        public Vehicle(double fuelQuantity,double litersPerKm,double tankCapacity)
        {
           
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }
        
        public double FuelQuantity { get; set; }
        public double LitersPerKm { get; set; }
        public double TankCapacity { get; set; }
        public abstract void Drive(double distance);
        public abstract void Refuel(double fuel);
        public abstract void DriveEmpty(double distance);


    }
}

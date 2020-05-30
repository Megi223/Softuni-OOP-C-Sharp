using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles
{
   public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity,double litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
        }
        public double FuelQuantity { get; set; }
        public double LitersPerKm { get; set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double fuel);


    }
}

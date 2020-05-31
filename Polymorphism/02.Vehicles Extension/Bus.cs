using System;
using System.Collections.Generic;
using System.Text;

namespace P01P02Vehicles
{
    public class Bus : Vehicle
    {
        private const double INCREASED_FUEL_CONSUMPTION = 1.4;
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
        {
            
        }

        public override void Drive(double distance)
        {
            double litersPerKmNew = this.LitersPerKm + INCREASED_FUEL_CONSUMPTION;
            double neededFuel = distance * litersPerKmNew;
            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
       

        public override void DriveEmpty(double distance)
        {
            double neededFuel = distance * LitersPerKm;
            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double allFuel = this.FuelQuantity + fuel;
                if (allFuel > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += fuel;
                }
            }
            
        }
    }
}

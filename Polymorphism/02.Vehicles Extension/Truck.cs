using System;
using System.Collections.Generic;
using System.Text;

namespace P01P02Vehicles
{
    public class Truck : Vehicle
    {
        private const double INCREASED_FUEL_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
        {
            
        }

        public override void Drive(double distance)
        {
            double litersPerKmNew = this.LitersPerKm + INCREASED_FUEL_CONSUMPTION;
            double neededFuel = distance * litersPerKmNew;
            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void DriveEmpty(double distance)
        {
            
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double fuelToBeAdded = 0.95 * fuel;
                double allFuel = this.FuelQuantity + fuelToBeAdded;
                if (allFuel > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += fuelToBeAdded;
                }
            }
            
        }
    }
}

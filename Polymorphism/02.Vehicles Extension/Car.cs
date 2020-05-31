using System;
using System.Collections.Generic;
using System.Text;

namespace P01P02Vehicles
{
    public class Car : Vehicle
    {
        private const double INCREASED_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) : base(fuelQuantity, litersPerKm, tankCapacity)
        {
            
        }

        public override void Drive(double distance)
        {
            double litersPerKmNew = this.LitersPerKm + INCREASED_FUEL_CONSUMPTION;
            double neededFuel = distance * litersPerKmNew;
            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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

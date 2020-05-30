using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles
{
    public class Truck : Vehicle
    {
        private const double INCREASED_FUEL_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double litersPerKm) : base(fuelQuantity, litersPerKm)
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

        public override void Refuel(double fuel)
        {
            double fuelToBeAdded = 0.95 * fuel;
            this.FuelQuantity += fuelToBeAdded;
        }
    }
}

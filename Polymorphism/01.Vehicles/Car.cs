using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles
{
    public class Car : Vehicle
    {
        private const double INCREASED_FUEL_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double litersPerKm) : base(fuelQuantity, litersPerKm)
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

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}

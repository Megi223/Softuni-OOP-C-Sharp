using System;
using System.Linq;

namespace P01Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split()
                .ToArray();
            string[] truckArgs = Console.ReadLine()
               .Split()
               .ToArray();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputLine= Console.ReadLine()
                .Split()
                .ToArray();

                string cmdType = inputLine[0];
                string vehicleType = inputLine[1];
                if (cmdType == "Drive" && vehicleType=="Car")
                {
                    double distance = double.Parse(inputLine[2]);
                    car.Drive(distance);
                }
                else if (cmdType == "Drive" && vehicleType == "Truck")
                {
                    double distance = double.Parse(inputLine[2]);
                    truck.Drive(distance);
                }
                else if (cmdType == "Refuel" && vehicleType == "Car")
                {
                    double fuel = double.Parse(inputLine[2]);
                    car.Refuel(fuel);
                }
                else if (cmdType == "Refuel" && vehicleType == "Truck")
                {
                    double fuel = double.Parse(inputLine[2]);
                    truck.Refuel(fuel);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}

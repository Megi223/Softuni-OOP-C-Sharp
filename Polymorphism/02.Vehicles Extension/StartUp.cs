using System;
using System.Linq;

namespace P01P02Vehicles
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
            string[] busArgs = Console.ReadLine()
               .Split()
               .ToArray();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]),double.Parse(carArgs[3]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            Vehicle bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));


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
                    DriveVehicle(car, inputLine);
                }
                else if (cmdType == "Drive" && vehicleType == "Truck")
                {
                    DriveVehicle(truck, inputLine);
                }
                else if (cmdType == "Refuel" && vehicleType == "Car")
                {
                    RefuelVehicle(car, inputLine);
                }
                else if (cmdType == "Refuel" && vehicleType == "Truck")
                {
                    RefuelVehicle(truck, inputLine);

                }
                else if(cmdType=="Refuel" && vehicleType == "Bus")
                {
                    RefuelVehicle(bus, inputLine);

                }
                else if(cmdType=="Drive" && vehicleType == "Bus")
                {
                    DriveVehicle(bus, inputLine);

                }
                else if(cmdType=="DriveEmpty" && vehicleType == "Bus")
                {
                    double distance = double.Parse(inputLine[2]);
                    bus.DriveEmpty(distance);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");


        }

        private static void DriveVehicle(Vehicle vehicle, string[] inputLine)
        {
            double distance = double.Parse(inputLine[2]);
            vehicle.Drive(distance);
        }

        private static void RefuelVehicle(Vehicle vehicle, string[] inputLine)
        {
            double fuel = double.Parse(inputLine[2]);
            vehicle.Refuel(fuel);
        }
    }
}

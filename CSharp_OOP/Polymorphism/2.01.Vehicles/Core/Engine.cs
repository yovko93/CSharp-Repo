using System;
using System.Linq;

using _2._01.Vehicles.Models;
using _2._01.Vehicles.Factories;
using _2._01.Vehicles.Core.Contracts;

namespace _2._01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory  vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();  
        }

        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                string command = input[0];
                string vehicleType = input[1];
                double arg = double.Parse(input[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void Refuel(Vehicle vehicle, double litters)
        {
            vehicle.Refuel(litters);
        }

        private void Drive(Vehicle vehicle, double km)
        {
            Console.WriteLine(vehicle.Drive(km));
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);

            Vehicle currentVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);

            return currentVehicle;
        }
    }
}

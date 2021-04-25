using System;
using System.Linq;

using _2._02.VehiclesExtension.Models;
using _2._02.VehiclesExtension.Factories;
using _2._02.VehiclesExtension.Core.Contracts;

namespace _2._02.VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

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
                        else if (vehicleType == "Bus")
                        {
                            bus.IsEmpty = false;
                            this.Drive(bus, arg);
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
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, arg);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        if (vehicleType == "Bus")
                        {
                            bus.IsEmpty = true;
                            this.Drive(bus, arg);
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
            Console.WriteLine(bus);
        }

        private void Drive(Vehicle vehicle, double km)
        {
            Console.WriteLine(vehicle.Drive(km));
        }

        private void Refuel(Vehicle vehicle, double litters)
        {
            vehicle.Refuel(litters);
        }

        //private void DriveEmpty(Vehicle vehicle, double km)
        //{
        //    vehicle.DriveEmpty(km);
        //}

        private Vehicle ProcessVehicleInfo()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string vehicleType = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            Vehicle currentVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return currentVehicle;
        }
    }
}

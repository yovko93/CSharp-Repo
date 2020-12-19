using System;
using System.Collections.Generic;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new CatalogVehicle();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] data = command.Split('/');
                string type = data[0];
                string brand = data[1];
                string model = data[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(data[3]);

                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;

                    cars.Add(car);
                    catalog.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(data[3]);

                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;

                    trucks.Add(truck);
                    catalog.Trucks.Add(truck);
                }
                
                command = Console.ReadLine();
            }

           
        }

        class Car
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public int HorsePower { get; set; }

            public override string ToString()
            {
                return $"{Brand}: {Model} - {HorsePower}kg";
            }
        }

        class Truck
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public int Weight { get; set; }

            public override string ToString()
            {
                return $"{Brand}: {Model} - {Weight}kg";
            }
        }

        class CatalogVehicle
        {
            public List<Car> Cars { get; set; }

            public List<Truck> Trucks { get; set; }

            public CatalogVehicle()
            {
                //Cars = new List<Car>();
            }
        }
    }
}

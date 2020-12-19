using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] info = command.Split().ToArray();
                string typeOfVehicle = info[0];
                string model = info[1];
                string color = info[2];
                double horsepower = double.Parse(info[3]);

                Vehicle vehicle = new Vehicle(typeOfVehicle, model, color, horsepower);

                vehicles.Add(vehicle);

                command = Console.ReadLine();
            }

            string modelOfVehicle = Console.ReadLine();
            while (modelOfVehicle != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.FirstOrDefault(x => x.Model == modelOfVehicle).ToString());

                modelOfVehicle = Console.ReadLine();
            }

            var cars = vehicles.FindAll(x => x.Type == "car");
            var carHorsepower = cars.Sum(c => c.Horsepower);
            var carAveragePower = carHorsepower / cars.Count;

            var trucks = vehicles.FindAll(x => x.Type == "truck");
            var truckHorsePower = trucks.Sum(c => c.Horsepower);
            var truckAveragePower = truckHorsePower / trucks.Count;

            if (cars.Count == 0)
            {
                carAveragePower = 0;
            }
            if (trucks.Count == 0)
            {
                truckAveragePower = 0;
            }

            Console.WriteLine($"Cars have average horsepower of: {carAveragePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAveragePower:f2}.");
        }

        public class Vehicle
        {

            public string Type { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }

            public double Horsepower { get; set; }

            public Vehicle(string type, string model, string color, double horsepower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.Horsepower = horsepower;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (Type == "car")
                {
                    sb.AppendLine($"Type: Car");
                }
                else
                {
                    sb.AppendLine($"Type: Truck");
                }
                sb.AppendLine($"Model: {this.Model}");
                sb.AppendLine($"Color: {this.Color}");
                sb.AppendLine($"Horsepower: {this.Horsepower}");

                return sb.ToString().TrimEnd();
            }
        }
    }
}

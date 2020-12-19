using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;


        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count
           => this.cars.Count;

        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = cars.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);

            return cars.Remove(car);
        }

        public Car GetLatestCar()
        {
            if (cars.Count > 0)
            {
                var car = cars.OrderByDescending(x => x.Year).First();
                return car;
            }
            else
            {
                return null;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            var car = cars.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);

            if (car != null)
            {
                return car;
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb
                .ToString()
                .Trim();
        }

    }
}

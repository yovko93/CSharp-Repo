using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.SpeedRacing
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();

                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionFor1km = double.Parse(info[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split().ToArray();

                if (data[0] == "Drive")
                {
                    string carModel = data[1];
                    double amountOfKm = double.Parse(data[2]);

                    //Car car = GetCar(cars, carModel);

                    Car car = cars.FirstOrDefault(x => x.Model == carModel);
                    car.Drive(amountOfKm);

                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {

                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");

            }
        }

        //private static Car GetCar(List<Car> cars, string model)
        //{
        //    foreach (var car in cars)
        //    {
        //        if (car.Model == model)
        //        {
        //            return car;
        //        }
        //    }

        //    return null;
        //}
    }
}

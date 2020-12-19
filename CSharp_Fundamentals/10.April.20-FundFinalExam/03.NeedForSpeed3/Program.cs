using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CarInfo> cars = new Dictionary<string, CarInfo>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string car = carInfo[0];
                int distance = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                CarInfo currentCar = new CarInfo(distance, fuel);

                cars.Add(car, currentCar);
                cars[car].Mileage = distance;
                cars[car].Fuel = fuel;
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                var data = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = data[0];
                string car = data[1];

                if (command == "Drive")
                {
                    int currentDistance = int.Parse(data[2]);
                    int currentFuel = int.Parse(data[3]);

                    if (cars[car].Fuel < currentFuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Mileage += currentDistance;
                        cars[car].Fuel -= currentFuel;
                        Console.WriteLine($"{car} driven for {currentDistance} kilometers. {currentFuel} liters of fuel consumed.");
                    }
                    if (cars[car].Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }

                }
                else if (command == "Refuel")
                {
                    int currentFuel = int.Parse(data[2]);
                    int refueled = currentFuel;

                    if (cars[car].Fuel + currentFuel > 75)
                    {
                        refueled = 75 - cars[car].Fuel;
                        cars[car].Fuel = 75;
                    }
                    else
                    {
                        cars[car].Fuel += refueled;
                    }

                    Console.WriteLine($"{car} refueled with {refueled} liters");
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(data[2]);

                    cars[car].Mileage -= kilometers;

                    if (cars[car].Mileage < 10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }

                input = Console.ReadLine();
            }

            var sorted = cars
                .OrderByDescending(x => x.Value.Mileage)
                .ThenBy(c => c.Key)
                .ToList();

            foreach (var car in sorted)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }

        }

        public class CarInfo
        {
            public int Mileage { get; set; }

            public int Fuel { get;  set; }

            public CarInfo(int mileage, int fuel)
            {
                this.Mileage = mileage;
                this.Fuel = fuel;
            }

        }
    }
}

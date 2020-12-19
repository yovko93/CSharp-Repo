using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> cars = new HashSet<string>();

            while (input != "END")
            {
                string[] command = input
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                string direction = command[0];
                string licensePlate = command[1];

                if (direction == "IN")
                {
                    cars.Add(licensePlate);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(licensePlate);
                }

                input = Console.ReadLine();
            }

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

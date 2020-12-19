using System;
using System.Collections.Generic;

namespace _1._08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsForGreenLight = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsForGreenLight; i++)
                    {
                        string car;

                        if (cars.TryDequeue(out car))
                        {
                            Console.WriteLine($"{car} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

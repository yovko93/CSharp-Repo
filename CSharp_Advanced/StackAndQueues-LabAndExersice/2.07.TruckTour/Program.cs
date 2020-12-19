using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }

            int totalFuel = 0;

            for (int i = 0; i < n; i++)
            {
                string currentInfo = circle.Dequeue();
                var info = currentInfo.Split().Select(int.Parse).ToArray();

                int fuel = info[0];
                int distance = info[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    i = -1;
                    totalFuel = 0;
                }

                circle.Enqueue(currentInfo);
            }

            var data = circle.Dequeue().Split().ToArray();

            Console.WriteLine(data[2]);
        }
    }
}

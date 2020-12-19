using System;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int time = 0;

            int peoplePerHour = firstEmployee + secondEmployee + thirdEmployee;

            while (peopleCount > 0)
            {
                peopleCount -= peoplePerHour;
                time++;
                if (time % 4 == 0)
                {
                    time++;
                    continue;
                }

            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}

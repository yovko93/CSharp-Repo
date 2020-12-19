using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int time = 0;

            int helpedPeoplePerHour = firstEmployee + secondEmployee + thirdEmployee;

            while (studentsCount > 0)
            {
                studentsCount -= helpedPeoplePerHour;
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

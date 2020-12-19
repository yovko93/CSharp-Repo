using System;

namespace _5.Time_15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());

            int timeSum = (startHour * 60) + startMinutes + 15;
            int hour = timeSum / 60;
            int minutes = timeSum % 60;

            if (hour >= 24)
            {
                hour -= 24;
                Console.WriteLine($"{hour}:{minutes:00}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes:00}");
            }
        }
    }
}

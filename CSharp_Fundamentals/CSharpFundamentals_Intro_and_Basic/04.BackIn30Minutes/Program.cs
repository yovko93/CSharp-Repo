using System;

namespace _04.BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // minutes += 30;

            //if (minutes > 59)
            //{
            //    minutes -= 60;
            //    hour += 1;
            //    if (hour > 23)
            //    {
            //        hour -= 24;
            //        Console.WriteLine($"{hour}:{minutes:00}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{hour}:{minutes:00}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"{hour}:{minutes:00}");
            //}

            int timeSum = (hour * 60) + (minutes + 30);
            int realHour = timeSum / 60;
            int realMinute = timeSum % 60;
            if (realHour >=24)
            {
                realHour -= 24;
                Console.WriteLine($"{realHour}:{realMinute:00}");
            }
            else
            {
                Console.WriteLine($"{realHour}:{realMinute:00}");
            }
        }
    }
}

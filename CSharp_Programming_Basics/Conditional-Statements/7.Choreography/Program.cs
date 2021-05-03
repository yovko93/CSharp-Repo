using System;

namespace _7.Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = int.Parse(Console.ReadLine());
            double dancers = int.Parse(Console.ReadLine());
            double daysForTraining = int.Parse(Console.ReadLine());

            double stepsInDay = (steps / daysForTraining) / steps * 100;
            double percent = Math.Ceiling(stepsInDay);
            double stepsForDancers = percent / dancers;

            if(percent <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsForDancers:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepsForDancers:f2}% steps to be learned per day.");
            }


        }
    }
}

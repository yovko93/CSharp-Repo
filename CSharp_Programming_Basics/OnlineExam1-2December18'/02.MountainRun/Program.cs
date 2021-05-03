using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsInMeter = double.Parse(Console.ReadLine());

            double slow = Math.Floor(distance / 50);
            double time = (distance * secondsInMeter) + slow * 30;

            if (time < record)
            {
                Console.WriteLine($" Yes! The new record is {time:f2} seconds.");
            }
            else
            {
                double diff = time - record;
                Console.WriteLine($"No! He was {diff:f2} seconds slower.");
            }
        }
    }
}

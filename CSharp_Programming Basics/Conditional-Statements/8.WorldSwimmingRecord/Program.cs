using System;

namespace _8.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanceInM = double.Parse(Console.ReadLine());
            double timeFor1M = double.Parse(Console.ReadLine());

            double slowdown = Math.Floor(distanceInM / 15);
            double resistance = slowdown * 12.5;
            double ivanchoTime = (timeFor1M * distanceInM) + resistance;

            if(record > ivanchoTime)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {ivanchoTime:f2} seconds.");
            }
            else
            {
                double neededTime = ivanchoTime - record;
                Console.WriteLine($"No, he failed! He was {neededTime:f2} seconds slower.");
            }

        }
    }
}

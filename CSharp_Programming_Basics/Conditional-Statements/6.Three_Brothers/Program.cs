using System;

namespace _6.Three_Brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrother = double.Parse(Console.ReadLine());
            double secondBrother = double.Parse(Console.ReadLine());
            double thirdBrother = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double cleaningTime = 1 / (1 / firstBrother + 1 / secondBrother + 1 / thirdBrother);
            double totalCleaningTime = cleaningTime + (cleaningTime * 0.15);

            Console.WriteLine($"Cleaning time: {totalCleaningTime:f2}");

            double timeLeft = fatherTime - totalCleaningTime;

            if (timeLeft >= 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }
            else
            {
                Console.WriteLine("No, there isn't a surprise - shortage of time -> {0:f0} hours.", Math.Ceiling(Math.Abs(timeLeft)));
            }

        }
    }
}

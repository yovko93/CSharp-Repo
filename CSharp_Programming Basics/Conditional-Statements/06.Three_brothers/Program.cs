using System;

namespace 06.Three_brothers
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
            double totalCleaningTime = cleaningTime * 1.15;

            Console.WriteLine($"Cleaning time: {totalCleaningTime:f2}");

            double timeLeft = fatherTime - totalCleaningTime;

            if (timeLeft >= 0)
            {
               ;
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }
            else if (timeLeft < 0)
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeLeft)} hours.");
            }


        }
    }
}

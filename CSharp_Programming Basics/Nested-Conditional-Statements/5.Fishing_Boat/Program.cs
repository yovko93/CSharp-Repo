using System;

namespace _5.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double currentPrice = 0.0;
            double finalPrice = 0.0;

            if (season == "Spring")
            {
                if (fishers <= 6)
                {
                    currentPrice = 3000 - (3000 * 0.1);
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    currentPrice = 3000 - (3000 * 0.15);
                }
                else if (fishers >= 12)
                {
                    currentPrice = 3000 - (3000 * 0.25);
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                if (fishers <= 6)
                {
                    currentPrice = 4200 - (4200 * 0.1);
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    currentPrice = 4200 - (4200 * 0.15);
                }
                else if (fishers >= 12)
                {
                    currentPrice = 4200 - (4200 * 0.25);
                }           
            }
            else if (season == "Winter")
            {
                if (fishers <= 6)
                {
                    currentPrice = 2600 - (2600 * 0.1);
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    currentPrice = 2600 - (2600 * 0.15);
                }
                else if (fishers >= 12)
                {
                    currentPrice = 2600 - (2600 * 0.25);
                }
            }
            if (fishers % 2 == 0 && season != "Autumn")
            {
                finalPrice = currentPrice - (currentPrice * 0.05);
            }
            else
            {
                finalPrice = currentPrice;
            }
            if (finalPrice <= budget)
            {
                double leftMoney = budget - finalPrice;
                Console.WriteLine($"Yes! You have {leftMoney:f2} leva left.");
            }
            else
            {
                double neededMoney = finalPrice - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva.");
            }
        }
    }
}

using System;

namespace _02.FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double shirtPrice = double.Parse(Console.ReadLine());
            double neededSum = double.Parse(Console.ReadLine());

            double shortsPrice = shirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.2;
            double bottonsPrice = 2 * (shirtPrice + shortsPrice);

            double totalSum = shirtPrice + shortsPrice + socksPrice + bottonsPrice;
            double discount = totalSum * 0.15;
            double finalPrice = totalSum - discount;

            if (finalPrice >= neededSum)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {finalPrice:f2} lv.");
            }
            else
            {
                double diff = neededSum - finalPrice;
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {diff:f2} lv. more.");
            }
        }
    }
}

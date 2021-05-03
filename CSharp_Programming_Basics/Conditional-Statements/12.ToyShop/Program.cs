using System;

namespace _12.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double toysPrice = (puzzleCount * 2.60) + (dollsCount * 3.0) + (bearsCount * 4.10) + (minionsCount * 8.2) + (trucksCount * 2.0);
            int toysCount = puzzleCount + dollsCount + bearsCount + minionsCount + trucksCount;

            double totalEarning = 0.0;
            double discount = 0.0;
            double rent = 0.0;

            if (toysCount >= 50)
            {
                discount = toysPrice * 0.25;
                totalEarning = toysPrice - discount;
                rent = totalEarning * 0.1;
                totalEarning -= rent;
            }
            else
            {
                rent = toysPrice * 0.1;
                totalEarning = toysPrice - rent;
            }
            if (tripPrice <= totalEarning)
            {
                double diff = totalEarning - tripPrice;
                Console.WriteLine($"Yes! {diff:f2} lv left.");
            }
            else if(totalEarning < tripPrice)
            {
                double diff = tripPrice - totalEarning;
                Console.WriteLine($"Not enough money! {diff:f2} lv needed.");
            }
           
        }
    }
}

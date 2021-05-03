using System;

namespace _05.FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int totalPrice = 0;


            while (counter < n)
            {
                string article = Console.ReadLine();
                counter++;
                if (article == "hoodie")
                {
                    totalPrice += 30;
                }
                else if (article == "keychain")
                {
                    totalPrice += 4;
                }
                else if (article == "T-shirt")
                {
                    totalPrice += 20;
                }
                else if (article == "flag")
                {
                    totalPrice += 15;
                }
                else if (article == "sticker")
                {
                    totalPrice += 1;
                }
            }
            int diff = Math.Abs(budget - totalPrice);
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You bought {n} items and left with {diff} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {diff} more lv.");
            }
        }
    }
}

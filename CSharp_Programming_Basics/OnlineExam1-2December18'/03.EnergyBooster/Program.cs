using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int countSet = int.Parse(Console.ReadLine());

            double price = 0.0;
            double discount = 0.0;
            double totalPrice = 0.0;

            if (fruit == "Watermelon")
            {
                if (size == "small")
                {
                    price = 2 * countSet * 56.0;
                }
                else if (size == "big")
                {
                    price = 5 * countSet * 28.70;
                }
            }
            else if (fruit == "Mango")
            {
                if (size == "small")
                {
                    price = 2 * countSet * 36.66;
                }
                else if (size == "big")
                {
                    price = 5 * countSet * 19.60;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (size == "small")
                {
                    price = 2 * countSet * 42.10;
                }
                else if (size == "big")
                {
                    price = 5 * countSet * 24.80;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (size == "small")
                {
                    price = 2 * countSet * 20.0;
                }
                else if (size == "big")
                {
                    price = 5 * countSet * 15.20;
                }
            }
            if (price >= 400 && price <= 1000)
            {
                discount = price * 0.15;
                totalPrice = price - discount;
            }
            else if (price > 1000)
            {
                totalPrice = price / 2;
            }
            else
            {
                totalPrice = price;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}

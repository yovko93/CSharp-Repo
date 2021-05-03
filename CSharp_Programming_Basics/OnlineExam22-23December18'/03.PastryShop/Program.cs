using System;

namespace _03.PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string sweet = Console.ReadLine();
            int countSweets = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());

            double discount = 0.0;
            double price = 0.0;
            double totalPrice = 0.0;

            if (sweet == "Cake")
            {
                if (day <= 15)
                {
                    price = countSweets * 24.0;
                }
                else
                {
                    price = countSweets * 28.70;
                }
            }
            else if (sweet == "Souffle")
            {
                if (day <= 15)
                {
                    price = countSweets * 6.66;
                }
                else
                {
                    price = countSweets * 9.80;
                }
            }
            else if (sweet == "Baklava")
            {
                if (day <= 15)
                {
                    price = countSweets * 12.60;
                }
                else
                {
                    price = countSweets * 16.98;
                }
            }

            if (day <= 22)
            {
                if (price > 200)
                {
                    discount = 0.25;
                    totalPrice = price - price * discount;
                    
                }
                else if (price >= 100)
                {
                    discount = 0.15;
                    totalPrice = price - price * discount;
                }
                else
                {
                    totalPrice = price;
                }
                if (day <= 15)
                {
                    discount = 0.1;
                    totalPrice = totalPrice - totalPrice * 0.1;
                }
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (day > 22)
            {
                totalPrice = price;
                Console.WriteLine($"{totalPrice:f2}");
            }
            
        }
    }
}

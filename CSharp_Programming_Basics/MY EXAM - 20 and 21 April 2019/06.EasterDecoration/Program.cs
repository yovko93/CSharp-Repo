using System;

namespace _06.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());
            
            double allMoney = 0.0;

            for (int i = 1; i <= customers; i++)
            {
                string purchase = Console.ReadLine();
                double price = 0;
                int items = 0;

                while (purchase != "Finish")
                {
                    items++;
                    if (purchase == "basket")
                    {
                        price += 1.5;
                    }
                    else if (purchase == "wreath")
                    {
                        price += 3.8;
                    }
                    else if (purchase == "chocolate bunny")
                    {
                        price += 7.0;
                    }
                    purchase = Console.ReadLine();
                }
                if (items % 2 == 0)
                {
                    double discount = price * 0.2;
                    price -= discount;
                }
                allMoney += price;
                if (purchase == "Finish")
                {
                    Console.WriteLine($"You purchased {items} items for {price:f2} leva.");
                }
            }
            double averageMoney = allMoney/customers; 
            Console.WriteLine($"Average bill per client is: {averageMoney:f2} leva.");
        }
    }
}

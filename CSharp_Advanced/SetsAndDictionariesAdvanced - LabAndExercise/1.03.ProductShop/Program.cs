using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, double>> foodShops = new SortedDictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] data = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!foodShops.ContainsKey(shop))
                {
                    foodShops.Add(shop, new Dictionary<string, double>());
                }

                foodShops[shop].Add(product, price);

                input = Console.ReadLine();
            }

            foreach (var shop in foodShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {(double)product.Value}");
                }
            }
        }
    }
}

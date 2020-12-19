using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> productsInfo = new Dictionary<string, Product>();
            
            string command = Console.ReadLine();
            while (command != "buy")
            {
                var info = command.Split().ToArray();
                string name = info[0];
                decimal price = decimal.Parse(info[1]);
                int quantity = int.Parse(info[2]);

                Product product = new Product(name,price,quantity);

                if (productsInfo.ContainsKey(name))
                {
                    productsInfo[name].Price = price;
                    productsInfo[name].Quantity += quantity;
                }
                else
                {
                    productsInfo.Add(name, product);
                }

                command = Console.ReadLine();
            }

            foreach (var product in productsInfo)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price* product.Value.Quantity:f2}");
            }

        }

        public class Product
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public int Quantity { get; set; }

            public Product(string name, decimal price, int quantity)
            {
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;
            }

        }
    }
}

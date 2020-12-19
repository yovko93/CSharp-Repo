using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintResult(quantity, product);
        }

        static void PrintResult(int n, string product)
        {
            double result = 0;
            double coffee = 1.5;
            double water = 1.0;
            double coke = 1.4;
            double snacks = 2.0;

            switch (product)
            {
                case "coffee":
                    result = coffee * n;
                    break;
                case "water":
                    result = water * n;
                    break;
                case "coke":
                    result = coke * n;
                    break;
                case "snacks":
                    result = snacks * n;
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }

       
    }
}

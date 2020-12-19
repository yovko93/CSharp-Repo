using System;

namespace _02.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double uniformPrice = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.1;
            double statistPrice = statist * uniformPrice;
            double discount = 0.0;
            if (statist > 150)
            {
                 discount = statistPrice * 0.1;
            }
            double totalPrice = decorPrice + statistPrice - discount;
            double diff = Math.Abs(totalPrice - budget);

            if (totalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {diff:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {diff:f2} leva left.");
            }
        }
    }
}

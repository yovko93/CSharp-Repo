using System;

namespace _02.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double sideTriangle = double.Parse(Console.ReadLine());
            double hTriangle = double.Parse(Console.ReadLine());
            double tailPrice = double.Parse(Console.ReadLine());
            double work = double.Parse(Console.ReadLine());

            double area = a * b;
            double areaTail = (sideTriangle * hTriangle) / 2;
            double tailNeeded = Math.Ceiling(area / areaTail) + 5;
            double moneyNeeded = (tailNeeded*tailPrice) + work;

            double diff = Math.Abs(budget - moneyNeeded);
            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"{diff:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"You'll need {diff:f2} lv more.");
            }
        }
    }
}

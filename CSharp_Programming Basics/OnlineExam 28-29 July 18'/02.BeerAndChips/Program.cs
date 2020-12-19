using System;

namespace _02.BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int countBeers = int.Parse(Console.ReadLine());
            int countChips = int.Parse(Console.ReadLine());

            double beerPrice = countBeers * 1.2;
            double chipsPrice = Math.Ceiling(beerPrice * 0.45 * countChips);
            double neededMoney = beerPrice + chipsPrice;
            double diff = Math.Abs(budget - neededMoney);

            if (budget >= neededMoney)
            {
                
                Console.WriteLine($"{name} bought a snack and has {diff:f2} leva left.");
            }
            else
            {

                Console.WriteLine($"{name} needs {diff:f2} more leva!");
            }
        }
    }
}

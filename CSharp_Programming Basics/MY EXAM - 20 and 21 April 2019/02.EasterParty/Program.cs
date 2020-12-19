using System;

namespace _02.EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double personPrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double discount = 0.0;
            double moneyNeeded = 0.0;
            double cakePrice = budget * 0.1;

            if (guests >= 10 && guests <= 15)
            {
                discount = personPrice * 0.85;

            }
            else if (guests > 15 && guests <= 20)
            {
                discount = personPrice * 0.8;
            }
            else if(guests > 20)
            {
                discount = personPrice * 0.75;
            }
            else
            {
                discount = personPrice;
            }
            moneyNeeded = guests * discount + cakePrice;
            double diff = Math.Abs(budget - moneyNeeded);

            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"It is party time! {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {diff:f2} leva needed.");
            }
        }
    }
}

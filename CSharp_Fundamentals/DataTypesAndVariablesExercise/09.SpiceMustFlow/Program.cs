using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield= int.Parse(Console.ReadLine());
            int days = 0;
            int yield = startingYield;
            int totalAmount = 0;

            while (yield >= 100)
            {
                days++;
                totalAmount += yield;
                totalAmount -= 26;
                yield -= 10;
                if (yield < 100)
                {
                    totalAmount -= 26;
                    break;
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}

using System;
using System.Linq;

namespace _1._04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(n => n * 1.2m)
                .ToArray();

            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine($"{prices[i]:f2}");
            }

        }
    }
}

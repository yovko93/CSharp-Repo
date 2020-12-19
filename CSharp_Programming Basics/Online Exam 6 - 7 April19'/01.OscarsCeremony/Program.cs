using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statue = rent * 0.7;
            double catering = statue * 0.85;
            double music = catering / 2;

            double expenses = rent + statue + catering + music;
            Console.WriteLine($"{expenses:f2}");
        }
    }
}

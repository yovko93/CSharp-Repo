using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> info = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!info.ContainsKey(continent))
                {
                    info.Add(continent, new Dictionary<string, List<string>>());
                   
                }

                if (!info[continent].ContainsKey(country))
                {
                    info[continent].Add(country, new List<string>());
                }

                info[continent][country].Add(city);
            }

            foreach (var data in info)
            {
                Console.WriteLine($"{data.Key}:");

                foreach (var country in data.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

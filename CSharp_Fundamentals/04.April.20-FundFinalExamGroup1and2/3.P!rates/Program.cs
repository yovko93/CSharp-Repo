using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                var data = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cityName = data[0];
                int population = int.Parse(data[1]);
                int gold = int.Parse(data[2]);

                if (cities.ContainsKey(cityName))
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                }
                else
                {
                    City city = new City(population, gold);
                    city.Population = population;
                    city.Gold = gold;

                    cities.Add(cityName, city);
                }

                input = Console.ReadLine();
            }

            string events = Console.ReadLine();

            while (events != "End")
            {
                var command = events
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string town = command[1];

                if (command[0] == "Plunder")
                {
                    int peopleKilled = int.Parse(command[2]);
                    int goldStollen = int.Parse(command[3]);

                    cities[town].Population -= peopleKilled;
                    cities[town].Gold -= goldStollen;

                    Console.WriteLine($"{town} plundered! {goldStollen} gold stolen, {peopleKilled} citizens killed.");

                    if (cities[town].Population == 0 || cities[town].Gold == 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command[0] == "Prosper")
                {
                    int gold = int.Parse(command[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                    }
                }

                events = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                var sorted = cities
                    .OrderByDescending(x => x.Value.Gold)
                    .ThenBy(x => x.Key)
                    .ToList();

                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in sorted)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        public class City
        {
            public int Population { get; set; }

            public int Gold { get; set; }

            public City(int population, int gold)
            {
                this.Population = population;
                this.Gold = gold;
            }
        }
    }
}

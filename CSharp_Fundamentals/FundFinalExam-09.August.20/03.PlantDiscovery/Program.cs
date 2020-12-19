using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<double>>> allPlants = new Dictionary<string, Dictionary<string, List<double>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plant = plantInfo[0];
                double rarity = double.Parse(plantInfo[1]);

                if (allPlants.ContainsKey(plant))
                {
                    allPlants[plant]["rarity"].Add(rarity);
                }
                else
                {
                    allPlants.Add(plant, new Dictionary<string, List<double>>());
                    allPlants[plant].Add("rating", new List<double>());
                    allPlants[plant].Add("rarity", new List<double>() { rarity });
                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                var command = input
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plant = command[1];

                if (command[0] == "Rate")
                {
                    if (allPlants.ContainsKey(plant))
                    {
                        double rating = double.Parse(command[2]);

                        if (allPlants[plant].ContainsKey("rating"))
                        {
                            allPlants[plant]["rating"].Add(rating);
                        }
                        else
                        {
                            allPlants[plant].Add("rating", new List<double>() { rating });
                        }

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "Update")
                {
                    if (allPlants.ContainsKey(plant))
                    {
                        double newRarity = double.Parse(command[2]);
                        allPlants[plant]["rarity"].RemoveRange(0, allPlants[plant]["rarity"].Count);
                        allPlants[plant]["rarity"].Add(newRarity);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "Reset")
                {
                    if (allPlants.ContainsKey(plant))
                    {
                        allPlants[plant]["rating"].RemoveRange(0, allPlants[plant]["rating"].Count);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                input = Console.ReadLine();
            }

           
            Console.WriteLine("Plants for the exhibition:");

            var sorted = allPlants
                .OrderByDescending(x => x.Value["rarity"].Sum())
                .ThenByDescending(x => x.Value["rating"].TakeLast(x.Value["rating"].Count -1).Average())
                .ToList();

            foreach (var item in sorted)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value["rarity"].Sum()}; Rating: {item.Value["rating"].Average():f2}");
            }
        }

        
    }
}

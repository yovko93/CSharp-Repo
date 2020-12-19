using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            bool isLegendary = true;

            while (isLegendary)
            {
                string[] input = Console.ReadLine().Split().ToArray();  //  6 leathers 255 fragments 7 Shards
                for (int i = 0; i < input.Length - 1; i++)
                {
                    int quantity = 0;
                    string material = string.Empty;
                    if (i % 2 == 0)
                    {
                        quantity = int.Parse(input[i]);
                        material = input[i + 1].ToLower();
                        
                        if (material == "shards" || material == "fragments" || material == "motes")
                        {
                            if (!keyMaterials.ContainsKey("shards")
                                || !keyMaterials.ContainsKey("fragments")
                                || !keyMaterials.ContainsKey("motes"))
                            {
                                keyMaterials.Add("shards", 0);
                                keyMaterials.Add("fragments", 0);
                                keyMaterials.Add("motes", 0);
                            }
                            if (keyMaterials.ContainsKey(material))
                            {
                                keyMaterials[material] += quantity;
                            }

                            if (keyMaterials[material] >= 250)
                            {
                                PrintLegendaryItem(material);
                                keyMaterials[material] -= 250;
                                isLegendary = false;
                            }
                            if (!isLegendary)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (junkItems.ContainsKey(material))
                            {
                                junkItems[material] += quantity;
                            }
                            else
                            {
                                junkItems.Add(material, quantity);
                            }
                        }
                    }
                }
            }

            var sortedMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var pair in sortedMaterials)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }

            var sortedJunkItems = junkItems
                .OrderBy(x => x.Key)
                .ToList();

            foreach (var pair in sortedJunkItems)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        static void PrintLegendaryItem(string item)
        {
            if (item == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (item == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (item == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
        }
    }
}

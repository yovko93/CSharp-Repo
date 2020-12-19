using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = input[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentItem = clothes[j];

                    if (!wardrobe[color].ContainsKey(currentItem))
                    {
                        wardrobe[color].Add(currentItem, 0);
                    }

                    wardrobe[color][currentItem]++;
                }
            }

            string[] searchedClothes = Console.ReadLine().Split().ToArray();
            string searchedColor = searchedClothes[0];
            string searchedclothes = searchedClothes[1];


            foreach (var data in wardrobe)
            {
                Console.WriteLine($"{data.Key} clothes:");
                
                foreach (var item in data.Value)
                {
                    if (searchedColor == data.Key && searchedclothes == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
            
        }
    }
}

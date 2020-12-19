using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Nikulden_sMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            List<string> unlikedMeals = new List<string>();

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                var command = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = command[1];
                string meal = command[2];
                
                if (command[0] == "Like")
                {
                    if (guests.ContainsKey(name))
                    {
                        if (!guests[name].Contains(meal))
                        {
                            guests[name].Add(meal);
                        }
                    }
                    else
                    {
                        guests.Add(name, new List<string>());
                        guests[name].Add(meal);
                    }
                }
                else if (command[0] == "Unlike")
                {
                    if (!guests.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is not at the party.");
                    }
                    else
                    {
                        if (!guests[name].Contains(meal))
                        {
                            Console.WriteLine($"{name} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            unlikedMeals.Add(meal);
                            guests[name].Remove(meal);
                            Console.WriteLine($"{name} doesn't like the {meal}.");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var sorted = guests
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var guest in sorted)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");

            }
            
            Console.WriteLine($"Unliked meals: {unlikedMeals.Count}");
        }
    }
}

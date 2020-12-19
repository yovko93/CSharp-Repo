using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                var command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string heroName = command[1];

                if (command[0] == "Enroll")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        heroes.Add(heroName, new List<string>());
                    }
                }
                else if (command[0] == "Learn")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        string spellName = command[2];
                        if (heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                        else
                        {
                            heroes[heroName].Add(spellName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                else if (command[0] == "Unlearn")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        string spellName = command[2];
                        if (heroes[heroName].Contains(spellName))
                        {
                            heroes[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Heroes:");

            foreach (var item in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"== {item.Key}:");

                int count = 0;
                foreach (var kvp in item.Value)
                {
                    count++;
                    if (count == item.Value.Count)
                    {
                        Console.Write($" {kvp}");
                    }
                    else
                    {
                        Console.Write($" {kvp},");
                    }

                }
                Console.WriteLine();
            }

            // това не работи 90/100 judge!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //var sorted = heroes
            //    .OrderByDescending(x => heroes.Values.Count)
            //    .ThenBy(x => x.Key)
            //    .ToList();

            //foreach (var hero in sorted)
            //{
            //    if (hero.Value.Count > 0)
            //    {
            //        Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"== {hero.Key}:");
            //    }
            //}

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                var heroInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string heroName = heroInfo[0];
                int hitPoints = int.Parse(heroInfo[1]);
                int manaPoints = int.Parse(heroInfo[2]);

                Hero hero = new Hero(hitPoints, manaPoints);
                hero.HitPoints = hitPoints;
                hero.ManaPoints = manaPoints;

                heroes.Add(heroName, hero);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                var command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string heroName = command[1];

                if (command[0] == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(command[2]);
                    string spellName = command[3];

                    if (heroes[heroName].ManaPoints >= manaPointsNeeded)
                    {
                        heroes[heroName].ManaPoints -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command[0] == "TakeDamage")
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    heroes[heroName].HitPoints -= damage;

                    if (heroes[heroName].HitPoints > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HitPoints} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (command[0] == "Recharge")
                {
                    int amount = int.Parse(command[2]);
                    int amountRecovered = amount;

                    if (heroes[heroName].ManaPoints + amount > 200)
                    {
                        amountRecovered = 200 - heroes[heroName].ManaPoints;
                        heroes[heroName].ManaPoints = 200;
                    }
                    else
                    {
                        heroes[heroName].ManaPoints += amount;
                    }
                    Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
                }
                else if (command[0] == "Heal")
                {
                    int amount = int.Parse(command[2]);
                    int amountRecovered = amount;

                    if (heroes[heroName].HitPoints + amount > 100)
                    {
                        amountRecovered = 100 - heroes[heroName].HitPoints;
                        heroes[heroName].HitPoints = 100;
                    }
                    else
                    {
                        heroes[heroName].HitPoints += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
                }


                input = Console.ReadLine();
            }

            var sorted = heroes
                .Where(x => x.Value.HitPoints > 0)
                .OrderByDescending(x => x.Value.HitPoints)
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var hero in sorted)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HitPoints}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}");
            }
        }

        public class Hero
        {
            public int HitPoints { get; set; }

            public int ManaPoints { get; set; }

            public Hero(int hitPoints, int manaPoints)
            {
                this.HitPoints = HitPoints;
                this.ManaPoints = manaPoints;
            }
        }
    }
}

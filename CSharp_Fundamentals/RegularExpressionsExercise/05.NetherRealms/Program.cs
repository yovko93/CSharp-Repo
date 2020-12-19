using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, DemonInfo> participants = new SortedDictionary<string, DemonInfo>();

            var demons = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string healthPattern = @"[^0-9+,\-*\/\.]";
            string damagePattern = @"-?\d+\.?\d*";
            string divideOrMultiplyPattern = @"[*\/]";

            for (int i = 0; i < demons.Length; i++)
            {
                string demonName = demons[i];
                if (Regex.IsMatch(demonName, @"[\s,]"))
                {
                    continue;
                }
                if (Regex.IsMatch(demonName, healthPattern))
                {
                    string health = string.Concat(Regex.Matches(demonName, healthPattern));
                    int sumOfHealth = 0;
                    double sumOfDamage = 0;

                    foreach (var item in health)
                    {
                        sumOfHealth += item;
                    }
                    if (Regex.IsMatch(demonName, damagePattern))
                    {
                        var digits = Regex.Matches(demonName, damagePattern);
                        for (int k = 0; k < digits.Count; k++)
                        {
                            sumOfDamage += double.Parse(digits[k].ToString());
                        }

                        if (Regex.IsMatch(demonName, divideOrMultiplyPattern))
                        {
                            var symbols = Regex.Matches(demonName, divideOrMultiplyPattern);

                            for (int y = 0; y < symbols.Count; y++)
                            {
                                if (symbols[y].ToString() == "*")
                                {
                                    sumOfDamage *= 2;
                                }
                                else if (symbols[y].ToString() == "/")
                                {
                                    sumOfDamage /= 2;
                                }
                            }
                        }

                    }

                    DemonInfo demon = new DemonInfo(sumOfHealth, sumOfDamage);
                    
                    participants.Add(demonName, demon);

                }

            }

            foreach (var pair in participants)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value.Health} health, {pair.Value.Damage:f2} damage");
            }
        }

        public class DemonInfo
        {
            public int Health { get; set; }

            public double Damage { get; set; }

            public DemonInfo(int health, double damage)
            {
                this.Health = health;
                this.Damage = damage;
            }

        }
    }
}

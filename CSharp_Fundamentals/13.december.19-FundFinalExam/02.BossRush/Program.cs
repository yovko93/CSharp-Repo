using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-za-z]+\s[A-Za-z]+)#";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["name"].Value}, The {match.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {match.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {match.Groups["title"].Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}

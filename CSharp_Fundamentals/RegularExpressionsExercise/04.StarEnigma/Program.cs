using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            string pattern = @"[sStTaArR]";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var matches = Regex.Matches(input, pattern);
                int count = matches.Count;

                string decryptedMessage = "";

                for (int j = 0; j < input.Length; j++)
                {
                    decryptedMessage += (char)(input[j] - count);
                   
                }

                string decryptedPattern = @"(?<=@)(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>\d+)";

                if (Regex.IsMatch(decryptedMessage, decryptedPattern))
                {
                    Match match = Regex.Match(decryptedMessage, decryptedPattern);
                    string planet = match.Groups["planetName"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            if (attackedPlanets.Count > 0)
            {
                foreach (var planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            if (destroyedPlanets.Count > 0)
            {
                foreach (var planet in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

        }
    }
}

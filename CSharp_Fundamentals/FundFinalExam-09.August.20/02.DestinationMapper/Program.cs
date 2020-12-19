using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([=\/])(?<place>[A-Z][A-Za-z]{2,})\1";

            var matches = Regex.Matches(input, pattern);

            List<string> destinations = new List<string>();
            int travelPoints = 0;

            if (Regex.IsMatch(input, pattern))
            {
                foreach (Match destination in matches)
                {
                    destinations.Add(destination.Groups["place"].Value);
                    travelPoints += destination.Groups["place"].Length;
                }
            }

            if (destinations.Count > 0)
            {
                Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            }
            else
            {
                Console.WriteLine("Destinations:");
            }
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}

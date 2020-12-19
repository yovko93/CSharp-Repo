using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();

            var participants = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string info = Console.ReadLine();
            string namePattern = "[A-Za-z]";
            string numberPattern = @"\d";

            while (info != "end of race")
            {
                var nameMatch = Regex.Matches(info, namePattern);
                var distance = Regex.Matches(info, numberPattern);

                var name = string.Concat(nameMatch);
                var sumOfDistance = distance.Select(x => int.Parse(x.Value)).Sum();

                if (participants.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += sumOfDistance;
                    }
                    else
                    {
                        racers.Add(name, sumOfDistance);
                    }
                }

                info = Console.ReadLine();
            }

            var sorted = racers
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}

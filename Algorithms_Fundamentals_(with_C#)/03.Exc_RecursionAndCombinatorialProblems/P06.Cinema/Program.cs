using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P06.Cinema
{
    class Program
    {
        private static HashSet<int> lockedSeats;
        private static List<string> names;
        private static string[] seats;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ")
                .ToList();

            seats = new string[names.Count];
            lockedSeats = new HashSet<int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                seats[position] = name;
                lockedSeats.Add(position);

                names.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var namesIdx = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (lockedSeats.Contains(i))
                    {
                        continue;
                    }

                    seats[i] = names[namesIdx];
                    namesIdx += 1;
                }

                Console.WriteLine(string.Join(" ", seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}

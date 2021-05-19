using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.SchoolTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");


            var girlsComb = new string[3];
            var girlsList = new List<string[]>();
            Comb(0, 0, girlsComb, girls, girlsList);

            var boysComb = new string[2];
            var boysList = new List<string[]>();
            Comb(0, 0, boysComb, boys, boysList);

            foreach (var currentGirlsComb in girlsList)
            {
                foreach (var currentBoysComb in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", currentGirlsComb)}, {string.Join(", ", currentBoysComb)}");
                }
            }

        }

        private static void Comb(
            int cellIdx, 
            int elementIdx,
            string[] comb,
            string[] elements,
            List<string[]> result)
        {
            if (cellIdx >= comb.Length)
            {
                result.Add(comb.ToArray());
                return;
            }

            for (int i = elementIdx; i < elements.Length; i++)
            {
                comb[cellIdx] = elements[i];
                Comb(cellIdx + 1, i + 1, comb, elements, result);
            }
        }
    }
}

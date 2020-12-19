using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < elements.Length; j++)
                {
                    chemicalElements.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(' ', chemicalElements));
        }
    }
}

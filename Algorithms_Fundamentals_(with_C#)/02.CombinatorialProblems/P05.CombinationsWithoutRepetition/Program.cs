﻿using System;
using System.IO;

namespace P05.CombinationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static int k;

        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combinations(0, 0);
        }

        private static void Combinations(int combIdx, int elementStartIndex)
        {
            if (combIdx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIndex; i < elements.Length; i++)
            {
                combinations[combIdx] = elements[i];
                Combinations(combIdx + 1, i + 1);
            }
        }
    }
}

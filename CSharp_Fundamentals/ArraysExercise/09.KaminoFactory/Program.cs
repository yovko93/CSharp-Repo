using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int[] bestDNA = new int[n];

            int bestSequenceSum = 0;
            int bestLength = 0;
            int length = 1;
            int currentIndex = 0;
            int bestSequenceIndex = int.MaxValue;
            int sample = 0;
            int bestSample = 0;
            // 5
            // 1!0!1!1!0
            // 0!1!1!0!0
            // Clone them!
            do
            {
                int[] dna = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sample++;
                int sum = 0;
                int startIndex = 0;

                for (int i = 1; i < dna.Length; i++)
                {
                    if (dna[i] == dna[i - 1] && dna[i] > 0)
                    {
                        length++;
                    }
                    else
                    {
                        length = 1;
                        startIndex = i;
                    }
                    if (length >= bestLength)
                    {
                        bestLength = length;
                        currentIndex = startIndex;
                    }
                }
                for (int j = 0; j < dna.Length; j++)
                {
                    sum += dna[j];
                }
                if (bestSequenceIndex == currentIndex)
                {
                    if (sum > bestSequenceSum)
                    {
                        bestSequenceIndex = currentIndex;
                        bestDNA = dna.ToArray();
                        bestSample = sample;
                        bestSequenceSum = sum;
                    }
                }
                else if (bestSequenceIndex > currentIndex)
                {
                    bestSequenceIndex = currentIndex;
                    bestDNA = dna.ToArray();
                    bestSample = sample;
                    bestSequenceSum = sum;
                }

                command = Console.ReadLine();
            } while (command != "Clone them!");

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}

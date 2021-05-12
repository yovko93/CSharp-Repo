using System;

namespace P04.CombsWithoutRep
{
    class Program
    {
        private static int n;
        private static int k;

        private static int[] combinations;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            Combinations(0, 1, n);
        }

        private static void Combinations(int index, int elementStartIdx, int n)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIdx; i <= n; i++)
            {
                combinations[index] = i;
                Combinations(index + 1, i + 1, n);
            }
        }
    }
}

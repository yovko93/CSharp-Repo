using System;

namespace P03.CombsWithRepet
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

        private static void Combinations(int combIdx, int elementStartIndex, int n)
        {
            if (combIdx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIndex; i <= n; i++)
            {
                combinations[combIdx] = i;
                Combinations(combIdx + 1, i, n);
            }
        }
    }
}

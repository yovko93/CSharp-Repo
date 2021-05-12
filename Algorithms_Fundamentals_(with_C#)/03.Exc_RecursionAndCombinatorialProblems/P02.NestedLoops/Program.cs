using System;

namespace P02.NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            Gen01(arr, 0, n);
        }

        private static void Gen01(int[] arr, int index, int n)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int number = 1; number <= n; number++)
            {
                arr[index] = number;
                Gen01(arr, index + 1, n);
            }
        }
    }
}

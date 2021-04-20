using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(array, 0);

            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            int currentSum = array[index] + Sum(array, index + 1);

            return currentSum;
        }
    }
}

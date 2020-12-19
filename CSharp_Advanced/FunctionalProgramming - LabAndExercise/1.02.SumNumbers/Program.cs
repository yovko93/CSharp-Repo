using System;
using System.Linq;

namespace _1._02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(ParseNumber)
                 .ToArray();

            PrintResult(numbers, GetCount, Sum);

            ///// втори начин!!!
            ///
            //PrintResult(numbers, GetCount, x =>
            //{
            //    int sum = 0;
            //    for (int i = 0; i < x.Length; i++)
            //    {
            //        sum += x[i];
            //    }
            //    return sum;
            //});

        }

        static int GetCount(int[] array)
        {
            return array.Length;
        }

        static int Sum(int[] array)
        {
            return array.Sum();
        }

        static int ParseNumber(string num)
        {
            return int.Parse(num);
        }
        static void PrintResult(int[] array,
            Func<int[], int> count,
            Func<int[], int> sum)
        {
            Console.WriteLine(count(array));

            Console.WriteLine(sum(array));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            for (int i = 0; i < integers.Length; i++)
            {
                sum += integers[i];
            }

            double averageValue = (double)sum / integers.Length;

            List<int> numbers = new List<int>();

            for (int i = 0; i < integers.Length; i++)
            {
                int currentNum = integers[i];
                if (currentNum > averageValue)
                {
                    numbers.Add(currentNum);
                }
            }

            numbers.Sort();
            numbers.Reverse();
            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (numbers.Count >= 5)
            {
                Console.WriteLine(string.Join(' ', numbers.GetRange(0, 5)));
            }
            else
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}

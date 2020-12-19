using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> values = new Dictionary<double, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                double currentNum = arr[i];

                if (!values.ContainsKey(currentNum))
                {
                    values.Add(currentNum, 1);
                   // values[currentNum] = 1;
                }
                else
                {
                    values[currentNum]++;
                }

            }

            foreach (var pair in values)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }

        }
    }
}

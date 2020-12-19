using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            PrintResult(firstList, secondList);
        }

        static void PrintResult(List<int> first, List<int> second)
        {
            int biggerCount = Math.Max(first.Count, second.Count);
            List<int> result = new List<int>();

            for (int i = 0; i < biggerCount; i++)
            {
                if (first.Count > i)
                {
                    result.Add(first[i]);
                }
                if (second.Count > i)
                {
                    result.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>();

            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }

            for (int j = 0; j < input[1]; j++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
            }

            first.IntersectWith(second);

            Console.WriteLine(string.Join(' ', first));

            //foreach (var num in first)
            //{
            //    Console.Write($"{num} ");
            //}

        }
    }
}

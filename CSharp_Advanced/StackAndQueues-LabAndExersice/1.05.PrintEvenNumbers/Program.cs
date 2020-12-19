﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Queue<int> evenNums = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNums.Enqueue(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}

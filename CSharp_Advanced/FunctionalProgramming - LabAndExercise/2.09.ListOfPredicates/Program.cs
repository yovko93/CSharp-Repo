using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool IsDivisible = true;

                foreach (var item in dividers)
                {
                    Predicate<int> predicate = x => i % x == 0;

                    if (!predicate(item))
                    {
                        IsDivisible = false;
                        break;
                    }
                }

                if (IsDivisible)
                {
                    numbers.Add(i);
                }

            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        //static bool DevidersInfo(int n, List<int> deviders)
        //{
        //    bool isDivisible = true;

        //    foreach (var num in deviders)
        //    {
        //        Predicate<int> predicate = n => n % num != 0;

        //        if (predicate(n))
        //        {
        //            isDivisible = false;
        //        }
        //    }

        //    return isDivisible;
        //}

    }
}

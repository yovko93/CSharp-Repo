using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

            string command = Console.ReadLine();

            int start = range[0];
            int end = range[1];

            Func<int, int, List<int>> generateList = (start, end) =>
            {
                List<int> numbers = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    numbers.Add(i);
                }

                return numbers;
            };
            
            List<int> numbers = generateList(start, end);

            Predicate<int> predicate = n => n % 2 == 0;

            if (command == "odd")
            {
                predicate = n => n % 2 != 0;
            }

            numbers = MyWhere(numbers, predicate);

            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> MyWhere(List<int> items, Predicate<int> predicate)
        {
            List<int> res = new List<int>();

            foreach (var item in items)
            {
                if (predicate(item))
                {
                    res.Add(item);
                }
            }


            return res;
        }
    }
}

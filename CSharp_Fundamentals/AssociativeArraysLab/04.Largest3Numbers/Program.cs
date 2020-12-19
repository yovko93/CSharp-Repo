using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(num => num).Take(3).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

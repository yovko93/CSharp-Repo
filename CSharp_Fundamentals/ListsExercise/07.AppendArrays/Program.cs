using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split('|')
                .ToList();
            numbers.Reverse();
           
            List<string> result = new List<string>();

            for (int i = 0; i < numbers.Count; i++)
            {
                string[] current = numbers[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(current);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int> getAsciiSum = p => p.Select(c => (int)c).Sum();
            //string person = GetName(names, n, GetAsciiSum);
            //Console.WriteLine(person);

            Func<List<string>, int, Func<string, int>, string> nameFunc = (names, n, func) => names.FirstOrDefault(p => func(p) >= n);

            string res = nameFunc(names, n, getAsciiSum);
            Console.WriteLine(res);
        }

        static string GetName(List<string> people, int n, Func<string, int> func)
        {
            string res = null;

            foreach (var person in people)
            {
                if (func(person) >= n)
                {
                    res = person;
                }
            }

            return res;
        }
    }
}

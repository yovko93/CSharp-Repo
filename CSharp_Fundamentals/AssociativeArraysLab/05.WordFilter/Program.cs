using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split().ToArray();

            List<string> evenWords = array.Where(word => word.Length % 2 == 0).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, evenWords));
        }
    }
}

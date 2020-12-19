using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _2._06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            //Func<int, bool> predicate = x => x % n != 0;

            numbers = numbers.Where(x => x % n != 0).ToList();

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}

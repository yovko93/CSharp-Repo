using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace _2._07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, bool> predicate = x => x.Length <= nameLength;

            names = names.Where(predicate).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}

using System;
using System.Linq;

namespace _2._02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> printNames = Print;

            printNames(names);

        }

        static void Print(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Sir {names[i]}");
            }
        }
    }
}

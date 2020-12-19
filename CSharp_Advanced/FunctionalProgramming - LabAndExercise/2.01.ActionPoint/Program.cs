using System;
using System.Linq;

namespace _2._01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> printNames = a => Console.WriteLine(string.Join(Environment.NewLine, a));

            printNames(input);

            //// 2-ри вариант
            //
            //Action<string[]> action = PrintName;

            //action(input);
        }

        //static void PrintName(string[] names)
        //{
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        Console.WriteLine(names[i]);
        //    }
        //}
    }
}

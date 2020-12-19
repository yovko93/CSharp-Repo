using System;
using System.Linq;

namespace _1._03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Abc"[0] == "Abc".ToUpper()[0]);
            //Console.WriteLine("abc"[0] == "abc".ToUpper()[0]);


            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();



            Console.WriteLine(string.Join(Environment.NewLine, text));

        }
    }
}

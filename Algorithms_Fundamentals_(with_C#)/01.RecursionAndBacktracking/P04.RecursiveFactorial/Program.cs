using System;
using System.IO;

namespace P04.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveFactorial(n));
        }

        private static int RecursiveFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * RecursiveFactorial(n - 1);
        }
    }
}

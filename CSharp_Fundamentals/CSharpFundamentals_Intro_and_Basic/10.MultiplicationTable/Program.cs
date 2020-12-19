using System;

namespace _10.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine($"{n} X {i} = {n*i}");
                i += 1;
            }
        }
    }
}

using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            decimal result = CalculateFactorial(first) / CalculateFactorial(second);

            Console.WriteLine($"{result:f2}");
        }

        static decimal CalculateFactorial(int first)
        {
            decimal factorial = 1;

            for (int i = 1; i <= first; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}

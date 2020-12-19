using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial.Calculate(num));
        }

        public class Factorial
        {
            public static BigInteger Calculate(int n)
            {
                BigInteger result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
            
        }
    }
}

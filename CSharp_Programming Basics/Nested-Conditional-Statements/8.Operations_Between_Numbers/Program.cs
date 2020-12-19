using System;

namespace _8.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double result = 0.0;

            if (symbol == '+' || symbol == '-' || symbol == '*')
            {
                if (symbol == '+')
                {
                    result = n1 + n2;
                }
                else if (symbol == '-')
                {
                    result = n1 - n2;
                }
                else if (symbol == '*')
                {
                    result = n1 * n2;
                }
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - odd");
                }
            }
            else if (symbol == '/' && n2 != 0)
            {
                result = n1 / n2;
                Console.WriteLine($"{n1} / {n2} = {result:f2}");
            }
            else if (symbol == '%' && n2 != 0)
            {
                result = n1 % n2;
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
            else if (n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
        }
    }
}

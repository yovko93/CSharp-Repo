using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            string typeOperator = Console.ReadLine();
            double second = double.Parse(Console.ReadLine());
            Console.WriteLine(PrintResult(first,typeOperator,second));
        }

        static double PrintResult(double first, string typeOperator, double second)
        {
            double result = 0;
            switch (typeOperator)
            {
                case "/":
                    result = first / second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
            }
            return result;
        }
    }
}

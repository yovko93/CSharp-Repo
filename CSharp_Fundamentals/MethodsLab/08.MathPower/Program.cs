using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = PowerNumber(number,power);
            Console.WriteLine(result);
        }

        static double PowerNumber(double number, double power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            //result = Math.Pow(number, power);
            return result;
        }
    }
}

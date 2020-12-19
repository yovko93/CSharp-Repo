using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool isEqual = false;

            double diff = Math.Abs(a - b);
            if (diff > eps)
            {
                Console.WriteLine(isEqual);
            }
            else if (diff < eps)
            {
                isEqual = true;
                Console.WriteLine(isEqual);
            }

        }
    }
}

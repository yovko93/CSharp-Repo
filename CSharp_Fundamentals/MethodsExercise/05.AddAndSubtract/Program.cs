using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(first, second, third));
        }

        static int Sum(int first, int second)
        {
            return first + second;
        }

        static int Subtract(int first, int second, int third)
        {
            return Sum(first, second) - third;
        }
    }
}

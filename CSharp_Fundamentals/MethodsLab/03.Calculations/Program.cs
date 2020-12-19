using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Console.WriteLine(Add(first, second));
                    break;
                case "subtract":
                    Subtract(first, second);
                    break;
                case "multiply":
                    Multiply(first, second);
                    break;
                case "divide":
                    Divide(first, second);
                    break;
            }
        }

        static int Add(int first, int second)
        {
            //Console.WriteLine(first + second);
            return first + second;
        }
        static void Subtract(int first, int second)
        {
            Console.WriteLine(first - second);
        }
        static void Multiply(int first, int second)
        {
            Console.WriteLine(first * second);
        }
        static void Divide(int first, int second)
        {
            Console.WriteLine(first / second);
        }
        
    }
}

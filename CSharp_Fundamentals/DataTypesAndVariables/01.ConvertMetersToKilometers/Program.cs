using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters * 0.001;
            Console.WriteLine($"{kilometers:f2}");

        }
    }
}

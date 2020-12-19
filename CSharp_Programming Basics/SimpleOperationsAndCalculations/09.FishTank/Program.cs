using System;

namespace _09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int wide = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            int capacity = length * wide * high;
            double littres = capacity * 0.001;
            double percentige = percent * 0.01;

            double sum = littres * (1 - percentige);
            Console.WriteLine($"{sum:f3}");
        }
    }
}

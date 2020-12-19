using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int capacity = 255;
            int totalLiters = 0;

            for (int i = 0; i < n; i++)
            {
                int quantities = int.Parse(Console.ReadLine());
                if (quantities > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalLiters += quantities;
                    capacity -= quantities;
                }
            }
            Console.WriteLine(totalLiters);
        }
    }
}

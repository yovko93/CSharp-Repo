using System;

namespace _04.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;


            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (current > max)
                {
                    max = current;
                }
                if (current < min)
                {
                    min = current;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}

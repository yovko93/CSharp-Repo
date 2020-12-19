using System;

namespace _6.Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double countN1 = 0.0;
            double countN2 = 0.0;
            double countN3 = 0.0;

            for(int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    countN1++;
                }
                if (num % 3 == 0)
                {
                    countN2++;
                }
                if (num % 4 == 0)
                {
                    countN3++;
                }
            }
            double p1 = countN1 / n * 100;
            double p2 = countN2 / n * 100;
            double p3 = countN3 / n * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}

using System;

namespace _5.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           double n1 = 0;
           double n2 = 0;
           double n3 = 0;
           double n4 = 0;
           double n5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    n1++;
                }
                else if (num >= 200 && num < 400)
                {
                    n2++;
                }
                else if (num >= 400 && num < 600)
                {
                    n3++;
                }
                else if (num >= 600 && num < 800)
                {
                    n4++;
                }
                else if (num >= 800)
                {
                    n5++;
                }
            }

            double p1 = n1 / n * 100;
            double p2 = n2 / n * 100;
            double p3 = n3 / n * 100;
            double p4 = n4 / n * 100;
            double p5 = n5 / n * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}

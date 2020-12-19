using System;

namespace USDToBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;

            Console.WriteLine($"{bgn:F2}");
            
            //Втори начин: със закръгляне
            //double usd = double.Parse(Console.ReadLine());
            //double bgn = Math.Round((usd * 1.79549), 2);

            //Console.WriteLine(bgn);


        }
    }
}

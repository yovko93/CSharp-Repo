using System;

namespace _01.BiscuitsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorkerPerDay = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int competingFactory = int.Parse(Console.ReadLine());

            int productionPerDay = biscuitsPerWorkerPerDay * workersCount;
            int totalProduction = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    double thirdDay = Math.Floor(productionPerDay * 0.75);
                    totalProduction += (int)thirdDay;
                }
                else
                {
                    totalProduction += productionPerDay;
                }
            }

            Console.WriteLine($"You have produced {totalProduction} biscuits for the past month.");

            double diff = Math.Abs(totalProduction - competingFactory);
            double percentage = diff / competingFactory * 100.0;

            if (totalProduction > competingFactory)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}

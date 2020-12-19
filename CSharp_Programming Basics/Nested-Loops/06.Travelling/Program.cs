using System;

namespace _06.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double saveMoney = 0;
                while (saveMoney < budget)
                {
                    double money = double.Parse(Console.ReadLine());
                    saveMoney += money;
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }

        }
    }
}

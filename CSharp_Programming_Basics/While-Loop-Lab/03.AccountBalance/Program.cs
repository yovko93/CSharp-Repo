using System;

namespace _03.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int payments = int.Parse(Console.ReadLine());
            double balance = 0.0;
            int counter = 0;

            while (counter < payments)
            {             
                double sum = double.Parse(Console.ReadLine());
                if (sum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance += sum;
                Console.WriteLine($"Increase: {sum:f2}");
                counter++;
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}

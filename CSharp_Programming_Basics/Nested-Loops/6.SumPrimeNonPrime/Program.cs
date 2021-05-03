using System;

namespace _6.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {

            int primeNum = 0;
            int nonPrimeNum = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {primeNum}");
                    Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNum}");
                    break;
                }
                int num = int.Parse(command);
                bool isPrime = true;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                else if (num == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = num; i >= 2; i--)
                    {
                        if (num % i == 0 && i != num)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                if (isPrime)
                {
                    primeNum += num;
                }
                else
                {
                    nonPrimeNum += num;
                }
            }


        }
    }
}

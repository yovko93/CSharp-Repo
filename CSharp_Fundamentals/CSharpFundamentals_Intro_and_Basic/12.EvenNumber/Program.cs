using System;

namespace _12.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int num = int.Parse(Console.ReadLine());
                
                if (num % 2 == 0)
                {
                    if (num < 0)
                    {
                        num *= -1;
                    }
                    Console.WriteLine($"The number is: {num}");
                    break;
                }
                Console.WriteLine("Please write an even number.");
            } while (true);
        }
    }
}

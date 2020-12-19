using System;

namespace _02.Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int searchNumber = 0;

            if (number % 10 == 0)
            {
                searchNumber = 10;
            }
            else if (number % 7 == 0)
            {
                searchNumber = 7;
            }
            else if (number % 6==0)
            {
                searchNumber = 6;
            }
            else if (number % 3==0)
            {
                searchNumber = 3;
            }
            else if (number % 2==0)
            {
                searchNumber = 2;
            }
            if (searchNumber != 0)
            {
                Console.WriteLine($"The number is divisible by {searchNumber}");
            }
            else
            {
                Console.WriteLine("Not divisible");   
            }


            //if (number % 10 == 0)
            //{
            //    Console.WriteLine($"The number is divisible by 10");
            //}
            //else if (number % 7 == 0)
            //{
            //    Console.WriteLine($"The number is divisible by 7");
            //}
            //else if (number % 3 == 0)
            //{
            //    if (number % 2 == 0)
            //    {
            //        Console.WriteLine($"The number is divisible by 6");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"The number is divisible by 3");
            //    }
            //}
            //else if (number % 2 == 0)
            //{
            //    Console.WriteLine($"The number is divisible by 2");
            //}
            //else
            //{
            //    Console.WriteLine("Not divisible");
            //}
        }
    }
}

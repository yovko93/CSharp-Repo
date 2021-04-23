using System;

namespace _2.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, end);
            }

        }

        public static int ReadNumber(int start, int end)
        {
            int number = 0;

            try
            {
                Console.WriteLine($"Enter number {start} < your number < {end}:");
                number = int.Parse(Console.ReadLine());

                while (!(start < number && number < end))
                {
                    Console.WriteLine("Your number is not in range {0} - {1} !", start, end);
                    Console.WriteLine("Enter number {0} < your number < {1}: ", start, end);
                    number = int.Parse(Console.ReadLine());
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
                throw;
            }

            return number;
        }
    }
}

using System;

namespace _1.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    throw new ArgumentException();
                }

                double squareRoot = Math.Sqrt(n);

                Console.WriteLine(squareRoot);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

        }
    }
}

using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char first = (char)('a' + i);
                for (int j = 0; j < n; j++)
                {
                    char second = (char)('a' + j);
                    for (int k = 0; k < n; k++)
                    {
                        char third = (char)('a' + k);
                        Console.Write("" + first + second + third);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

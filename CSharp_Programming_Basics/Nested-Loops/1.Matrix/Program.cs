using System;

namespace _1.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                for (int x = a; x <= b; x++)
                {
                    for (int y = c; y <= d; y++)
                    {
                        for (int z = c; z <= d; z++)
                        {
                            if ((i+z) == (x+y) && (i != x) && (y != z))
                            {
                                Console.WriteLine($"{i}{x}");
                                Console.WriteLine($"{y}{z}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

        }
    }
}

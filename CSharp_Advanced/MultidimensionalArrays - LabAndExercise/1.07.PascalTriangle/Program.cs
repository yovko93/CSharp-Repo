using System;

namespace _03.MA._07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long currentLength = 1;

            long[][] triangle = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                triangle[i] = new long[currentLength];
                triangle[i][0] = 1;
                triangle[i][currentLength - 1] = 1;

                if (currentLength > 2)
                {
                    for (int j = 1; j < currentLength - 1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }

                currentLength++;
            }


            for (int row = 0; row < triangle.Length; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write($"{triangle[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

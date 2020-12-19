using System;
using System.Linq;

namespace _03.MA._03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[size, size];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = colElements[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = row; col < row + 1; col++)
                {
                    sum += squareMatrix[row, col];
                }
            }

            Console.WriteLine(sum);
        }
    }
}

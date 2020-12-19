using System;
using System.Linq;

namespace _2._02._2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int numOfSquaresMatrix = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char topLeft = matrix[row, col];
                    char topRight = matrix[row, col + 1];
                    char bottomLeft = matrix[row + 1, col];
                    char bottomRight = matrix[row + 1, col + 1];

                    if (topLeft == topRight && topRight == bottomLeft && bottomLeft == bottomRight)
                    {
                        numOfSquaresMatrix++;
                    }
                }
            }

            Console.WriteLine(numOfSquaresMatrix);
        }
    }
}

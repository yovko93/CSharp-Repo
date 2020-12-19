using System;
using System.Linq;

namespace _2._03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int maxSum = int.MinValue;
            int startIndexRow = -1;
            int startIndexCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                int sum = 0;
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    sum += matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    sum += matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startIndexRow = row;
                        startIndexCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startIndexRow; row < startIndexRow + 3; row++)
            {
                for (int col = startIndexCol; col < startIndexCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

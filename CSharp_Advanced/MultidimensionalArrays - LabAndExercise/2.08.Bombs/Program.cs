using System;
using System.Linq;

namespace _2._08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string[] bombCells = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < bombCells.Length; i++)
            {
                int[] bombCoordinates = bombCells[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];

                int currentBombValue = matrix[bombRow, bombCol];

                if (currentBombValue > 0)
                {
                    BombExplode(matrix, currentBombValue, bombRow, bombCol, n);
                }
            }

            int aliveCells = 0;
            int sumAliveCells = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumAliveCells += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintMatrix(matrix);
        }
        static int[,] BombExplode(int[,] matrix, int bombValue, int row, int col, int n)
        {

            matrix[row, col] -= bombValue;

            if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] -= bombValue;
            }
            if (row - 1 >= 0 && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= bombValue;
            }
            if (row - 1 >= 0 && col + 1 < n && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= bombValue;
            }
            if (col - 1 >= 0 && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= bombValue;
            }
            if (col + 1 < n && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] -= bombValue;
            }
            if (row + 1 < n && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= bombValue;
            }
            if (row + 1 < n && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= bombValue;
            }
            if (row + 1 < n && col + 1 < n && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= bombValue;
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    
    }
}

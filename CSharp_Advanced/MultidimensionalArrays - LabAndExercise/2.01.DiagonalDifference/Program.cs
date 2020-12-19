using System;
using System.Linq;

namespace _2._01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int leftDiagonal = 0;
            int rightDiagonal = 0;

            int counter = size - 1;
            for (int row = 0; row < size; row++)
            {
                leftDiagonal += matrix[row, row];
                rightDiagonal += matrix[row, counter--];
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = row; col < row + 1; col++)
            //    {
            //        leftDiagonal += matrix[row, col];
            //    }
            //}

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = matrix.GetLength(1) - 1 - row; col >= matrix.GetLength(1) - row - 1; col--)
            //    {
            //        rightDiagonal += matrix[row, col];
            //    }
            //}

            int diff = Math.Abs(leftDiagonal - rightDiagonal);
            Console.WriteLine(diff);
        }
    }
}

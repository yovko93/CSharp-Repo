using System;
using System.Linq;

namespace _2._10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int currentRow = -1;
            int currentCol = -1;

            char[,] lair = new char[size[0], size[1]];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = elements[col];

                    if (elements[col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                }
            }

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == 'U')
                {
                    
                }
            }
        }

        static bool IsTheCellFree (int[,] matrix, char direction, int currentRow, int currentCol)
        {
            if (direction == 'U')
            {

            }
            else if (direction == 'D')
            {

            }
            else if (direction == 'R')
            {

            }
            else if (direction == 'L')
            {

            }

            return false;
        }

        static int[,] ReturMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        matrix
                    }

                }
            }

            return matrix;
        }
    }
}

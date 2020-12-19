using System;
using System.IO;
using System.Security.Principal;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int currentRow = -1;
            int currentCol = -1;

            int foodQuantity = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (elements[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }

            }

            string command = Console.ReadLine();

            while (foodQuantity < 10)
            {

                matrix[currentRow, currentCol] = '.';

                if (command == "up" && currentRow - 1 >= 0)
                {
                    currentRow = currentRow - 1;
                    SnakeMoves(matrix, ref currentRow, ref currentCol, ref foodQuantity);
                }
                else if (command == "down" && currentRow + 1 < size)
                {
                    currentRow = currentRow + 1;
                    SnakeMoves(matrix, ref currentRow, ref currentCol, ref foodQuantity);
                }
                else if (command == "left" && currentCol - 1 >= 0)
                {
                    currentCol = currentCol - 1;
                    SnakeMoves(matrix, ref currentRow, ref currentCol, ref foodQuantity);
                }
                else if (command == "right" && currentCol + 1 < size)
                {
                    currentCol = currentCol + 1;
                    SnakeMoves(matrix, ref currentRow, ref currentCol, ref foodQuantity);
                }

                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (foodQuantity == 10)
                {
                    break;
                }
                command = Console.ReadLine();
            }


            if (foodQuantity == 10)
            {
                matrix[currentRow, currentCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(matrix);

        }

        static void SnakeMoves(char[,] matrix, ref int row, ref int col, ref int food)
        {
            if (matrix[row, col] == '*') //има храна
            {
                food++;
                matrix[row, col] = '.'; // променя настоящата клетка на '.'
            }
            else if (matrix[row, col] == 'B') // влиза в BURROW
            {
                matrix[row, col] = '.';
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (matrix[rows, cols] == 'B')
                        {
                            matrix[rows, cols] = '.';
                            row = rows;
                            col = cols;
                            break;
                        }
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}

using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int rowPlayer = -1;
            int colPlayer = -1;

            bool isWinner = false;

            for (int rows = 0; rows < n; rows++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    if (elements[cols] == 'f')
                    {
                        rowPlayer = rows;
                        colPlayer = cols;
                    }
                }

            }


            matrix[rowPlayer, colPlayer] = '-';

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    rowPlayer--;
                    if (rowPlayer < 0)
                    {
                        rowPlayer = n - 1;
                    }
                    if (matrix[rowPlayer, colPlayer] == 'B')
                    {
                        rowPlayer--;
                    }
                    else if (matrix[rowPlayer, colPlayer] == 'T')
                    {
                        rowPlayer++;
                    }
                }
                else if (command == "down")
                {
                    rowPlayer++;
                    if (rowPlayer > n - 1)
                    {
                        rowPlayer = 0;
                    }
                    if (matrix[rowPlayer, colPlayer] == 'B')
                    {
                        rowPlayer++;
                    }
                    else if (matrix[rowPlayer, colPlayer] == 'T')
                    {
                        rowPlayer--;
                    }
                }
                else if (command == "left")
                {
                    colPlayer--;
                    if (colPlayer < 0)
                    {
                        colPlayer = n - 1;
                    }
                    if (matrix[rowPlayer, colPlayer] == 'B')
                    {
                        colPlayer--;
                    }
                    else if (matrix[rowPlayer, colPlayer] == 'T')
                    {
                        colPlayer++;
                    }
                }
                else if (command == "right")
                {
                    colPlayer++;
                    if (colPlayer > n - 1)
                    {
                        colPlayer = 0;
                    }
                    if (matrix[rowPlayer, colPlayer] == 'B')
                    {
                        colPlayer++;
                    }
                    else if (matrix[rowPlayer, colPlayer] == 'T')
                    {
                        colPlayer--;
                    }
                }

                if (matrix[rowPlayer, colPlayer] == 'F')
                {
                    Console.WriteLine("Player won!");
                    isWinner = true;
                    matrix[rowPlayer, colPlayer] = 'f';
                    break;
                }

            }

            if (!isWinner)
            {
                matrix[rowPlayer, colPlayer] = 'f';
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix, n);
        }

        static void PrintMatrix(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

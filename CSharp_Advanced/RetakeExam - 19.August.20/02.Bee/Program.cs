using System;
using System.IO;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int row = -1;
            int col = -1;

            int pollinatedFlower = 0;

            for (int rows = 0; rows < n; rows++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    if (elements[cols] == 'B')
                    {
                        row = rows;
                        col = cols;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                matrix[row, col] = '.'; // оставя следа

                if (command == "up" && row - 1 >= 0)
                {
                    row = row - 1; // горния ред

                    Move(ref matrix, n,ref row,ref col, ref pollinatedFlower, command);


                }
                else if (command == "down" && row + 1 < n)
                {
                    row = row + 1;

                    Move(ref matrix, n, ref row, ref col, ref pollinatedFlower, command);
                }
                else if (command == "left" && col - 1 >= 0)
                {
                    col = col - 1;

                    Move(ref matrix, n, ref row, ref col, ref pollinatedFlower, command);
                }
                else if (command == "right" && col + 1 < n)
                {
                    col = col + 1;

                    Move(ref matrix, n, ref row, ref col, ref pollinatedFlower, command);
                }
                else if (!IsInField(n, row, col, command))
                {
                    Console.WriteLine("The bee got lost!");
                    break;

                }

                matrix[row, col] = 'B';

                command = Console.ReadLine();
            }


            if (pollinatedFlower < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlower} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlower} flowers!");
            }
            PrintMatrix(n, matrix);


        }

        static void Move(ref char[,] matrix, int n,ref int row,ref int col, ref int pollinatedFlower, string command)
        {
            if (matrix[row, col] == 'f')
            {
                pollinatedFlower++;
                matrix[row, col] = '.';
            }
            else if (matrix[row, col] == 'O')
            {
                matrix[row, col] = '.';

                if (command == "up")
                {
                    row = row - 1;
                    if (matrix[row, col] == 'f')
                    {
                        pollinatedFlower++;
                    }
                }
                else if (command == "down")
                {
                    row = row + 1;
                    if (matrix[row, col] == 'f')
                    {
                        pollinatedFlower++;
                    }
                }
                else if (command == "left")
                {
                    col = col - 1;
                    if (matrix[row, col] == 'f')
                    {
                        pollinatedFlower++;
                    }
                }
                else if (command == "right")
                {
                    col = col + 1;
                    if (matrix[row, col] == 'f')
                    {
                        pollinatedFlower++;
                    }
                }
                matrix[row, col] = '.';
            }
        }

        static bool IsInField(int n, int row, int col, string command)
        {
            if (command == "up" && row - 1 >= 0)
            {
                return true;
            }
            else if (command == "down" && row + 1 < n)
            {
                return true;
            }
            else if (command == "left" && col - 1 >= 0)
            {
                return true;
            }
            else if (command == "right" && col + 1 < n)
            {
                return true;
            }

            return false;
        }

        static void PrintMatrix(int n, char[,] matrix)
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

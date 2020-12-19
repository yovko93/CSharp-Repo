using System;
using System.IO;
using System.Linq;

namespace _02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int row = -1;
            int col = -1;
            int niceKids = 0;
            int happyKids = 0;

            for (int rows = 0; rows < n; rows++)
            {
                char[] elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    if (elements[cols] == 'S')
                    {
                        row = rows;
                        col = cols;
                    }
                    if (elements[cols] == 'V')
                    {
                        niceKids++;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "Christmas morning")
            {
                matrix[row, col] = '-';

                if (command == "up" && --row >= 0)
                {
                    if (matrix[row, col] == 'V')
                    {
                        happyKids++;
                        countOfPresents--;
                        niceKids--;
                        if (countOfPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents!");
                            matrix[row, col] = 'S';
                            break;
                        }
                    }
                    else if (matrix[row, col] == 'C')
                    {
                        if (!Cookie(ref matrix, row, col, ref happyKids, ref niceKids, ref countOfPresents))
                        {
                            break;
                        }
                    }
                }
                else if (command == "down" && ++row < n)
                {
                    if (matrix[row, col] == 'V')
                    {
                        happyKids++;
                        countOfPresents--;
                        niceKids--;
                        if (countOfPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents!");
                            matrix[row, col] = 'S';
                            break;
                        }
                    }
                    else if (matrix[row, col] == 'C')
                    {
                        if (!Cookie(ref matrix, row, col, ref happyKids, ref niceKids, ref countOfPresents))
                        {
                            break;
                        }
                    }
                }
                else if (command == "left" && --col >= 0)
                {
                    if (matrix[row, col] == 'V')
                    {
                        happyKids++;
                        countOfPresents--;
                        niceKids--;
                        if (countOfPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents!");
                            matrix[row, col] = 'S';
                            break;
                        }
                    }
                    else if (matrix[row, col] == 'C')
                    {
                        if (!Cookie(ref matrix, row, col, ref happyKids, ref niceKids, ref countOfPresents))
                        {
                            break;
                        }
                    }
                }
                else if (command == "right" && ++col < n)
                {
                    if (matrix[row, col] == 'V')
                    {
                        happyKids++;
                        countOfPresents--;
                        niceKids--;
                        if (countOfPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents!");
                            matrix[row, col] = 'S';
                            break;
                        }
                    }
                    else if (matrix[row, col] == 'C')
                    {
                        if (!Cookie(ref matrix, row, col, ref happyKids, ref niceKids, ref countOfPresents))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }

                matrix[row, col] = 'S';

                command = Console.ReadLine();
            }

            PrintMatrix(n, matrix);
            if (niceKids > 0)
            {
                Console.WriteLine($"No presents for {niceKids} nice kid/s.");

            }
            else
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
        }

        static bool Cookie(ref char[,] matrix, int row, int col, ref int happyKids, ref int niceKids, ref int countOfPresents)
        {
            if (matrix[row - 1, col] == 'V' || matrix[row - 1, col] == 'X')
            {
                if (matrix[row - 1, col] == 'V')
                {
                    happyKids++;
                    niceKids--;
                }
                matrix[row - 1, col] = '-';
                countOfPresents--;
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    matrix[row, col] = 'S';
                    return false;
                }
            }
            if (matrix[row + 1, col] == 'V' || matrix[row + 1, col] == 'X')
            {
                if (matrix[row + 1, col] == 'V')
                {
                    happyKids++;
                    niceKids--;
                }
                matrix[row + 1, col] = '-';
                countOfPresents--;
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    matrix[row, col] = 'S';
                    return false;
                }
            }
            if (matrix[row, col - 1] == 'V' || matrix[row, col - 1] == 'X')
            {
                if (matrix[row, col - 1] == 'V')
                {
                    happyKids++;
                    niceKids--;
                }
                matrix[row, col - 1] = '-';
                countOfPresents--;
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    matrix[row, col] = 'S';
                    return false;
                }
            }
            if (matrix[row, col + 1] == 'V' || matrix[row, col + 1] == 'X')
            {
                if (matrix[row, col + 1] == 'V')
                {
                    happyKids++;
                    niceKids--;
                }
                matrix[row, col + 1] = '-';
                countOfPresents--;
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    matrix[row, col] = 'S';
                    return false;
                }
            }

            return true;
        }

        static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = n[0];
            int cols = n[1];

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            int counter = 0;
            var myQue = new Queue<char>();

            int capacity = rows * cols;

            for (int i = 0; i < snake.Length; i++)
            {
                myQue.Enqueue(snake[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            for (int j = 0; j < rows; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        matrix[j, i] = myQue.Dequeue();
                    }
                }
                else if (j % 2 != 0)
                {
                    for (int k = cols - 1; k > -1; k--)
                    {
                        matrix[j, k] = myQue.Dequeue();
                    }
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

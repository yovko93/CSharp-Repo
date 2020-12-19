using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];

            int[,] garden = new int[dimensions[0], dimensions[1]];

            for (int rows = 0; rows < garden.GetLength(0); rows++)
            {
                for (int cols = 0; cols < garden.GetLength(1); cols++)
                {
                    garden[rows, cols] = 0;
                }
            }


            string input = Console.ReadLine();

            List<int[]> flowers = new List<int[]>();

            while (input != "Bloom Bloom Plow")
            {
                int[] positions = input.Split().Select(int.Parse).ToArray();

                int row = positions[0];
                int col = positions[1];

                if ((row >= 0 && row < n)
                    && (col >= 0 && col < n))
                {
                    int[] currentPosition = new int[2] { row, col };
                    flowers.Add(currentPosition);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }


            for (int i = 0; i < flowers.Count; i++)
            {
                int[] currentFlower = flowers[i];
                int row = currentFlower[0]; /// 1
                int col = currentFlower[1]; /// 1

                garden[row, col]++;

                for (int r = 0; r < n; r++)
                {
                    for (int c = col; c <= col; c++)
                    {
                        if (row == r && col == c)
                        {
                        }
                        else
                        {
                            garden[r, c]++;
                        }
                    }
                }

                for (int j = row; j <= row; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (row == j && col == k)
                        {

                        }
                        else
                        {
                            garden[j, k]++;
                        }

                    }
                }
            }

            PrintGarden(garden, n);
        }

        static void PrintGarden(int[,] garden, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

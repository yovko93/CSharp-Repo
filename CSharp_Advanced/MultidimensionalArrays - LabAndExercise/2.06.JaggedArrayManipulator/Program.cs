using System;
using System.Linq;

namespace _2._06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArr[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    // MultiplyArr(jaggedArr, row);
                    jaggedArr[row] = jaggedArr[row].Select(e => e * 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(e => e * 2).ToArray();
                }
                else
                {
                    // DivideArr(jaggedArr, row);
                    jaggedArr[row] = jaggedArr[row].Select(e => e / 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(e => e / 2).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split().ToArray();
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                double value = double.Parse(command[3]);

                if (row >= 0 && row < rows
                    && col >= 0 && col < jaggedArr[row].Length)
                {
                    if (command[0] == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (double[] row in jaggedArr)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        public static double[][] MultiplyArr(double[][] jaggedArr, int currentRow)
        {
            for (int row = currentRow; row <= currentRow + 1; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    jaggedArr[row][col] *= 2;
                }
            }

            return jaggedArr;
        }

        public static double[][] DivideArr(double[][] jaggedArr, int currentRow)
        {
            for (int row = currentRow; row <= currentRow + 1; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    jaggedArr[row][col] /= 2;
                }
            }

            return jaggedArr;
        }
    }
}

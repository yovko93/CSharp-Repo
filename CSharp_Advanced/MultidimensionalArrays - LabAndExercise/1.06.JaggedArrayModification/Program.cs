using System;
using System.Linq;

namespace _03.MA._06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                //int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                //jaggedArray[row] = new int[colElements.Length];
                //jaggedArray[row] = colElements;

                ////for (int col = 0; col < jaggedArray[row].Length; col++)
                ////{
                ////    jaggedArray[row][col] = colElements[col];
                ////}
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row > rows - 1
                    || col < 0 || col > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (command[0])
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }

                command = Console.ReadLine().Split();
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}

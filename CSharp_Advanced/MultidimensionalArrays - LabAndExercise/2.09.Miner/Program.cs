using System;
using System.Linq;

namespace _2._09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[,] field = new char[n, n];

            int coals = 0;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = elements[col];
                    else if (elements[col] == 'c')
                    {
                        coals++;
                    }
                    else if (elements[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int countOfCollectedCoals = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                char currentChar = field[startRow, startCol];

                if (IsValidIndex(field, currentCommand, startRow, startCol))
                {
                    if (currentCommand == "up")
                    {
                        currentChar = field[startRow - 1, startCol];
                        field[startRow - 1, startCol] = '*';
                        startRow = startRow - 1;
                    }
                    else if (currentCommand == "down")
                    {
                        currentChar = field[startRow + 1, startCol];
                        field[startRow + 1, startCol] = '*';
                        startRow = startRow + 1;
                    }
                    else if (currentCommand == "right")
                    {
                        currentChar = field[startRow, startCol + 1];
                        field[startRow, startCol + 1] = '*';
                        startCol = startCol + 1;
                    }
                    else if (currentCommand == "left")
                    {
                        currentChar = field[startRow, startCol - 1];
                        field[startRow, startCol - 1] = '*';
                        startCol = startCol - 1;
                    }

                    if (currentChar == 'c')
                    {
                        countOfCollectedCoals++;

                        if (countOfCollectedCoals == coals)
                        {
                            Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                            return;
                        }
                    }
                    else if (currentChar == 'e')
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                    else if (i == commands.Length - 1)
                    {
                        Console.WriteLine($"{coals - countOfCollectedCoals} coals left. ({startRow}, {startCol})");
                    }
                }
            }
        }

        static bool IsValidIndex(char[,] matrix, string currentCommand, int startRow, int startCol)
        {
            if (currentCommand == "up")
            {
                if (startRow - 1 >= 0)
                {
                    return true;
                }
            }
            else if (currentCommand == "down")
            {
                if (startRow + 1 < matrix.GetLength(0))
                {
                    return true;
                }
            }
            else if (currentCommand == "right")
            {
                if (startCol + 1 < matrix.GetLength(1))
                {
                    return true;
                }
            }
            else if (currentCommand == "left")
            {
                if (startCol - 1 >= 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

using System;
using System.Collections.Generic;

namespace P05.PathsInLabyrinth
{
    class Program
    {
        static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            lab = ReadLab();
            FindPaths(0, 0, 'S');

        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
                return;

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                UnMark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }
    }
}

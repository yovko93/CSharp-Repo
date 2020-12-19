using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize]; // 0 0 0

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                int currentIndex = initialIndexes[i];

                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 1;
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] elements = command.Split();
                int ladyBugIndex = int.Parse(elements[0]);
                string direction = elements[1];
                int flyLength = int.Parse(elements[2]);

                if (ladyBugIndex >= 0 && ladyBugIndex < field.Length && field[ladyBugIndex] == 1)
                {
                    field[ladyBugIndex] = 0;

                    if (direction == "right")
                    {
                        int indexToLand = ladyBugIndex + flyLength;
                        if (indexToLand > field.Length - 1)
                        {
                            continue;
                        }

                        if (field[indexToLand] == 1)
                        {
                            while (field[indexToLand] == 1)
                            {
                                indexToLand += flyLength;
                                if (indexToLand > field.Length - 1)
                                {
                                    break;
                                }
                            }
                        }
                        if (indexToLand >= 0 && indexToLand < field.Length)
                        {
                            field[indexToLand] = 1;
                        }
                    }
                    else if (direction == "left")
                    {
                        int indexToLand = ladyBugIndex - flyLength;
                        if (indexToLand < 0)
                        {
                            continue;
                        }

                        if (field[indexToLand] == 1)
                        {
                            while (field[indexToLand] == 1)
                            {
                                indexToLand -= flyLength;
                                if (indexToLand < 0)
                                {
                                    break;
                                }
                            }
                        }
                        if (indexToLand >= 0 && indexToLand < field.Length)
                        {
                            field[indexToLand] = 1;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}

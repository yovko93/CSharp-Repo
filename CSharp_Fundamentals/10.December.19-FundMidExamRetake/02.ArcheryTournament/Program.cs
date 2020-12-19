using System;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split('|')
                .Select(int.Parse)
                .ToArray();
            
            int iskrenPoints = 0;
            int startIndex = 0;
            int length = 0;

            string input = Console.ReadLine();

            while (input != "Game over")
            {
                string[] command = input.Split('@', StringSplitOptions.RemoveEmptyEntries);
              
                if (command[0] == "Shoot Left")
                {
                     startIndex = int.Parse(command[1]);
                     length = int.Parse(command[2]);

                    if (startIndex >= 0 && startIndex < targets.Length)
                    {
                        int targetIndex = startIndex - length;
                        while (targetIndex < 0)
                        {
                            targetIndex = targets.Length + targetIndex;
                        }
                        if (targets[targetIndex] >= 5)
                        {
                            iskrenPoints += 5;
                            targets[targetIndex] -= 5;
                        }
                        else
                        {
                            iskrenPoints += targets[targetIndex];
                            targets[targetIndex] = 0;
                        }
                    }
                }
                else if (command[0] == "Shoot Right")
                {
                    startIndex = int.Parse(command[1]);
                    length = int.Parse(command[2]);

                    if (startIndex >= 0 && startIndex < targets.Length)
                    {
                        int targetIndex = startIndex + length;
                        while (targetIndex >= targets.Length)
                        {
                            targetIndex -= targets.Length;
                        }
                        if (targets[targetIndex] >= 5)
                        {
                            iskrenPoints += 5;
                            targets[targetIndex] -= 5;
                        }
                        else
                        {
                            iskrenPoints += targets[targetIndex];
                            targets[targetIndex] = 0;
                        }
                    }
                }
                else if (input == "Reverse")
                {
                    ReverseTargets(targets);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {iskrenPoints} points!");
        }

        static int[] ReverseTargets(int[] archeryField)
        {
            for (int i = 0; i < archeryField.Length/2; i++)
            {
                int temp = archeryField[i];
                archeryField[i] = archeryField[archeryField.Length - 1 - i];
                archeryField[archeryField.Length - 1 - i] = temp;
            }

            return archeryField;
        }
    }
}

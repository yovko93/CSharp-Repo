using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split();
                int index = int.Parse(command[1]);

                if (command[0] == "Shoot")
                {
                    int power = int.Parse(command[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (command[0] == "Add")
                {
                    int value = int.Parse(command[2]);
                    if (index < 0 || index > targets.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                        input = Console.ReadLine();
                        continue;
                    }
                    targets.Insert(index, value);
                }
                else if (command[0] == "Strike")
                {
                    int radius = int.Parse(command[2]);
                    int leftTargets = index - radius;
                    int rightTargets = index + radius;

                    if (leftTargets < 0 || rightTargets > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        input = Console.ReadLine();
                        continue;
                    }
                    targets.RemoveRange(leftTargets, rightTargets - leftTargets + 1);
                }

                input = Console.ReadLine();
            }
            if (targets.Count > 0)
            {
                Console.WriteLine(string.Join('|', targets));

            }
        }
    }
}

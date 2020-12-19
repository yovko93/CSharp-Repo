using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targetsValue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            int countOfShootTargets = 0;

            while (command != "End")
            {
                int index = int.Parse(command);
                if (index < 0 || index > targetsValue.Length - 1 || targetsValue[index] == -1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                int currentTarget = targetsValue[index];
                countOfShootTargets++;
                targetsValue[index] = -1;

                for (int i = 0; i < targetsValue.Length; i++)
                {
                    if (targetsValue[i] > currentTarget)
                    {
                        targetsValue[i] -= currentTarget;
                    }
                    else if (targetsValue[i] > -1 && targetsValue[i] <= currentTarget)
                    {
                        targetsValue[i] += currentTarget;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {countOfShootTargets} -> {string.Join(" ", targetsValue)}");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfBottles = new Stack<int>(bottles);
            Queue<int> queueOfCups = new Queue<int>(cups);

            int wastedWater = 0;
            int currentCup = 0;

            while (stackOfBottles.Any() && queueOfCups.Any())
            {
                int currentFilling = stackOfBottles.Pop() - queueOfCups.Peek();

                if (currentFilling >= 0)
                {
                    queueOfCups.Dequeue();
                    wastedWater += currentFilling;
                }
                else
                {
                    currentCup = Math.Abs(currentFilling);

                    while (currentCup > 0) // && stackOfBottles.Any()
                    {
                        currentCup -= stackOfBottles.Pop();
                        if (currentCup < 0)
                        {
                            wastedWater += Math.Abs(currentCup);
                        }
                    }

                    queueOfCups.Dequeue();
                }

            }

            if (queueOfCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', stackOfBottles)}");
            }
            else if (stackOfBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', queueOfCups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numsToAdd = data[0];
            int numsToRemove = data[1];
            int numToFind = data[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numsToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numsToRemove; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(numToFind))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}

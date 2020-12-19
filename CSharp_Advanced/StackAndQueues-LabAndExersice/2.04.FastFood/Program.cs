using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int foodLeft = quantityFood;
            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (queue.Peek() <= foodLeft)
                {
                    foodLeft -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

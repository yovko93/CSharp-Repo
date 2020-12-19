using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._01.BasicStackOperations
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

            int numsToPush = data[0];
            int numsToPop = data[1];
            int lookingNum = data[2];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(lookingNum))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}

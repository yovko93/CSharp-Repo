using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (command[0] == 1)
                {
                    int currentNum = command[1];
                    stack.Push(currentNum);
                }
                else if (command[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (command[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (command[0] == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }


            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

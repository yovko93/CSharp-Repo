using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                var command = input.Split().ToArray();

                if (command[0].ToLower() == "add")
                {
                    int firstNum = int.Parse(command[1]);
                    int secondNum = int.Parse(command[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command[0].ToLower() == "remove")
                {
                    int countOfNum = int.Parse(command[1]);

                    if (stack.Count >= countOfNum)
                    {
                        for (int i = 0; i < countOfNum; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine();
            }


            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

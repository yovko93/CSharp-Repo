using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                char opr = char.Parse(stack.Pop());
                int secondNum = int.Parse(stack.Pop());
                int currentSum = 0;

                switch (opr)
                {
                    case '+':
                        currentSum = firstNum + secondNum;
                        break;
                    case '-':
                        currentSum = firstNum - secondNum;
                        break;
                    default:
                        throw new ArgumentException("Unknown operator");
                }

                stack.Push(currentSum.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}

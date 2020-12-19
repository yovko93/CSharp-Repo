using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            stack.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        string someString = input[1];
                        sb.Append(someString);
                        stack.Push(sb.ToString());
                        break;

                    case 2:
                        int count = int.Parse(input[1]);
                        sb.Remove(sb.Length - count, count);
                        stack.Push(sb.ToString());
                        break;

                    case 3:
                        int index = int.Parse(input[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;

                    case 4:
                        stack.Pop();
                        sb = new StringBuilder();
                        sb.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}

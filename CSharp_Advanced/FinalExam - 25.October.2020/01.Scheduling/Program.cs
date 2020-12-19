using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threads = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> stackTasks = new Stack<int>(tasks);
            Queue<int> queueThreads = new Queue<int>(threads);

            bool isDeath = false;

            while (!isDeath)
            {
                int taskValue = stackTasks.Peek();
                int threadVaue = queueThreads.Peek();

                if (taskToBeKilled == taskValue)
                {
                    isDeath = true;
                    continue;
                }
                if (threadVaue >= taskValue)
                {
                    stackTasks.Pop();
                    queueThreads.Dequeue();
                }
                else
                {
                    queueThreads.Dequeue();
                }



            }


            Console.WriteLine($"Thread with value {queueThreads.Peek()} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(' ', queueThreads));
        }
    }
}

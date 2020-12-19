using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] females = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueFemales = new Queue<int>(females);
            Stack<int> stackMales = new Stack<int>(males);

            int matches = 0;

            while (queueFemales.Any() && stackMales.Any())
            {
                if (queueFemales.Peek() <= 0)
                {
                    queueFemales.Dequeue();
                    continue;

                }
                if (stackMales.Peek() <= 0)
                {
                    stackMales.Pop();
                    continue;
                }
                if (queueFemales.Peek() % 25 == 0)
                {
                    queueFemales.Dequeue();
                    if (queueFemales.Count > 0)
                    {
                        queueFemales.Dequeue();
                    }
                    continue;
                }
                if (stackMales.Peek() == 0)
                {
                    stackMales.Pop();
                    if (stackMales.Count > 0)
                    {
                        stackMales.Pop();
                    }
                    continue;
                }


                if (queueFemales.Peek() == stackMales.Peek())
                {
                    matches++;
                    queueFemales.Dequeue();
                    stackMales.Pop();
                }
                else
                {
                    queueFemales.Dequeue();
                    stackMales.Push(stackMales.Pop() - 2);
                }
            }


            Console.WriteLine($"Matches: {matches}");

            if (stackMales.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", stackMales)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (queueFemales.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", queueFemales)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}

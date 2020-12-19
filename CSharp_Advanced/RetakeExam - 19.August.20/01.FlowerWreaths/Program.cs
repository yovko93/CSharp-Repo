using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] roses = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> stackLilies = new Stack<int>(lilies);
            Queue<int> queueRoses = new Queue<int>(roses);

            List<int> storedFlowers = new List<int>();

            int flowerWreaths = 0;

            while (queueRoses.Count > 0 && stackLilies.Count > 0)
            {
                int value = queueRoses.Peek() + stackLilies.Peek();

                if (value == 15)
                {
                    flowerWreaths++;
                    queueRoses.Dequeue();
                    stackLilies.Pop();
                }
                else if (value > 15)
                {
                    stackLilies.Push(stackLilies.Pop() - 2);
                }
                else
                {
                    storedFlowers.Add(stackLilies.Pop());
                    storedFlowers.Add(queueRoses.Dequeue());
                }
            }

            int restFlowers = storedFlowers.Sum();
            int restWreaths = restFlowers / 15;
            if (restWreaths > 0)
            {
                flowerWreaths += restWreaths;
            }

            if (flowerWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {flowerWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - flowerWreaths} wreaths more!");
            }
        }
    }
}

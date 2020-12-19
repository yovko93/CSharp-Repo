using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] bombCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueEffects = new Queue<int>(bombEffects);
            Stack<int> stackCasing = new Stack<int>(bombCasing);

            SortedDictionary<string, int> bombsCount = new SortedDictionary<string, int>
            {
                {"Cherry Bombs", 0 },
                {"Datura Bombs", 0},
                {"Smoke Decoy Bombs", 0 }
            };

            while ((queueEffects.Count > 0 && stackCasing.Count > 0))
            {
                int value = queueEffects.Peek() + stackCasing.Peek();

                if (value == 40)
                {
                    queueEffects.Dequeue();
                    stackCasing.Pop();
                    bombsCount["Datura Bombs"]++;
                }
                else if (value == 60)
                {
                    queueEffects.Dequeue();
                    stackCasing.Pop();
                    bombsCount["Cherry Bombs"]++;
                }
                else if (value == 120)
                {
                    queueEffects.Dequeue();
                    stackCasing.Pop();
                    bombsCount["Smoke Decoy Bombs"]++;
                }
                else
                {
                    stackCasing.Push(stackCasing.Pop() - 5);
                }


                if (bombsCount["Datura Bombs"] >= 3
                    && bombsCount["Cherry Bombs"] >= 3
                    && bombsCount["Smoke Decoy Bombs"] >= 3)
                {

                    break;
                }

            }

            if (bombsCount["Datura Bombs"] >= 3
                   && bombsCount["Cherry Bombs"] >= 3
                   && bombsCount["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }


            if (queueEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queueEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (stackCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stackCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bombPair in bombsCount)
            {
                Console.WriteLine($"{bombPair.Key}: {bombPair.Value}");
            }
        }
    }
}

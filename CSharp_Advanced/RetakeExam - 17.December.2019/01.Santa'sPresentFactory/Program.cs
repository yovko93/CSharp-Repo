using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materials = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] magicLevel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackMaterials = new Stack<int>(materials);
            Queue<int> queueMagic = new Queue<int>(magicLevel);

            SortedDictionary<string, int> presents = new SortedDictionary<string, int>()
            {
                {"Doll", 0 },
                {"Wooden train", 0 },
                {"Teddy bear", 0 },
                {"Bicycle", 0 }
            };

            while (stackMaterials.Count > 0 && queueMagic.Count > 0)
            {
                if (stackMaterials.Peek() == 0)
                {
                    stackMaterials.Pop();
                }
                if (queueMagic.Peek() == 0)
                {
                    queueMagic.Dequeue();
                }
                if (!stackMaterials.Any() || !queueMagic.Any())
                {
                    break;
                }

                int value = stackMaterials.Peek() * queueMagic.Peek();

                if (value < 0)
                {
                    int sum = stackMaterials.Pop() + queueMagic.Dequeue();
                    stackMaterials.Push(sum);
                }
                else if (value == 150)
                {
                    presents["Doll"]++;

                    stackMaterials.Pop();
                    queueMagic.Dequeue();
                }
                else if (value == 250)
                {
                    presents["Wooden train"]++;

                    stackMaterials.Pop();
                    queueMagic.Dequeue();
                }
                else if (value == 300)
                {
                    presents["Teddy bear"]++;

                    stackMaterials.Pop();
                    queueMagic.Dequeue();
                }
                else if (value == 400)
                {
                    presents["Bicycle"]++;

                    stackMaterials.Pop();
                    queueMagic.Dequeue();
                }
                else
                {
                    queueMagic.Dequeue();
                    stackMaterials.Push(stackMaterials.Pop() + 15);
                }

            }


            if ((presents["Doll"] > 0 && presents["Wooden train"] > 0)
                || (presents["Teddy bear"] > 0 && presents["Bicycle"] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stackMaterials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", stackMaterials)}");
            }
            if (queueMagic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", queueMagic)}");
            }

            foreach (var present in presents.Where(x => x.Value > 0))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}

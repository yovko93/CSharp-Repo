using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int[] secondLootBox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueFirst = new Queue<int>(firstLootBox);
            Stack<int> stackSecond = new Stack<int>(secondLootBox);

            int claimedItems = 0;

            while (queueFirst.Count > 0 && stackSecond.Count > 0)
            {
                int sum = queueFirst.Peek() + stackSecond.Peek();

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    queueFirst.Dequeue();
                    stackSecond.Pop();
                }
                else
                {
                    queueFirst.Enqueue(stackSecond.Pop());
                }

            }

            if (!queueFirst.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if(!stackSecond.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(clothes);
            int capacityOfRack = int.Parse(Console.ReadLine());

            int countOfRacks = 1;
            int currentCapacity = 0;

            //5 4 8 6 3 8 7 7 9
            while (stack.Count > 0)
            {
                int currentItem = stack.Peek();

                currentCapacity += currentItem;

                if (currentCapacity > capacityOfRack)
                {
                    countOfRacks++;
                    currentCapacity = currentItem;
                    stack.Pop();
                }
                else if (currentCapacity <= capacityOfRack)
                {
                    stack.Pop();
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}

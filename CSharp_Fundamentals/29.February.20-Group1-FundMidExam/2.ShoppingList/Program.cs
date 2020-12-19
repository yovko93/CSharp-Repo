using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split('!')
                .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] command = input.Split();
                string item = command[1];

                if (command[0] == "Urgent")
                {
                    if (!(groceries.Contains(item)))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (command[0] == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (command[0] == "Correct")
                {
                    if (groceries.Contains(item))
                    {
                        string newItem = command[2];
                        int index = groceries.IndexOf(item);
                        groceries[index] = newItem;
                    }
                }
                else if (command[0] == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}

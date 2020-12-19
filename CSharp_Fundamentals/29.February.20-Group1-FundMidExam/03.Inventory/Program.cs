using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] command = input.Split(" - ");
                string item = command[1];

                if (command[0] == "Collect")
                {
                    if (!(journal.Contains(item)))
                    {
                        journal.Add(item);
                    }
                }
                else if (command[0] == "Drop")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                    }
                }
                else if (command[0] == "Combine Items")
                {
                    string[] itemsToBeCombine = item.Split(':');
                    string oldItem = itemsToBeCombine[0];

                    if (journal.Contains(oldItem))
                    {
                        string newItem = itemsToBeCombine[1];
                        int index = journal.IndexOf(oldItem);
                        journal.Insert(index + 1, newItem);
                    }
                }
                else if (command[0] == "Renew")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}

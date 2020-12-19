using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();
                int element = int.Parse(command[1]);

                if (command[0] == "Delete")
                {
                    numbers.RemoveAll(items => items == element);
                }
                else if (command[0] == "Insert")
                {
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, element);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
        
    }
}

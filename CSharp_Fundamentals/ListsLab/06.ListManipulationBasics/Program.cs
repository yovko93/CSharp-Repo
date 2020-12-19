using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
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
                int n = int.Parse(command[1]);

                if (command[0] == "Add")
                {
                    numbers.Add(n);
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(n);
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(n);
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, n);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

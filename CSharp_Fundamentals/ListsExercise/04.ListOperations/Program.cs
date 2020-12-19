using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();
                string operation = command[0];

                switch (operation)
                {
                    case "Add":
                        int num = int.Parse(command[1]);
                        numbers.Add(num);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int index = int.Parse(command[2]);
                        if (index >= 0 && index <= numbers.Count - 1)
                        {
                            numbers.Insert(index, numberToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(command[1]);
                        if (indexToRemove >= 0 && indexToRemove <= numbers.Count - 1)
                        {
                            numbers.RemoveAt(indexToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        int count = int.Parse(command[2]);
                        if (command[1] == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int temp = numbers[0];
                                numbers.Add(temp);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (command[1] == "right")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int temp = numbers[numbers.Count - 1];
                                numbers.Insert(0, temp);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        
    }
}

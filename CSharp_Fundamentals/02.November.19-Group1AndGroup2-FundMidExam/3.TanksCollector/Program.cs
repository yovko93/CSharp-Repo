using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.TanksCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tankList = Console.ReadLine()
              .Split(", ")
              .ToList();

            int numOfCommand = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfCommand; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split(", ");

                if (command[0] == "Add")
                {
                    string tankName = command[1];
                    if (tankList.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tankList.Add(tankName);
                    }
                }
                else if (command[0] == "Remove")
                {
                    string tankName = command[1];

                    if (tankList.Contains(tankName))
                    {
                        Console.WriteLine("Tank successfully sold");
                        tankList.Remove(tankName);
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }
                else if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < tankList.Count)
                    {
                        tankList.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string tankName = command[2];

                    if (index >= 0 && index < tankList.Count)
                    {
                        if (tankList.Contains(tankName))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            tankList.Insert(index, tankName);
                            Console.WriteLine("Tank successfully bought");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }

            Console.WriteLine(string.Join(", ", tankList));
        }
    }
}

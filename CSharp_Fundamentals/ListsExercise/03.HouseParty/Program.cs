using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string input = Console.ReadLine(); //"Allie is going!"
                string[] text = input.Split(' ','!');
                string name = text[0];

                if (text[1] == "is" && text[2] == "going")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else if(text[2] == "not")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }

                }
            }

            //Console.WriteLine(string.Join("\n", guests));
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}

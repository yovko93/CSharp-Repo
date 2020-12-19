using System;
using System.Collections.Generic;

namespace _1._06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Queue<string> people = new Queue<string>();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(name);
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}

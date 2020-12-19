using System;
using System.Linq;
using System.Text;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder(text);

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                var command = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Add Stop")
                {
                    int index = int.Parse(command[1]);
                    string newStop = command[2];

                    if (index >= 0 && index < sb.Length)
                    {
                        sb.Insert(index, newStop);
                    }
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex >= startIndex && endIndex < sb.Length)
                    {
                        sb.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Switch")
                {
                    string oldString = command[1];
                    string newString = command[2];

                    if (sb.ToString().Contains(oldString))
                    {
                        sb.Replace(oldString, newString);
                    }
                    Console.WriteLine(sb);
                }

                input = Console.ReadLine();
            }


            Console.WriteLine($"Ready for world tour! Planned stops: {sb}");
        }
    }
}

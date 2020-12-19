using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            StringBuilder message = new StringBuilder(concealedMessage);

            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                var instructions = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = instructions[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(instructions[1]);
                    message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string substring = instructions[1];

                    if (message.ToString().Contains(substring))
                    {
                        int index = message.ToString().IndexOf(substring);
                        message.Remove(index, substring.Length);
                       
                        string reversedSubstring = "";
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }

                        message.Append(reversedSubstring);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = instructions[1];
                    string replacement = instructions[2];

                    message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}

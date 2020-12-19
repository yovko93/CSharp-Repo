using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})]";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    dict.Add(command, new List<int>());

                    string message = match.Groups["message"].Value;

                    for (int j = 0; j < message.Length; j++)
                    {
                        int currentNum = message[j];

                        dict[command].Add(currentNum);
                    }

                    Console.WriteLine($"{command}: {string.Join(" ", dict[command])}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }

            }
            
        }
    }
}

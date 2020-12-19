using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[-.]*\w*)@(?<host>[a-z]+-?[a-z]+(\.[a-z]+)+)";

            var matches = Regex.Matches(text, pattern);

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}

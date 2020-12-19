using System;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Z][a-z]+) ([A-Z][a-z]+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            Console.WriteLine(regex.IsMatch(input));
            Console.WriteLine(regex.Match(input).Value);
            Console.WriteLine(regex.Matches(input).Count);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Ime:{match.Groups[1].Value} Familia:{match.Groups[2].Value}");
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^(.+)\>(?<num>\d{3})\|(?<low>[a-z]{3})\|(?<upp>[A-Z]{3})\|(?<symb>[^\<\>]{3})\<\1$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string firstGroup = match.Groups["num"].Value;
                    string secondGroup = match.Groups["low"].Value;
                    string thirdGroup = match.Groups["upp"].Value;
                    string fourthGroup = match.Groups["symb"].Value;

                    string pass = string.Concat(firstGroup, secondGroup, thirdGroup, fourthGroup);

                    Console.WriteLine($"Password: {pass}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}

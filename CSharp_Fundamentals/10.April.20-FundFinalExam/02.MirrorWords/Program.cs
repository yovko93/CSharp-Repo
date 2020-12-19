using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> mirrorWords = new List<string>();

            string pattern = @"(@|#)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1";

            var matches = Regex.Matches(text, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                
                foreach (Match pair in matches)
                {
                    string firstWord = pair.Groups["first"].Value;
                    string secondWord = pair.Groups["second"].Value;
                    char[] currentWord = secondWord.ToCharArray();

                    Array.Reverse(currentWord);
                    string reversedWord = new string(currentWord);

                    if (firstWord == reversedWord)
                    {
                        mirrorWords.Add(firstWord + " <=> " + secondWord);
                    }
                }

            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}

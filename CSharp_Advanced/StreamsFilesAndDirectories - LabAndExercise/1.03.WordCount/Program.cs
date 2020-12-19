using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (var reader = new StreamReader("../../../words.txt"))
            {
                string word = reader.ReadLine();

                while (word != null)
                {
                    string[] currentWord = word.Split().ToArray();
                    foreach (var currWord in currentWord)
                    {
                        words[currWord] = 0;
                    }

                    word = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("../../../text.txt"))
            {
                string data = reader.ReadToEnd();

                foreach (Match match in Regex.Matches(data, @"\w+"))
                {
                    string word = match.Value.ToLower();

                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                    Console.WriteLine(($"{word.Key} - {word.Value}"));
                }
            }
        }
    }
}

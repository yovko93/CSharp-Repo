using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> countOccur = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordToLowerCase = word.ToLower();
                if (countOccur.ContainsKey(wordToLowerCase))
                {
                    countOccur[wordToLowerCase]++;
                }
                else
                {
                    countOccur.Add(wordToLowerCase, 1);
                }
            }

            foreach (var word in countOccur)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}

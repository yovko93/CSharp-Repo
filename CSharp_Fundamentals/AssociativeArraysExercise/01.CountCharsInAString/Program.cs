using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == ' ')
                {
                    continue;
                }
                if (charsCount.ContainsKey(symbol))
                {
                    charsCount[symbol]++;
                }
                else
                {
                    charsCount.Add(symbol, 1);
                }
            }
            
            foreach (var pair in charsCount)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}

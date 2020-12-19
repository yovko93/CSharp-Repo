using System;
using System.Collections.Generic;

namespace _2._05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> occurances = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!occurances.ContainsKey(text[i]))
                {
                    occurances.Add(text[i], 1);
                }
                else
                {
                    occurances[text[i]]++;
                }
            }

            foreach (var symbol in occurances)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}

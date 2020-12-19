using System;
using System.Collections.Generic;
using System.IO;

namespace _2._02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("../../../text.txt");

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int letters = CountOfLettersAndPunctuations(line)[0];
                int punctuations = CountOfLettersAndPunctuations(line)[1];

                result[i] = $"Line {i + 1}: {line}({letters})({punctuations})";

                Console.WriteLine($"Line {i + 1}: {line}({letters})({punctuations})");
            }

            File.WriteAllLines("../../../output.txt", result);
        }


        static int[] CountOfLettersAndPunctuations(string text)
        {
            int[] data = new int[2];

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    data[0]++;
                }
                else if (char.IsPunctuation(text[i]))
                {
                    data[1]++;
                }
            }

            return data;
        }

    }
}

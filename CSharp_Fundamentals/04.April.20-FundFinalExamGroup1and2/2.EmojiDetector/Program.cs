using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coolEmojis = new List<string>();
            ulong coolThresholdSum = 1;

            string input = Console.ReadLine();

            string pattern = @"((::)|(\*\*))(?<emoji>[A-Z][a-z]{2,})\1";
            string thresholdPattern = @"\d";

            var validEmojis = Regex.Matches(input, pattern);
            var coolThreshold = Regex.Matches(input, thresholdPattern);

            foreach (Match num in coolThreshold)
            {
                coolThresholdSum *= ulong.Parse(num.ToString());
            }

            for (int i = 0; i < validEmojis.Count; i++)
            {
                char[] currentEmojiChar = validEmojis[i].Groups["emoji"].Value.ToCharArray();
                ulong currentEmojiSum = 0;

                for (int j = 0; j < currentEmojiChar.Length; j++)
                {
                    currentEmojiSum += currentEmojiChar[j];
                }
                if (currentEmojiSum > coolThresholdSum)
                {
                    coolEmojis.Add(validEmojis[i].ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            Console.WriteLine($"{validEmojis.Count} emojis found in the text. The cool ones are:");

            if (coolEmojis.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
            }
        }
    }
}

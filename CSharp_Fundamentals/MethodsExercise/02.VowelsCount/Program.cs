using System;
using System.Linq;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(PrintVowelsCount(input));
        }

        static int PrintVowelsCount(string input)
        {
            int vowelsCount = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'o' || input[i] == 'e' || input[i] == 'u' || input[i] == 'i' || input[i] == 'y')
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }

        //static void CountVowels(string text)
        //{
        //    int vowelsCounter = 0;
        //    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (vowels.Contains(text[i]))
        //        {
        //            vowelsCounter++;
        //        }
        //    }
        //    Console.WriteLine(vowelsCounter);
            
        //}

    }
}

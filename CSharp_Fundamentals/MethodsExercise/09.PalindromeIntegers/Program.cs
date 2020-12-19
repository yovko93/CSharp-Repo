using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "END")
            {
                Console.WriteLine(CheckIfIsPalindrome(text).ToString().ToLower());
                text = Console.ReadLine();
            }
        }

        static bool CheckIfIsPalindrome(string text)
        {
            var reversed = text.Reverse().ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!(reversed[i] == text[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

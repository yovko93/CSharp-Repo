using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            PrintTheMiddleCharacter(text);
        }

        static void PrintTheMiddleCharacter(string text)
        {
            string output = string.Empty;

            if (text.Length % 2 == 0)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (i == text.Length/2 - 1)
                    {
                        output = text[i].ToString() + text[i + 1].ToString();
                    }
                }
            }
            else if (text.Length % 2 == 1)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (i == text.Length / 2)
                    {
                        output = text[i].ToString();
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}

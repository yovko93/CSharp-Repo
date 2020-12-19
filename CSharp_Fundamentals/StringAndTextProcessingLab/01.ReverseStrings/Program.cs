using System;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string reversedWord = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedWord += input[i];
                }

                Console.WriteLine($"{input} = {reversedWord}");
                input = Console.ReadLine();
            }
        }
    }
}

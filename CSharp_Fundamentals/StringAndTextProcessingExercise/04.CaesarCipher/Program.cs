using System;
using System.Linq;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

            //StringBuilder result = new StringBuilder();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    int current = input[i] + 3;
            //    result.Append((char)current);
            //}

            //Console.WriteLine(result);
            
            char[] outText = Console.ReadLine()
                .Select(x => x + 3)
                .Select(x => (char)x)
                .ToArray();

            Console.WriteLine(string.Join("", outText));
        }
    }
}

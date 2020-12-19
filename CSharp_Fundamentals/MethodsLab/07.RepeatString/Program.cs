using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            PrintString(input, n);
        }

        static string PrintString(string input, int n)
        {
            //StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                //result.Append(input);
                Console.Write(input);
            }
            //return result.ToString();
            return input;
        }
    }
}

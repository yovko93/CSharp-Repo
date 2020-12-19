using System;

namespace _05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                char characters = char.Parse(Console.ReadLine());
                text += (char)(characters + key);

            }
            Console.WriteLine(text);

        }
    }
}

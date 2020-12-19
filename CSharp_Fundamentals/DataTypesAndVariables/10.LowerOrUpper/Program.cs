using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            int a = (char)letter;
            if (a >= 65 && a <= 90 )
            {
                Console.WriteLine("upper-case");
            }
            else if (a >= 97 && a <= 122)
            {
                Console.WriteLine("lower-case");
            }

            //if (ch >= 'A' && ch <= 'Z')
            //else if (ch >= 'a' && ch <= 'z')
        }
    }
}

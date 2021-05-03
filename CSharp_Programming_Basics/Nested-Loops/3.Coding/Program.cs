using System;

namespace _3.Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int num = int.Parse(text);
            int a = 0;

            for (int i = 0; i < text.Length; i++)
            {
                a = num % 10;
                num = (num - a) / 10;
                if (a == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
                for (int x = 0; x < a; x++)
                {
                    char number = (char)(a + 33);
                    Console.Write(number);
                }
                Console.WriteLine();
                
            }


            ////string text = Console.ReadLine();

            ////for (int i = text.Length - 1; i >= 0; i--)
            ////{
            ////    char a = text[i];
            ////    int number = int.Parse(a.ToString());
            ////    if (number == 0)
            ////    {
            ////        Console.WriteLine("ZERO");
            ////        continue;
            ////    }
            ////    for (int n = 1; n <= number; n++)
            ////    {
            ////        Console.Write((char)(number + 33));
            ////    }
            ////    Console.WriteLine();
            ////}
        }
    }
}

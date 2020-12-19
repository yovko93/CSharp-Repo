using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second)); 
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));

            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetMax(first, second));
            }
        }

        static char GetMax(char first, char second)
        {
            int compare = first.CompareTo(second);
            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static string GetMax(string first, string second)
        {
            int compare = first.CompareTo(second);
            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static int GetMax(int first, int second)
        {
            int compare = first.CompareTo(second);
            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

    }
}

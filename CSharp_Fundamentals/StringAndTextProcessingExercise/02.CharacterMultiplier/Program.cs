using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            int sum = ReturnSum(input[0], input[1]);
            Console.WriteLine(sum);
        }

        static int ReturnSum(string first, string second)
        {
            int sum = 0;
            string longest = "";
            string shortest = "";

            if (first.Length > second.Length)
            {
                longest = first;
                shortest = second;
            }
            else
            {
                longest = second;
                shortest = first;
            }
            
            for (int i = 0; i < shortest.Length; i++)
            {
                sum += first[i] * second[i];
            }
            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }

            return sum;
        }
    }
}

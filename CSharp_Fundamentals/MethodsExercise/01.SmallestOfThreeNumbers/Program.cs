using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(GetTheSmallest(first,second,third));
        }

        static int GetTheSmallest(int first, int second, int third)
        {
            int minNum = Math.Min(Math.Min(first, second), third);
            return minNum;

        }
    }
}

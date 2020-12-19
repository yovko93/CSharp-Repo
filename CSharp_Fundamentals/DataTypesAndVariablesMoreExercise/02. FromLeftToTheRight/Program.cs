using System;
using System.Linq;

namespace _02._FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                string[] numbers = Console.ReadLine().Split().ToArray();
                string leftNum = numbers[0];
                string rightNum = numbers[1];
                long left = long.Parse(leftNum);
                long right = long.Parse(rightNum);
                long sum = 0;

                if (left > right)
                {
                    for (int z = 0; z <= leftNum.Length - 1; z++)
                    {
                        sum += left % 10;
                        left /= 10;
                    }
                }
                else
                {
                    for (int z = 0; z <= rightNum.Length - 1; z++)
                    {
                        sum += right % 10;
                        right /= 10;
                    }
                }
                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}

using System;
using System.Linq;

namespace _2._03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> func = nums =>
            {
                int minNum = int.MaxValue;

                foreach (var num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            };

            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(func(nums));

            //int smallest = PrintSmallestNum(nums, func);
        }

        //static int PrintSmallestNum(int[] nums, Func<int[], int> func)
        //{

        //    return nums.Min();
        //}
    }
}

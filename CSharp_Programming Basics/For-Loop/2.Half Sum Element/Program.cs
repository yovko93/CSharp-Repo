using System;

namespace _2.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
                sum += num;
            }
           int diff = sum - max;
            if (diff == max)
            {
                Console.WriteLine("Yes\nSum = " + max);
            }
            else
            {
                int difference = Math.Abs(max - diff);
                Console.WriteLine("No\nDiff = " + difference);
            }
        }
    }
}

using System;

namespace _4.Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int value = 0;
            int currentDiff = 0;
            int maxDiff = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                
                sum = num1 + num2;
                if (i == 1)
                {
                    value = sum;
                }
                if (value != sum)
                {
                    currentDiff = Math.Abs(sum - value);
                    if (currentDiff > maxDiff)
                    {
                        maxDiff = currentDiff;
                    }
                }
                value = sum;
            }
            if (maxDiff != int.MinValue)
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
            else
            {
                Console.WriteLine($"Yes, value={sum}");
            }
        }
    }
}

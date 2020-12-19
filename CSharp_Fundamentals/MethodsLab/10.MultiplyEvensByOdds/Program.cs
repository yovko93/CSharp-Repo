using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            num = Math.Abs(num);
            Console.WriteLine(GetMultipleOfEvenAndOdds(num));
        }

        static int GetMultipleOfEvenAndOdds(int n)
        {
            return GetSumOfDigits(n, 0) * GetSumOfDigits(n,1);
        }

        static int GetSumOfDigits(int n, int isOdd)
        {
            string number = n.ToString();
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == isOdd)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }
        
    }
}

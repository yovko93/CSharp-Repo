using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintMasterNumbers(num);
            
        }

        static void PrintMasterNumbers(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                int sumOfDigits = 0;

                while (currentNum > 0)
                {
                    int currentDigit = currentNum % 10;
                    sumOfDigits += currentDigit;
                    currentNum /= 10;
                }
                
                if (sumOfDigits % 8 == 0)
                {
                    currentNum = i;
                    while (currentNum > 0)
                    {
                        int currentDigit = currentNum % 10;
                        currentNum /= 10;
                        if (currentDigit % 2 == 1)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }

        }
    }
}

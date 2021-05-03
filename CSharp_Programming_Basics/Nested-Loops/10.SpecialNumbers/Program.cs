using System;

namespace _10.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9 ; j++)
                {
                    for (int k = 1; k <= 9 ; k++)
                    {
                        for (int l = 1; l <= 9 ; l++)
                        {
                            if (n % i == 0 && n % j == 0 && n % k == 0 && n % l == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
            //for (int i = 1111; i <= 9999; i++)
            //{
            //    int number = i;
            //    int lastDigit = number % 10;
            //    if (lastDigit == 0)
            //    {
            //        continue;
            //    }
            //    if (n % lastDigit == 0)
            //    {
            //        number /= 10;
            //        lastDigit = number % 10;
            //        if (lastDigit == 0)
            //        {
            //            continue;
            //        }
            //        if (n % lastDigit == 0)
            //        {
            //            number /= 10;
            //            lastDigit = number % 10;
            //            if (lastDigit == 0)
            //            {
            //                continue;
            //            }
            //            if (n % lastDigit == 0)
            //            {
            //                number /= 10;
            //                if (n % number == 0)
            //                {
            //                    Console.Write(i + " ");
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}

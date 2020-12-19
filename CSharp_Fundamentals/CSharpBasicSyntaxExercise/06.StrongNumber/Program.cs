using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                char letter = number[i];
                int letterInt = int.Parse(letter.ToString());

                int factorial = 1;
                for (int n = 1; n <= letterInt; n++)
                {
                    factorial *= n;
                }
                sum += factorial;
            }
            int numberInt = int.Parse(number);

            if (numberInt == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }


            //int num = int.Parse(Console.ReadLine());
            //int tempNum = num;
            //int factorialSum = 0;

            //while (tempNum > 0)
            //{
            //  int digit = tempNum % 10;
            //    tempNum /= 10;
            //    int res = 1;
            //    for (int i = 1; i <= digit; i++)
            //    {
            //        res *= i;
            //    }
            //    factorialSum += res;
            //}
            //if (factorialSum == num)
            //{
            //    Console.WriteLine("yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
        }
    }
}

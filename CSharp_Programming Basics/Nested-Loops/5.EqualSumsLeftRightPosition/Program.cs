using System;

namespace _5.EqualSumsLeftRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                int middle = 0;
                int digit = 0;
                int number = i;
                for (int j = 5; j >= 1; j--)
                {
                    digit = number % 10;
                    number = number / 10;
                    if (j > 3)
                    {
                        rightSum += digit;
                    }
                    else if (j == 2 || j == 1)
                    {
                        leftSum += digit;
                    }
                    else
                    {
                        middle = digit;
                    }
                }
                if (leftSum < rightSum)
                {
                    leftSum += middle;
                }
                else if (rightSum < leftSum)
                {
                    rightSum += middle;
                }
                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                }
            }

            //for (int i = firstNumber; i <= secondNumber; i++)
            //{
            //    int leftSum = 0;
            //    int rightSum = 0;
            //    int middle = 0;
            //    string currentNum = i.ToString();
            //    for (int j = 0; j < currentNum.Length; j++)
            //    {
            //        int currentDigit = int.Parse(currentNum[j].ToString());
            //        if (j <= 1)
            //        {
            //            leftSum += currentDigit;
            //        }
            //        else if (j > 2)
            //        {
            //            rightSum += currentDigit;
            //        }
            //        else
            //        {
            //            middle = currentDigit;
            //        }
            //    }
            //    if (leftSum < rightSum)
            //    {
            //        leftSum += middle;
            //    }
            //    else if (rightSum < leftSum)
            //    {
            //        rightSum += middle;
            //    }
            //    if (leftSum == rightSum && leftSum != 0)
            //    {
            //        Console.Write(i + " ");
            //    }
            //}
        }
    }
}

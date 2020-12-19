using System;

namespace _1.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine()); //2
            int num2= int.Parse(Console.ReadLine()); //1
            int num3 = int.Parse(Console.ReadLine()); //3
            
            int realNum1 = 0;
            int realNum2 = 0;
            int realNum3 = 0;

            if (num1 > num2 && num1 > num3)
            {
                realNum1 = num1;
                
            }
            if (num2 > num1 && num2 > num3)
            {
                realNum1 = num2;
                realNum2 = num1;
            }
            if (num3 > num1 && num3 > num2)
            {
                realNum1 = num3;

            }
        }
    }
}

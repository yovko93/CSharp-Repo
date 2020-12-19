using System;
using System.Linq;

namespace _06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            //1. go through each element
            //2. sum all elements on its left
            //3. sum all element on its right
            //4. if they are equal -> break;

           
            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0;
                int rigthSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += array[j];
                }
                for (int k = i + 1; k < array.Length; k++)
                {
                    rigthSum += array[k];

                }

                if (leftSum == rigthSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");

        }
    }
}

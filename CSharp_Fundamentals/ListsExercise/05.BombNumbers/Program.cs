using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int specialNum = arr[0];
            int power = arr[1];
            int bombIndex = list.IndexOf(specialNum);
           
            while (bombIndex != -1)
            {
                int leftNumbers = bombIndex - power;
                int rightNumbers = bombIndex + power;

                if (leftNumbers < 0)
                {
                    leftNumbers = 0;
                }
                if (rightNumbers > list.Count - 1)
                {
                    rightNumbers = list.Count - 1;
                }

                list.RemoveRange(leftNumbers, rightNumbers - leftNumbers + 1);
                bombIndex = list.IndexOf(specialNum);
            }

            Console.WriteLine(list.Sum());
            //int sum = 0;
            //foreach (var num in list)
            //{
            //    sum += num;
            //}
            //Console.WriteLine(sum);
        }
    }
}

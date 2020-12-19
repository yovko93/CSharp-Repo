using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                list.Add(num);

            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Box<int> box = new Box<int>(list);
            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                list.Add(input);
            }


            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Box<string> box = new Box<string>(list);

            box.Swap(list, firstIndex, secondIndex);

            Console.WriteLine(box);
         }
    }
}

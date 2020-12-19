using System;
using System.Collections.Generic;
using System.IO;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string elements = Console.ReadLine();

                list.Add(elements);
            }

            string elementToCompare = Console.ReadLine();

            Box<string> box = new Box<string>(list);

            int count = box.GetCountOfGreaterValues(elementToCompare);

            Console.WriteLine(count);

        }
    }
}

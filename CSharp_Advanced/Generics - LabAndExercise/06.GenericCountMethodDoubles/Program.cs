using System;
using System.Collections.Generic;
using System.IO;

namespace _06.GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double elements = double.Parse(Console.ReadLine());

                list.Add(elements);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(list);

            int count = box.GetCountOfGreaterValues(elementToCompare);

            Console.WriteLine(count);
        }
    }
}

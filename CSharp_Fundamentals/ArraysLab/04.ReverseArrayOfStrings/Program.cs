using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < values.Length/2; i++)
            {
                string temp = values[i];
                values[i] = values[values.Length - i - 1];
                values[values.Length - i - 1] = temp;
            }
            Console.WriteLine(string.Join(" ",values));

            //string[] array = Console.ReadLine().Split().ToArray();

            //for (int i = array.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(array[i] + " ");
            //}
        }
    }
}

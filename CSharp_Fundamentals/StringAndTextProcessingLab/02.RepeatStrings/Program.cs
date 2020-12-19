using System;
using System.Linq;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] array = Console.ReadLine().Split().ToArray();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    result.Append(array[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] number = Console.ReadLine().Split().Select(double.Parse).ToArray();

            //може и без този ред!!
            int[] rounded = new int[number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                //int rounded = (int)Math.Round(number[i], MidpointRounding.AwayFromZero);
                rounded[i] = (int)Math.Round(number[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{number[i]} => {rounded[i]} ");
            }
        }
    }
}

using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            //arr Length = 4
            //8 пъти
            // count = count % arr.Length;

            for (int index = 0; index < n; index++)
            {
                string temp = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

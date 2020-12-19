using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            string result = "";
            foreach (var word1 in arr2)
            {
                foreach (var word2 in arr1)
                {
                    if (word1 == word2)
                    {
                        result += word1 + " ";
                    }
                }
            }

            //Втори вариант
            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    for (int j = 0; j < arr1.Length; j++)
            //    {
            //        if (arr2[i] == arr1[j])
            //        {
            //            result += arr2[i] + " ";
            //        }
            //    }
            //}

            Console.WriteLine(result);
        }
    }
}

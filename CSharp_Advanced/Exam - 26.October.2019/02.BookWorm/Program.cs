using System;
using System.IO;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string someSrtring = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            for (int rows = 0; rows < n; rows++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {

                }
            }
        }
    }
}

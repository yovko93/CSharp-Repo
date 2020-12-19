using System;
using System.IO;

namespace _1._01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}

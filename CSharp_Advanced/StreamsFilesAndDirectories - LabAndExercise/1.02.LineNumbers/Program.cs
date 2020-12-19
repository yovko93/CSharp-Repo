using System;
using System.IO;

namespace _1._02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt"))
            {

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    int counter = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();

                        Console.WriteLine($"{counter}. {line}");
                    }


                }
            }
        }
    }
}

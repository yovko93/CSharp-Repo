using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    int counter = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            Regex pattern = new Regex("[-,.!?]");
                            line = pattern.Replace(line, "@");

                            string[] newLine = line.Split().Reverse().ToArray();
                            writer.WriteLine(string.Join(' ', newLine));
                            Console.WriteLine(string.Join(' ', newLine));
                        }

                        counter++;
                        line = reader.ReadLine();
                    }

                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace _1._04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> data = new SortedSet<string>();

            using (var reader  = new StreamReader("../../../FileOne.txt"))
            {
                string item = reader.ReadLine();
                while (item != null)
                {
                    data.Add(item);

                    item = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("../../../FileTwo.txt"))
            {
                string item = reader.ReadLine();
                while (item != null)
                {
                    data.Add(item);

                    item = reader.ReadLine();
                }
            }

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(item);
                    Console.WriteLine(item);
                }
            }
        }
    }
}

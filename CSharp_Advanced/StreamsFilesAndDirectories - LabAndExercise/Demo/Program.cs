using System;
using System.IO;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = 
                new FileStream ("../../../input.txt", FileMode.Open))
            {
                Console.WriteLine(stream.Length);
                stream.Position = 3;
                byte[] buffer = new byte[6];
                while (stream.Position < stream.Length)
                {
                    stream.Read(buffer, 0, buffer.Length);

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        Console.WriteLine((char)buffer[i]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

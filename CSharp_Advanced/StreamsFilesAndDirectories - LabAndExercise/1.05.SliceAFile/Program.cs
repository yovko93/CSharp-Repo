using System;
using System.IO;

namespace _1._05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;

            using (FileStream stream = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                long size = stream.Length / parts;

                for (int i = 0; i < parts; i++)
                {
                    using (var pieceStream =
                        new FileStream($"../../../part-{i + 1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[1];

                        int count = 0;
                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStream.Write(buffer, 0, buffer.Length);

                            count += buffer.Length;
                        }
                    }
                }

            }
        }
    }
}

using System;
using System.IO;

namespace _1._06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            //////  не е решена!!!


            string path = Console.ReadLine();

            Console.WriteLine(GetDirectorySize(path));
        }

        static double GetDirectorySize(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);

            double sum = 0;
            string[] directories = Directory.GetDirectories(directoryPath);

            for (int i = 0; i < directories.Length; i++)
            {
                sum += GetDirectorySize(directories[i]);
            }
            for (int j = 0; j < files.Length; j++)
            {
                FileInfo info = new FileInfo(files[j]);

                sum += info.Length;
            }


            return sum;
        }
    }
}

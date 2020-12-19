using System;
using System.IO;
using System.IO.Compression;

namespace _2._06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileDemo", @"D:\ZipFileDemo2\myZipFile.zip");

            ZipFile.ExtractToDirectory(@"D:\ZipFileDemo2\myZipFile.zip", @"D:\ZipFileDemoResult");
        }
    }
}

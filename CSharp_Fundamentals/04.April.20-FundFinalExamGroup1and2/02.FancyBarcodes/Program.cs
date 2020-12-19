using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(@#+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            for (int i = 0; i < n; i++)
            {
                string barcodes = Console.ReadLine();

                if (Regex.IsMatch(barcodes, pattern))
                {
                    string productGroup = "00";
                    if (Regex.IsMatch(barcodes, @"\d"))
                    {
                        productGroup = string.Concat(Regex.Matches(barcodes, @"\d"));

                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}

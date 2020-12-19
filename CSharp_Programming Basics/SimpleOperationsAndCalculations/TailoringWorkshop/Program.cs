using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tablesLength = double.Parse(Console.ReadLine());
            double tablesWidth = double.Parse(Console.ReadLine());

            double areaCover = tables * (tablesLength + 2 * 0.3) * (tablesWidth + 2 * 0.3);
            double areaSquare = tables * (tablesLength / 2) * (tablesLength / 2);

            double priceUSD = areaCover * 7 + areaSquare * 9;
            double priceBGN = priceUSD * 1.85;

            Console.WriteLine("{0:f2} USD", priceUSD);
            Console.WriteLine($"{priceBGN:f2} BGN");


        }
    }
}

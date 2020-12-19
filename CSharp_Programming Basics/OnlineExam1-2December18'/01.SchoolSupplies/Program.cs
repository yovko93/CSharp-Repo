using System;

namespace _01.SchoolSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int pencils = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double littres = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pencilPrice = pencils * 5.8;
            double markerPrice = markers * 7.2;
            double drugPrice = littres * 1.2;
            double percent = discount / 100.0;

            double totalPrice = pencilPrice + markerPrice + drugPrice;
            totalPrice -= (totalPrice * percent);
            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}

using System;

namespace _01.EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterCake = int.Parse(Console.ReadLine());
            int eggPack = int.Parse(Console.ReadLine());
            int kgCoocieks = int.Parse(Console.ReadLine());

            double easterCakePrice = easterCake * 3.2;
            double eggsPrice = eggPack * 4.35;
            double cookiesPrice = kgCoocieks * 5.4;
            double paintPrice = eggPack * 12 * 0.15;

            double totalPrice = easterCakePrice + eggsPrice + cookiesPrice + paintPrice;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

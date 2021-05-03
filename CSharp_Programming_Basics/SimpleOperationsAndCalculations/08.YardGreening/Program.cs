using System;

namespace _08.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double sqMeter = double.Parse(Console.ReadLine());
            double price = sqMeter * 7.61;
            double discount = price * 0.18;

            Console.WriteLine($"The final price is: {(price-discount):f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}

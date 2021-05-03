using System;

namespace _01.TrekkingEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int alpinist = int.Parse(Console.ReadLine());
            int carabiner = int.Parse(Console.ReadLine());
            int rope = int.Parse(Console.ReadLine());
            int pikel = int.Parse(Console.ReadLine());

            double carabinerPrice = carabiner * 36.0;
            double ropePrice = rope * 3.60;
            double pikelPrice = pikel * 19.80;

            double price = alpinist * (carabinerPrice + ropePrice + pikelPrice);
            double totalPrice = price + price * 0.2;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

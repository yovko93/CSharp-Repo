using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double shoes = tax * 0.6;
            double ekip = shoes * 0.8;
            double ball = ekip * 0.25;
            double accessoar = ball * 0.2;

            double totalPrice = tax + shoes + ekip + ball + accessoar;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

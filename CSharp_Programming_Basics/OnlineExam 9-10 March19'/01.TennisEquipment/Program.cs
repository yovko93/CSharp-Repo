using System;

namespace _01.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tenisRocket = double.Parse(Console.ReadLine());
            int countTenisRocket = int.Parse(Console.ReadLine());
            int shoes = int.Parse(Console.ReadLine());

            double tenisRocketPrice = countTenisRocket * tenisRocket;
            double shoesPrice = shoes * (tenisRocket/6);

            double moreStuff = (tenisRocketPrice + shoesPrice) * 0.2;
            double totalPrice = tenisRocketPrice + shoesPrice + moreStuff;

            double djokovic = totalPrice/8;
            double sponsors = totalPrice*7/8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(djokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsors)}");
        }
    }
}

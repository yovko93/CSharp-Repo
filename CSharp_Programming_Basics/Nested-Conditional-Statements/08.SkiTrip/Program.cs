using System;

namespace _08.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rate = Console.ReadLine();
            int nights = days - 1;
            double discount = 0.0;
            double pricePerNight = 0.0;

            if(room == "room for one person")
            {
                    pricePerNight = 18;
            }
            else if(room == "apartment")
            {
                if (nights < 10)
                {
                    pricePerNight = 25;
                    discount = 0.3;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    pricePerNight = 25;
                    discount = 0.35;
                }
                else if (nights > 15)
                {
                    pricePerNight = 25;
                    discount = 0.5;
                }
            }
            else if (room == "president apartment")
            {
                if (nights < 10)
                {
                    pricePerNight = 35;
                    discount = 0.1;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    pricePerNight = 35;
                    discount = 0.15;
                }
                else if (nights > 15)
                {
                    pricePerNight = 35;
                    discount = 0.2;
                }
            }
            double totalPrice = pricePerNight * nights;
            totalPrice -= totalPrice * discount;

            if(rate == "positive")
            {
                totalPrice += totalPrice * 0.25;       
            }
            else if(rate == "negative")
            {
                totalPrice -= totalPrice * 0.1;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

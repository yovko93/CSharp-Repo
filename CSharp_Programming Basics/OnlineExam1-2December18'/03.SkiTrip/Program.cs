using System;

namespace _03.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string opinion = Console.ReadLine();

            int nights = days - 1;
            double discount = 0.0;
            double price = 0.0;
            double totalPrice = 0.0;

            switch (typeOfRoom)
            {
                case "room for one person":
                    if (nights < 10)
                    {
                        price = nights * 18.00;
                    }
                    else if (nights >= 10 && nights < 15)
                    {
                        price = nights * 18.00;
                    }
                    else if (nights > 15)
                    {
                        price = nights * 18.00;
                    }
                    break;
                case "apartment":
                    if (nights < 10)
                    {
                        price = nights * 25.00;
                        discount = price * 0.3;
                    }
                    else if (nights >= 10 && nights < 15)
                    {
                        price = nights * 25.0;
                        discount = price * 0.35;
                    }
                    else if (nights > 15)
                    {
                        price = nights * 25.00;
                        discount = price * 0.5;
                    }
                    break;
                case "president apartment":
                    if (nights < 10)
                    {
                        price = nights * 35.00;
                        discount = price * 0.1;
                    }
                    else if (nights >= 10 && nights < 15)
                    {
                        price = nights * 35.0;
                        discount = price * 0.15;
                    }
                    else if (nights > 15)
                    {
                        price = nights * 35.00;
                        discount = price * 0.2;
                    }
                    break;
            }

            if (opinion == "positive")
            {
                totalPrice = price - discount;
                totalPrice = totalPrice * 1.25;
            }
            else if (opinion == "negative")
            {
                totalPrice = price - discount;
                totalPrice = totalPrice * 0.9;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

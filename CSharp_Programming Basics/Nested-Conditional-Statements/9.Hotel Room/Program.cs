using System;

namespace _9.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            if (month == "May" || month == "October")
            {
                if (nights > 7 && nights <= 14)
                {
                    studioPrice = nights * 50 * 0.95;
                    apartmentPrice = nights * 65;
                }
                else if (nights > 14)
                {
                    studioPrice = nights * 50 * 0.7;
                    apartmentPrice = nights * 65 * 0.9;
                }
                else
                {
                    studioPrice = nights * 50;
                    apartmentPrice = nights * 65;
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nights > 14)
                {
                    studioPrice = nights * 75.20 * 0.8;
                    apartmentPrice = nights * 68.70 * 0.9;
                }
                else
                {
                    studioPrice = nights * 75.20;
                    apartmentPrice = nights * 68.70;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = nights * 76;
                if (nights > 14)
                {
                    apartmentPrice = nights * 77 * 0.9;
                }
                else
                {
                    apartmentPrice = nights * 77;
                }
            }
            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}

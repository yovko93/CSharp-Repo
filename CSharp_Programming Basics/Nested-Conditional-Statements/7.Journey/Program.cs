using System;

namespace _7.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0.0;
            string destination = string.Empty;
            string typeHoliday = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {    
                    typeHoliday = "Camp";
                    price = budget * 0.3;
                }
                else if (season == "winter")
                {
                    typeHoliday = "Hotel";
                    price = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    typeHoliday = "Camp";
                    price = budget * 0.4;
                }
                else if (season == "winter")
                {
                    typeHoliday = "Hotel";
                    price = budget * 0.8;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                typeHoliday = "Hotel";
                price = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeHoliday} - {price:f2}");
        }
    }
}

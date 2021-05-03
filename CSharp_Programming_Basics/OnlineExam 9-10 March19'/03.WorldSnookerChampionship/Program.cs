using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            char picture = char.Parse(Console.ReadLine());

            decimal totalPrice = 0;
            decimal ticketPrice = 0;

            if (stage == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = ticketsCount * 55.5m;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = ticketsCount * 105.2m;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = ticketsCount * 118.9m;
                }
            }
            else if (stage == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = ticketsCount * 75.88m;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = ticketsCount * 125.22m;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = ticketsCount * 300.4m;
                }
            }
            else if (stage == "Final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = ticketsCount * 110.1m;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = ticketsCount * 160.66m;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = ticketsCount * 400.0m;
                }
            }
            decimal pic = ticketsCount * 40;
           
            if (ticketPrice > 4000)
            {
                totalPrice = ticketPrice * 0.75m;
            }
            else if (ticketPrice <= 4000 && ticketPrice > 2500)
            {
                totalPrice = ticketPrice * 0.9m;
                if (picture == 'Y')
                {
                    totalPrice += pic;
                }
            }
            else
            {
                if (picture == 'Y')
                {
                    totalPrice += pic;
                }
                else if (picture == 'N')
                {
                    totalPrice = ticketPrice;
                }
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

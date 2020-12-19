using System;

namespace _01.TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketGoing = double.Parse(Console.ReadLine());
            double ticketBack = double.Parse(Console.ReadLine());
            double ticketGame = double.Parse(Console.ReadLine());
            int countGames = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double tickets = 6 * (ticketGoing + ticketBack);
            double percent = discount / 100.0;
            double ticketsPrice = tickets - (tickets * percent);
            double ticketsGamesPrice = 6 * countGames * ticketGame;
            double totalSum = ticketsGamesPrice + ticketsPrice;
            double friend = totalSum / 6;

            Console.WriteLine($"Total sum: {totalSum:f2} lv.");
            Console.WriteLine($"Each friend has to pay {friend:f2} lv.");
        }
    }
}

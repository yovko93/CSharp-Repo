using System;

namespace _01.StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double incomeOneSector = (capacity * ticketPrice) / sectors;
            double totalIncome = capacity * ticketPrice;
            double charity = (totalIncome - incomeOneSector * 0.75) * 1 / 8;

            Console.WriteLine($"Total income - {totalIncome:f2} BGN");
            Console.WriteLine($"Money for charity - {charity:f2} BGN");
        }
    }
}

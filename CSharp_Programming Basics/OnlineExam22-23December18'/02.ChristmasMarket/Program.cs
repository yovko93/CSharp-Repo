using System;

namespace _02.ChristmasMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            int countFantasy = int.Parse(Console.ReadLine());
            int countHorror = int.Parse(Console.ReadLine());
            int countRomantic = int.Parse(Console.ReadLine());

            double fantasyPrice = countFantasy * 14.90;
            double horrorPrice = countHorror * 9.8;
            double romanticPrice = countRomantic * 4.3;

            double totalSales = fantasyPrice + horrorPrice + romanticPrice;
            totalSales *= 0.8;

            double diff = Math.Abs(totalSales - neededMoney);

            if (totalSales >= neededMoney)
            {
                double sellers = Math.Floor(diff * 0.1);
                totalSales -= sellers;
                Console.WriteLine($"{totalSales:f2} leva donated.");
                Console.WriteLine($"Sellers will receive {sellers} leva.");
            }
            else
            {
                Console.WriteLine($"{diff:f2} money needed.");
            }

        }
    }
}

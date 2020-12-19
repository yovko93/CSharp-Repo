using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskeyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double wiskeyLiters = double.Parse(Console.ReadLine());

           
            double rakiaPrice = wiskeyPrice / 2;
            double wineTotalPrice = wineLiters * (rakiaPrice - (0.4 * rakiaPrice));
            double beerTotalPrice = beerLiters * (rakiaPrice - (0.8 * rakiaPrice));
            double rakiaTotalPrice = rakiaLiters * rakiaPrice;
            double wiskieyTotalPrice = wiskeyLiters * wiskeyPrice;

            double Totalsum = wiskieyTotalPrice + wineTotalPrice + beerTotalPrice + rakiaTotalPrice;

            Console.WriteLine("{0:f2}", Totalsum);
        }
    }
}

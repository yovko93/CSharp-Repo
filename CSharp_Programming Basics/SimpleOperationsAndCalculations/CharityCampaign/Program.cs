using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesPrice = cakes * 45;
            double wafflesPrice = waffles * 5.80;
            double pancakesPrice = pancakes * 3.20;
            double totalsumperday = (cakesPrice + wafflesPrice + pancakesPrice) * bakers;

            double totalsum = days * totalsumperday;
            double total = totalsum - totalsum/8;

            Console.WriteLine($"{total:f2}");

        }
    }
}

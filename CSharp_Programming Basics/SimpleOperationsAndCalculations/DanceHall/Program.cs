using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double Lhall = double.Parse(Console.ReadLine());
            double Whall = double.Parse(Console.ReadLine());
            double Awardrobe = double.Parse(Console.ReadLine());

            double areaHall = (Lhall*100) * (Whall*100);
            double areaWardrobe = (Awardrobe * 100) * (Awardrobe * 100);
            double areaBench = areaHall / 10;

            double areaFree = areaHall - areaWardrobe - areaBench;
            double dancers = areaFree / (40 + 7000);

            Console.WriteLine(Math.Floor(dancers));
         
        }
    }
}

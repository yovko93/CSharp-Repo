using System;

namespace _6.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsToHome = int.Parse(Console.ReadLine());

            double weekendInSofia = 48 - weekendsToHome;
            double playWeekendsInSofia = weekendInSofia * 3.0 / 4;
            double playInHolidays = holidays * 2.0 / 3;
            double playTime = (playInHolidays + playWeekendsInSofia + weekendsToHome);

            if (year == "leap")
            {
                playTime *= 1.15;
            }
            else if (year == "normal")
            {
                playTime = playTime;
            }
            Console.WriteLine(Math.Floor(playTime));
        }
    }
}

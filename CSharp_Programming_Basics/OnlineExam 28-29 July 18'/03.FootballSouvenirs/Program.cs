using System;

namespace _03.FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int countSouvenirs = int.Parse(Console.ReadLine());

            bool teamCheck = team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark";
            bool souvenirsCheck = souvenirs == "flags" || souvenirs == "caps" || souvenirs == "posters" || souvenirs == "stickers";
            double totalSum = 0.0;

            if (team == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 3.25;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 7.2;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 5.1;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.25;
                }
            }
            else if (team == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 4.2;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 8.5;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 5.35;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.2;
                }
            }
            else if (team == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 2.75;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 6.9;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 4.95;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.1;
                }
            }
            else if (team == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 3.1;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 6.5;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 4.8;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 0.9;
                }
            }
            if (teamCheck && souvenirsCheck)
            {
                Console.WriteLine($"Pepi bought {countSouvenirs} {souvenirs} of {team} for {totalSum:f2} lv.");
            }
            else if (!teamCheck)
            {
                Console.WriteLine("Invalid country!");
            }
            else if (!souvenirsCheck)
            {
                Console.WriteLine("Invalid stock!");
            }

        }
    }
}

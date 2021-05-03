using System;

namespace _03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string room = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double profit = 0.0;

            switch (movie)
            {
                case "A Star Is Born":
                    switch (room)
                    {
                        case "normal":
                            profit = tickets * 7.5;
                            break;
                        case "luxury":
                            profit = tickets * 10.5;
                            break;
                        case "ultra luxury":
                            profit = tickets * 13.5;
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (room)
                    {
                        case "normal":
                            profit = tickets * 7.35;
                            break;
                        case "luxury":
                            profit = tickets * 9.45;
                            break;
                        case "ultra luxury":
                            profit = tickets * 12.75;
                            break;
                    }
                    break;
                case "Green Book":
                    switch (room)
                    {
                        case "normal":
                            profit = tickets * 8.15;
                            break;
                        case "luxury":
                            profit = tickets * 10.25;
                            break;
                        case "ultra luxury":
                            profit = tickets * 13.25;
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (room)
                    {
                        case "normal":
                            profit = tickets * 8.75;
                            break;
                        case "luxury":
                            profit = tickets * 11.55;
                            break;
                        case "ultra luxury":
                            profit = tickets * 13.95;
                            break;
                    }
                    break;
            }

            Console.WriteLine($"{movie} -> {profit:f2} lv.");
        }
    }
}

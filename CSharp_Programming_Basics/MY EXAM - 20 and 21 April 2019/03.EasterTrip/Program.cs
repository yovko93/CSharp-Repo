using System;

namespace _03.EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string date = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double expenses = 0.0;

            switch (destination)
            {
                case "France":
                    switch (date)
                    {
                        case "21-23":
                            expenses = nights * 30.0;
                            break;
                        case "24-27":
                            expenses = nights * 35.0;
                            break;
                        case "28-31":
                            expenses = nights * 40.0;
                            break;
                    }
                    break;
                case "Italy":
                    switch (date)
                    {
                        case "21-23":
                            expenses = nights * 28.0;
                            break;
                        case "24-27":
                            expenses = nights * 32.0;
                            break;
                        case "28-31":
                            expenses = nights * 39.0;
                            break;
                    }
                    break;
                case "Germany":
                    switch (date)
                    {
                        case "21-23":
                            expenses = nights * 32.0;
                            break;
                        case "24-27":
                            expenses = nights * 37.0;
                            break;
                        case "28-31":
                            expenses = nights * 43.0;
                            break;
                    }
                    break;
            }


            Console.WriteLine($"Easter trip to {destination} : {expenses:f2} leva.");
        }
    }
}

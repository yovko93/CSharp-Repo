using System;

namespace _2.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string show = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int seats = row * columns;
            double income = 0.0;

            switch (show)
            {
                case "Premiere":
                    income = seats * 12;
                    break;
                case "Normal":
                    income = seats * 7.50;
                    break;
                case "Discount":
                    income = seats * 5.0;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}

using System;

namespace _04.ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int kids = 0;
            int adults = 0;
            int toys = 0;
            int sweaters = 0;

            while (command != "Christmas")
            {
                int age = int.Parse(command);
                if (age <= 16)
                {
                    kids++;
                    toys += 5;
                }
                else
                {
                    adults++;
                    sweaters += 15;
                }
                command = Console.ReadLine();

            }
            if (command == "Christmas")
            {
                Console.WriteLine($"Number of adults: {adults}");
                Console.WriteLine($"Number of kids: {kids}");
                Console.WriteLine($"Money for toys: {toys}");
                Console.WriteLine($"Money for sweaters: {sweaters}");
            }
        }
    }
}

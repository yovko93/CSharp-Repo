using System;

namespace _04.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());

            int eggsInStock = eggs;
            int soldEggs = 0;
            string command = Console.ReadLine();

            while (command != "Close")
            {
                int purchaseEggs = int.Parse(Console.ReadLine());
                if (command == "Buy")
                {
                    if (purchaseEggs > eggsInStock)
                    {
                        Console.WriteLine($"Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsInStock}.");
                        break;
                    }
                    soldEggs += purchaseEggs;
                    eggsInStock -= purchaseEggs;
                }
                else if (command == "Fill")
                {
                    eggsInStock += purchaseEggs;
                }

                command = Console.ReadLine();
            }
            if (command == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{soldEggs} eggs sold.");
            }
        }
    }
}

using System;

namespace _04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucher = int.Parse(Console.ReadLine());

            int counterTickets = 0;
            int counterPurchase = 0;
            int purchase = 0;
            int money = vaucher;
            string command = string.Empty;
            command = Console.ReadLine();

            while (command != "End") //&& money > 0
            {
                if (command.Length > 8)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        purchase += command[i];
                    }
                    money -= purchase;
                    if (money >= 0)
                    {
                        counterTickets++;
                    }
                    purchase = 0;
                }
                else if (command.Length <= 8)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        purchase += command[i];
                    }
                    money -= purchase;
                    if (money >= 0)
                    {
                        counterPurchase++;
                    }
                    purchase = 0;
                }
                if (money <= 0)
                {
                    break;
                }
                command = Console.ReadLine();

            }
            Console.WriteLine($"{counterTickets}");
            Console.WriteLine($"{counterPurchase}");
        }
    }
}

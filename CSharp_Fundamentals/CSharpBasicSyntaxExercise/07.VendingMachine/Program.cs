using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalCoins = 0;
            double change = 0;
            double nuts = 2.0;
            double water = 0.7;
            double crisps = 1.5;
            double soda = 0.8;
            double coke = 1.0;

            while (command != "Start")
            {
                double coins = double.Parse(command);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                command = Console.ReadLine();
            }
            while (command != "End")
            {
                command = Console.ReadLine();
                // switch работи също
                if (command == "Nuts")
                {
                    if (totalCoins >= nuts)
                    {
                        Console.WriteLine($"Purchased nuts");
                        totalCoins -= nuts;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Water")
                {
                    if (totalCoins >= water)
                    {
                        Console.WriteLine($"Purchased water");
                        totalCoins -= water;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Crisps")
                {
                    if (totalCoins >= crisps)
                    {
                        Console.WriteLine($"Purchased crisps");
                        totalCoins -= crisps;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Soda")
                {
                    if (totalCoins >= soda)
                    {
                        Console.WriteLine($"Purchased soda");
                        totalCoins -= soda;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Coke")
                {
                    if (totalCoins >= coke)
                    {
                        Console.WriteLine($"Purchased coke");
                        totalCoins -= coke;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "End")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                change = totalCoins;
            }
            Console.WriteLine($"Change: {change:f2}");
        }
    }
}

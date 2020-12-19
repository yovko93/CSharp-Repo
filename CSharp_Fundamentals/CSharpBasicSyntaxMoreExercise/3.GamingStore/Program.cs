using System;

namespace _3.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double OutFall4 = 39.99;
            double CSOG = 15.99;
            double ZplinterZell = 19.99;
            double Honored2 = 59.99;
            double RoverWatch = 29.99;
            double RoverWatchOriginsEdition = 39.99;
            string command = Console.ReadLine();
            double totalSpent = 0;
            //double remaining = currentBalance;


            while (command != "Game Time")
            {
                if (command == "OutFall 4")
                {
                    if (currentBalance >= OutFall4)
                    {
                        currentBalance -= OutFall4;
                        totalSpent += OutFall4;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "CS: OG")
                {
                    if (currentBalance >= CSOG)
                    {
                        currentBalance -= CSOG;
                        totalSpent += CSOG;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (currentBalance >= ZplinterZell)
                    {
                        currentBalance -= ZplinterZell;
                        totalSpent += ZplinterZell;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Honored 2")
                {
                    if (currentBalance >= Honored2)
                    {
                        currentBalance -= Honored2;
                        totalSpent += Honored2;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (currentBalance >= RoverWatch)
                    {
                        currentBalance -= RoverWatch;
                        totalSpent += RoverWatch;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (currentBalance >= RoverWatchOriginsEdition)
                    {
                        currentBalance -= RoverWatchOriginsEdition;
                        totalSpent += RoverWatchOriginsEdition;
                        Console.WriteLine($"Bought {command}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                command = Console.ReadLine();

            }
            if (currentBalance == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}

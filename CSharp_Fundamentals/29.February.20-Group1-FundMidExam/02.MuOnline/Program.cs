using System;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                 .Split('|')
                 .ToArray();

            int health = 100;
            int bitcoins = 0;
            int countBestRoom = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] commandAndNum = rooms[i].Split();

                string command = commandAndNum[0];
                int num = int.Parse(commandAndNum[1]);
                countBestRoom++;

                if (command == "potion")
                {
                    int currentHealth = health + num;

                    if (currentHealth > 100)
                    {
                        currentHealth = 100;
                        int currentAmount = 100 - health;
                        Console.WriteLine($"You healed for {currentAmount} hp.");
                        Console.WriteLine($"Current health: {currentHealth} hp.");
                        health = 100;
                    }
                    else
                    {
                        health += num;
                        Console.WriteLine($"You healed for {num} hp.");
                        Console.WriteLine($"Current health: {currentHealth} hp.");
                    }
                }
                else if (command == "chest")
                {
                    bitcoins += num;
                    Console.WriteLine($"You found {num} bitcoins.");
                }
                else
                {
                    health -= num;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {countBestRoom}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                }

                if (i == rooms.Length - 1)
                {
                    Console.WriteLine("You've made it!");
                    Console.WriteLine($"Bitcoins: {bitcoins}");
                    Console.WriteLine($"Health: {health}");
                }
            }

        }
    }
}

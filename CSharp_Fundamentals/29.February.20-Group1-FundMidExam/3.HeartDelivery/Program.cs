using System;
using System.Linq;

namespace _3.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            int lastPositionIndex = 0;

            while (command != "Love!")
            {
                string[] jumpCommand = command.Split();
                int length = int.Parse(jumpCommand[1]);

                int houseIndex = lastPositionIndex + length;

                if (houseIndex > neighborhood.Length - 1)
                {
                    houseIndex = 0;
                }
                if (neighborhood[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                }
                else
                {
                    neighborhood[houseIndex] -= 2;
                    if (neighborhood[houseIndex] == 0)
                    {
                        Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                    }
                }
                lastPositionIndex = houseIndex;

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {lastPositionIndex}.");

            int count = 0;
            for (int i = 0; i < neighborhood.Length; i++)
            {
                if (neighborhood[i] == 0)
                {
                    count++;
                }
            }
            if (count == neighborhood.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int houseCount = neighborhood.Length - count;
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}

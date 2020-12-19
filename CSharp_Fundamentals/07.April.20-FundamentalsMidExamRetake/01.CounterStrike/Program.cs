using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            short energy = short.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            short winsCount = 0;

            while (command != "End of battle")
            {
                short distance = short.Parse(command);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount} won battles and {energy} energy");
                    break;
                }

                energy -= distance;
                winsCount++;
                if (winsCount % 3 == 0)
                {
                    energy += winsCount;
                }

                command = Console.ReadLine();
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {winsCount}. Energy left: {energy}");
            }
        }
    }
}

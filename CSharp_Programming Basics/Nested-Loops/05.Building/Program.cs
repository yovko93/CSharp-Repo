using System;

namespace _05.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int floor = floors; floor >= 1; floor--)
            {
                if (floor == floors)
                {
                    for (int room = 0; room < roomsPerFloor; room++)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                }
                else if (floor % 2 == 0)
                {
                    for (int room = 0; room < roomsPerFloor; room++)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                }
                else if (floor % 2 != 0)
                {
                    for (int room = 0; room < roomsPerFloor; room++)
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

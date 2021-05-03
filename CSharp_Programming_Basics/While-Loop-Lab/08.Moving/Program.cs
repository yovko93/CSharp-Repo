using System;

namespace _08.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * length * height;
            int boxes = 0;
            string command = Console.ReadLine();

            while (command != "Done")
            {
                int moreBoxes = int.Parse(command);
                boxes += moreBoxes;
                if (boxes >= freeSpace)
                {
                    int neededSpace = boxes - freeSpace;
                    Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();

            }
            if (command == "Done")
            {
                int availableSpace = freeSpace - boxes;
                Console.WriteLine($"{availableSpace} Cubic meters left.");
            }
        }
    }
}

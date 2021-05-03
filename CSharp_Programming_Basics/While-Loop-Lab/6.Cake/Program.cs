using System;

namespace _6.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakeSize = width * length;
            int pieces = 0;

            while (pieces <= cakeSize)
            {
                string command = Console.ReadLine();
                if (command == "STOP")
                {
                    int diff = cakeSize - pieces;
                    Console.WriteLine($"{diff} pieces are left.");
                    break;
                }
                pieces += int.Parse(command);

            }
            if (pieces > cakeSize)
            {
                int diff = pieces - cakeSize;
                Console.WriteLine($"No more cake left! You need {diff} pieces more.");
            }
        }
    }
}

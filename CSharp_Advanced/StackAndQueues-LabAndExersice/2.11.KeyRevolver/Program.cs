using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int SizeOfGunBarrel = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullets);
            Queue<int> queueOfLocks = new Queue<int>(locks);

            int counterOfGunBarrel = 0;
            int usedBullets = 0;

            while (stackOfBullets.Any() && queueOfLocks.Any())
            {
                int currentBullet = stackOfBullets.Pop();
                int currentLock = queueOfLocks.Peek();
                counterOfGunBarrel++;
                usedBullets++;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counterOfGunBarrel == SizeOfGunBarrel && stackOfBullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    counterOfGunBarrel = 0;
                }
            }

            if (queueOfLocks.Count == 0)
            {
                int bulletLeft = bullets.Length - usedBullets;
                int moneyEarned = valueOfIntelligence - ((bullets.Length - bulletLeft) * priceForBullet);

                Console.WriteLine($"{bulletLeft} bullets left. Earned ${moneyEarned}");
            }
            else if (stackOfBullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}

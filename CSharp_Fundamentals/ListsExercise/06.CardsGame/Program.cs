using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int big = Math.Min(firstHand.Count, secondHand.Count);
            
            while (big != 0)
            {
                int biggerCard = firstHand[0].CompareTo(secondHand[0]);
                if (biggerCard == 1)
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.Add(secondHand[0]);
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else if (biggerCard == 0)
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else
                {
                    secondHand.Add(secondHand[0]);
                    secondHand.Add(firstHand[0]);
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }
                big = Math.Min(firstHand.Count, secondHand.Count);
            }

            int firstPlayer = firstHand.Sum();
            int secondPlayer = secondHand.Sum();

            int winner = firstPlayer.CompareTo(secondPlayer);
            if (winner == 1)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer}");
            }
            else if (winner == -1)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer}");
            }
        }
    }
}

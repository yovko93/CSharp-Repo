using System;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int totalPoints = 301;
            int shots = 0;
            int missed = 0;
            string command = Console.ReadLine();

            while (command != "Retire")
            {
                int points = int.Parse(Console.ReadLine());
                if (command == "Single")
                {
                    if (totalPoints >= points)
                    {
                        totalPoints -= points;
                        shots++;
                    }
                    else
                    {
                        missed++;
                    }
                }
                else if (command == "Double")
                {
                    points *= 2;
                    if (totalPoints >= points)
                    {
                        totalPoints -= points;
                        shots++;
                    }
                    else
                    {
                        missed++;
                    }
                }
                else if (command == "Triple")
                {
                    points *= 3;
                    if (totalPoints >= points)
                    {
                        totalPoints -= points;
                        shots++;
                    }
                    else
                    {
                        missed++;
                    }
                }
                if (totalPoints == 0)
                {
                    Console.WriteLine($"{name} won the leg with {shots} shots.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Retire")
            {
                Console.WriteLine($"{name} retired after {missed} unsuccessful shots.");
            }
        }
    }
}

using System;

namespace _04.GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            int goalsFor = 0;
            int goalsAgainst = 0;
            int points = 0;
            int play = 0;

            while (play < games)
            {
                int scoreGoals = int.Parse(Console.ReadLine());
                int receivedGoals = int.Parse(Console.ReadLine());
                play++;
                if (scoreGoals > receivedGoals)
                {
                    goalsFor += scoreGoals;
                    goalsAgainst += receivedGoals;
                    points += 3;
                }
                else if (scoreGoals == receivedGoals)
                {
                    goalsFor += scoreGoals;
                    goalsAgainst += receivedGoals;
                    points += 1;
                }
                else if (receivedGoals > scoreGoals)
                {
                    goalsFor += scoreGoals;
                    goalsAgainst += receivedGoals;
                    points += 0;
                }
            }
            int diff = goalsFor - goalsAgainst;
            if (goalsFor >= goalsAgainst)
            {

                Console.WriteLine($"{team} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {diff}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {diff}.");
            }

        }
    }
}

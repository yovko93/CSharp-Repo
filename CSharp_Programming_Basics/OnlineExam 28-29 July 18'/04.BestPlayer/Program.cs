using System;

namespace _04.BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int goals = int.Parse(Console.ReadLine());

            int moreGoals = int.MinValue;
            string player = string.Empty;

            while (name != "END")
            {
                if (goals > moreGoals)
                {
                    player = name;
                    moreGoals = goals;
                }
                if (goals >= 10)
                {
                    Console.WriteLine($"{name} is the best player!");
                    Console.WriteLine($"He has scored {goals} goals and made a hat-trick !!!");
                    break;
                }
                name = Console.ReadLine();
                if (name == "END")
                {
                    Console.WriteLine($"{player} is the best player!");
                    if (moreGoals >= 3)
                    {
                        Console.WriteLine($"He has scored {moreGoals} goals and made a hat-trick !!!");
                    }
                    else
                    {
                        Console.WriteLine($"He has scored {moreGoals} goals.");
                    }
                    break;
                }
                goals = int.Parse(Console.ReadLine());
            }
        }
    }
}

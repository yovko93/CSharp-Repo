using System;

namespace _1.ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double experianceToGain = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());

            double gainExp = 0;

            for (int i = 1; i <= countOfBattles; i++)
            {
                double experiancePerBattle = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    double moreExp = experiancePerBattle * 0.15;
                    experiancePerBattle += moreExp;
                }
                if (i % 5 == 0)
                {
                    double lessExp = experiancePerBattle * 0.1;
                    experiancePerBattle -= lessExp;
                }

                gainExp += experiancePerBattle;
                if (gainExp >= experianceToGain)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                    break;
                }
            }
            if (gainExp < experianceToGain)
            {
                double neededExp = experianceToGain - gainExp;
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExp:f2} more needed.");
            }
        }
    }
}

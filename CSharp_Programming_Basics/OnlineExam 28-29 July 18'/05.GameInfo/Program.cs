using System;

namespace _05.GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            int counter = 0;
            double minutes = 0.0;
            int penalties = 0;
            int extraTime = 0;

            while (counter < games)
            {
                int time = int.Parse(Console.ReadLine());
                counter++;
                minutes += time;
                if (time > 120)
                {
                    penalties++;
                }
                else if (time > 90)
                {
                    extraTime++;
                }
            }
            if (counter == games)
            {
                Console.WriteLine($"{team} has played {minutes} minutes. Average minutes per game: {(minutes / games):f2}");
                Console.WriteLine($"Games with penalties: {penalties}");
                Console.WriteLine($"Games with additional time: {extraTime}" );
            }
        }
    }
}

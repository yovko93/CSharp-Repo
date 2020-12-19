using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            byte YexhaustionFactor = byte.Parse(Console.ReadLine());

            double halfPower = 1.0 * power / 2;
            int countTargets = 0;

            while (power >= distance)
            {
                power -= distance;
                countTargets++;
                if (power == halfPower && YexhaustionFactor != 0)
                {
                    power /= YexhaustionFactor;
                }
            }
            Console.WriteLine(power);
            Console.WriteLine(countTargets);
        }
    }
}

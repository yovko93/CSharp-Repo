using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberSnowballs = byte.Parse(Console.ReadLine());

            BigInteger snowballValue = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;
            for (int i = 0; i < numberSnowballs; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                byte currentSnowballQuality = byte.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);
                if (value > snowballValue)
                {
                    snowballValue = value;
                    snow = currentSnowballSnow;
                    time = currentSnowballTime;
                    quality = currentSnowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {snowballValue} ({quality})");
        }
    }
}

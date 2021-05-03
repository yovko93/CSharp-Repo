using System;

namespace _1.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeFirst = int.Parse(Console.ReadLine());
            int timeSecond = int.Parse(Console.ReadLine());
            int timeThird = int.Parse(Console.ReadLine());

            int timeSum = timeFirst + timeSecond + timeThird;
            int minutes = timeSum / 60;
            int seconds = timeSum % 60;

            Console.WriteLine($"{minutes}:{seconds:00}");
        }
    }
}

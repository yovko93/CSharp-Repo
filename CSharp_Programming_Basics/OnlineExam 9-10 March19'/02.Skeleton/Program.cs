using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double furrowLong = double.Parse(Console.ReadLine());
            double secFor100m = double.Parse(Console.ReadLine());

            double totalSeconds = minutes * 60 + seconds;
            double timeSlow = furrowLong / 120;
            double totalTimeSlow = timeSlow * 2.5;
            double marinTime = (furrowLong / 100) * secFor100m - totalTimeSlow;

            if (marinTime <= totalSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {(marinTime-totalSeconds):f3} second slower.");
            }
        }
    }
}

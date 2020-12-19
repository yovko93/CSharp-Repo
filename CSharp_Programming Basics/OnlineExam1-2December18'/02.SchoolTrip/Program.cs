using System;

namespace _02.SchoolTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysAni = int.Parse(Console.ReadLine());
            int foodKG = int.Parse(Console.ReadLine());
            double firstDog = double.Parse(Console.ReadLine());
            double secondDog = double.Parse(Console.ReadLine());
            double thirdDog = double.Parse(Console.ReadLine());

            double foodNeeded = daysAni * (firstDog + secondDog + thirdDog);
            double diff = Math.Abs(foodKG - foodNeeded);

            if (foodKG >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");
            }
        }
    }
}

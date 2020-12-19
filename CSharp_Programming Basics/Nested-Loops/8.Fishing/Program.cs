using System;

namespace _8.Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int fishesPerDay = int.Parse(Console.ReadLine());

            int countFishes = 0;
            double money = 0.0;
            double totalMoney = 0.0;

            string nameFish = string.Empty;
            double weight = 0.0;

            while ((nameFish = Console.ReadLine()) != "Stop")
            {
                weight = double.Parse(Console.ReadLine());
                countFishes++;
                for (int i = 0; i < nameFish.Length; i++)
                {
                    money += nameFish[i]/weight;
                }
                // money = money / weight;
                if (countFishes % 3 == 0)
                {
                    totalMoney += money;
                }
                else
                {
                    totalMoney -= money;
                }
                money = 0.0;
                if (countFishes >= fishesPerDay)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
            }
            if (totalMoney >= 0)
            {
                Console.WriteLine($"Lyubo's profit from {countFishes} fishes is {totalMoney:f2} leva.");

            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(totalMoney):f2} leva today.");
            }
        }
    }
}

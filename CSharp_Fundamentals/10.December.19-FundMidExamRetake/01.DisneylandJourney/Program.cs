using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal journeyCost = decimal.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            int currentMonths = 1;
            decimal savingsPerMonth = journeyCost * 0.25m;
            decimal moneyCollected = 0;

            while (currentMonths <= months)
            {

                if ((currentMonths % 2 != 0) && currentMonths != 1)
                {
                    decimal moneyForClothes = moneyCollected * 0.16m;
                    moneyCollected -= moneyForClothes;
                }
                if (currentMonths % 4 == 0)
                {
                    decimal bonus = moneyCollected * 0.25m;
                    moneyCollected += bonus;
                }

                moneyCollected += savingsPerMonth;

                currentMonths++;

            }

            if (moneyCollected >= journeyCost)
            {
                decimal souvenirsMoney = moneyCollected - journeyCost;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {souvenirsMoney:f2}lv. for souvenirs.");
            }
            else if (moneyCollected < journeyCost)
            {
                decimal moneyNeeded = journeyCost - moneyCollected;
                Console.WriteLine($"Sorry. You need {moneyNeeded:f2}lv. more.");
            }
        }
    }
}

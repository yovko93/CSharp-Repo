using System;

namespace _4.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlowers = Console.ReadLine();
            int countOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;

            if (typeOfFlowers == "Roses")
            {
                price = countOfFlowers * 5;
                if (countOfFlowers > 80)
                {
                    price -= price * 0.1;
                }

            }
            else if (typeOfFlowers == "Dahlias")
            {
                price = countOfFlowers * 3.8;
                if (countOfFlowers > 90)
                {
                    price -= price * 0.15;
                }
            }
            else if (typeOfFlowers == "Tulips")
            {
                price = countOfFlowers * 2.8;
                if (countOfFlowers > 80)
                {
                    price -= price * 0.15;
                }
            }
            else if (typeOfFlowers == "Narcissus")
            {
                price = countOfFlowers * 3;
                if (countOfFlowers < 120)
                {
                    price += price * 0.15;
                }
            }
            else if (typeOfFlowers == "Gladiolus")
            {
                price = countOfFlowers * 2.5;
                if (countOfFlowers < 80)
                {
                    price += price * 0.2;
                }
            }

            //double diffPrice = Math.Abs(budget - price);

            if (budget >= price)
            {
                double leftSum = budget - price;
                Console.WriteLine($"Hey, you have a great garden with {countOfFlowers} {typeOfFlowers} and {leftSum:f2} leva left.");
            }
            else
            {
                double neededSum = price - budget;
                Console.WriteLine($"Not enough money, you need {neededSum:f2} leva more.");
            }
        }
    }
}

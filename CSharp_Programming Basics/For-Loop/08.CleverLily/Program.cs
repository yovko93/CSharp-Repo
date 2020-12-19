using System;

namespace _08.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int countToys = 0;
            int money = 0;
            double totalMoney = 0.0;
            int brotherMoney = 0;

            for(int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += 10;
                    totalMoney += money;
                    brotherMoney++;
                }
                else
                {
                    countToys++;
                    //totalMoney += countToys;
                }
                
            }
            double saveMoney = totalMoney + (toyPrice * countToys) - brotherMoney;
            double diff = Math.Abs(saveMoney - washerPrice);

            if (saveMoney >= washerPrice)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}

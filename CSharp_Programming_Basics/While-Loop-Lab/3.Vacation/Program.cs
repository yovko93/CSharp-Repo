using System;

namespace _3.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int days = 0;
            int spendDays = 0;
            double savedMoney = currentMoney;

            while (savedMoney < tripMoney && spendDays < 5)
            {
                string command = Console.ReadLine();
                double transaction = double.Parse(Console.ReadLine());
                days++;
                
                if (command == "save")
                {
                    savedMoney += transaction;
                    spendDays = 0;
                    if (savedMoney >= tripMoney)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                }
                else if (command == "spend")
                {
                    savedMoney -= transaction;
                    spendDays++;
                    if (savedMoney < 0)
                    {
                        savedMoney = 0;
                    }
                    if (spendDays >= 5)
                    {
                        Console.WriteLine("You can't save the money." + Environment.NewLine + days);
                        //Console.WriteLine($"{days}");
                    }
                }

            }
        }
    }
}

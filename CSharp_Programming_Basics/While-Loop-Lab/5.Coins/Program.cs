using System;

namespace _5.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            int countCoins = 0;
            change = Math.Floor(change * 100);

            while (change > 0)
            {
                if (change >= 200)
                {
                    change = change - 200;
                    countCoins++;
                }
                else if (change >= 100)
                {
                    change = change - 100;
                    countCoins++;
                }
                else if (change >= 50)
                {
                    change = change - 50;
                    countCoins++;
                }
                else if (change >= 20)
                {
                    change = change - 20;
                    countCoins++;
                }
                else if (change >= 10)
                {
                    change = change - 10;
                    countCoins++;
                }
                else if (change >= 5)
                {
                    change = change - 5;
                    countCoins++;
                }
                else if (change >= 2)
                {
                    change = change - 2;
                    countCoins++;
                }
                else if (change >= 1)
                {
                    change = change - 1;
                    countCoins++;
                }
            }
            Console.WriteLine(countCoins);
            // if (num % 10 == 9)
            // {
            //     monets++;
            //     monets++;
            //     monets++;
            //     num -= 9;
            // }
            // else if (num % 10 == 8)
            // {
            //     monets++;
            //     monets++;
            //     monets++;
            //     num -= 8;
            // }
            // else if (num % 10 == 7)
            // {
            //     monets++;
            //     monets++;
            //     num -= 7;
            // }
            // else if (num % 10 == 6)
            // {
            //     monets++;
            //     monets++;
            //     num -= 6;
            // }
            // else if (num % 10 == 5)
            // {
            //     monets++;
            //     num -= 5;
            // }
            // else if (num % 10 == 4)
            // {
            //     monets++;
            //     monets++;
            //     num -= 4;
            // }
            // else if (num % 10 == 3)
            // {
            //     monets++;
            //     monets++;
            //     num -= 3;
            // }
            // else if (num % 10 == 2)
            // {
            //     monets++;
            //     num -= 2;
            // }
            // else if (num % 10 == 1)
            // {
            //     monets++;
            //     num -= 1;
            // }
            // if (num % 100 == 90)
            // {
            //     monets++;
            //     monets++;
            //     monets++;
            //     num -= 90;
            // }
            // else if (num % 100 == 80)
            // {
            //     monets++;
            //     monets++;
            //     monets++;
            //     num -= 80;
            // }
            // else if (num % 100 == 70)
            // {
            //     monets++;
            //     monets++;
            //     num -= 70;
            // }
            // else if (num % 100 == 60)
            // {
            //     monets++;
            //     monets++;
            //     num -= 60;
            // }
            // else if (num % 100 == 50)
            // {
            //     monets++;
            //     num -= 50;
            // }
            // else if (num % 100 == 40)
            // {
            //     monets++;
            //     monets++;
            //     num -= 40;
            // }
            // else if (num % 100 == 30)
            // {
            //     monets++;
            //     monets++;
            //     num -= 30;
            // }
            // else if (num % 100 == 20)
            // {
            //     monets++;
            //     num -= 20;
            // }
            // else if (num % 100 == 10)
            // {
            //     monets++;
            //     num -= 10;
            // }
            // if (num % 500 == 0 && num > 0)
            // {
            //     monets++;
            //     monets++;
            //     monets++;
            // }
            //else if (num % 400 == 0 && num > 0)
            // {
            //     monets++;
            //     monets++;
            // }
            // else if (num % 300 == 0 && num > 0)
            // {
            //     monets++;
            //     monets++;
            // }
            // else if (num % 200 == 0 && num > 0)
            // {
            //     monets++;
            // }
            // else if (num % 100 == 0 && num > 0)
            // {
            //     monets++;
            // }
            // else if (num % 10 == 0 && num > 0)
            // {
            //     monets++;
            // }
            // Console.WriteLine(monets);
            // break;
        
    
        }
    }
}

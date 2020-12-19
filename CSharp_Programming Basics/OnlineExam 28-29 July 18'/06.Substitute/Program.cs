using System;

namespace _06.Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int firstDigit = k; firstDigit < 9; firstDigit++)
            {
                for (int secondDigit = 9; secondDigit >= l; secondDigit--)
                {
                    for (int firstNum = m; firstNum < 9; firstNum++)
                    {
                        for (int secondNum = 9; secondNum >= n; secondNum--)
                        {
                            if (firstDigit % 2 == 0 && firstNum % 2 == 0 && secondDigit % 2 != 0 && secondNum % 2 != 0)
                            {
                                if (firstDigit == firstNum && secondDigit == secondNum)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{firstDigit}{secondDigit} - {firstNum}{secondNum}");
                                    counter++;
                                }
                                if (counter == 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

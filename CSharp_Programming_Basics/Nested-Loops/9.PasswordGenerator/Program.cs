using System;

namespace _9.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            
            for (int firstSymbol = 1; firstSymbol <= n; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol <= n; secondSymbol++)
                {
                    for (int thirdSymbol = 'a'; thirdSymbol < 'a' + l; thirdSymbol++)
                    {
                        for (int fourthSymbol = 'a'; fourthSymbol < 'a' + l; fourthSymbol++)
                        {
                            for (int fifthSymbol = 1; fifthSymbol <= n; fifthSymbol++)
                            {
                                if (fifthSymbol > firstSymbol && fifthSymbol > secondSymbol)
                                {
                                    Console.Write($"{firstSymbol}{secondSymbol}{(char)thirdSymbol}{(char)fourthSymbol}{fifthSymbol} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

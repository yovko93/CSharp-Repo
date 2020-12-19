using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalheadsetPrice = headsetPrice * (lostGamesCount / 2);
            double totalMousePrice = mousePrice * (lostGamesCount / 3);
            double totalKeyboardPrice = keyboardPrice * (lostGamesCount / 6);
            double totalDisplayPrice = displayPrice * (lostGamesCount / 12);

            double expenses = totalheadsetPrice + totalMousePrice + totalKeyboardPrice + totalDisplayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}

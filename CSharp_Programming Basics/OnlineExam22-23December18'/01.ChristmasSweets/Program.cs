using System;

namespace _01.ChristmasSweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double baklavaPrice = double.Parse(Console.ReadLine());
            double muffinPrice = double.Parse(Console.ReadLine());
            double kilogramStolen = double.Parse(Console.ReadLine());
            double kilogramBonbon = double.Parse(Console.ReadLine());
            int kilogramBiscuit = int.Parse(Console.ReadLine());

            double stolenPrice = kilogramStolen * (baklavaPrice + (baklavaPrice * 0.6));
            double bonbonPrice = kilogramBonbon * (muffinPrice + (muffinPrice * 0.8));
            double biscuitPrice = kilogramBiscuit * 7.5;

            double totalPrice = stolenPrice + bonbonPrice + biscuitPrice;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

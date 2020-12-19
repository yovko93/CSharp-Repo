using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double yuan = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double bitcoinToLev = bitcoin * 1168.00 ; //1168lv
            double yuanToUSD = yuan * 0.15;
            double yuanToLev = yuanToUSD * 1.76; //1.32lv
            double levToEuro = (yuanToLev + bitcoinToLev) / 1.95;
            double euroComission = levToEuro * (comission / 100.0);
            double euro = levToEuro - euroComission;

            Console.WriteLine($"{euro:f2}");
        }
    }
}

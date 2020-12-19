using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyOwn = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            double moneyNeeded = 0;

            double totalLightsabersPrice = lightsabersPrice * Math.Ceiling(studentCount*1.1);
            double totalRobesPrice = robesPrice * studentCount;
            double totalBeltsPrice = beltsPrice * studentCount;
            double freeBelts = studentCount / 6;

            moneyNeeded = totalLightsabersPrice + totalRobesPrice + (totalBeltsPrice - (freeBelts*beltsPrice));

            if (moneyOwn >= moneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                double diff = moneyNeeded - moneyOwn;
                Console.WriteLine($"Ivan Cho will need {diff:f2}lv more.");
            }
        }
    }
}

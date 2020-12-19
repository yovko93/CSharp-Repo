using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double aquariumLength = double.Parse(Console.ReadLine());
            double aquariumWidth = double.Parse(Console.ReadLine());
            double aquariumHeight = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double aquariumCapacity = aquariumLength * aquariumWidth * aquariumHeight;
            double totalLiters = aquariumCapacity * 0.001;
            double calculatedPercent = percent * 0.01;
            double litersNeeded = totalLiters * (1 - calculatedPercent);

            Console.WriteLine("{0:F3}", litersNeeded);

            //int length = int.Parse(Console.ReadLine());
            //int width = int.Parse(Console.ReadLine());
            //int height = int.Parse(Console.ReadLine());
            //double percent = double.Parse(Console.ReadLine());

            //int area = length * width * height;
            //double liters = area * 0.001;
            //double finalliters = liters - (percent / 100 * liters);

            //Console.WriteLine($"{ finalliters:f3}");


            //int length = int.Parse(Console.ReadLine());
            //int width = int.Parse(Console.ReadLine());
            //int height = int.Parse(Console.ReadLine());
            //double percent = double.Parse(Console.ReadLine());

            //double capacity = length * width * height;
            //double totalLittres = capacity * 0.001;
            //percent /= 100;
            ////double littresNeeded = totalLittres - (totalLittres * percent);
            //double littresNeeded = totalLittres * (1 - percent);
            //Console.WriteLine($"{littresNeeded:f3}");
        }
    }
}

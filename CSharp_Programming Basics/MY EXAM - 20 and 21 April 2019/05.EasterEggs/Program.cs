using System;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int paintedEggs = int.Parse(Console.ReadLine());

            int countRed = 0;
            int countOrange = 0;
            int countBlue = 0;
            int countGreen = 0;
            int maxEggs = int.MinValue;
            string color = string.Empty;

            for (int i = 1; i <= paintedEggs; i++)
            {
                string text = Console.ReadLine();
                if (text == "red")
                {
                    countRed++;
                }
                else if (text == "orange")
                {
                    countOrange++;
                }
                else if (text == "blue")
                {
                    countBlue++;
                }
                else if (text == "green")
                {
                    countGreen++;
                }

            }
            if (countRed > maxEggs)
            {
                maxEggs = countRed;
                color = "red";
            }
            if (countOrange > maxEggs)
            {
                maxEggs = countOrange;
                color = "orange";
            }
            if (countBlue > maxEggs)
            {
                maxEggs = countBlue;
                color = "blue";
            }
            if (countGreen > maxEggs)
            {
                maxEggs = countGreen;
                color = "green";
            }

            Console.WriteLine($"Red eggs: {countRed}");
            Console.WriteLine($"Orange eggs: {countOrange}");
            Console.WriteLine($"Blue eggs: {countBlue}");
            Console.WriteLine($"Green eggs: {countGreen}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {color}");
        }
    }
}

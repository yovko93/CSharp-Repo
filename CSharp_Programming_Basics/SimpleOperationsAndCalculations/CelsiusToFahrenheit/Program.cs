using System;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 9) / 5 + 32;

            Console.WriteLine("{0:F2}", fahrenheit);
            //Console.WriteLine($"{fahrenheit:f2}");

            //double rounded = Math.Round(fahrenheit, 2);
            //Console.WriteLine(rounded);
        }
    }
}

using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();

            double percent = 0;
            double grade = 0;

            if (country == "Russia")
            {
                if (instrument == "ribbon")
                {
                    grade = 9.1 + 9.4;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "hoop")
                {
                    grade = 9.3 + 9.8;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "rope")
                {
                    grade = 9.6 + 9.0;
                    percent = (20 - grade) / 20 * 100;
                }
            }
            else if (country == "Bulgaria")
            {
                if (instrument == "ribbon")
                {
                    grade = 9.6 + 9.4;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "hoop")
                {
                    grade = 9.550 + 9.75;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "rope")
                {
                    grade = 9.5 + 9.4;
                    percent = (20 - grade) / 20 * 100;
                }
            }
            else if (country == "Italy")
            {
                if (instrument == "ribbon")
                {
                    grade = 9.2 + 9.5;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "hoop")
                {
                    grade = 9.450 + 9.350;
                    percent = (20 - grade) / 20 * 100;
                }
                else if (instrument == "rope")
                {
                    grade = 9.7 + 9.15;
                    percent = (20 - grade) / 20 * 100;
                }
            }
            Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}

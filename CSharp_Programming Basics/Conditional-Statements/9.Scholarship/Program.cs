using System;

namespace _9.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double earning = double.Parse(Console.ReadLine());
            double result = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            if(earning < minSalary && result >= 4.5)
            {
                double scholarship = result * 25;
                double socialSchoralship = minSalary * 0.35;

                if (result >= 5.50 && scholarship >= socialSchoralship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialSchoralship)} BGN");
                }              
            }
            else if (result >= 5.50)
            {
                double scholarship = result * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
            }
            else
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
        }
    }
}

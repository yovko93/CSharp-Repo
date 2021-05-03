using System;

namespace _09.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();
            double area = 0.0;

            if (typeOfFigure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (typeOfFigure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (typeOfFigure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
            }
            else if (typeOfFigure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                area = (a * h) / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}

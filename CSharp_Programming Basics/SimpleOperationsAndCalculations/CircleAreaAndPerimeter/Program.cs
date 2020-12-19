using System;

namespace CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;

            Console.WriteLine("{0:F2}", area);
            Console.WriteLine("{0:F2}", perimeter);

            //Console.WriteLine("{0:f2}\n{1:f2}", area, perimeter);
        }
    }
}

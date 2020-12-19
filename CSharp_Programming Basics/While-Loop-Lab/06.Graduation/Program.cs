using System;

namespace _06.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double averageGrade = 0.0;
            int count = 0;

            while (count < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    averageGrade += grade;
                    count++;
                }
                //if (grade < 4)
                //{
                //    averageGrade -= grade;
                //    count--;
                //}
                //averageGrade += grade;
                //count++;

            }

            averageGrade = averageGrade / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
        }
    }
}

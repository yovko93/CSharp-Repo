using System;

namespace _07.Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double averageGrade = 0.0;
            int excluded = 0;
            bool isExcluded = false;


            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.0)
                {
                    excluded++;
                }
                else if (grade >= 4.00)
                {
                    averageGrade += grade;
                    counter++;
                }
                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }
            if (isExcluded == false)
            {
                averageGrade = averageGrade / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }

        }
    }
}

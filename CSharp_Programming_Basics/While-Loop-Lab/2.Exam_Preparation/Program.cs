using System;

namespace _2.Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPoorResults = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int countPoorGrades = 0;
            double averageGrade = 0.0;
            int counterCommand = 0;
            string nameProblem = string.Empty;

            while (command != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    countPoorGrades++;
                    if (countPoorGrades == countPoorResults)
                    {
                        Console.WriteLine($"You need a break, {countPoorResults} poor grades.");
                        break;
                    }
                }
                averageGrade += grade;
                counterCommand++;
                nameProblem = command;
                command = Console.ReadLine();
            }
            if (command == "Enough")
            {

                Console.WriteLine($"Average score: {(averageGrade/counterCommand):f2}");
                Console.WriteLine($"Number of problems: {counterCommand}");
                Console.WriteLine($"Last problem: {nameProblem}");
            }
        }
    }
}

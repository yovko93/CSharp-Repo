using System;

namespace _7.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());

            string presentation = string.Empty;
            double averageGrade = 0.0;
            double sumAverage = 0.0;
            double count = 0;

            string text = Console.ReadLine();

            while (text != "Finish")
            {
                for (int i = 1; i <= juryCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    averageGrade += grade;
                    count++;
                }
                sumAverage += averageGrade;
                presentation = text;
                Console.WriteLine($"{presentation} - {(averageGrade/juryCount):f2}.");
                averageGrade = 0.0;
                text = Console.ReadLine();
            }

            if (text == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {(sumAverage/count):f2}.");
            }
        }
    }
}

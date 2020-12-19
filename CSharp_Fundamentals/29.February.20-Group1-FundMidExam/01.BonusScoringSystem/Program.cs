using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            int studentAttendances = 0;
            double maxBonus = 0.0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = (double)(attendances) / lecturesCount * (5 + additionalBonus);
                
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    studentAttendances = attendances;
                }

            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendances} lectures.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecords = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentRecords.ContainsKey(name))
                {
                    studentRecords.Add(name, new List<decimal>());
                }

                studentRecords[name].Add(grade);
            }

            foreach (var student in studentRecords)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(x => x.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}

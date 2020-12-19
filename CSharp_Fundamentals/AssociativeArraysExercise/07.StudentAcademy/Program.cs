using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentGrades.ContainsKey(name))
                {
                    studentGrades[name].Add(grade);
                }
                else
                {
                    studentGrades.Add(name, new List<double>());
                    studentGrades[name].Add(grade);
                }
            }

            var averageResults = new Dictionary<string, double>();
            
            foreach (var pair in studentGrades)
            {
                averageResults.Add(pair.Key, pair.Value.Average());
            }

            foreach (var pairs in averageResults.Where(x => x.Value >= 4.5).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pairs.Key} -> {pairs.Value:f2}");
            }
        }
    }
}

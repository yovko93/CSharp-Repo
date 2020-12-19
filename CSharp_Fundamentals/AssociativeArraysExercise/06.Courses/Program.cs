using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();
            
            string command = Console.ReadLine();
            while (command != "end")
            {
                var info = command.Split(" : ").ToArray();
                string course = info[0];
                string student = info[1];

                if (courseInfo.ContainsKey(course))
                {
                    courseInfo[course].Add(student);
                }
                else
                {
                    courseInfo.Add(course, new List<string>());
                    courseInfo[course].Add(student);
                }

                command = Console.ReadLine();
            }

            
            foreach (var pair in courseInfo.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.Count);
                foreach (var student in pair.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}

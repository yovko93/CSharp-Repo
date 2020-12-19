using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string firstName = input[0];
                string secondName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student(firstName, secondName, grade);

                students.Add(student);
            }

            List<Student> orderedStudents = students
                .OrderBy(x => x.Grade)
                .ToList();
            orderedStudents.Reverse();

            Console.WriteLine(string.Join(Environment.NewLine, orderedStudents));

            //Console.WriteLine(string.Join(Environment.NewLine, students.OrderByDescending(x => x.Grade)));
        }

        class Student
        {
            public string FirstName { get; set; }

            public string SecondName { get; set; }

            public double Grade { get; set; }

            public Student(string firstName, string secondName, double grade)
            {
                this.FirstName = firstName;
                this.SecondName = secondName;
                this.Grade = grade;
            }

            public override string ToString()
            {
                return $"{FirstName} {SecondName}: {Grade:f2}";
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _06.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] information = command.Split();

                string firstName = information[0];
                string lastName = information[1];
                int age = int.Parse(information[2]);
                string homeTown = information[3];

                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student student = GetStundent(students, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown,
                    };
                    
                    students.Add(student);
                }
                command = Console.ReadLine();
            }

            string nameOfCity = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == nameOfCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string HomeTown { get; set; }
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (firstName == student.FirstName && lastName == student.LastName)
                {
                    return true;
                }
            }

            return false;
        }

        static Student GetStundent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (firstName == student.FirstName && lastName == student.LastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }
}

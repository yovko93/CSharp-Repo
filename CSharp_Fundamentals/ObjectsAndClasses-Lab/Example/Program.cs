using System;
using System.Collections.Generic;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student pesho = new Student();
            //pesho.name = "Pesho";
            //pesho.age = 15;
            //pesho.skills = new string[] {"nishto", "i", "polovina" };

            //Student gosho = new Student();
            //gosho.name = "Gosho";
            //gosho.age = 15;
            //gosho.skills = new string[0];

            //PrintStudent(pesho);
            //PrintStudent(gosho);

            
            Console.WriteLine("How many student int softuni???");
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                students.Add(ReadStudent());

            }
            for (int i = 0; i < n; i++)
            {
                PrintStudent(students[i]);
            }
        }

        static Student ReadStudent()
        {
            Student newStudent = new Student();
            Console.WriteLine("Enter name: ");
            newStudent.name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            newStudent.age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter skills: ");
            newStudent.skills = Console.ReadLine().Split();

            return newStudent;
        }

        static void PrintStudent(Student student)
        {
            Console.WriteLine($"Student name -> {student.name} -> student age -> {student.age} -> skills -> {string.Join(", ", student.skills)}");
        }
    }
}

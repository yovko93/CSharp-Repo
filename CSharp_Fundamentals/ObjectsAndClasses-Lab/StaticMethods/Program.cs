using System;

namespace StaticMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student()
            //{
            //    Name = "Pesho",
            //    Age = 15,
            //    Skills = new string[0]
            //};

            //Console.WriteLine(student.Age);
            //student.AgeStudent();
            //student.AgeStudent();
            //student.AgeStudent();
            //Console.WriteLine(student.Age);

            Student peshoStudent = Student.ReadStudent();
            Student gosho = Student.ReadStudent();

            peshoStudent.AgeStudent();
            gosho.AgeStudent();
            Student.PrintStudent(peshoStudent);
            
        }
    }
}

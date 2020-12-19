using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    class Classroom
    {
        private List<Student> students;


        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }


        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
               return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName
            && x.LastName == lastName);

            students.Remove(student);

            if (student != null)
            {
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> currentStudents = students.Where(x => x.Subject == subject).ToList();

            if (currentStudents.Any())
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in currentStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().Trim();

            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {

            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            return student;
        }

    }

}

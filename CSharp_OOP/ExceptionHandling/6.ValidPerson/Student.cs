using System;
using System.Collections.Generic;
using System.Text;

namespace _6.ValidPerson
{
    public class Student
    {
        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}

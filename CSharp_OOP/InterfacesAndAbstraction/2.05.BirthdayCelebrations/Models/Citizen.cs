using _2._05.BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._05.BirthdayCelebrations.Models
{
    public class Citizen : IId, IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}

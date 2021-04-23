using _2._04.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._04.BorderControl.Models
{
    public class Citizen : IId
    {
       
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}

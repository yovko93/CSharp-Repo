using _2._09.ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._09.ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}

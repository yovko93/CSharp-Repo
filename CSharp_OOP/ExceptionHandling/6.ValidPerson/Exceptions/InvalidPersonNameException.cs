
using System;

namespace _6.ValidPerson.Exceptions
{
    public class InvalidPersonNameException : Exception
    {

        public InvalidPersonNameException()
        {

        }

        public InvalidPersonNameException(string name, string message)
            : base(message)
        {
            this.Name = name;
        }


        public string Name { get; set; }

    }
}

using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Person ivan = new Person("Ivan", "Ivanov", 19, "ivan@softuni.bg");
            Person ani = new Person("Ani", "Ivanova", 22, "ani@softuni.bg");
            Person sanya = new Person();

            Console.WriteLine(ani.ToString());
            Console.WriteLine(ivan.ToString());
            Console.WriteLine(sanya.ToString());
        }

        class Person
        {
            // 1. Properties

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string Email { get; set; }

            // 2. Constructors

            public Person(string firstName, string lastName, int age, string email)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
                this.Email = email;
            }

            public Person()
            {

            }

            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            // 3. Methods

            public override string ToString()
            {
                return $"{FirstName}, {LastName}, Age = {Age}, E-mail = {Email}";
            }

        }
    }
}

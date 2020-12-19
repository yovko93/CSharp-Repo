using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] elements = input.Split().ToArray();
                string name = elements[0];
                string id = elements[1];
                int age = int.Parse(elements[2]);

                Person person = new Person(name, id, age);

                people.Add(person);
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people.OrderBy(x => x.Age)));
        }

        class Person
        {
            public string Name { get; set; }

            public string ID { get; set; }

            public int Age { get; set; }

            public Person(string name, string id, int age)
            {
                this.Name = name;
                this.ID = id;
                this.Age = age;
            }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Person person1 = new Person();

            //Person person2 = new Person(12);

            //Person person3 = new Person("Stoyan", 24);

            ////-----------------------------------
            ///
            //Family family = new Family();

            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    string[] info = Console.ReadLine().Split().ToArray();

            //    string name = info[0];
            //    int age = int.Parse(info[1]);

            //    Person member = new Person(name, age);

            //    family.AddMember(member);

            //}

            //Person person = family.GetOldestMember();

            //Console.WriteLine($"{person.Name} {person.Age}");
            ////------------------------------------
            ///

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();

                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name ,age);

                family.AddMember(person);
            }

            List<Person> people = family.GetPeople();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

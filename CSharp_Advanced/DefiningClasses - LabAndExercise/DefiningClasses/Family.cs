using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }


        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
            => People.OrderByDescending(x => x.Age).First();

        //int maxAge = int.MinValue;
        //Person oldestPerson = null;

        //foreach (var person in People)
        //{
        //    var currentAge = person.Age;

        //    if (currentAge > maxAge)
        //    {
        //        maxAge = currentAge;
        //        oldestPerson = person;
        //    }
        //}

        //return oldestPerson;

        public List<Person> GetPeople()
        {
            var people = People.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();
       
            return people;
        }
    }

}

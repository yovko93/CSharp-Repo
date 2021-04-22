using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //---------------------------
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                decimal salary = decimal.Parse(data[3]);

                Person person = new Person(firstName, lastName, age, salary);

                people.Add(person);

            }
            //Console.WriteLine(person);

            // people.ForEach(p => Console.WriteLine(p.ToString()));

            Team team = new Team("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}

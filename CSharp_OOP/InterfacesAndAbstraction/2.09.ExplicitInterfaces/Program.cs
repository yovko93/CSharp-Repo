using _2._09.ExplicitInterfaces.Contracts;
using _2._09.ExplicitInterfaces.Models;
using System;
using System.Linq;

namespace _2._09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Both variants work

            PrintNamesAsDifferentInterfaces();
            //PrintNamesWithTypeCasting();
        }

        private static void PrintNamesAsDifferentInterfaces()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                IPerson person = new Citizen(name[0]);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name[0]);
                Console.WriteLine(resident.GetName());

                name = Console.ReadLine().Split();
            }
        }

        private static void PrintNamesWithTypeCasting()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                var human = new Citizen(name[0]);
                Console.WriteLine(((IPerson)human).GetName());
                Console.WriteLine(((IResident)human).GetName());

                name = Console.ReadLine().Split();
            }
        }
    }
}

﻿using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _1._05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person()
                {
                    Name = info[0],
                    Age = int.Parse(info[1])
                };
            }

            string condition = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, ageToFilter);
            Action<Person> printerDelegate = GetPrinter(format);

            foreach (var person in people)
            {
                if (conditionDelegate(person))
                {
                    printerDelegate(person);
                }
            }

        }

        static Action<Person> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => 
                    {
                        Console.WriteLine($"{p.Name}"); 
                    };

                case "age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Age}");
                    };

                case "name age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name} - {p.Age}");
                    };
                default:
                    return null;
            }
        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return p => p.Age < age;
                case "older": return p => p.Age >= age;
                default:
                    return null;
            }
        }
    }
}

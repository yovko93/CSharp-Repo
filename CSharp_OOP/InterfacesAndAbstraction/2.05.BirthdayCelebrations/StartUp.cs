using _2._05.BirthdayCelebrations.Contracts;
using _2._05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._05.BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command;

            List<IBirthdate> birthdates = new List<IBirthdate>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split().ToArray();

                string type = data[0];

                switch (type)
                {
                    case "Citizen":
                        string name = data[1];
                        int age = int.Parse(data[2]);
                        string id = data[3];
                        string birthdate = data[4];

                        IBirthdate citizen = new Citizen(name, age, id, birthdate);
                        birthdates.Add(citizen);
                        break;

                    case "Pet":
                        string petName = data[1];
                        string petBirthdate = data[2];

                        IBirthdate pet = new Pet(petName, petBirthdate);
                        birthdates.Add(pet);
                        break;

                    case "Robot":
                        string model = data[1];
                        string robotId = data[2];

                        Robot robot = new Robot(model, robotId);
                        break;
                }
            }

            int year = int.Parse(Console.ReadLine());

            var specificBirthdates = birthdates.FindAll(x => x.Birthdate.EndsWith(year.ToString()));

            if (specificBirthdates.Any())
            {
                foreach (var birthdate in specificBirthdates)
                {
                    Console.WriteLine(birthdate.Birthdate);
                }
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}

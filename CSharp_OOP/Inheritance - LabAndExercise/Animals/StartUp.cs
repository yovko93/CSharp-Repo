using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animals> animals = new List<Animals>();

            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];

                    switch (input)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                input = Console.ReadLine();
            }


            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

            //foreach (var animal in animals)
            //{
            //    Console.WriteLine(animal.GetType().Name);
            //    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            //    animal.ProduceSound();
            //}
        }
    }
}

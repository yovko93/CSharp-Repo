﻿using System;

namespace ClassProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog pesho = new Dog("Pesho", 51);
            pesho.PrintDog();
            Dog sharo = new Dog("Sharo");
            sharo.PrintDog();
            Dog strayDog = new Dog();
            strayDog.PrintDog();


            //sharo.Name = "Pesho";
            // sharo.Age = 51;
            //Console.WriteLine(pesho.Name);
            //Console.WriteLine(sharo.Age);
        }

        public class Dog
        {
            public Dog(string name, int age)
            {
                Console.WriteLine("In the dog constructor");
                this.Name = name;
                this.Age = age;
            }

            public Dog(string name)
            {
                Console.WriteLine("In the name only");
                this.Name = name;
            }

            public Dog()
            {
                Console.WriteLine("In the empty");

            }

            public string Name { get; set; }

            public int Age { get; set; }

            public void PrintDog()
            {
                Console.WriteLine($"Name -> {Name} Age -> {Age}");
            }

            //private int age;
            //public int Age
            //{
            //    get
            //    {
            //        Console.WriteLine("Getting age");
            //        return age;
            //    }
            //    set
            //    {
            //        Console.WriteLine("Setting age");
            //        this.Age = value;
            //    }
            //}
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using _2._03.ShoppingSpree.Models;

namespace _2._03.ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }


        public void Run()
        {
            try
            {
                this.ParsePeopleInput();

                this.ParseProductsInput();

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = this.people
                        .FirstOrDefault(p => p.Name == personName);
                    Product product = this.products
                        .FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

        private void ParsePeopleInput()
        {
            string[] peopleAndMoney = Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            foreach (var personAndMoney in peopleAndMoney)
            {
                string[] personInfo = personAndMoney
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = personInfo[0];
                decimal personMoney = decimal.Parse(personInfo[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }

        private void ParseProductsInput()
        {
            string[] productArgs = Console.ReadLine()
           .Split(";", StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

            foreach (var productStr in productArgs)
            {
                string[] productArg = productStr
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string productName = productArg[0];
                decimal productPrice = decimal.Parse(productArg[1]);

                Product product = new Product(productName, productPrice);

                this.products.Add(product);

            }
        }
    }
}

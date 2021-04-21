using System;

namespace Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            Drink drink = new Drink("Coke");

            Sandwich sandwich = new Sandwich("bb", "cc", "vv", "mm", drink);
            Sandwich sandwich2 = sandwich.ShallowCopy();
            Sandwich sandwich3 = sandwich.DeepCopy();

            Console.WriteLine("Original object: " + sandwich);
            Console.WriteLine("Shallow Copy object: " + sandwich2);
            Console.WriteLine("Deep Copy object: " + sandwich3);
            Console.WriteLine();

            sandwich.Bread = "123";
            sandwich.Cheese = "123";
            sandwich.Meat = "123";
            sandwich.Veggies = "123";
            sandwich.Drink.Name = "Test";

            Console.WriteLine("Original object: " + sandwich);
            Console.WriteLine("Shallow Copy object: " + sandwich2);
            Console.WriteLine("Deep Copy object: " + sandwich3);
        }
    }
}

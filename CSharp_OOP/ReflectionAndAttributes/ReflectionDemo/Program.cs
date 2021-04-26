using System;
using System.Linq;
using System.Reflection;
using ReflectionDemo.Animals;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type personType = typeof(Person);

            var getType = GetType("ReflectionDemo.Person");

            // не може да стигне до Cat защото трябва да се въведе пътя 
            // using ReflectionDemo.Animals
            var typeExample = typeof(Cat);
            Console.WriteLine(getType.Namespace);


            //==========================
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Person");

            var instance = Activator.CreateInstance(type);

            //============================


        }

        static Type GetType(string name)
        {
            var type = Type.GetType(name);

            return type;
        }
    }
}

using System;

using _2._04.WildFarm.Common;
using _2._04.WildFarm.Models.Animals;

namespace _2._04.WildFarm.Factories
{
    public class AnimalFactory
    {

        public Animal CreateAnimal(string type, string name, double weight, string[] args)
        {
            //if (args.Length == 1)
            //{
            //    //bool isBird = double.TryParse(args[0], out double wingSize);
            //    if (isBird)
            //    {
            //        // hen and owl
            //    }
            //    else
            //    {
            //        //Mouse and dog
            //        string livingRegion = args[0];
            //    }
            //}
            //else if (args.Length == 2)
            //{
            //    // cat and tiger
            //}

            Animal animal;

            if (type == "Hen" || type == "Owl")
            {
                double wingSize = double.Parse(args[0]);
                if (type == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidType);
                }
            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = args[0];

                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidType);
                }
            }
            else if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = args[0];
                string breed = args[1];

                if (type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidType);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidType);
            }

            return animal;
        }
    }
}

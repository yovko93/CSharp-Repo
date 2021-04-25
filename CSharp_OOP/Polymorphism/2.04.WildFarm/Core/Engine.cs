using System;
using System.Linq;
using System.Collections.Generic;

using _2._04.WildFarm.Factories;
using _2._04.WildFarm.Models.Foods;
using _2._04.WildFarm.Models.Animals;
using _2._04.WildFarm.Core.Contracts;

namespace _2._04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new HashSet<Animal>();

            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                // Animal
                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                string[] args = animalInfo
                     .Skip(3)
                     .ToArray();

                Animal animal = null;

                try
                {
                    animal = this.animalFactory.CreateAnimal(animalType, name, weight, args);

                    Console.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                //Food
                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);

                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    animal?.Feed(food);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

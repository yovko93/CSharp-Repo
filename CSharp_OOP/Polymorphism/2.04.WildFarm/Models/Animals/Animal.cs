using System;
using System.Collections.Generic;

using _2._04.WildFarm.Models.Foods.Contracts;
using _2._04.WildFarm.Models.Animals.Contracts;

namespace _2._04.WildFarm.Models.Animals
{
    public abstract class Animal 
        : IAnimal, IFeedable, ISoundProducable
    {
        private const string INV_FOOD_TYPE = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
           this.Name = name;
           this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        //This will hold the types of preferred foods
        // typeof(Fruit), typeof(Vegetable)
        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(String.Format(INV_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;

            
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

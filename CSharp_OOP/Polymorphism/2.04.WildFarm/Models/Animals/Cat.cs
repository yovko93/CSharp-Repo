using System;
using System.Collections.Generic;

using _2._04.WildFarm.Models.Foods;

namespace _2._04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.3;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() {typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

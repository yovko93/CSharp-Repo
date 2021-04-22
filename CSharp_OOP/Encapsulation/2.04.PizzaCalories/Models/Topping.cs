using _2._04.PizzaCalories.Common;
using System;

namespace _2._04.PizzaCalories.Models
{
    public class Topping
    {
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType 
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if ((value.ToLower()) != "meat" 
                    && (value.ToLower()) != "veggies"
                    && (value.ToLower()) != "cheese"
                    && (value.ToLower()) != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public int Weight 
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }


        public double ToppingCalories()
        {
            double modifier = this.Weight * GlobalConstants.BASE_CALORIES_PER_GRAM;

            switch (this.ToppingType.ToLower())
            {
                case "meat": modifier *= 1.2;
                    break;
                case "veggies": modifier *= 0.8;
                    break;
                case "cheese": modifier *= 1.1;
                    break;
                case "sauce": modifier *= 0.9;
                    break;
            }

            return modifier;
        }
    }
}

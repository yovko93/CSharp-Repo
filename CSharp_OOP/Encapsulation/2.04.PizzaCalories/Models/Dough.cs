using _2._04.PizzaCalories.Common;
using System;

namespace _2._04.PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if ((value.ToLower() != "white") && (value.ToLower()) != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.INVALID_TYPE_EXC_MSG);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique 
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if ((value.ToLower() != "crispy") && (value.ToLower() != "chewy") && (value.ToLower() != "homemade"))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_TYPE_EXC_MSG);
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalConstants.INVALID_WEIGHT_EXC_MSG);
                }

                this.weight = value;
            }
        }


        public double DoughCalories()
        {
            double modifier = GlobalConstants.BASE_CALORIES_PER_GRAM * this.Weight;

            switch (this.FlourType.ToLower())
            {
                case "white": modifier *= 1.5;
                    break;
                case "wholegrain":  modifier *= 1.0;
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9;
                    break;
                case "chewy": modifier *= 1.1;
                    break;
                case "homemade": modifier *= 1.0;
                    break;
            }

            return modifier;
        }
    }
}

using _2._06.FoodShortage.Contracts;

namespace _2._06.FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public Rebel()
        {
            this.Food = 0;
        }

        public Rebel(string name, int age, string group)
            :this()
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}

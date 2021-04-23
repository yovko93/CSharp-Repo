using _2._06.FoodShortage.Contracts;

namespace _2._06.FoodShortage.Models
{
    public class Citizen : IId, IBirthdate, IBuyer
    {
        public Citizen()
        {
            this.Food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this()
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

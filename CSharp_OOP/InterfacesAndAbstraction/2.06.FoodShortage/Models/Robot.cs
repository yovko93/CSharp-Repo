
using _2._06.FoodShortage.Contracts;

namespace _2._06.FoodShortage.Models
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}

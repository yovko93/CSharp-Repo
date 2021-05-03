using System;

namespace _3.Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = string.Empty;
            string shoes = string.Empty;

            if (timeOfDay == "Morning")
            {
                if(degree >= 10 && degree <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (degree > 18 && degree <=24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degree >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (timeOfDay == "Afternoon")
            {
                if (degree >= 10 && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degree > 18 && degree <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (degree >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else if (timeOfDay == "Evening")
            {
                if (degree >= 10 && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degree > 18 && degree <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degree >= 25)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");
        }
    }
}

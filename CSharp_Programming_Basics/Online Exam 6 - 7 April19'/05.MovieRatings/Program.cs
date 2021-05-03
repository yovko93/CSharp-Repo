using System;

namespace _05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int movie = int.Parse(Console.ReadLine());

            double highestRating = double.MinValue;
            double lowestRating = double.MaxValue;
            double averageRating = 0.0;
            string nameLowest = string.Empty;
            string nameHighest = string.Empty;

            for (int i = 1; i <= movie; i++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating > highestRating)
                {
                    highestRating = rating;
                    nameHighest = name;
                }
                if (rating < lowestRating)
                {
                    lowestRating = rating;
                    nameLowest = name;
                }
                averageRating += rating;
            }
            Console.WriteLine($"{nameHighest} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{nameLowest} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {averageRating/movie:f1}");
        }
    }
}

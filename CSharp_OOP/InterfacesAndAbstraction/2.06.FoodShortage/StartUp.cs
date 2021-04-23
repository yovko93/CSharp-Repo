using System;
using System.Linq;

using System.Collections.Generic;
using _2._06.FoodShortage.Models;

namespace _2._06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string name = data[0];
                int age = int.Parse(data[1]);

                if (data.Length == 4)
                {
                    string id = data[2];
                    string birthdate = data[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    citizens.Add(citizen);

                }
                else if (data.Length == 3)
                {
                    string group = data[2];

                    Rebel rebel = new Rebel(name, age, group);

                    rebels.Add(rebel);
                }

            }

            int food = 0;

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                if (citizens.Any(x => x.Name == name))
                {
                    Citizen citizen = citizens.First(x => x.Name == name);
                    citizen.BuyFood();
                    food += 10;
                }
                else if (rebels.Any(x => x.Name == name))
                {
                    Rebel rebel = rebels.First(x => x.Name == name);
                    rebel.BuyFood();
                    food += 5;
                }
            }

            Console.WriteLine(food);
        }
    }
}

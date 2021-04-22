using System;
using System.Linq;
using System.Collections.Generic;

using _2._04.PizzaCalories.Models;

namespace _2._04.PizzaCalories.Core
{
    public class Engine
    {
        
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split().ToArray();
                string pizzaName = pizzaInfo[1];

                string[] firstIngredient = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string doughIngredient = firstIngredient[0];

                Dough dough = new Dough(firstIngredient[1],
                                        firstIngredient[2],
                                        int.Parse(firstIngredient[3]));

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = null;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] secondIngredient = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var toppingIngredient = secondIngredient[0];

                    Topping topping = new Topping(secondIngredient[1], int.Parse(secondIngredient[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

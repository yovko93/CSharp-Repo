﻿using System;
using System.Linq;
using System.Reflection;

using _2._04.WildFarm.Common;
using _2._04.WildFarm.Models.Foods;

namespace _2._04.WildFarm.Factories
{
    public class FoodFactory
    {

        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == strType);

            if (type == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidType);
            }

            object[] ctorParams = new object[] { quantity };

            Food food = (Food)Activator.CreateInstance(type, ctorParams);

            return food;
        }
    }
}

﻿using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());

            double sum = (dogs * 2.5) + (animals * 4);
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}

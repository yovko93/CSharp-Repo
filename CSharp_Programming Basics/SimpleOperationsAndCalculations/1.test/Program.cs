﻿using System;

namespace _1.test
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;

            Console.WriteLine(Math.Round((deg), 2));

        }

    }
}

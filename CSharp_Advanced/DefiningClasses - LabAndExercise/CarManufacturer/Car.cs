using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires): this(make, model, year, fuelQuantity, fuelConsumption)
        //{
        //    this.Engine = engine;
        //    this.Tire = tires;
        //}

        //public Car()
        //{
        //    Make = "VW";
        //    this.Model = "Golf";
        //    this.Year = 2025;
        //    FuelQuantity = 200;
        //    FuelConsumption = 10;
        //}

        //public Car(string make, string model, int year): this()
        //{
        //    this.Make = make;
        //    this.Model = model;
        //    this.Year = year;
        //}

        //public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption): this(make, model, year)
        //{
        //    this.FuelQuantity = fuelQuantity;
        //    this.FuelConsumption = fuelConsumption;
        //}

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tire { get; set; }


    }

}

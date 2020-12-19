using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
   public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            TravelledDistance = 0;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance{ get; set; }


        public void Drive(double amountOfKm)
        {
            double neededLitters = (FuelConsumptionPerKilometer * amountOfKm);
            bool canMove = FuelAmount - neededLitters >= 0;

            if (canMove)
            {
                FuelAmount -= neededLitters;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

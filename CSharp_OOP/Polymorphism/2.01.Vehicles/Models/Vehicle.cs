using System;

using _2._01.Vehicles.Common;
using _2._01.Vehicles.Models.Contracts;

namespace _2._01.Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, distance);
        }

        public virtual void Refuel(double litters)
        {
            if (litters < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegFuel);
            }

            this.FuelQuantity += litters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

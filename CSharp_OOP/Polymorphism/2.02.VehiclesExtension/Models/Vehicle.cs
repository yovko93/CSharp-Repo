using System;

using _2._02.VehiclesExtension.Common;
using _2._02.VehiclesExtension.Models.Contracts;

namespace _2._02.VehiclesExtension.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const int DefaultFuelQuantity = 0;
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {

            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DefaultFuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set
            {
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                this.tankCapacity = value;
            }
        }

        public bool IsEmpty { get; set; }


        public virtual string Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, distance);

        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegFuel);
            }

            if ((litters + this.FuelQuantity) > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CannotFitFuel, litters));
            }

            this.FuelQuantity += litters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

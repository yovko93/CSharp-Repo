using _2._02.VehiclesExtension.Common;
using System;

namespace _2._02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.6;
        private const double REFUEL_SUCC_COEFF = 0.95;


        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption =>
            base.FuelConsumption + FUEL_CONSUMPTION_INCR;

        public override void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegFuel);
            }

            if ((litters + this.FuelQuantity) > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CannotFitFuel, litters));
            }

            base.Refuel(litters * REFUEL_SUCC_COEFF);
        }
    }
}

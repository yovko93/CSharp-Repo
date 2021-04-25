namespace _2._02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private double fuelConsumptionIncrease = 1.4;
        private double defaultFuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            // втори начин без долните 2 реда

            this.defaultFuelConsumption = fuelConsumption;
            this.fuelConsumptionIncrease += fuelConsumption;
        }

        //public override double FuelConsumption =>
        //    base.FuelConsumption + FUEL_CONSUMPTION_INCR;

        public override double FuelConsumption =>
            base.FuelConsumption;

        public override string Drive(double distance)
        {
            if (!this.IsEmpty)
            {
                this.FuelConsumption = this.fuelConsumptionIncrease;
            }
            else
            {
                this.FuelConsumption = this.defaultFuelConsumption;
            }

            return base.Drive(distance);
        }

        //public string DriveEmpty(double distance)
        //{
        //    this.FuelConsumption -= fuelConsumptionIncrease;

        //    return base.Drive(distance);
        //}

    }
}

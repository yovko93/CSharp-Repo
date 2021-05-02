namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CubicCentimetersDefaultValue = 3000;
        private const int MinHorsePowerDefaultValue = 250;
        private const int MaxHorsePowerDefaultValue = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersDefaultValue, MinHorsePowerDefaultValue, MaxHorsePowerDefaultValue)
        {
        }


    }
}

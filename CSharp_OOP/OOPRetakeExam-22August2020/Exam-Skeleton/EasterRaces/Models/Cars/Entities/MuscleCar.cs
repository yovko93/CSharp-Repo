namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CubicCentimetersDefaultValue = 5000;
        private const int MinHorsePowerDefaultValue = 400;
        private const int MaxHorsePowerDefaultValue = 600;


        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersDefaultValue, MinHorsePowerDefaultValue, MaxHorsePowerDefaultValue)
        {
        }
      

    }
}

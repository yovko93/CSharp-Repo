namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DamagePointsDefaultValue = 120;
        private const int HealthPointsDefaultValue = 5;

        public TrapCard(string name) 
            : base(name, DamagePointsDefaultValue, HealthPointsDefaultValue)
        {
        }
    }
}

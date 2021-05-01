namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DamagePointsDefaultValue = 5;
        private const int HealthPointsDefaultValue = 80;

        public MagicCard(string name) 
            : base(name, DamagePointsDefaultValue, HealthPointsDefaultValue)
        {
        }
    }
}

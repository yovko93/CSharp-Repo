using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        //private readonly ICardRepository cardRepository = new CardRepository();
        private const int InitialHealthPoints = 50;

        public Beginner(string username) 
            : base(new CardRepository(), username, InitialHealthPoints)
        {
        }
    }
}

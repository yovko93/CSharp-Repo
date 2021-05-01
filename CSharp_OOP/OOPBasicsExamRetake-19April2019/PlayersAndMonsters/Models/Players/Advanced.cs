using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        //private readonly ICardRepository cardRepository = new CardRepository();

        private const int InitialHealthPoints = 250;


        public Advanced(string username) 
            : base(new CardRepository(), username, InitialHealthPoints)
        {
        }
    }
}

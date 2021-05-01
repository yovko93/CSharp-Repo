using System;

using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckIfThereIsADeadPlayer(attackPlayer, enemyPlayer);

            CheckIfPlayerIsBeginner(attackPlayer, enemyPlayer);

            GetBonusFromDeck(attackPlayer, enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                foreach (var attackCard in attackPlayer.CardRepository.Cards)
                {
                    enemyPlayer.TakeDamage(attackCard.DamagePoints);
                }

                if (enemyPlayer.IsDead)
                {
                    continue;
                }

                foreach (var enemyCard in enemyPlayer.CardRepository.Cards)
                {
                    attackPlayer.TakeDamage(enemyCard.DamagePoints);
                }
            }

        }


        //        while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
        //            {
        //                foreach (var terro in terrorists)
        //                {
        //                    if (!terro.IsAlive)
        //                    {
        //                        continue;
        //                    }

        //                    foreach (var counterTerro in counterTerrorists)
        //                    {
        //                        if (!counterTerro.IsAlive)
        //                        {
        //                            continue;
        //                        }

        //                        counterTerro.TakeDamage(terro.Gun.Fire());
        //                    }

        //}


        private void CheckIfThereIsADeadPlayer(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
        }

        private void CheckIfPlayerIsBeginner(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void GetBonusFromDeck(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += card.HealthPoints;
            }
        }
    }
}

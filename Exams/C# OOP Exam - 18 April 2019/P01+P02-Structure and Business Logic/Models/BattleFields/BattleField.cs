using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(h => h.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(h => h.HealthPoints);
            while (attackPlayer.IsDead==false && enemyPlayer.IsDead==false)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints));
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints));
                if (attackPlayer.IsDead)
                {
                    break;
                }

                
            }

        }
    }
}

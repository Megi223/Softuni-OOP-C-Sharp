using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int DEF_BEGINNER_HEALTH = 50;
        public Beginner(ICardRepository cardRepository, string username) : base(cardRepository, username, DEF_BEGINNER_HEALTH)
        {
        }
    }
}

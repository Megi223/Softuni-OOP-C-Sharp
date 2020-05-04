using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DEF_DAMAGE_POINTS = 5;
        private const int DEF_HEALTH_POINTS = 80;
        public MagicCard(string name) : base(name, DEF_DAMAGE_POINTS, DEF_HEALTH_POINTS)
        {
        }
    }
}

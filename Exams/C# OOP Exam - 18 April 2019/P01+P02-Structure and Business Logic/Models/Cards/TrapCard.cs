using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DEF_DAMAGE_POINTS = 120;
        private const int DEF_HEALTH_POINTS = 5;

        public TrapCard(string name) : base(name, DEF_DAMAGE_POINTS, DEF_HEALTH_POINTS)
        {
        }
    }
}

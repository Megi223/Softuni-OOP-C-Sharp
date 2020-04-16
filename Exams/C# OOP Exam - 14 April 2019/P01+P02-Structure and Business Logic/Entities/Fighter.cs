using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine
    {
        private const double FighterInitialHealthPoints= 200;
        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints+50, defensePoints-25, FighterInitialHealthPoints)
        {
            this.AggressiveMode = true;
        }
        public bool AggressiveMode  { get; private set; }
        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            string onOff = "";
            if (this.AggressiveMode == true)
            {
                onOff = "ON";
            }
            else if(this.AggressiveMode==false)
            {
                onOff = "OFF";
            }
            return base.ToString() + Environment.NewLine +
                $" *Aggressive: {onOff}";
        }
    }
}

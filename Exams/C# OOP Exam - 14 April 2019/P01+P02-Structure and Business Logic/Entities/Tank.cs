using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine
    {
        private const double InitialTankHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints-40, defensePoints+30, InitialTankHealthPoints)
        {
            this.DefenseMode = true;
        }
        public bool DefenseMode  { get; private set; }
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            string onOff = "";
            if (this.DefenseMode == true)
            {
                onOff = "ON";
            }
            else if (this.DefenseMode == false)
            {
                onOff = "OFF";
            }
            return base.ToString() + Environment.NewLine +
                $" *Defense: {onOff}";
        }
    }
}

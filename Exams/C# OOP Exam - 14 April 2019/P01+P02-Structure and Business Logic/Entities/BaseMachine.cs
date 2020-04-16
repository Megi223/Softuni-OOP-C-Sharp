using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidMachineName);
                }
                this.name = value;
            }
        }

        public IPilot Pilot 
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.PilonCannotBeNull);
                }
                this.pilot = value;
            }
        }
        public double HealthPoints 
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    this.healthPoints = 0;
                }
                this.healthPoints = value;
            }
        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.TargetCannotBeNull);
            }
            double difference = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= difference;
            //TODO: Check if this should be in the property
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            this.Targets.Add(target.Name);

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}") //TODO:Check if this return correct type
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}");
            string nextLine = "";
            if (Targets.Count == 0)
            {
                nextLine = "None";
            }
            else
            {
                nextLine = String.Join(", ", this.Targets);
            }
            sb.AppendLine($" *Targets: {nextLine}");
            return sb.ToString().TrimEnd();
        }
    }
}

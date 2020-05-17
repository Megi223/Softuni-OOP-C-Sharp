using System;
using System.Collections.Generic;
using System.Text;
using P05FootballTeamGenerator.Common;

namespace P05FootballTeamGenerator.Models
{
    public class Player
    {       
        private string name;

        public Player(string name,Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(GlobalConstants.InvalidNameExceptionMessage);
                }
                this.name = value;
            }
        }
        public Stats Stats { get; }

        public double OverallSkillLevel => Stats.CalculateAverage;

    }
}

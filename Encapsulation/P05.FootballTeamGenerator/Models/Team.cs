using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P05FootballTeamGenerator.Common;

namespace P05FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return this.name;
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

        public int Rating 
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                return (int)(Math.Round(this.players.Sum(p => p.OverallSkillLevel) / this.players.Count));
            }
        }  
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                throw new ArgumentException(String.Format(GlobalConstants.RemovingMissingPlayerExceptionMessage, name, this.Name));
            }
            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}

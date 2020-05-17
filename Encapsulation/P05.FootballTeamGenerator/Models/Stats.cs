using System;
using System.Collections.Generic;
using System.Text;
using P05FootballTeamGenerator.Common;

namespace P05FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance,int sprint,int dribble,int passing,int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidStatExceptionMessage,nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMessage, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMessage, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMessage, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < MIN_STAT || value > MAX_STAT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMessage, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }
        public double CalculateAverage => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.00;

    }
}

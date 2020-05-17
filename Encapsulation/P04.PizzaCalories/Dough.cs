using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Dough
    {
        private const double WHITE = 1.5;
        private const double WHOLEGRAIN = 1.0;
        private const double CRISPY = 0.9;
        private const double CHEWY = 1.1;
        private const double HOMEMADE = 1.0;
        private const int MINWEIGHT = 0;
        private const int MAXWEIGHT = 200;
        private const int DEFAULTCALORIESPERGRAM = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType,string bakingTechnique,int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if(value.ToLower()!= "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
               
                this.flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if(value.ToLower()!= "crispy" && value.ToLower()!= "chewy" && value.ToLower()!= "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value<MINWEIGHT || value>MAXWEIGHT)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }
                this.weight = value;
            }
        }
        private double DetermineFlourTypeModifier()
        {
            double flourTypeModifier = 0;
            if (this.FlourType.ToLower() == "white")
            {
                flourTypeModifier = WHITE;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                flourTypeModifier = WHOLEGRAIN;
            }
            return flourTypeModifier;
        }

        private double DetermineBakingTechniqueModifier()
        {
            double bakingTechniqueModifier = 0;

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueModifier = CRISPY;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueModifier = CHEWY;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                bakingTechniqueModifier = HOMEMADE;
            }
            return bakingTechniqueModifier;
        }

        public string CalculateDoughCalories()
        {
            double flourTypeModifier = DetermineFlourTypeModifier();
            double bakingTechniqueModifier = DetermineBakingTechniqueModifier();
            double calories = (DEFAULTCALORIESPERGRAM * this.Weight) * flourTypeModifier * bakingTechniqueModifier;
            return String.Format("{0:0.00}", calories);
        }
    }
}

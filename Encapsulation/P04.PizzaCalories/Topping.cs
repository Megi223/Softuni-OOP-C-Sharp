using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Topping
    {
        private const int BASE_CALORIES_PER_GRAM = 2;
        private const int MIN_WEIGHT = 0;
        private const int MAX_WEIGHT = 50;

        private string type;
        private int weight;

        public Topping(string type,int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type 
        {
            get
            {
                return this.type;
            }
            set
            {
                if(value.ToLower()!="meat" && value.ToLower()!="veggies" && value.ToLower()!="cheese" 
                    && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if(value<MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        private double DetermineModifier()
        {
            double modifier = 0;
            if (this.Type.ToLower() == "meat")
            {
                modifier = 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                modifier = 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                modifier = 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                modifier = 0.9;
            }
            return modifier;

        }

        public string CalculateToppingCalories()
        {
            double modifier = DetermineModifier();
            double calories = this.Weight * BASE_CALORIES_PER_GRAM * modifier;
            return String.Format("{0:0.00}", calories);

        }
    }
}

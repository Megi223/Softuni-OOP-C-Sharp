using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
    public class Owl : Bird
    {
        private const double INCREASE_IN_WEIGHT = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if (foodType == "Meat")
            {
                double weightIncrease = foodQuantity * INCREASE_IN_WEIGHT;
                this.Weight += weightIncrease;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}

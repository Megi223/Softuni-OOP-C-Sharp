using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
    public class Hen : Bird
    {
        private const double INCREASE_IN_WEIGHT = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            double weightIncrease = foodQuantity * INCREASE_IN_WEIGHT;
            this.Weight += weightIncrease;
            this.FoodEaten += foodQuantity;

        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double INCREASE_IN_WEIGHT = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}

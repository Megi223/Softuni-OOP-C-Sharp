using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double INCREASE_IN_WEIGHT = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if(foodType=="Fruit" || foodType == "Vegetable")
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
            return "Squeak";
        }
    }
}

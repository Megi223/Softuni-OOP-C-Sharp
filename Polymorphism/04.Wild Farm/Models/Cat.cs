using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
    public class Cat : Feline
    {
        private const double INCREASE_IN_WEIGHT = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if(foodType=="Vegetable" || foodType == "Meat")
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
            return "Meow";
        }
    }
}

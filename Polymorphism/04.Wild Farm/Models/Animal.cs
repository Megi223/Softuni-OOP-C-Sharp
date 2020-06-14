using System;
using System.Collections.Generic;
using System.Text;

namespace P04WildFarm.Models
{
   public abstract class Animal
    {
        public Animal(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string ProduceSound();
        public abstract void Eat(string foodType,int foodQuantity);
    }
}

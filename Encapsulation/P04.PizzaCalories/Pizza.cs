using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Pizza
    {
        private const int MIN_CHARACTERS = 1;
        private const int MAX_CHARACTERS = 15;

        private string name;
        private Dough dough;
        private List<Topping> listOfToppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.listOfToppings = new List<Topping>();
        }
        public string Name 
        {
            get { return this.name; }
            private set
            {
                
                if(value.Length<MIN_CHARACTERS || value.Length > MAX_CHARACTERS)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        //public IReadOnlyCollection<Topping> toppings => this.listOfToppings.AsReadOnly();

        public Dough Dough 
        {
            set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (this.listOfToppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.listOfToppings.Add(topping);
        }

        public double CalculateAllCalories()
        {
            double doughCal = double.Parse(this.dough.CalculateDoughCalories());
            double toppingCal = 0;
            foreach (var topping in listOfToppings)
            {
                toppingCal += double.Parse(topping.CalculateToppingCalories());
            }
            double allCal = doughCal + toppingCal;
            return allCal;

        }
        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateAllCalories():F2} Calories.";
        }
    }
}

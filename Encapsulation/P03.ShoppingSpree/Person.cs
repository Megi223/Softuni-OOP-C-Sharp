using System;
using System.Collections.Generic;
using System.Text;

namespace P03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name,decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();
        public void AddProductToBag(Product product)
        {
            this.bag.Add(product);
        }
        public void DecreaseMoney(decimal costOfDecreasing)
        {
            this.Money -= costOfDecreasing;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price,double mil) : base(name, price)
        {
            this.Milliliters = mil;
        }
        public double Milliliters { get; set; }

        
    }
}

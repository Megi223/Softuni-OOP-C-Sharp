using System;
using System.Collections.Generic;
using System.Text;

namespace P04P05P06BorderControl
{
    public class Rebel : IRebel,IBuyer
    {
        public Rebel(string name,int age,string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 5;
            return this.Food;
        }
    }
}

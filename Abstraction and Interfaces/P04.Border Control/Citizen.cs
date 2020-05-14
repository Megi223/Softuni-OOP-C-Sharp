using System;
using System.Collections.Generic;
using System.Text;
using P04P05P06BorderControl;

namespace P04BorderControl
{
    public class Citizen:IResident,IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 10;
            return this.Food;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P09ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name,string country,int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
        {
            return "{0}";
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs {0}";
        }
    }
}

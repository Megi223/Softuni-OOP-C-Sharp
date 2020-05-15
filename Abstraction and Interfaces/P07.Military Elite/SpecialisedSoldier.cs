using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public abstract class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            private set
            {
                if(value!="Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                this.corps = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class Engineer : SpecialisedSoldier,IEngineer
    {
        private List<Repair> listOfRepairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.listOfRepairs = new List<Repair>();
        }
        public List<Repair> ListOfRepairs => this.listOfRepairs;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine($"Repairs:");
            foreach (var item in this.ListOfRepairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

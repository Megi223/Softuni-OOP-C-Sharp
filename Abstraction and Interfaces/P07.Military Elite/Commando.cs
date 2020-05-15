using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> listOfMissions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.listOfMissions = new List<Mission>();
        }
        public List<Mission> ListOfMissions => this.listOfMissions;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine($"Missions:");
            foreach (var item in this.ListOfMissions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

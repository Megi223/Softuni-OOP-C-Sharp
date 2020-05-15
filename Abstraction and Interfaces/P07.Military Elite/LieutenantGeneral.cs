using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class LieutenantGeneral : Private,ILieutenantGeneral
    {
        private List<Private> listOfPrivates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.listOfPrivates = new List<Private>();

        }

        public List<Private> ListOfPrivates => listOfPrivates;


        // public IReadOnlyCollection<Private> ListOfPrivates => listOfPrivates.AsReadOnly();
        //public void Add(Private sth)
        // {
        //     this.listOfPrivates.Add(sth);
        // }



        //public List<Private> listOfPrivates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine("Privates:");
            foreach (var item in ListOfPrivates)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd() ;
        }


    }
}

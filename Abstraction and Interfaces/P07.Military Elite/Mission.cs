using System;
using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class Mission : IMission
    {
        private string state;
        public string CodeName { get; private set; }

        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if(value!="Finished" && value!= "inProgress")
                {
                    throw new ArgumentException();
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }


    }
}

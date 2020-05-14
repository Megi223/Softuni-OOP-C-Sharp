using System;
using System.Collections.Generic;
using System.Text;

namespace P04BorderControl
{
    public class Pet : IBirthable
    {
        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}

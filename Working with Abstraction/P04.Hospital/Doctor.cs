using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private List<Patient> patients;
        public Doctor(string firstName,string lastName)
        {
            this.patients = new List<Patient>();
            this.FistName = firstName;
            this.LastName = lastName;            
        }
        public IReadOnlyCollection<Patient> Patients => this.patients;
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string FullName => this.FistName + this.LastName;

        public void AddPatientToDoctor(Patient patient)
        {
            this.patients.Add(patient);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.patients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
           
        }
    }
}

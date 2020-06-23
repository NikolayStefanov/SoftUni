using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Patients = new List<Patient>();
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public List<Patient> Patients { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var patient in Patients.OrderBy(x=> x.Name))
            {
                sb.AppendLine(patient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}

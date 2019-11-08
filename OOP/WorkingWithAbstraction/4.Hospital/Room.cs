using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }
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

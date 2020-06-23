using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department 
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            for (int i = 1; i <= 20; i++)
            {
                var newestRoom = new Room();
                this.Rooms.Add(newestRoom);
            }
        }
        public List<Room> Rooms { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var room in Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
        public bool IsntFull()
        {
            foreach (var room in this.Rooms)
            {
                if (room.Patients.Count < 3)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddPatient(Patient patient)
        {
            foreach (var room in this.Rooms)
            {
                if (room.Patients.Count < 3)
                {
                    room.Patients.Add(patient);
                    break;
                }
            }
        }

    }
}

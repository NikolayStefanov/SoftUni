using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var departments = new List<Department>();    
            
            CreateDoctorsAndDepartments(doctors, departments);
            PrintOutput(doctors, departments);         
        }

        private static void CreateDoctorsAndDepartments(List<Doctor> doctors, List<Department> departments)
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] commandInList = command.Split();
                var departament = commandInList[0];
                var firstName = commandInList[1];
                var secondName = commandInList[2];
                var patient = commandInList[3];

                var currDoctor = new Doctor(firstName, secondName);

                if (!doctors.Any(x => x.FirstName == firstName && x.SecondName == secondName))
                {
                    doctors.Add(currDoctor);
                }
                else
                {
                    foreach (var doctor in doctors)
                    {
                        if (doctor.FirstName == currDoctor.FirstName && doctor.SecondName == currDoctor.SecondName)
                        {
                            currDoctor = doctor;
                            break;
                        }
                    }
                }

                var currDepartment = new Department(departament);

                if (departments.All(x => x.Name != departament))
                {
                    departments.Add(currDepartment);
                }

                else
                {
                    foreach (var dep in departments)
                    {
                        if (dep.Name == currDepartment.Name)
                        {
                            currDepartment = dep;
                            break;
                        }
                    }
                }
                if (currDepartment.IsntFull())
                {
                    var currPatient = new Patient(patient);
                    currDoctor.Patients.Add(currPatient);
                    currDepartment.AddPatient(currPatient);
                }
                command = Console.ReadLine();
            }
        }

        private static void PrintOutput(List<Doctor> doctors, List<Department> departments)
        {
            var newCommand = Console.ReadLine();

            while (newCommand != "End")
            {
                string[] args = newCommand.Split();

                if (args.Length == 1)
                {
                    foreach (var dep in departments)
                    {
                        if (dep.Name == args[0])
                        {
                            Console.WriteLine(dep);
                            break;
                        }
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    foreach (var dep in departments)
                    {
                        if (dep.Name == args[0])
                        {
                            var targetRoom = dep.Rooms[room - 1];
                            Console.WriteLine(targetRoom);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var doctor in doctors)
                    {
                        if (doctor.FirstName == args[0] && doctor.SecondName == args[1])
                        {
                            Console.WriteLine(doctor);
                            break;
                        }
                    }
                }
                newCommand = Console.ReadLine();
            }
        }
    }
}

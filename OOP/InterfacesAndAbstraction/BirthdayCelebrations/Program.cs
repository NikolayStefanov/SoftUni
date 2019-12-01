using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> aliveCreators = new List<IBirthable>();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arguments[0] == "Citizen")
                {
                    var name = arguments[1];
                    var age = int.Parse(arguments[2]);
                    var id = arguments[3];
                    var birthdate = arguments[4];
                    var currCitizen = new Citizen(name, age, id, birthdate);
                    aliveCreators.Add(currCitizen);
                }
                else if (arguments[0] == "Pet")
                {
                    var name = arguments[1];
                    var birthdate = arguments[2];
                    var currPet = new Pet(name, birthdate);
                    aliveCreators.Add(currPet);
                }
            }
            var targetYear = Console.ReadLine();
            var targetCreations = aliveCreators.Where(x => x.BirthDate.EndsWith(targetYear)).ToList();
            if (targetCreations.Count > 0)
            {
                foreach (var year in targetCreations)
                {
                    Console.WriteLine(year.BirthDate);
                }
            }
            
        }
    }
}

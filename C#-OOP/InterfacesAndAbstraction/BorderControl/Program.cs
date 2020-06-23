using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputInfo = string.Empty;
            List<IFakable> peopleAndRobots = new List<IFakable>();
            while ((inputInfo =Console.ReadLine().ToLower()) != "end")
            {
                var arguments = inputInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arguments.Length == 2)
                {
                    var robotName = arguments[0];
                    var robotId = arguments[1];
                    var currRobot = new Robot(robotName, robotId);
                    peopleAndRobots.Add(currRobot);
                }
                else if (arguments.Length == 3)
                {
                    var personName = arguments[0];
                    var personAge = int.Parse(arguments[1]);
                    var personId = arguments[2];
                    var currPerson = new Citizen(personName, personAge, personId);
                    peopleAndRobots.Add(currPerson);
                }
            }
            
            var fakeId = Console.ReadLine();
            var listOfFakes = peopleAndRobots.Where(c => c.ID.EndsWith(fakeId)).ToList();
            foreach (var creation in listOfFakes)
            {
                Console.WriteLine(creation.ID);
            }
        }
    }
}

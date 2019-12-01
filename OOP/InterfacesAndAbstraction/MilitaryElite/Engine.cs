using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using _8.MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.MilitaryElite
{
    public class Engine
    {
        public void Run()
        {
            var command = string.Empty;
            var soldiers = new List<Soldier>();
            while ((command = Console.ReadLine()) != "End")
            {
                var arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var soldierType = arguments[0];
                var id = int.Parse(arguments[1]);
                var firstName = arguments[2];
                var lastName = arguments[3];
                if (soldierType == "Private")
                {
                    var salary = decimal.Parse(arguments[4]);
                    var currPrivate = new Private(id, firstName,lastName,salary);
                    soldiers.Add(currPrivate);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(arguments[4]);
                    var privatesList = new List<IPrivate>();
                    for (int i = 5; i < arguments.Length; i++)
                    {
                        var currId = int.Parse(arguments[i]);
                        var targetPrivate = soldiers.FirstOrDefault(x => x.ID == currId);
                        privatesList.Add((Private)targetPrivate);
                    }
                    var currLieutenant = new LieutenantGeneral(id, firstName, lastName, salary, privatesList);
                    soldiers.Add(currLieutenant);
                }
                else if (soldierType == "Engineer")
                {
                    
                    var salary = decimal.Parse(arguments[4]);
                    var corps = arguments[5];
                    bool isValidCorps = Enum.TryParse(corps, out Corp result);
                    if (!isValidCorps)
                    {
                        continue;
                    }
                    var repairs = new List<IRepair>();
                    for (int i = 6; i < arguments.Length; i+=2)
                    {
                        var currPart = arguments[i];
                        var currHours = int.Parse(arguments[i + 1]);
                        var currRepair = new Repair(currPart, currHours);
                        repairs.Add(currRepair);
                    }
                    var currEngineer = new Engineer(id, firstName, lastName, salary, result, repairs);
                    soldiers.Add(currEngineer);
                }
                else if (soldierType == "Commando")
                {
                    var salary = decimal.Parse(arguments[4]);
                    var corps = arguments[5];
                    bool isValidCorps = Enum.TryParse(corps, out Corp result);
                    if (!isValidCorps)
                    {
                        continue;
                    }
                    var missions = new List<IMission>();
                    for (int i = 6; i < arguments.Length; i+=2)
                    {
                        var currCodeName = arguments[i];
                        var currState = arguments[i + 1];
                        var isValidMission = Enum.TryParse(currState, out State rightState);
                        if (!isValidMission)
                        {
                            continue;
                        }
                        var currMission = new Mission(currCodeName, rightState);
                        missions.Add(currMission);
                    }
                    var currCommando = new Commando(id, firstName, lastName, salary, result, missions);
                    soldiers.Add(currCommando);
                }
                else if (soldierType == "Spy")
                {
                    var currCodeNum = int.Parse(arguments[4]);
                    var currSpy = new Spy(id, firstName, lastName, currCodeNum);
                    soldiers.Add(currSpy);
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}

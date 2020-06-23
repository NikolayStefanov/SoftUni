using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            var input = string.Empty;
            try
            {
                var machineManager = new MachinesManager();
                while ((input = Console.ReadLine()) != "Quit")
                {
                    var arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (input.ToLower().StartsWith("hirepilot"))
                    {
                        var name = arguments[1];
                        Console.WriteLine(machineManager.HirePilot(name));
                    }
                    else if (input.ToLower().StartsWith("pilotreport"))
                    {
                        var name = arguments[1];
                        Console.WriteLine(machineManager.PilotReport(name));
                    }
                    else if (input.ToLower().StartsWith("manufacturetank"))
                    {
                        var name = arguments[1];
                        var attack = double.Parse(arguments[2]);
                        var defense = double.Parse(arguments[3]);
                        Console.WriteLine(machineManager.ManufactureTank(name, attack, defense));
                        
                    }
                    else if (input.ToLower().StartsWith("manufacturefighter"))
                    {
                        var name = arguments[1];
                        var attack = double.Parse(arguments[2]);
                        var defense = double.Parse(arguments[3]);
                        Console.WriteLine(machineManager.ManufactureFighter(name, attack, defense));                       
                    }
                    else if (input.ToLower().StartsWith("machinereport"))
                    {
                        var name = arguments[1];
                        Console.WriteLine(machineManager.MachineReport(name));
                        
                    }
                    else if (input.ToLower().StartsWith("aggressivemode"))
                    {
                        var name = arguments[1];
                        Console.WriteLine(machineManager.ToggleFighterAggressiveMode(name));
                        
                    }
                    else if (input.ToLower().StartsWith("defensemode"))
                    {
                        var name = arguments[1];
                        Console.WriteLine(machineManager.ToggleTankDefenseMode(name));
                    }
                    else if (input.ToLower().StartsWith("engage"))
                    {
                        var pilotName = arguments[1];
                        var machineName = arguments[2];
                        Console.WriteLine(machineManager.EngageMachine(pilotName, machineName));
                    }
                    else if (input.ToLower().StartsWith("attack"))
                    {
                        var attackMachineName = arguments[1];
                        var defenceMachineName = arguments[2];
                        Console.WriteLine(machineManager.AttackMachines(attackMachineName, defenceMachineName));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

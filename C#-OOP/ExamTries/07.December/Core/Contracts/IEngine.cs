using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core.Contracts
{
    public class IEngine
    {
        public void Run()
        {
            var input = string.Empty;
            var handler = new ChampionshipController();
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {

                    var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var command = args[0];
                    switch (command)
                    {
                        case "CreateRider":
                            var name = args[1];
                            Console.WriteLine(handler.CreateRider(name));

                            break;
                        case "CreateMotorcycle":
                            var type = args[1];
                            var model = args[2];
                            var power = int.Parse(args[3]);
                            Console.WriteLine(handler.CreateMotorcycle(type, model, power));

                            break;
                        case "AddMotorcycleToRider":
                            var ridarName = args[1];
                            var motorName = args[2];
                            Console.WriteLine(handler.AddMotorcycleToRider(ridarName, motorName));

                            break;
                        case "AddRiderToRace":
                            var raceName = args[1];
                            var ridaarName = args[2];
                            Console.WriteLine(handler.AddRiderToRace(raceName, ridaarName));

                            break;
                        case "CreateRace":
                            var nname = args[1];
                            var laps = int.Parse(args[2]);
                            Console.WriteLine(handler.CreateRace(nname, laps));
                            break;
                        case "StartRace":
                            var raaaceName = args[1];
                            Console.WriteLine(handler.StartRace(raaaceName));
                            break;
                    }
                }
                catch (InvalidOperationException target)
                {
                    Console.WriteLine(target.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }
    }
}

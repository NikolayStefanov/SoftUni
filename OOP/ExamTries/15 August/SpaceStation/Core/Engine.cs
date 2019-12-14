using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        writer.WriteLine(controller.AddAstronaut(input[1], input[2]));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var listOfParams = new List<string>();
                        for (int i = 2; i < input.Length; i++)
                        {
                            listOfParams.Add(input[i]);
                        }
                        writer.WriteLine(controller.AddPlanet(input[1], listOfParams.ToArray()));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        writer.WriteLine(controller.RetireAstronaut(input[1]));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        writer.WriteLine(controller.ExplorePlanet(input[1]));
                    }
                    else if(input[0] == "Report")
                    {
                        writer.WriteLine(controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}

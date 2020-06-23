using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    
    public class Controller : IController
    {
        private AstronautRepository astronautRepo;
        private PlanetRepository planetRepo;
        private Mission theMission;
        private PlanetRepository exploredPlanets;
        public Controller()
        {
            this.astronautRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.exploredPlanets = new PlanetRepository();
            theMission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut currAstronaut;
            if (type == "Biologist")
            {
                currAstronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                currAstronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                currAstronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronautRepo.Add(currAstronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var newPlanet = new Planet(planetName);
            foreach (var item in items)
            {
                newPlanet.Items.Add(item);
            }
            planetRepo.Add(newPlanet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var targetPlanet = planetRepo.FindByName(planetName);
            List<IAstronaut> suitableAstronauts = astronautRepo.Models.Where(x => x.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException($"You need at least one astronaut to explore the planet");
            }
            theMission.Explore(targetPlanet, suitableAstronauts);
            var deadAstronautsCount = suitableAstronauts.Where(x => !x.CanBreath).Count();
            this.exploredPlanets.Add(targetPlanet);
            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronautsCount} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanets.Models.Count} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in this.astronautRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();

        }

        public string RetireAstronaut(string astronautName)
        {
            var targetAstronaut = astronautRepo.FindByName(astronautName);
            if (!astronautRepo.Remove(targetAstronaut) || targetAstronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else 
            {
                astronautRepo.Remove(targetAstronaut);
                return $"Astronaut {astronautName} was retired!";
            }
        }
    }
}

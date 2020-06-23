using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private Repository<Rider> riderRepo = new RiderRepository();
        private Repository<Motorcycle> motorcycleRepo = new MotorcycleRepository();
        private Repository<Race> raceRepo = new RaceRepository();
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            Motorcycle targetMotor = motorcycleRepo.GetByName(motorcycleModel);
            Rider targetRider = riderRepo.GetByName(riderName);
            if (targetRider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (targetMotor == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            targetRider.AddMotorcycle(targetMotor);
            return $"Rider {targetRider.Name} received motorcycle {targetMotor.Model}.";

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var targetRace = raceRepo.GetByName(raceName);
            var targetRider = riderRepo.GetByName(riderName);
            if (targetRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (targetRider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            targetRace.AddRider(targetRider);
            return $"Rider {targetRider.Name} added in {targetRace.Name} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            Motorcycle motorcycle = null;
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            if (motorcycleRepo.GetAll().Any(x=> x.Model == model))
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            motorcycleRepo.Add(motorcycle);
            return $"{type}Motorcycle { model} is created.";
            
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepo.GetAll().Any(x=> x.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            var race = new Race(name, laps);
            raceRepo.Add(race);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            if (riderRepo.GetAll().Any(x=> x.Name == riderName))
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            var rider = new Rider(riderName);
            riderRepo.Add(rider);
            return $"Rider {rider.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepo.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var targetRace = raceRepo.GetByName(raceName);
            if (targetRace.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var bestThreeRiders = targetRace.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(targetRace.Laps)).Take(3);
            var sb = new StringBuilder();
            int counter = 0;
            raceRepo.Remove(targetRace);
            foreach (var rider in bestThreeRiders)
            {
                if ( counter == 0)
                {
                    sb.AppendLine($"Rider {rider.Name} wins {raceName} race.");
                    rider.WinRace();
                }
                else if (counter == 1)
                {
                    sb.AppendLine($"Rider {rider.Name} is second in {raceName} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {raceName} race.");
                }
                counter++;
            }
            return sb.ToString().TrimEnd();
        }
    }
}

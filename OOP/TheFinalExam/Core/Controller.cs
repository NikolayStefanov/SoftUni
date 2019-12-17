using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        
        private DecorationRepository decorRepo = new DecorationRepository();
        private List<IAquarium> aquariumRepo = new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            IAquarium currAquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                currAquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                currAquarium = new SaltwaterAquarium(aquariumName);
            }
            this.aquariumRepo.Add(currAquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, currAquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Plant" && decorationType != "Ornament")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            IDecoration currDecor;
            if (decorationType == "Plant")
            {
                currDecor = new Plant();
            }
            else
            {
                currDecor = new Ornament();
            }
            this.decorRepo.Add(currDecor);
            return $"Successfully added {currDecor.GetType().Name}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            var targetAquarium = this.aquariumRepo.Find(x => x.Name == aquariumName);
            Fish currFish;
            if (fishType == "FreshwaterFish")
            {
                currFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            if (targetAquarium.GetType().Name.StartsWith("Fresh") && currFish.GetType().Name.StartsWith("Salt"))
            {
                return $"Water not suitable.";
            }
            if (targetAquarium.GetType().Name.StartsWith("Salt") && currFish.GetType().Name.StartsWith("Fresh"))
            {
                return $"Water not suitable.";
            }
            targetAquarium.AddFish(currFish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal totalPrice = 0;
            var targetAquarium = this.aquariumRepo.Find(x => x.Name == aquariumName);
            foreach (var fish in targetAquarium.Fish)
            {
                totalPrice += fish.Price;
            }
            foreach (var decor in targetAquarium.Decorations)
            {
                totalPrice += decor.Price;
            }
            return $"The value of Aquarium {aquariumName} is {totalPrice:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var targetAquarium = this.aquariumRepo.Find(x => x.Name == aquariumName);
            targetAquarium.Feed();
            return $"Fish fed: {targetAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var targetDecor = this.decorRepo.FindByType(decorationType);
            if (targetDecor == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            var targetAquarium = this.aquariumRepo.Find(x => x.Name == aquariumName);
            targetAquarium.AddDecoration(targetDecor);
            this.decorRepo.Remove(targetDecor);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in this.aquariumRepo)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

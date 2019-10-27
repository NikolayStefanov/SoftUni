using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Trainer_EXE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var setOfTrainers = new List<Trainer>();
            var command = string.Empty;
            while ((command=Console.ReadLine())!= "Tournament")
            {
                var commandInList = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                var trainerName = commandInList[0];
                var pokemonName = commandInList[1];
                var pokemonElement = commandInList[2];
                var pokemonHealth = int.Parse(commandInList[3]);

                var currentPokemon = new Pokemon(pokemonName,pokemonElement,pokemonHealth);
                GenerateTrainer(trainerName, setOfTrainers, currentPokemon);
            }
            var tourCommand = string.Empty;
            while ((tourCommand = Console.ReadLine()) != "End")
            {
                bool minusBadge = true;
                var currentElement = tourCommand;

                ElementalMethods(setOfTrainers, minusBadge, tourCommand);
            }
            foreach (Trainer trainer in setOfTrainers.OrderByDescending(x=> x.NumberOfBadges).ThenBy(x => x.Appierence))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count}");
            }
        }

        private static void ElementalMethods(List<Trainer> setOfTrainers, bool minusBadge, string tourCommand)
        {
            foreach (Trainer trainer in setOfTrainers)
            {
                minusBadge = true;
                foreach (var element in trainer.CollectionOfPokemons)
                {
                    if (element.Element == tourCommand)
                    {
                        trainer.NumberOfBadges++;
                        minusBadge = false;
                        break;
                    }
                }
                if (minusBadge)
                {
                    foreach (var pokemon in trainer.CollectionOfPokemons)
                    {
                        pokemon.Health -= 10;
                    }
                    //trainer.RemovePokemons();
                    trainer.CollectionOfPokemons.RemoveAll(x => x.Health <= 0);
                }
            }
        }
        private static void GenerateTrainer(string trainerName, List<Trainer> setOfTrainers, Pokemon currentPokemon)
        {
            bool isntSame = true;
            foreach (Trainer trainer in setOfTrainers.Where(x=> x.Name == trainerName))
            {
                trainer.CollectionOfPokemons.Add(currentPokemon);
                isntSame = false;
                break;
            }
            if (isntSame)
            {
                var newTrainer = new Trainer(trainerName, currentPokemon);
                setOfTrainers.Add(newTrainer);
            }
        }
    }
}

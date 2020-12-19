using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string line = Console.ReadLine();

            while (line != "Tournament")
            {
                string[] info = line.Split().ToArray();

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                //Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = new Trainer(trainerName);

                trainer.AddPokemon(pokemonName, pokemonElement, pokemonHealth);

                line = Console.ReadLine();
            }

            int badges = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.pokemons.Any(p => p.Element == input))
                    {
                        trainer.numOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.pokemons.Count; i++)
                        {
                            var pokemonToCheck = trainer.pokemons[i];
                            if (pokemonToCheck.Health > 10)
                            {
                                pokemonToCheck.Health -= 10;
                            }
                            else
                            {
                                trainer.pokemons.Remove(pokemonToCheck);
                                i--;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }


            foreach (var trainer in trainers.OrderBy(x => x.numOfBadges))
            {
                Console.WriteLine(trainer.ToString());
            }

        }
    }
}
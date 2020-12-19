using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Trainer
    {
        public string name;
        public int numOfBadges;
        public List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.numOfBadges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Count
            => this.pokemons.Count;

        public void AddPokemon(string name, string element, int health)
        {
            Pokemon pokemon = new Pokemon(name, element, health);

            pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var trainer in pokemons)
            {
                sb.AppendLine($"{trainer.Name} {} {Count}");
            }

            return sb.ToString().Trim();
        }
    }
}

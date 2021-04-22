using System;
using System.Linq;
using System.Collections.Generic;

using _2._05.FootballTeamGenerator.Common;

namespace _2._05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }


        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXC_MSG);
                }

                this.name = value;
            }
        }

        public int Rating
        => this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.OveralSkill)) : 0;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players
                .FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.MISSING_PLAYER_EXC_MSG, playerName, this.Name));
            }

            this.players.Remove(playerToRemove);
        }


        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}

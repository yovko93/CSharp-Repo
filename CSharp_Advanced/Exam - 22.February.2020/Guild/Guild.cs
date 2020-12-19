using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
            => this.roster.Count;


        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);

            return roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            var player = roster.FirstOrDefault(p => p.Name == name).Rank = "Member";

            //if (player != null)
            //{
            //    player.Rank = "Member";
            //}

        }

        public void DemotePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name && x.Rank != "Trial");

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> players = roster.Where(x => x.Class == @class).ToList();
            Player[] kickedPlayers = new Player[players.Count];

            kickedPlayers = players.ToArray();
            roster.RemoveAll(x => x.Class == @class);
            return kickedPlayers;

            //List<Player> myListTemp = new List<Player>();
            //foreach (var player in this.roster)
            //{
            //    if (player.Class == @class)
            //    {
            //        myListTemp.Add(player);
            //    }
            //}
            //Player[] myArrayToReturn = myListTemp.ToArray();

            //this.roster = this.roster.Where(x => x.Class != @class).ToList();

            //return myArrayToReturn;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"{player.ToString()}");
            }
            return sb
                .ToString()
                .Trim();
        }
    }
}

using System;
using System.Linq;
using System.Text;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Repositories;
using CounterStrike.Models.Players;
using CounterStrike.Core.Contracts;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }


        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);
            var msg = String.Format(OutputMessages.SuccessfullyAddedGun, name);
            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);

            if (gun is null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }


            this.players.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var allPlayers = players.Models
                 .OrderBy(x => x.GetType().Name)
                 .ThenByDescending(x => x.Health)
                 .ThenBy(x => x.Username)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var player in allPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var allAlivePlayers = this.players.Models
                .Where(x => x.IsAlive)
                .ToList();

            string result = this.map.Start(allAlivePlayers);

            return result;
        }
    }
}

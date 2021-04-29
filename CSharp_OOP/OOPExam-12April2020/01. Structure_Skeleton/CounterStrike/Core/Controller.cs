﻿using System;
using System.Linq;

using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Repositories;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Players;
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
            IGun gun;

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

            string result = String.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);

            return result;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player;

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

            string result = String.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);

            return result;
        }

        public string Report()
        {
            var players = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var allAlivePlayers = this.players.Models
                .Where(x => x.IsAlive).ToList();

           string result = this.map.Start(allAlivePlayers);

            return result;
        }
    }
}

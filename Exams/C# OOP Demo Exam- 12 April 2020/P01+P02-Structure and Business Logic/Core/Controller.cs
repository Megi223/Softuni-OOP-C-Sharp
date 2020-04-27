using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            if(type!="Pistol" && type!= "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            IGun gun = null;
            if(type== "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if(type== "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            this.guns.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun,name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun wantedGun = this.guns.FindByName(gunName);
            if (wantedGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            if (type!= "Terrorist" && type!= "CounterTerrorist")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            IPlayer player = null;
            if(type== "Terrorist")
            {
                player = new Terrorist(username, health, armor, wantedGun);
            }
            else if(type== "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, wantedGun);
            }
            this.players.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            ICollection<IPlayer> orderedPlayers = this.players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToList();
            foreach (var currentPlayer in orderedPlayers)
            {
                sb.AppendLine($"{currentPlayer.GetType().Name}: {currentPlayer.Username}")
                    .AppendLine($"--Health: {currentPlayer.Health}")
                    .AppendLine($"--Armor: {currentPlayer.Armor}")
                    .AppendLine($"--Gun: {currentPlayer.Gun.Name}");

            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            ICollection<IPlayer> suitablePlayers = this.players.Models.Where(p => p.IsAlive).ToList();
            string result=this.map.Start(suitablePlayers);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> players;
        private Queue<IGun> guns;
        private INeighbourhood neighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.players.Add(new MainPlayer());
            this.guns = new Queue<IGun>();
            this.neighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if(type== "Pistol")
            {
                gun = new Pistol(name);
            }
            else if(type== "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Enqueue(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            if(name== "Vercetti")
            {
                IGun wantedGun = this.guns.Dequeue();
                IPlayer wantedPlayer = this.players.FirstOrDefault(p => p.Name == "Tommy Vercetti");
                wantedPlayer.GunRepository.Add(wantedGun);
                return $"Successfully added {wantedGun.Name} to the Main Player: Tommy Vercetti";
            }
            IPlayer currentPlayer = this.players.FirstOrDefault(p => p.Name == name);
            IGun currentGun = this.guns.Dequeue();

            if (currentPlayer == null)
            {
                return "Civil player with that name doesn't exists!";
            }
            currentPlayer.GunRepository.Add(currentGun);
            return $"Successfully added {currentGun.Name} to the Civil Player: {currentPlayer.Name}";


        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.players.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            IPlayer mainPlayer = this.players.FirstOrDefault(p => p.Name == "Tommy Vercetti");

            List<IPlayer> civilPlayers = this.players
                .Where(p => p.GetType().Name != nameof(MainPlayer))
                .ToList();

            neighbourhood.Action(mainPlayer, civilPlayers);
            StringBuilder sb = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive == true) &&
                mainPlayer.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");

                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");

                sb.AppendLine($"Tommy has killed: {civilPlayers.Where(p => p.IsAlive == false).Count()} players!");

                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(p => p.IsAlive == true).Count()}!");
                    
            }

            return sb.ToString().TrimEnd();
        }
    }
}

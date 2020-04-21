
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private int exploredPlanets;
        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if(type!= "Biologist" && type!= "Geodesist"&& type!= "Meteorologist")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            IAstronaut astronaut = null;
            if(type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type== "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            this.astronautRepository.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planetRepository.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet wantedPlanet = this.planetRepository.FindByName(planetName);
            ICollection<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            Mission mission = new Mission();
            mission.Explore(wantedPlanet, suitableAstronauts);
            exploredPlanets++;
            //int countDeadAstronauts = suitableAstronauts.Where(a => a == null).Count();
            var deadAstronauts = suitableAstronauts
                .Count(x => !x.CanBreath);
            return String.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!")
                .AppendLine("Astronauts info:");
            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}");
                string thirdLine = null;
                if (astronaut.Bag.Items.Count ==0)
                {
                    thirdLine = "none";
                }
                else
                {
                    thirdLine = String.Join(", ", astronaut.Bag.Items);
                }
                sb.AppendLine($"Bag items: {thirdLine}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut wantedAstronaut = this.astronautRepository.Models.FirstOrDefault(a => a.Name == astronautName);
            if (wantedAstronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            this.astronautRepository.Remove(wantedAstronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}

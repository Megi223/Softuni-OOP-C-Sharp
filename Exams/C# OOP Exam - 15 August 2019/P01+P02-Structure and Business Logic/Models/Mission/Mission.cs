using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission

{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet,ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                var astronaut = astronauts
                    .FirstOrDefault(x => x.CanBreath);

                if (astronaut == null)
                {
                    break;
                }

                var item = planet
                    .Items
                    .FirstOrDefault();

                if (item == null)
                {
                    break;
                }

                astronaut.Breath();

                astronaut
                    .Bag
                    .Items
                    .Add(item);

                planet
                    .Items
                    .Remove(item);
            }
        }
    }
}

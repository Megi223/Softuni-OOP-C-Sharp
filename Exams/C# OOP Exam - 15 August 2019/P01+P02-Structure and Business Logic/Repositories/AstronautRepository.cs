using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories

{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut wantedAstronaut = this.models.FirstOrDefault(a => a.Name == name);
            return wantedAstronaut;
        }

        public bool Remove(IAstronaut model)
        {
            IAstronaut wantedAstronaut = this.models.FirstOrDefault(a => a == model);
            if (wantedAstronaut == null)
            {
                return false;
            }
            this.models.Remove(wantedAstronaut);
            return true;

        }
    }
}

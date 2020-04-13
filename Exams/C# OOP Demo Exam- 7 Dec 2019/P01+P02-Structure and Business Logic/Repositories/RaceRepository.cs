using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.models;
        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll() => this.models;
        

        public IRace GetByName(string name)
        {
            IRace wantedRace = this.models.FirstOrDefault(r => r.Name == name);
            return wantedRace;
        }

        public bool Remove(IRace model)
        {
            IRace wantedRace = this.models.FirstOrDefault(m => m == model);
            if (wantedRace == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}

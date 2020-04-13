using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> models;
        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }
        public IReadOnlyCollection<IMotorcycle> Models => this.models;
        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.models;

        public IMotorcycle GetByName(string name)
        {
            IMotorcycle wantedMotorcycle = this.models.FirstOrDefault(m => m.Model == name);
            return wantedMotorcycle;

        }

        public bool Remove(IMotorcycle model)
        {
            IMotorcycle wantedMotorcycle = this.models.FirstOrDefault(m => m == model);
            if (wantedMotorcycle == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}

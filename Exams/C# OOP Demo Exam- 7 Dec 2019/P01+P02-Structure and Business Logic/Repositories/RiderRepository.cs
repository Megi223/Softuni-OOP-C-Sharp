using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    class RiderRepository : IRepository<IRider>
    {
        private List<IRider> models;
        public RiderRepository()
        {
            this.models = new List<IRider>();
        }
        public IReadOnlyCollection<IRider> Models => this.models;
        public void Add(IRider model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.models;
        }

        public IRider GetByName(string name)
        {
            IRider wantedRider = this.models.FirstOrDefault(r => r.Name == name);
            return wantedRider;
        }

        public bool Remove(IRider model)
        {
            IRider wantedRider = this.models.FirstOrDefault(m => m == model);
            if (wantedRider == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}

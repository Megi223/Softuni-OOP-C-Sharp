using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration wantedDecoration = this.models.FirstOrDefault(d => d.GetType().Name == type);
            return wantedDecoration;
        }

        public bool Remove(IDecoration model)
        {
            IDecoration wantedDecoration = this.models.FirstOrDefault(d => d == model);
            if (wantedDecoration == null)
            {
                return false;
            }
            this.models.Remove(wantedDecoration);
            return true;
        }
    }
}

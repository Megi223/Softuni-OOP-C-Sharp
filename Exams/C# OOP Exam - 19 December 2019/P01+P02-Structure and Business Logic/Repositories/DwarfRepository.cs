using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private List<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            IDwarf wantedDwarf = this.models.FirstOrDefault(d => d.Name == name);
            return wantedDwarf;
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}

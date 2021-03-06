﻿using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private List<IPresent> models;
        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => this.models.AsReadOnly();

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            IPresent wantedPresent = this.models.FirstOrDefault(p => p.Name == name);
            return wantedPresent;
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }
    }
}

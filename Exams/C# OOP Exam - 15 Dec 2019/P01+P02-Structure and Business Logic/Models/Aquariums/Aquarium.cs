using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value)||String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }


        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;


        public ICollection<IFish> Fish => this.fish;

        public abstract void AddDecoration(IDecoration decoration);


        public abstract void AddFish(IFish fish);
        

        public abstract void Feed();
        

        public abstract string GetInfo();
        

        public abstract bool RemoveFish(IFish fish);
        
    }
}

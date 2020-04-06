using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        public SaltwaterAquarium(string name) : base(name, 25)
        {
        }

        public override void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public override void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }

        public override void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public override string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} (SaltwaterAquarium):");
            string secondLine = "";
            if (this.Fish.Count == 0)
            {
                secondLine = "none";
            }
            else
            {
                secondLine = String.Join(", ", this.Fish.Select(f => f.Name));
            }
            sb.AppendLine($"Fish: {secondLine}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public override bool RemoveFish(IFish fish)
        {
            IFish wantedFish = this.Fish.FirstOrDefault(f => f == fish);
            if (wantedFish == null)
            {
                return false;
            }
            this.Fish.Remove(wantedFish);
            return true;
        }
    }
}

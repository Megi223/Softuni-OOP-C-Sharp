using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if(aquariumType!= "FreshwaterAquarium" && aquariumType!= "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium=null;
            if(aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if(decorationType!="Ornament"&& decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            IDecoration decoration = null; 
            if(decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if(fishType!= "FreshwaterFish" && fishType!= "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium wantedAquarium = aquariums.FirstOrDefault(a => a.Name==aquariumName);
            if(wantedAquarium.GetType().Name== "FreshwaterAquarium" && fishType== "FreshwaterFish")
            {
                wantedAquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if(wantedAquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                wantedAquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium wantedAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal sumOfAllDecorationPrices = wantedAquarium.Decorations.Sum(d => d.Price);
            decimal sumOfAllFishPrices = wantedAquarium.Fish.Sum(f => f.Price);
            decimal totalSum = sumOfAllDecorationPrices + sumOfAllFishPrices;
            return String.Format(OutputMessages.AquariumValue, aquariumName,  $"{totalSum:F2}");

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium wantedAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            wantedAquarium.Feed();
            return String.Format(OutputMessages.FishFed, wantedAquarium.Fish.Count);

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium wantedAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration wantedDecoration = decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);
            if (wantedDecoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            wantedAquarium.AddDecoration(wantedDecoration);
            decorations.Remove(wantedDecoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
            
        }
    }
}

using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motorcycleRepository;
        private RiderRepository riderRepository;
        private RaceRepository raceRepository;
        private List<IRider> riders;


        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
            this.riders = new List<IRider>();
        }
        public void Ordering(Func<IRider, double> src)
        {
            riders = riders.OrderByDescending(src).ToList();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.Models.FirstOrDefault(r => r.Name == riderName);
            IMotorcycle motorcycle = this.motorcycleRepository.Models.FirstOrDefault(m => m.Model == motorcycleModel);
            if (rider==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }
            rider.AddMotorcycle(motorcycle);
            return String.Format(OutputMessages.MotorcycleAdded,rider.Name,motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            
            if ((raceRepository.Models.FirstOrDefault(r => r.Name == raceName)) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (riderRepository.Models.FirstOrDefault(r=>r.Name==riderName)==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            IRider rider = riderRepository.Models.FirstOrDefault(r => r.Name == riderName);
            IRace race = raceRepository.Models.FirstOrDefault(r => r.Name == raceName);
            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, rider.Name, race.Name);


        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if ((this.motorcycleRepository.GetByName(model) != null))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }
            IMotorcycle motorcycle = null;
            if(type== "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if(type== "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            
            this.motorcycleRepository.Add(motorcycle);
            return String.Format(OutputMessages.MotorcycleCreated,motorcycle.GetType().Name,motorcycle.Model);
            
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.Models.FirstOrDefault(r=>r.Name==name &&  r.Laps==laps)!=null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);
            return String.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = this.riderRepository.Models.FirstOrDefault(r => r.Name == riderName);
            if (rider != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }
            IRider newRider = new Rider(riderName);
            this.riderRepository.Add(newRider);
            return String.Format(OutputMessages.RiderCreated, newRider.Name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.Models.FirstOrDefault(r => r.Name == raceName);
            if ( race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }


            
            riders = race.Riders.ToList();
            Ordering(r => r.Motorcycle.CalculateRacePoints(race.Laps));
            string first = riders.First().Name;
            string sec = riders.Skip(1).First().Name;
            string third = riders.Skip(2).First().Name;


            StringBuilder sb = new StringBuilder();
           

            sb.AppendLine(String.Format(OutputMessages.RiderFirstPosition, first, race.Name))
            .AppendLine(String.Format(OutputMessages.RiderSecondPosition, sec, race.Name))
            .AppendLine(String.Format(OutputMessages.RiderThirdPosition,third, race.Name));
            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();

        }
        

        
    }
}

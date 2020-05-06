using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private int craftedPresentsCount;
        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if(dwarfType!= "HappyDwarf" && dwarfType!= "SleepyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            IDwarf dwarf = null;
            if(dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if(dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            this.dwarfs.Add(dwarf);
            return String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf wantedDwarf = this.dwarfs.Models.FirstOrDefault(d => d.Name == dwarfName);
            if (wantedDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            IInstrument instrument = new Instrument(power);
            wantedDwarf.AddInstrument(instrument);
            return String.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);
            this.presents.Add(present);

            return String.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            
            IPresent present = this.presents.Models.FirstOrDefault(p => p.Name == presentName);
            ICollection<IDwarf> suitableDwarves = this.dwarfs.Models.Where(d => d.Energy >= 50).OrderByDescending(d=>d.Energy).ToList();
            if (suitableDwarves.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            Workshop workshop = new Workshop();
            while (suitableDwarves.Any())
            {
                IDwarf currentDwarf = suitableDwarves.First();
                workshop.Craft(present, currentDwarf);
                if (currentDwarf.Instruments.Count == 0)
                {
                    suitableDwarves.Remove(currentDwarf);
                }
                if (currentDwarf.Energy == 0)
                {
                    suitableDwarves.Remove(currentDwarf);
                    this.dwarfs.Remove(currentDwarf);
                }
                if (present.IsDone())
                {
                    break;
                }

            }
            if (present.IsDone())
            {
                craftedPresentsCount++;
                return String.Format(OutputMessages.PresentIsDone, presentName);
            }
            return String.Format(OutputMessages.PresentIsNotDone, presentName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{craftedPresentsCount} presents are done!")
                .AppendLine("Dwarfs info:");
            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}")
                    .AppendLine($"Energy: {dwarf.Energy}");
                int countNotBrokenInstr = dwarf.Instruments.Where(i => !i.IsBroken()).Count();
                sb.AppendLine($"Instruments: {countNotBrokenInstr} not broken left");

            }
            return sb.ToString().TrimEnd();
        }
    }
}

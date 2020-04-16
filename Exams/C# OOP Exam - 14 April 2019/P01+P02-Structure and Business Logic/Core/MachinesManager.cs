namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == name);
            if (pilot != null)
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            IPilot newPilot = new Pilot(name);
            this.pilots.Add(newPilot);
            return string.Format(OutputMessages.PilotHired, newPilot.Name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == name && m.GetType().Name=="Tank");
            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            IMachine newMachine = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(newMachine);
            return string.Format(OutputMessages.TankManufactured, name, newMachine.AttackPoints, newMachine.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == name && m.GetType().Name == "Fighter");
            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            Fighter newMachine = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(newMachine);
            //TODO: Check "ON"
            return string.Format(OutputMessages.FighterManufactured, name, newMachine.AttackPoints, newMachine.DefensePoints,"ON");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot wantedPilot = this.pilots.FirstOrDefault(m => m.Name == selectedPilotName);
            if (wantedPilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            IMachine wantedMachine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (wantedMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            if (wantedMachine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            wantedPilot.AddMachine(wantedMachine);
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            IMachine defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);
            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            //TODO: Check if it can be below zero- keep in mind that there is no checking in the property
            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }
            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }
            attackingMachine.Attack(defendingMachine);
            return string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter machine = (Fighter)this.machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == "Fighter");
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            machine.ToggleAggressiveMode();
            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank machine = (Tank)this.machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name=="Tank");
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            machine.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankName);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        private readonly Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tiresFromInput)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tiresFromInput;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public IReadOnlyCollection<Tire> Tires
        {
            get
            {
                return this.tires;
            }
        }
    }
}

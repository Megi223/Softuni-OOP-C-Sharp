using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle unitMotorcycle;
        private UnitRider unitRider;
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            unitMotorcycle = new UnitMotorcycle("Audi", 100, 60.5);
            unitRider = new UnitRider("Pesho", unitMotorcycle);
            raceEntry = new RaceEntry();

        }
        [Test]
        public void UnitMotorcycleInitializesCorrectly()
        {
            Assert.AreEqual("Audi", unitMotorcycle.Model);
            Assert.AreEqual(100, unitMotorcycle.HorsePower);
            Assert.AreEqual(60.5, unitMotorcycle.CubicCentimeters);
        }
        [Test]
        public void UnitRiderShouldInitializeCorrectly()
        {
            Assert.AreEqual("Pesho", unitRider.Name);
            Assert.AreEqual("Audi", unitRider.Motorcycle.Model);
            Assert.AreEqual(100, unitRider.Motorcycle.HorsePower);
            Assert.AreEqual(60.5, unitRider.Motorcycle.CubicCentimeters);
        }
        [Test]
        public void UnitRiderShouldThrowExceptionWhenNameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitRider rider = new UnitRider(null, unitMotorcycle);
            }, "Name cannot be null!");            
        }

        [Test]
        public void RaceEntryInitializesCorrectly()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }
        [Test]
        public void AddRiderShouldThrowExceptionWhenRiderNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(null);
            }, "Rider cannot be null.");
        }
        [Test]
        public void AddRiderShouldThrowExWhenRiderAlreadyPresent()
        {
            
            raceEntry.AddRider(unitRider);
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(unitRider);
            }, $"Rider Pesho is already added.");

        }
        [Test]
        public void AddRiderShouldWorkProperly()
        {
            
            
            string expectedResult = "Rider Pesho added in race.";
            string actualResult= raceEntry.AddRider(unitRider);
            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void CalculateAverageHorsePowerShouldThrowExWhenRaceInvalid()
        {
            raceEntry.AddRider(unitRider);
            Assert.Throws<InvalidOperationException>(() =>
            {
                double res=raceEntry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");

        }
        [Test]
        public void CalculateAverageHorsePowerShouldWorkProperly()
        {
            UnitMotorcycle secondMotorcycle = new UnitMotorcycle("BMW", 110, 70);
            UnitRider secondRider = new UnitRider("Ivan", secondMotorcycle);
            raceEntry.AddRider(unitRider);
            raceEntry.AddRider(secondRider);
            double expectedResult = 105.0;
            double actualResult = raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
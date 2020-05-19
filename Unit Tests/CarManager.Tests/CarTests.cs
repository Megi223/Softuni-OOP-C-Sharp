using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Audi", "A5", 2, 20);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        
        public void MakeShouldThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Audi", 15, 10);
            });
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelShouldThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", model, 15, 10);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumpShouldThrowException(double fuelCon)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A30", fuelCon, 10);
            });
        }
        [Test]
        [TestCase(-1)]
        
        public void FuelAmountShouldThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A30", 15, fuelAmount);
            });
        }
        [Test]
        [TestCase(10,15)]
        [TestCase(1.5,0.2)]
        public void CarShouldBeInstantiatedProperly(double fuelCon,double fuelCapacity)
        {
            Car car = new Car("Audi", "A5", fuelCon, fuelCapacity);
            string expectedMake = "Audi";
            string expectedModel = "A5";
            double expectedFuelCon = fuelCon;
            double expectedFuelCapacity = fuelCapacity;
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelCon, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        
        public void RefuelShouldThrowExceptionWhenAddingNegativeFuel(double fuelToBeAdded)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToBeAdded);
            });
        }

        [Test]
        [TestCase(10)]
        [TestCase(3.4)]
        public void RefuelWorksProperlyWhenAddingFuelThatIsBelowFuelAmount(double fuelToBeAdded)
        {
            car.Refuel(fuelToBeAdded);
            double expectedFuel = fuelToBeAdded;
            double actualFuel = car.FuelAmount;
            Assert.AreEqual(expectedFuel, actualFuel);
        }
        [Test]
        public void RefuelWorksProperlyWhenAddingFuelThatIsAboveFuelAmount()
        {
            car.Refuel(30);
            double expectedFuel = 20;
            double actualFuel = car.FuelAmount;
            Assert.AreEqual(expectedFuel, actualFuel);
        }
        [Test]
        public void DriveShouldThrowExceptionWhenNeededFuelGreaterThanPresent()
        {
            car.Refuel(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(600);
            });
        }
        [Test]
        public void DriveShouldWorkProperly()
        {
            car.Refuel(10);
            car.Drive(400);
            double expectedFuelAm = 2.0;
            double actualFuelAm = this.car.FuelAmount;
            Assert.AreEqual(expectedFuelAm, actualFuelAm);
        }


    }
}
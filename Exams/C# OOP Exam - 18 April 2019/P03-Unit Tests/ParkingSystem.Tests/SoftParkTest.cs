namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;
        [SetUp]
        public void Setup()
        {
            car = new Car("Audi", "1234");
            softPark = new SoftPark();
        }

        [Test]
        public void CarInitializesCorrectly()
        {
            Assert.AreEqual("Audi", this.car.Make);
            Assert.AreEqual("1234", this.car.RegistrationNumber);
        }
        [Test]
        public void ParkingInitializesCorrectly()
        {
            Assert.AreEqual(12, this.softPark.Parking.Count);
        }
        [Test]
        public void CarShouldBeParkedProperly()
        {
            string actualMessage=this.softPark.ParkCar("A1", this.car);
            string expectedMessage = "Car:1234 parked successfully!";
            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(this.softPark.Parking["A1"].Make, this.car.Make);
            Assert.AreEqual(this.softPark.Parking["A1"].RegistrationNumber, this.car.RegistrationNumber);

        }
        [Test]
        public void ParkShouldThrowExceptinWhenParSpotInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("Z1", this.car);
            });
        }
        [Test]
        public void ParkShouldThrowExceptinWhenParSpotIsTaken()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("A1", this.car);
            });
        }
        [Test]
        public void ParkShouldThrowExceptinWhenCarIsAlreadyParked()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("C1", this.car);
            });
        }
        [Test]
        public void RemoveShouldThrowExceptinWhenParSpotInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("Z1", this.car);
            });
        }
        [Test]
        public void RemoveShouldThrowExceptinWhenParkSpotAndCarDoNotMatch()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("C1", this.car);
            });
        }
        [Test]
        public void RemoveCarWorksProperly()
        {
            this.softPark.ParkCar("A1", this.car);
            string actualMessage= this.softPark.RemoveCar("A1", this.car);
            string expectedMessage = "Remove car:1234 successfully!";
            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(null, this.softPark.Parking["A1"]);
        }
    }
}
namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship spaceship;
        [SetUp]
        public void SetUp()
        {
            this.astronaut = new Astronaut("Pesho", 50);
            this.spaceship = new Spaceship("Space", 3);
        }
        [Test]
        public void AstronautInitializesCorrectly()
        {
            Assert.AreEqual("Pesho", this.astronaut.Name);
            Assert.AreEqual(50, this.astronaut.OxygenInPercentage);

        }
        [Test]
        public void SpaceshipInitializesCorrectly()
        {
            Assert.AreEqual("Space", this.spaceship.Name);
            Assert.AreEqual(3, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void SpaceshipShouldThrowExceptionWhenNameInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship someSpaceship = new Spaceship(name, 20);
            }, "Invalid spaceship name!");
        }

        [Test]
        [TestCase(-1)]
        
        public void SpaceshipShouldThrowExceptionWhenCapacityBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship someSpaceship = new Spaceship("Mis", capacity);
            }, "Invalid capacity!");
        }
        [Test]
        public void AddShouldThrowExceptonWhenShipFull()
        {
            this.spaceship.Add(this.astronaut);
            this.spaceship.Add(new Astronaut("Ivan",20));
            this.spaceship.Add(new Astronaut("Misho",80));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("Petar", 40));
            }, "Spaceship is full!");
        }
        [Test]
        public void AddShouldThrowExceptonWhenAstronautAlreadyExists()
        {
            this.spaceship.Add(this.astronaut);          
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(this.astronaut);
            }, "Astronaut Pesho is already in!");
        }
        [Test]
        public void AddShouldWorkProperly()
        {
            this.spaceship.Add(this.astronaut);
            Assert.AreEqual(1, this.spaceship.Count);
            
        }
        [Test]
        public void RemoveShouldReturnTrueWhenRemovedSuccessfully()
        {
            this.spaceship.Add(this.astronaut);
            bool expected = true;
            bool actual = this.spaceship.Remove("Pesho");
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveShouldReturnFalseWhenRemovedUnsuccessfully()
        {
            
            bool expected = false;
            bool actual = this.spaceship.Remove("Pesho");
            Assert.AreEqual(expected, actual);
        }
    }
}